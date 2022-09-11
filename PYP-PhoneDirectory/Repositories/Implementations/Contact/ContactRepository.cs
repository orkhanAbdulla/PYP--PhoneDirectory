using PYP_PhoneDirectory.Models;
using PYP_PhoneDirectory.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PYP_PhoneDirectory.Repositories.Implementations
{
    public class ContactRepository:QueryRepository<Contact>,IContactRepository
    {
        public ContactRepository(SqlConnection connection):base(connection)
        {

        }
    }
}


