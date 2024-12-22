using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cactuses.DB
{
    class ConnectionClass
    {
        public static MDK_RPM_CactusEntities db = new MDK_RPM_CactusEntities();
        public static User user = new User();
    }
}
