using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TasksManager.App.Models
{
    [DataContract]
    public class RegisterUserResponseModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }
    }
}