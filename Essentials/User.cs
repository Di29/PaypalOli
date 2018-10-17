using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essentials
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public Guid ID { get; set; }
        [DataMember]
        public int PhoneNumber { get; set; }
        [DataMember]
        public DateTime CreatedDate { get; set; }
        [DataMember]
        public DateTime DeletedDate { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
