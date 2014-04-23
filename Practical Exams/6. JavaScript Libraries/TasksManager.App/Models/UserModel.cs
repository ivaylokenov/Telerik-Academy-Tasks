using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TasksManager.App.Models
{
    [DataContract]
    public class UserModel
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "authCode")]
        public string AuthCode { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }
    }
}