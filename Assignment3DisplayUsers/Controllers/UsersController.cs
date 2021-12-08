using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3DisplayUsers.Models;

namespace Assignment3DisplayUsers.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult DisplayAllUsers()
        {
            BusinessLayer bll = new BusinessLayer();
            List<Users> lstUsers= bll.GetAllUsers();
            
            return View(lstUsers);
        }

        [HttpGet]
        public ActionResult DisplayUser()
        {
            List<Users> lstUser = new BusinessLayer().GetAllUsers();
            // adding all the selectlistitem to list from business layer
            List<SelectListItem> user1 = new List<SelectListItem>();

            foreach (var item in lstUser)
            {
                SelectListItem lstItem = new SelectListItem();
                lstItem.Text = item.UserName;
                lstItem.Value = item.UserId.ToString();
                user1.Add(lstItem);
            }
            //var users = new List<SelectListItem>
            //{
            //    new SelectListItem{Text="Ramnath",Value="1"},
            //    new SelectListItem{Text="David",Value="2"},
            //    new SelectListItem{Text="Alex",Value="3"}


            //};
            ViewData.Add("users", user1);
            return View();
        }

        [HttpPost]
        public ActionResult DisplayUser(string userId)
        {
            
            BusinessLayer bll = new BusinessLayer();
            Users user = bll.GetUserById(Convert.ToInt32(userId));
           
            
            return RedirectToAction("DisplayUserDetail",user);
        }
        public ActionResult DisplayUserDetail(Users user)
        {

            return View(user);
        }
    }
}