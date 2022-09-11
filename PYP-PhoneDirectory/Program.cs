using PYP_PhoneDirectory.Data;
using PYP_PhoneDirectory.Helpers;
using PYP_PhoneDirectory.Models;
using PYP_PhoneDirectory.Repositories.Implementations;
using PYP_PhoneDirectory.Repositories.Interfaces;
using PYP_PhoneDirectory.Services.Implementations;
using PYP_PhoneDirectory.Services.interfaces;
using System.Data.SqlClient;

AppDbContext AppDbContext=new AppDbContext();

IContactRepository contactRepository = new ContactRepository(new SqlConnection(Helper.ConnectionString));

IContactService contactService = new ContactService(contactRepository);


while (true)
{
    Helper.Print("Add Info  (a) \nShowAll Info  (l) \nSearch Info  (s)  \nExit  (e)",ConsoleColor.Cyan);
    string menu = Console.ReadLine().ToLower().Trim();
    if (!String.IsNullOrWhiteSpace(menu)&& menu == Helper.AddInfo|| menu == Helper.ShowAllInfo||
        menu == Helper.SearchInfo ||menu == Helper.Exit)
    {
        switch (menu)
        {
            case Helper.AddInfo:
                Contact contact = await contactService.AddContactAsync();
                Helper.Print($"{contact.Name} {contact.Surname} Created successfully", ConsoleColor.Blue);
                break;
            case Helper.ShowAllInfo:
                foreach (var item in contactService.ShowAllContact())
                {
                    Helper.Print(item, ConsoleColor.Green);
                }
                break;
            case Helper.SearchInfo:
                Console.WriteLine("Seacrh");
                Console.ReadLine();
                break;
            default:
                break;
        }
    }
}


