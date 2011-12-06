using System.Runtime.Serialization;
using Epi.Web.WCF.SurveyService.MessageBase;

namespace Epi.Web.WCF.SurveyService.Messages
{
    /// <summary>
    /// Represents a login request message from a client. Contains user credentials.
    /// </summary>
    [DataContract(Namespace = "http://www.yourcompany.com/types/")]
    public class LoginRequest : RequestBase
    {
        /// <summary>
        /// User name credential.
        /// </summary>
        [DataMember]
        public string UserName = "";

        /// <summary>
        /// Password credential.
        /// </summary>
        [DataMember]
        public string Password = "";
    }
}
