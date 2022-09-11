using PYP_PhoneDirectory.Helpers;
using PYP_PhoneDirectory.Models;
using PYP_PhoneDirectory.Repositories.Interfaces;
using PYP_PhoneDirectory.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDirectory.Services.Implementations
{
    internal class ContactService : IContactService
    {
        private IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> AddContactAsync()
        {
            name:
            Helper.Print("Please input Name", ConsoleColor.Green);
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)&& !Helper.CheckName(name))
                goto name;
            surname:
            Helper.Print("Please input Surname", ConsoleColor.Green);
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname)&& !Helper.CheckName(surname))
                goto surname;
            phone:
            Helper.Print("Please input Phone", ConsoleColor.Green);
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(phone)&& !Helper.CheckNumber(phone))
                goto phone;
            mail:
            Helper.Print("Please input Mail", ConsoleColor.Green);
            string mail = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(mail)&& !Helper.CheckEmail(mail))
                goto mail;
            Contact contact = new Contact()
            {
                Name = name,
                Surname = surname,
                Phone = phone,
                Mail = mail
            };
            bool result =await _contactRepository.AddAsync(contact);
            if (!result)
            {
                contact = null;
            }
            return contact;
        }

        public ICollection<Contact> ShowAllContact()
        {
            return _contactRepository.GetAll();
        }
    }
}
