using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ralph
{
    // MenuHandler class to manage the menu operations
    public class MenuHandler
    {
        private AddressBook addressBook;

        public MenuHandler(AddressBook addressBook)
        {
            this.addressBook = addressBook;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Address Book Menu:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. View Contact");
                Console.WriteLine("3. Add Information to Contact");
                Console.WriteLine("4. Remove Information from Contact");
                Console.WriteLine("5. Exit");

                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContactMenu();
                        break;
                    case "2":
                        ViewContactMenu();
                        break;
                    case "3":
                        AddInfoMenu();
                        break;
                    case "4":
                        RemoveInfoMenu();
                        break;
                    case "5":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        // Add a contact through the menu
        private void AddContactMenu()
        {
            Console.Write("\nEnter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            var contact = new Contact(firstName, lastName);

            Console.Write("Enter Address (comma separated): ");
            string addresses = Console.ReadLine();
            contact.Addresses.AddRange(addresses.Split(','));

            Console.Write("Enter Phone Number(s) (comma separated): ");
            string phoneNumbers = Console.ReadLine();
            contact.PhoneNumbers.AddRange(phoneNumbers.Split(','));

            Console.Write("Enter Email(s) (comma separated): ");
            string emails = Console.ReadLine();
            contact.Emails.AddRange(emails.Split(','));

            addressBook.AddContact(contact);
        }

        // View a contact through the menu
        private void ViewContactMenu()
        {
            Console.Write("\nEnter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            addressBook.ViewContact(firstName, lastName);
        }

        // Add info to a contact through the menu
        private void AddInfoMenu()
        {
            Console.Write("\nEnter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Info Type (Addresses/Phone Numbers/Emails): ");
            string infoType = Console.ReadLine();
            Console.Write("Enter the value to add: ");
            string value = Console.ReadLine();

            addressBook.AddInfo(firstName, lastName, infoType, value);
        }

        // Remove info from a contact through the menu
        private void RemoveInfoMenu()
        {
            Console.Write("\nEnter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Info Type (Addresses/Phone Numbers/Emails): ");
            string infoType = Console.ReadLine();
            Console.Write("Enter the value to remove: ");
            string value = Console.ReadLine();

            addressBook.RemoveContactInfo(firstName, lastName, infoType, value);
        }
    }
}
