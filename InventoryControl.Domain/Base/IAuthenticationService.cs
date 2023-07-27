using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Domain.Base
{
    public interface IAuthenticationService
    {
        int GetIdUser();
        int GetRolUser();
    }
}
