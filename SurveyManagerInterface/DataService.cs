﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Epi.Web.Common.DTO;
using Epi.Web.Common.Message;
using Epi.Web.Common.MessageBase;
using Epi.Web.Common.Criteria;
using Epi.Web.Common.ObjectMapping;
using Epi.Web.Common.BusinessObject;

namespace Epi.Web.WCF.SurveyService
{
    public class DataService : IDataService
    {

        // Session state variables
        private string _accessToken;
        //private ShoppingCart _shoppingCart;
        private string _userName;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRequest"></param>
        /// <returns></returns>
        public SurveyInfoResponse GetSurveyInfo(SurveyInfoRequest pRequest)
        {
            SurveyInfoResponse result = new SurveyInfoResponse(pRequest.RequestId);
            Epi.Web.Interfaces.DataInterfaces.ISurveyInfoDao surveyInfoDao = new EF.EntitySurveyInfoDao();
            Epi.Web.BLL.SurveyInfo Implementation = new Epi.Web.BLL.SurveyInfo(surveyInfoDao);

            // Validate client tag, access token, and user credentials
            if (!ValidRequest(pRequest, result, Validate.All))
            {
                return result;
            }

            var criteria = pRequest.Criteria as SurveyInfoCriteria;
            string sort = criteria.SortExpression;

            //if (request.LoadOptions.Contains("SurveyInfos"))
            //{
            //    IEnumerable<SurveyInfoDTO> SurveyInfos;
            //    if (!criteria.IncludeOrderStatistics)
            //    {
            //        SurveyInfos = Implementation.GetSurveyInfos(sort);
            //    }
            //    else
            //    {
            //        SurveyInfos = Implementation.GetSurveyInfosWithOrderStatistics(sort);
            //    }

            //    response.SurveyInfos = SurveyInfos.Select(c => Mapper.ToDataTransferObject(c)).ToList();
            //}

            //if (pRequest.LoadOptions.Contains("SurveyInfo"))
            //{
                result.SurveyInfo = Mapper.ToDataTransferObject(Implementation.GetSurveyInfoById(pRequest.Criteria.SurveyId));
            //}

            return result;
        }


