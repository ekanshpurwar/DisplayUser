using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3DisplayUsers.Models
{
    public class BusinessLayer
    {
        public List<Users> GetAllUsers()
        {
            DataAccessLayer dal = new DataAccessLayer();
            return dal.GetAllUsers();
        }
        public Users GetUserById(int userId)
        {
            DataAccessLayer dal = new DataAccessLayer();
            return dal.GetUserById(userId);
        }
    }
}