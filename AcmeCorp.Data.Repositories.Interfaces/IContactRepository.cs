using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AcmeCorp.Data.Models;

namespace AcmeCorp.Data.Repositories.Interfaces
{
    internal interface IContactRepository
    {

        /// <summary>
        /// Adds a Contact to the database
        /// </summary>
        /// <param name="contact"></param>
        /// <returns>Id of the new Contact</returns>
        public int AddContact(Contact contact);

    }
}
