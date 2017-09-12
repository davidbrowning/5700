using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonClassLibrary
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int ObjectId { get; set; }
        [DataMember]
        public string StateFileNumber { get; set; }
        [DataMember]
        public string SocialSecurityNumber { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string MiddleName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public int BirthYear { get; set; }
        [DataMember]
        public int BirthMonth { get; set; }
        [DataMember]
        public int BirthDay { get; set; }
        [DataMember]
        public string Gender { get; set; }
        [DataMember]
        public string NewbornScreeningNumber { get; set; }
        [DataMember]
        public string IsPartOfMultipleBirth { get; set; }
        [DataMember]
        public int BirthOrder { get; set; }
        [DataMember]
        public string BirthCounty { get; set; }
        [DataMember]
        public string MothersFirstName { get; set; }
        [DataMember]
        public string MothersMiddleName { get; set; }
        [DataMember]
        public string MothersLastName { get; set; }
        [DataMember]
        public string Phone1 { get; set; }
        [DataMember]
        public string Phone2 { get; set; }
        [DataMember]
        public string BirthDate { get; set; }
        public override string ToString()
        {
            try
            {
                string d = this.BirthDay.ToString();
                string m = this.BirthMonth.ToString();
                string y = this.BirthYear.ToString();
                BirthDate = d + "/" + m + "/" + y; 
            }
            catch
            {
                Console.WriteLine("Error parsing Birthdate");
            }
            return $"ObjectId={ObjectId}, FirstName={FirstName}, MiddleName={MiddleName}, LastName={LastName} BirthDate={BirthDate}";
        }
    }
}
