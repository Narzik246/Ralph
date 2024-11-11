using Ralph;
using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBookApp
{
    // Main Program Class
    class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            MenuHandler menuHandler = new MenuHandler(addressBook);
            menuHandler.ShowMenu();
        }
    }
}


