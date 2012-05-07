﻿using System;
using System.Linq;
using System.Collections.Generic;

//using BusinessObjects;
//using DataObjects.EntityFramework.ModelMapper;
//using System.Linq.Dynamic;
using Epi.Web.Interfaces.DataInterfaces;
using Epi.Web.Common.BusinessObject;

namespace Epi.Web.EF
{
    /// <summary>
    /// Entity Framework implementation of the ISurveyInfoDao interface.
    /// </summary>
    public class EntitySurveyInfoDao : ISurveyInfoDao
    {
        /// <summary>
        /// Gets SurveyInfo based on a list of ids
        /// </summary>
        /// <param name="SurveyInfoId">Unique SurveyInfo identifier.</param>
        /// <returns>SurveyInfo.</returns>
        public List<SurveyInfoBO> GetSurveyInfo(List<string> SurveyInfoIdList, int PageNumber = -1, int PageSize = -1)
        {
            List<SurveyInfoBO> result = new List<SurveyInfoBO>();
            if (SurveyInfoIdList.Count > 0)
            {
                foreach (string surveyInfoId in SurveyInfoIdList.Distinct())
                {
                    Guid Id = new Guid(surveyInfoId);

                    using (var Context = DataObjectFactory.CreateContext())
                    {
                        result.Add(Mapper.Map(Context.SurveyMetaDatas.FirstOrDefault(x => x.SurveyId == Id)));
                    }
                }
            }
            else
            {
                using (var Context = DataObjectFactory.CreateContext())
                {
                    result = Mapper.Map(Context.SurveyMetaDatas.ToList());
                }
            }


            

            // remove the items to skip
            // remove the items after the page size
            if (PageNumber > 0 && PageSize > 0)
            {
                result.Sort(CompareByDateCreated);
                // remove the items to skip
                if (PageNumber * PageSize - PageSize > 0)
                {
                    result.RemoveRange(0, PageSize);
                }

                if (PageNumber * PageSize < result.Count)
                {
                    result.RemoveRange(PageNumber * PageSize, result.Count - PageNumber * PageSize);
                }
            }

            return result;
        }


        /// <summary>
        /// Gets SurveyInfo based on criteria
        /// </summary>
        /// <param name="SurveyInfoId">Unique SurveyInfo identifier.</param>
        /// <returns>SurveyInfo.</returns>
        public List<SurveyInfoBO> GetSurveyInfo(List<string> SurveyInfoIdList, DateTime pClosingDate,string Okey ,int pSurveyType = -1, int PageNumber = -1, int PageSize = -1)
        {
            List<SurveyInfoBO> result = new List<SurveyInfoBO>();

            List<SurveyMetaData> responseList = new List<SurveyMetaData>();

            int  OrganizationId =0;

            using (var Context = DataObjectFactory.CreateContext())
            {
               
                OrganizationId =  Context.Organizations.FirstOrDefault(x => x.OrganizationKey == Okey).OrganizationId;
            }


            if (SurveyInfoIdList.Count > 0)
            {
                foreach (string surveyInfoId in SurveyInfoIdList.Distinct())
                {
                    Guid Id = new Guid(surveyInfoId);

                    using (var Context = DataObjectFactory.CreateContext())
                    {
                        responseList.Add(Context.SurveyMetaDatas.FirstOrDefault(x => x.SurveyId == Id && x.OrganizationId == OrganizationId));
                    }
                }
            }
            else
            {
                using (var Context = DataObjectFactory.CreateContext())
                {
                    responseList = Context.SurveyMetaDatas.ToList();
                  
                }
            }

            if (pSurveyType > -1)
            {
                List<SurveyMetaData> statusList = new List<SurveyMetaData>();
                statusList.AddRange(responseList.Where(x => x.SurveyTypeId == pSurveyType));
                responseList = statusList;
            }


            if (OrganizationId >0){
                List<SurveyMetaData> OIdList = new List<SurveyMetaData>();
                OIdList.AddRange(responseList.Where(x => x.OrganizationId == OrganizationId));
                responseList = OIdList;
            
            }

            if (pClosingDate > DateTime.MinValue)
            {
                List<SurveyMetaData> dateList = new List<SurveyMetaData>();

                dateList.AddRange(responseList.Where(x => x.ClosingDate.Month >= pClosingDate.Month && x.ClosingDate.Year >= pClosingDate.Year && x.ClosingDate.Day >= pClosingDate.Day));
                responseList = dateList;
            }

            result = Mapper.Map(responseList);
            

            // remove the items to skip
            // remove the items after the page size
            if (PageNumber > 0 && PageSize > 0)
            {
                result.Sort(CompareByDateCreated);
                // remove the items to skip

                //List<SurveyInfoBO> temp = new List<SurveyInfoBO>();

                //foreach (var item in result.Skip((PageNumber * PageSize) - PageSize).Take(PageSize))
                //{

                //    temp.Add(item);

                //}
                //result = temp.ToList();

                if (PageNumber * PageSize - PageSize > 0)
                {
                    result.RemoveRange(0, PageSize);
                }

                if (PageNumber * PageSize < result.Count)
                {
                    result.RemoveRange(PageNumber * PageSize, result.Count - PageNumber * PageSize);
                }
            }
            
            return result;
        }

