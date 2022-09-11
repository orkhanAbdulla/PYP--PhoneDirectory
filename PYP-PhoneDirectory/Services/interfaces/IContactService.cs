using PYP_PhoneDirectory.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDirectory.Services.interfaces
{
    public interface IContactService
    {
        public Task<Contact> AddContactAsync();
        public ICollection<Contact> ShowAllContact();
    }
}
