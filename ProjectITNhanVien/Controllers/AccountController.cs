using ProjectITNhanVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectITNhanVien.Controllers
{
    public class AccountController : Controller
    {
        private DBContext db = new DBContext();
        public ActionResult Login(string Username, string Password)
        {
            var kt = db.Users.Where(o => o.Username.Equals(Username) && o.Password.Equals(Password)).ToList();
            if (kt.Count() > 0)
            {
                HttpCookie ck = new HttpCookie("Username");
                ck.Value = Username; // chỗ ni password chớ, k lấy usernam đễ xong kiểm tra côkie để re action về login nếu giá trị == null ok hiểu
                //lưu cookie 5 ngày
                ck.Expires = DateTime.Now.AddDays(5); // oke hiểu
                // moé quên hết haha , xong phần login đó. làm lând đi m t hiểu hết
                Response.Cookies.Add(ck);

            }
            else
            {
                ViewBag.error = "Sai tài khoản hoặc mật khẩu!"; // Username
                return View();
            }


            // cái reaction răng hè
            return RedirectToAction("Index", "Home");// hình nhưu phải haha. coppy nhiêfu quá quên hết mịa


        }
      
        public ActionResult Register(string UserName, string Password)
        {
            //cái ni bên t có cần đâu mà vẫn đăng ksy được
            if (Request.HttpMethod == "POST")
            {
                //ktra tên trong hệ thống k cso thi đăng ký
                if( UserName != null &&  Password != null)
                {
                    var us = db.Users.FirstOrDefault(o => o.Username == UserName);
                    if (us == null)
                    {
                        User use = new User();
                        use.Username = UserName;
                        use.Password = Password;
                        db.SaveChanges();
                        ViewBag.messenger = "Đăng ký thanh công";
                    }
                    
                }

            }
            return View();
            //var check = db.Users.FirstOrDefault(o => o.Username == Username);
            //if (Password != null)
            //{
            //    if (check == null)
            //    {
            //        Password = GetMD5(Password);
            //        db.Users.Add(systemDatabase);
            //        db.SaveChanges();
            //        ViewBag.confirn = "Đăng ký thành công!!";
            //    }
            //    else
            //    {
            //        ViewBag.error = "Tên đăng nhập đã tồn tại!";
            //    }

            //}
            //else
            //{
            //    ViewBag.error = "Đăng ký thất bại!";
            //    return View();
            //}
            //return View();
        }
    }
}