        /// <summary>
        /// Set (add, update, delete) SurveyInfo value.
        /// </summary>
        /// <param name="request">SurveyInfoRequest request message.</param>
        /// <returns>SurveyInfoRequest response message.</returns>
        public SurveyInfoResponse SetSurveyInfo(SurveyInfoRequest request)
        {
            Epi.Web.Interfaces.DataInterfaces.ISurveyInfoDao surveyInfoDao = new EF.EntitySurveyInfoDao();
            Epi.Web.BLL.SurveyInfo Implementation = new Epi.Web.BLL.SurveyInfo(surveyInfoDao);


            var response = new SurveyInfoResponse(request.RequestId);

            // Validate client tag, access token, and user credentials
            if (!ValidRequest(request, response, Validate.All))
                return response;

            // Transform SurveyInfo data transfer object to SurveyInfo business object
            var SurveyInfo = Mapper.ToBusinessObject(request.SurveyInfo);

            // Validate SurveyInfo business rules

            if (request.Action != "Delete")
            {
                //if (!SurveyInfo.Validate())
                //{
                //    response.Acknowledge = AcknowledgeType.Failure;

                //    foreach (string error in SurveyInfo.ValidationErrors)
                //        response.Message += error + Environment.NewLine;

                //    return response;
                //}
            }

            // Run within the context of a database transaction. Currently commented out.
            // The Decorator Design Pattern. 
            //using (TransactionDecorator transaction = new TransactionDecorator())
            {
                if (request.Action == "Create")
                {
                    Implementation.InsertSurveyInfo(SurveyInfo);
                    response.SurveyInfo = Mapper.ToDataTransferObject(SurveyInfo);
                }
                else if (request.Action == "Update")
                {
                    Implementation.UpdateSurveyInfo(SurveyInfo);
                    response.SurveyInfo = Mapper.ToDataTransferObject(SurveyInfo);
                }
                else if (request.Action == "Delete")
                {
                    var criteria = request.Criteria as SurveyInfoCriteria;
                    var survey = Implementation.GetSurveyInfoById(SurveyInfo.SurveyId);

                    try
                    {
                        if (Implementation.DeleteSurveyInfo(survey))
                        {
                            response.RowsAffected = 1;
                        }
                        else
                        {
                            response.RowsAffected = 0;
                        }
                    }
                    catch
                    {
                        response.RowsAffected = 0;
                    }
                }
            }

            return response;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRequest"></param>
        /// <returns></returns>
        public SurveyResponseResponse GetSurveyResponse(SurveyResponseRequest pRequest)
        {
            SurveyResponseResponse result = new SurveyResponseResponse(pRequest.RequestId);
            Epi.Web.Interfaces.DataInterfaces.ISurveyResponseDao surveyInfoDao = new EF.EntitySurveyResponseDao();
            Epi.Web.BLL.SurveyResponse Implementation = new Epi.Web.BLL.SurveyResponse(surveyInfoDao);

            // Validate client tag, access token, and user credentials
            if (!ValidRequest(pRequest, result, Validate.All))
            {
                return result;
            }

            var criteria = pRequest.Criteria as SurveyResponseCriteria;
            string sort = criteria.SortExpression;

            //if (request.LoadOptions.Contains("SurveyInfos"))
            //{
            //    IEnumerable<SurveyInfoDTO> SurveyInfos;
            //    if (!criteria.IncludeOrderStatistics)
            //    {
            //        SurveyInfos = Implementation.GetSurveyInfos(sort);
            //    }
            //    else
            //    {
            //        SurveyInfos = Implementation.GetSurveyInfosWithOrderStatistics(sort);
            //    }

            //    response.SurveyInfos = SurveyInfos.Select(c => Mapper.ToDataTransferObject(c)).ToList();
            //}

            //if (pRequest.LoadOptions.Contains("SurveyInfo"))
            //{
            result.SurveyResponseDTO = Mapper.ToDataTransferObject(Implementation.GetSurveyResponseById(pRequest.Criteria.ResposneId));
            //}

            return result;
        }



        /// <summary>
        /// Set (add, update, delete) SurveyInfo value.
        /// </summary>
        /// <param name="request">SurveyResponse request message.</param>
        /// <returns>SurveyResponse response message.</returns>
        public SurveyResponseResponse SetSurveyResponse(SurveyResponseRequest request)
        {
            Epi.Web.Interfaces.DataInterfaces.ISurveyResponseDao SurveyResponseDao = new EF.EntitySurveyResponseDao();
            Epi.Web.BLL.SurveyResponse Implementation = new Epi.Web.BLL.SurveyResponse(SurveyResponseDao);


            SurveyResponseResponse response = new SurveyResponseResponse(request.RequestId);

            // Validate client tag, access token, and user credentials
            if (!ValidRequest(request, response, Validate.All))
            {
                return response;
            }
            
            // Transform SurveyResponse data transfer object to SurveyResponse business object
            SurveyResponseBO SurveyResponse = Mapper.ToBusinessObject(request.SurveyResponseDTO);

            // Validate SurveyResponse business rules

            if (request.Action != "Delete")
            {
                //if (!SurveyResponse.Validate())
                //{
                //    response.Acknowledge = AcknowledgeType.Failure;

                //    foreach (string error in SurveyResponse.ValidationErrors)
                //        response.Message += error + Environment.NewLine;

                //    return response;
                //}
            }

            // Run within the context of a database transaction. Currently commented out.
            // The Decorator Design Pattern. 
            //using (TransactionDecorator transaction = new TransactionDecorator())
            {
                if (request.Action.Equals("Create", StringComparison.OrdinalIgnoreCase))
                {
                    Implementation.InsertSurveyResponse(SurveyResponse);
                    response.SurveyResponseDTO = Mapper.ToDataTransferObject(SurveyResponse);
                }
                else if (request.Action.Equals("Update", StringComparison.OrdinalIgnoreCase))
                {
                    Implementation.UpdateSurveyResponse(SurveyResponse);
                    response.SurveyResponseDTO = Mapper.ToDataTransferObject(SurveyResponse);
                }
                else if (request.Action.Equals("Delete", StringComparison.OrdinalIgnoreCase))
                {
                    var criteria = request.Criteria as SurveyResponseCriteria;
                    var survey = Implementation.GetSurveyResponseById(SurveyResponse.SurveyId);

                    try
                    {
                        if (Implementation.DeleteSurveyResponse(survey))
                        {
                            response.RowsAffected = 1;
                        }
                        else
                        {
                            response.RowsAffected = 0;
                        }
                    }
                    catch
                    {
                        response.RowsAffected = 0;
                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Gets unique session based token that is valid for the duration of the session.
        /// </summary>
        /// <param name="request">Token request message.</param>
        /// <returns>Token response message.</returns>
        public TokenResponse GetToken(TokenRequest request)
        {
            var response = new TokenResponse(request.RequestId);

            // Validate client tag only
            if (!ValidRequest(request, response, Validate.ClientTag))
                return response;

            // Note: these are session based and expire when session expires.
            _accessToken = Guid.NewGuid().ToString();
            //_shoppingCart = new ShoppingCart(_defaultShippingMethod);

            response.AccessToken = _accessToken;
            return response;
        }

        /// <summary>
        /// Login to application service.
        /// </summary>
        /// <param name="request">Login request message.</param>
        /// <returns>Login response message.</returns>
        public LoginResponse Login(LoginRequest request)
        {
            var response = new LoginResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            if (! ValidateUser(request.UserName, request.Password))
            {
                response.Acknowledge = AcknowledgeType.Failure;
                response.Message = "Invalid username and/or password.";
                return response;
            }

            _userName = request.UserName;

            return response;
        }

        /// <summary>
        /// Logout from application service.
        /// </summary>
        /// <param name="request">Logout request message.</param>
        /// <returns>Login request message.</returns>
        public LogoutResponse Logout(LogoutRequest request)
        {
            var response = new LogoutResponse(request.RequestId);

            // Validate client tag and access token
            if (!ValidRequest(request, response, Validate.ClientTag | Validate.AccessToken))
                return response;

            _userName = null;

            return response;
        }

        /// <summary>
        /// Validate 3 security levels for a request: ClientTag, AccessToken, and User Credentials
        /// </summary>
        /// <param name="request">The request message.</param>
        /// <param name="response">The response message.</param>
        /// <param name="validate">The validation that needs to take place.</param>
        /// <returns></returns>
        private bool ValidRequest(RequestBase request, ResponseBase response, Validate validate)
        {
            bool result = true;

            // Validate Client Tag. 
            // Hardcoded here. In production this should query a 'client' table in a database.
            if ((Validate.ClientTag & validate) == Validate.ClientTag)
            {
                if (request.ClientTag != "ABC123")
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Unknown Client Tag";
                    //return false;
                }
            }


            // Validate access token
            if ((Validate.AccessToken & validate) == Validate.AccessToken)
            {
                if (request.AccessToken != _accessToken)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Invalid or expired AccessToken. Call GetToken()";
                    //return false;
                }
            }

            // Validate user credentials
            if ((Validate.UserCredentials & validate) == Validate.UserCredentials)
            {
                if (_userName == null)
                {
                    response.Acknowledge = AcknowledgeType.Failure;
                    response.Message = "Please login and provide user credentials before accessing these methods.";
                    //return false;
                }
            }


            return result;
        }

        /// <summary>
        /// Validation options enum. Used in validation of messages.
        /// </summary>
        [Flags]
        private enum Validate
        {
            ClientTag = 0x0001,
            AccessToken = 0x0002,
            UserCredentials = 0x0004,
            All = ClientTag | AccessToken | UserCredentials
        }


        private bool ValidateUser(string pUserName, string pPassword)
        {
            bool result = true;

            return result;
        }

    }
}