﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class User
    {
        private string id;
        private string email;
        private Boolean isIT;

        public User(string id, string email, Boolean IT)
        {
            this.id = id;
            this.email = email;
            this.isIT = IT;
        }

        public string getID()
        {
            return id;
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

    public class Ticket
    {
        public string id, userId, solverId, name, email, title, description, status;

        public Ticket(string id, string userId, string solverId, string name, string email, string title, string description, string status)
        {
            this.id = id;
            this.userId = userId;
            this.solverId = solverId;
            this.name = name;
            this.email = email;
            this.title = title;
            this.description = description;
            this.status = status;
        }
    }
}
