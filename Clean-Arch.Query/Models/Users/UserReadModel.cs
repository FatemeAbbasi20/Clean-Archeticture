using Clean_Arch.Domain.Users.ValueObjects;
using Clean_Arch.Query.Shared;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Arch.Query.Models.Users
{
    public class UserReadModel:BaseReadModel
    {

        public string Name { get;  set; }
        public string Family { get;  set; }
        public string Email { get;  set; }
        public PhoneNumber PhoneNumber { get;  set; }
        public DateTime CreationTime { get; set; }

    }
}
