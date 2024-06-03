﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.ISOAPService")]
    public interface ISOAPService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISOAPService/NumToWords", ReplyAction="*")]
        System.Threading.Tasks.Task<ServiceReference.NumToWordsResponse> NumToWordsAsync(ServiceReference.NumToWordsRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class NumToWordsRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="NumToWords", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.NumToWordsRequestBody Body;
        
        public NumToWordsRequest()
        {
        }
        
        public NumToWordsRequest(ServiceReference.NumToWordsRequestBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class NumToWordsRequestBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int num;
        
        public NumToWordsRequestBody()
        {
        }
        
        public NumToWordsRequestBody(int num)
        {
            this.num = num;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class NumToWordsResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="NumToWordsResponse", Namespace="http://tempuri.org/", Order=0)]
        public ServiceReference.NumToWordsResponseBody Body;
        
        public NumToWordsResponse()
        {
        }
        
        public NumToWordsResponse(ServiceReference.NumToWordsResponseBody Body)
        {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class NumToWordsResponseBody
    {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string NumToWordsResult;
        
        public NumToWordsResponseBody()
        {
        }
        
        public NumToWordsResponseBody(string NumToWordsResult)
        {
            this.NumToWordsResult = NumToWordsResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface ISOAPServiceChannel : ServiceReference.ISOAPService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class SOAPServiceClient : System.ServiceModel.ClientBase<ServiceReference.ISOAPService>, ServiceReference.ISOAPService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SOAPServiceClient() : 
                base(SOAPServiceClient.GetDefaultBinding(), SOAPServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ISOAPService_soap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SOAPServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(SOAPServiceClient.GetBindingForEndpoint(endpointConfiguration), SOAPServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SOAPServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SOAPServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SOAPServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SOAPServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SOAPServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ServiceReference.NumToWordsResponse> ServiceReference.ISOAPService.NumToWordsAsync(ServiceReference.NumToWordsRequest request)
        {
            return base.Channel.NumToWordsAsync(request);
        }
        
        public System.Threading.Tasks.Task<ServiceReference.NumToWordsResponse> NumToWordsAsync(int num)
        {
            ServiceReference.NumToWordsRequest inValue = new ServiceReference.NumToWordsRequest();
            inValue.Body = new ServiceReference.NumToWordsRequestBody();
            inValue.Body.num = num;
            return ((ServiceReference.ISOAPService)(this)).NumToWordsAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISOAPService_soap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ISOAPService_soap))
            {
                return new System.ServiceModel.EndpointAddress("https://soapwebservice0.azurewebsites.net/NumToWords.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return SOAPServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ISOAPService_soap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return SOAPServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ISOAPService_soap);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ISOAPService_soap,
        }
    }
}
