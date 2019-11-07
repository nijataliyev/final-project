using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models
{
    public enum RoleType:byte
    {
        Admin=1,
        HR,
        Ps,
        Dh,
        Other
    }
}
