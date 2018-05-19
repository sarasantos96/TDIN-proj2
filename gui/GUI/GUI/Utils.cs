using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class User
    {
        private string solverId;
        private string email;
        private Boolean isIT;

        public User(string id, string email, Boolean IT)
        {
            this.solverId = id;
            this.email = email;
            this.isIT = IT;
        }

        public string getID()
        {
            return solverId;
        }

        public string getEmail()
        {
            return email;
        }

        public Boolean isSolverIT()
        {
            return isIT;
        }
    }
}
