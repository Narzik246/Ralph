using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ralph
{
    // Contact class to store individual contact information
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> Addresses { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public List<string> Emails { get; set; }

        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Addresses = new List<string>();
            PhoneNumbers = new List<string>();
            Emails = new List<string>();
        }
    
}
