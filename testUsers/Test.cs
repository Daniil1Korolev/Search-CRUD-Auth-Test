using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testUsers
{
    public class Function
    {
        public testdemEntities db = new testdemEntities();

        public int CountUsers()
        {
            return db.User.ToList().Count;
        }
    }
}