        /// <summary>
        /// Inserts a new SurveyInfo. 
        /// </summary>
        /// <remarks>
        /// Following insert, SurveyInfo object will contain the new identifier.
        /// </remarks>  
        /// <param name="SurveyInfo">SurveyInfo.</param>
        public  void InsertSurveyInfo(SurveyInfoBO SurveyInfo)
        {
           int OrganizationId = 0;
            using (var Context = DataObjectFactory.CreateContext() ) 
            {

                //retrieve OrganizationId based on OrganizationKey
                using (var ContextOrg = DataObjectFactory.CreateContext())
                {
                    string OrgKey = Epi.Web.Common.Security.Cryptography.Encrypt(SurveyInfo.OrganizationKey.ToString());
                    OrganizationId = ContextOrg.Organizations.FirstOrDefault(x => x.OrganizationKey == OrgKey).OrganizationId;
                }


                
                SurveyInfo.TemplateXMLSize = RemoveWhitespace(SurveyInfo.XML).Length;
                SurveyInfo.DateCreated = DateTime.Now;
                
                var SurveyMetaDataEntity = Mapper.Map(SurveyInfo);
                SurveyMetaDataEntity.OrganizationId = OrganizationId;
                Context.AddToSurveyMetaDatas(SurveyMetaDataEntity);
               
                Context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates a SurveyInfo.
        /// </summary>
        /// <param name="SurveyInfo">SurveyInfo.</param>
        public void UpdateSurveyInfo(SurveyInfoBO SurveyInfo)
        { 
            Guid Id = new Guid(SurveyInfo.SurveyId);

            //Update Survey
            using (var Context = DataObjectFactory.CreateContext())
            {
                var Query = from response in Context.SurveyMetaDatas
                            where response.SurveyId == Id
                            select response;

                var DataRow = Query.Single();
                DataRow.SurveyName = SurveyInfo.SurveyName;
                DataRow.SurveyNumber = SurveyInfo.SurveyNumber;
                DataRow.TemplateXML = SurveyInfo.XML;
                DataRow.IntroductionText = SurveyInfo.IntroductionText;
                DataRow.ExitText = SurveyInfo.ExitText;
                DataRow.OrganizationName = SurveyInfo.OrganizationName;
                DataRow.DepartmentName = SurveyInfo.DepartmentName;
                DataRow.ClosingDate = SurveyInfo.ClosingDate;
                DataRow.SurveyTypeId = SurveyInfo.SurveyType;
                DataRow.UserPublishKey = SurveyInfo.UserPublishKey;
                DataRow.TemplateXMLSize = RemoveWhitespace(SurveyInfo.XML).Length;

                Context.SaveChanges();
            }

        
        }

        /// <summary>
        /// Deletes a SurveyInfo
        /// </summary>
        /// <param name="SurveyInfo">SurveyInfo.</param>
        public void DeleteSurveyInfo(SurveyInfoBO SurveyInfo)
        {

           //Delete Survey
       
       }


                /// <summary>
        /// Gets SurveyInfo Size Data on a list of ids
        /// </summary>
        /// <param name="SurveyInfoId">Unique SurveyInfo identifier.</param>
        /// <returns>PageInfoBO.</returns>
        public PageInfoBO GetSurveySizeInfo(List<string> SurveyInfoIdList, int PageNumber = -1, int PageSize = -1, int ResponseMaxSize = -1)
        {
            PageInfoBO result = new PageInfoBO();

            List<SurveyInfoBO> resultRows = GetSurveyInfo(SurveyInfoIdList, PageNumber, PageSize);

            int NumberOfRows = 0;
            int ResponsesTotalsize = 0;
            decimal AvgResponseSize = 0;
            decimal NumberOfResponsPerPage = 0;


            NumberOfRows = resultRows.Count;
            ResponsesTotalsize = (int)resultRows.Select(x => x.TemplateXMLSize).Sum();

            AvgResponseSize = (int)resultRows.Select(x => x.TemplateXMLSize).Average();
          

            NumberOfResponsPerPage = (int)Math.Ceiling((ResponseMaxSize/2) / AvgResponseSize);


            result.PageSize = (int)Math.Ceiling(NumberOfResponsPerPage);
            result.NumberOfPages = (int)Math.Ceiling(NumberOfRows / NumberOfResponsPerPage);

            return result;

        }


        /// <summary>
        /// Gets SurveyInfo Size Data based on criteria
        /// </summary>
        /// <param name="SurveyInfoId">Unique SurveyInfo identifier.</param>
        /// <returns>PageInfoBO.</returns>
        public PageInfoBO GetSurveySizeInfo(List<string> SurveyInfoIdList, DateTime pClosingDate,string Okey, int pSurveyType = -1, int PageNumber = -1, int PageSize = -1, int ResponseMaxSize = -1)
        {

            PageInfoBO result = new PageInfoBO();

            List<SurveyInfoBO> resultRows =  GetSurveyInfo(SurveyInfoIdList, pClosingDate,Okey, pSurveyType, PageNumber, PageSize);

            int NumberOfRows = 0;
            int ResponsesTotalsize = 0;
            decimal AvgResponseSize = 0;
            decimal NumberOfResponsPerPage = 0;
             

            NumberOfRows = resultRows.Count;
            ResponsesTotalsize = (int)resultRows.Select(x => x.TemplateXMLSize ).Sum();

            AvgResponseSize  = (int)resultRows.Select(x => x.TemplateXMLSize).Average();
            NumberOfResponsPerPage = (int)Math.Ceiling((ResponseMaxSize/2) / AvgResponseSize);


            result.PageSize = (int)Math.Ceiling(NumberOfResponsPerPage);
            result.NumberOfPages = (int)Math.Ceiling(NumberOfRows / NumberOfResponsPerPage);
            
            


            return result;
        }

        private static int CompareByDateCreated(SurveyInfoBO x, SurveyInfoBO y)
        {
            return x.DateCreated.CompareTo(y.DateCreated);
        }

        public static string RemoveWhitespace(string xml)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@">\s*<");
            xml = regex.Replace(xml, "><");

            return xml.Trim();
        }
    }
}
