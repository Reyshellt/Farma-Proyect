using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_AD;

namespace C_LN
{
    public class userModel
    {
        UserDao userDao = new UserDao();
        public bool loginUser(string user, string clave)
        {
            return userDao.Login(user, clave);
        }
    }
}
