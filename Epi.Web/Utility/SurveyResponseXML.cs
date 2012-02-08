﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Epi.Web.Common.Message;

namespace Epi.Web.MVC.Utility
{
    public class SurveyResponseXML
    {

        Dictionary<string, string> ResponseDetailList = new Dictionary<string, string>();
        

        public void Add(MvcDynamicForms.Form pForm)
        {

            foreach (var field in pForm.InputFields)
            {

                if (this.ResponseDetailList.ContainsKey(field.Title))
                {
                    this.ResponseDetailList[field.Title] = field.Response;
                }
                else
                {
                    this.ResponseDetailList.Add(field.Title, field.Response);
                }
            }
        }

        public void Add(MvcDynamicForms.Fields.InputField pField)
        {
            if (this.ResponseDetailList.ContainsKey(pField.Title))
            {
                this.ResponseDetailList[pField.Title] = pField.GetXML();
            }
            else
            {
                this.ResponseDetailList.Add(pField.Title, pField.GetXML());
            }
        }

         public void SetValue(string pKey, string pXMLValue)
         {
            if(this.ResponseDetailList.ContainsKey(pKey))
            {
                this.ResponseDetailList[pKey] = pXMLValue;
            }
            else
            {
                this.ResponseDetailList.Add(pKey, pXMLValue);
            }
         }


          public string GetValue(string pKey)
         {
             string result = null;

            if(this.ResponseDetailList.ContainsKey(pKey))
            {
               result = this.ResponseDetailList[pKey];
            }

            return result;
         }

          public XmlDocument CreateResponseXml(string SurveyId, bool AddRoot, int CurrentPage)
          {

               

              
              XmlDocument xml = new XmlDocument();
              XmlElement root = xml.CreateElement("SurveyResponse");
            
              if (AddRoot == true)
              {

              root.SetAttribute("SurveyId", SurveyId);
              root.SetAttribute("LastPageVisited", "1");
              xml.AppendChild(root);
              }

              XmlElement PageRoot = xml.CreateElement("Page");
              PageRoot.SetAttribute("PageNumber", CurrentPage.ToString());
              if (AddRoot == true)
              {
                  root.AppendChild(PageRoot);
              }
              else {
                  xml.AppendChild(PageRoot);
              }

              foreach ( KeyValuePair<string, string> pair  in this.ResponseDetailList)
              {
                  XmlElement child = xml.CreateElement(Epi.Web.MVC.Constants.Constant.RESPONSE_DETAILS);
                  child.SetAttribute("QuestionName", pair.Key);
                  child.InnerText = pair.Value;
                  PageRoot.AppendChild(child);
              }


              return xml;
          }


          

    }
}
