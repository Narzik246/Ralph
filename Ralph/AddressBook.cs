using AddressBookApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ralph
{    
    // AddressBook class to manage contacts
    public class AddressBook
    {
        private string directory;

        public AddressBook(string directory = "Contacts")
        {
            this.directory = directory;
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        // Generate unique file name for each contact (in case of duplicate names)
        private string GetFileName(string firstName, string lastName)
        {
            string baseFileName = $"{firstName}_{lastName}.txt";
            string fileName = Path.Combine(directory, baseFileName);
            int counter = 1;

            while (File.Exists(fileName))
            {
                fileName = Path.Combine(directory, $"{firstName}_{lastName}_{counter}.txt");
                counter++;
            }

            return fileName;
        }

        // Add a new contact to the address book
        public void AddContact(Contact contact)
        {
            string fileName = GetFileName(contact.FirstName, contact.LastName);

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine($"First Name: {contact.FirstName}");
                writer.WriteLine($"Last Name: {contact.LastName}");

                writer.WriteLine("Addresses:");
                foreach (var address in contact.Addresses)
                {
                    writer.WriteLine($"  - {address}");
                }

                writer.WriteLine("Phone Numbers:");
                foreach (var phoneNumber in contact.PhoneNumbers)
                {
                    writer.WriteLine($"  - {phoneNumber}");
                }

                writer.WriteLine("Emails:");
                foreach (var email in contact.Emails)
                {
                    writer.WriteLine($"  - {email}");
                }
            }

            Console.WriteLine($"Contact {contact.FirstName} {contact.LastName} added successfully.");
        }

        // View a contact's details
        public void ViewContact(string firstName, string lastName)
        {
            string fileName = GetFileName(firstName, lastName);
            if (File.Exists(fileName))
            {
                Console.WriteLine(File.ReadAllText(fileName));
            }
            else
            {
                Console.WriteLine($"Contact {firstName} {lastName} not found.");
            }
        }

        // Add additional info to an existing contact
        public void AddInfo(string firstName, string lastName, string infoType, string value)
        {
            string fileName = GetFileName(firstName, lastName);
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Contact {firstName} {lastName} not found.");
                return;
            }

            var contactInfo = File.ReadAllLines(fileName);
            for (int i = 0; i < contactInfo.Length; i++)
            {
                if (contactInfo[i].StartsWith(infoType))
                {
                    string newLine = contactInfo[i] + $"  - {value}";
                    contactInfo[i] = newLine;
                    break;
                }
            }

            File.WriteAllLines(fileName, contactInfo);
            Console.WriteLine($"Added {value} to {infoType} of {firstName} {lastName}.");
        }

        // Remove specific information from an existing contact
        public void RemoveContactInfo(string firstName, string lastName, string infoType, string value)
        {
            string fileName = GetFileName(firstName, lastName);
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"Contact {firstName} {lastName} not found.");
                return;
            }

            var contactInfo = File.ReadAllLines(fileName);
            for (int i = 0; i < contactInfo.Length; i++)
            {
                if (contactInfo[i].StartsWith(infoType))
                {
                    contactInfo[i] = contactInfo[i].Replace($"  - {value}", string.Empty);
                    break;
                }
            }

            File.WriteAllLines(fileName, contactInfo);
            Console.WriteLine($"Removed {value} from {infoType} of {firstName} {lastName}.");
        }
    }
}
