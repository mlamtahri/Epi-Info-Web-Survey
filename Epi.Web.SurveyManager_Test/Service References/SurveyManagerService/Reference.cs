﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Epi.Web.SurveyManager_Test.SurveyManagerService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="cSurveyRequest", Namespace="http://schemas.datacontract.org/2004/07/Epi.Web.SurveyManager")]
    [System.SerializableAttribute()]
    public partial class cSurveyRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ClosingDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DepartmentNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IntroductionTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsSingleResponseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrganizationNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurveyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurveyNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TemplateXMLField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ClosingDate {
            get {
                return this.ClosingDateField;
            }
            set {
                if ((this.ClosingDateField.Equals(value) != true)) {
                    this.ClosingDateField = value;
                    this.RaisePropertyChanged("ClosingDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DepartmentName {
            get {
                return this.DepartmentNameField;
            }
            set {
                if ((object.ReferenceEquals(this.DepartmentNameField, value) != true)) {
                    this.DepartmentNameField = value;
                    this.RaisePropertyChanged("DepartmentName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IntroductionText {
            get {
                return this.IntroductionTextField;
            }
            set {
                if ((object.ReferenceEquals(this.IntroductionTextField, value) != true)) {
                    this.IntroductionTextField = value;
                    this.RaisePropertyChanged("IntroductionText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsSingleResponse {
            get {
                return this.IsSingleResponseField;
            }
            set {
                if ((this.IsSingleResponseField.Equals(value) != true)) {
                    this.IsSingleResponseField = value;
                    this.RaisePropertyChanged("IsSingleResponse");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrganizationName {
            get {
                return this.OrganizationNameField;
            }
            set {
                if ((object.ReferenceEquals(this.OrganizationNameField, value) != true)) {
                    this.OrganizationNameField = value;
                    this.RaisePropertyChanged("OrganizationName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SurveyName {
            get {
                return this.SurveyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurveyNameField, value) != true)) {
                    this.SurveyNameField = value;
                    this.RaisePropertyChanged("SurveyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SurveyNumber {
            get {
                return this.SurveyNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.SurveyNumberField, value) != true)) {
                    this.SurveyNumberField = value;
                    this.RaisePropertyChanged("SurveyNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TemplateXML {
            get {
                return this.TemplateXMLField;
            }
            set {
                if ((object.ReferenceEquals(this.TemplateXMLField, value) != true)) {
                    this.TemplateXMLField = value;
                    this.RaisePropertyChanged("TemplateXML");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="cSurveyRequestResult", Namespace="http://schemas.datacontract.org/2004/07/Epi.Web.SurveyManager")]
    [System.SerializableAttribute()]
    public partial class cSurveyRequestResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsPulishedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StatusTextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string URLField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsPulished {
            get {
                return this.IsPulishedField;
            }
            set {
                if ((this.IsPulishedField.Equals(value) != true)) {
                    this.IsPulishedField = value;
                    this.RaisePropertyChanged("IsPulished");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StatusText {
            get {
                return this.StatusTextField;
            }
            set {
                if ((object.ReferenceEquals(this.StatusTextField, value) != true)) {
                    this.StatusTextField = value;
                    this.RaisePropertyChanged("StatusText");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string URL {
            get {
                return this.URLField;
            }
            set {
                if ((object.ReferenceEquals(this.URLField, value) != true)) {
                    this.URLField = value;
                    this.RaisePropertyChanged("URL");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SurveyManagerService.ISurveyManager")]
    public interface ISurveyManager {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISurveyManager/PublishSurvey", ReplyAction="http://tempuri.org/ISurveyManager/PublishSurveyResponse")]
        Epi.Web.SurveyManager_Test.SurveyManagerService.cSurveyRequestResult PublishSurvey(Epi.Web.SurveyManager_Test.SurveyManagerService.cSurveyRequest pRequestMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISurveyManagerChannel : Epi.Web.SurveyManager_Test.SurveyManagerService.ISurveyManager, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SurveyManagerClient : System.ServiceModel.ClientBase<Epi.Web.SurveyManager_Test.SurveyManagerService.ISurveyManager>, Epi.Web.SurveyManager_Test.SurveyManagerService.ISurveyManager {
        
        public SurveyManagerClient() {
        }
        
        public SurveyManagerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SurveyManagerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SurveyManagerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SurveyManagerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Epi.Web.SurveyManager_Test.SurveyManagerService.cSurveyRequestResult PublishSurvey(Epi.Web.SurveyManager_Test.SurveyManagerService.cSurveyRequest pRequestMessage) {
            return base.Channel.PublishSurvey(pRequestMessage);
        }
    }
}