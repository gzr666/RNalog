using RadniNalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Services
{
    /*Interface za provjeru i kreiranje rola*/

   public interface IFillRole
    {

         Task createRolesandUsers();
        void fillNalog();
    }
}
