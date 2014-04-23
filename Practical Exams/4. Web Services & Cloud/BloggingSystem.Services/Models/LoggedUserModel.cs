namespace BloggingSystem.Service.Models
{
    using System.Runtime.Serialization;

    [DataContract]
    public class LoggedUserModel
    {
        [DataMember(Name="displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "sessionKey")]
        public string SessionKey { get; set; }
    }
}