using System.Runtime.Serialization;
using System.ServiceModel;
using System;
using System.Collections.Generic;

namespace WcfService
{
    [ServiceContract]
    public interface ILDAPLoginService
    {
        [OperationContract]
        LoginResponse Login(LoginRequest request);

        [OperationContract]
        LoginLogs GetLogs();
    }

    [DataContract]
    public class LoginLogs
    {
        [DataMember]
        public List<LoginLogElement> Logs { get; set; }
    }

    [DataContract]
    public class LoginLogElement
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public DateTime LoginDate { get; set; }
    }

    [DataContract]
    public class LoginRequest
    {
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Domain { get; set; }
    }

    [DataContract]
    public class LoginResponse
    {
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public bool IsOK { get; set; }
    }
}