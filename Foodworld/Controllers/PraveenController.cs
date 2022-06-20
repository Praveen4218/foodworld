using Microsoft.AspNetCore.Mvc;
using Foodworld.models;
using System.Linq;

namespace Foodworld.Controllers
{
    
    public class PraveenController : Controller
    {
        FoodcoreContext dc = new FoodcoreContext();
        public string Index()
        {
            return "bharathi";
        }
        public ViewResult home()
        {
            return View();
        }
        [HttpGet]
        public ViewResult login()
        {
            
            return View();
           
        }
        [HttpPost]
        public ActionResult Login(IFormCollection frm)
        {

            string uname = frm["uname"];
            string pwd = frm["pwd"];


            HttpContext.Session.SetString("uid", uname);

            //var res = (from t in dc.Registers
            //           where t.Username == uname && t.Pwd == pwd
            //           select t).Count();


            var c = dc.Registers.ToList().Where(c => c.Username == uname && c.Pwd == pwd).Count();

            if (c > 0)
            {
                return RedirectToAction("menu");

                // valid
            }
            else
            {

                ViewData["v"] = "Invalid username or password";
                // not valid
                return View();
            }


        }
        public ViewResult logout()
        {
            
            return View();

        }


        [HttpGet]
        public ViewResult Registerpage()
        {
            // logic for register page goes here
            return View();

        }
        [HttpPost]
        public ViewResult Registerpage(Register r)
        {
            if (ModelState.IsValid)
            {

                // logic for register page goes here
                dc.Registers.Add(r);
            int i = dc.SaveChanges();

            if (i > 0)
            {
                ViewData["a"] = "New User created successfully";
            }
            else
            {
                ViewData["a"] = "Error occured try after some time";
            }
                return View();
            }
            else
            {
                return View();
            }



        }
        
        public ViewResult menu ()
        {
            // logic for register page goes here
            var result = from t in dc.Menus
                         select t;

            return View(result);

        }

        [HttpGet]
        public ViewResult myorder(string myitemid)
        {
            // is it 1 or many

            var result = dc.Menus.ToList().Find(c => c.Itemid == myitemid);

            TempData["p"] = result.Price;
            TempData["i"] = result.Itemid;

            TempData.Keep();


            return View(result);


        }


        [HttpPost]
        public ActionResult myorder(IFormCollection c)
        {

            // insert new value to myorders table

            if (HttpContext.Session.GetString("uid") == null)
            {
                return RedirectToAction("Login");
            }

            else
            {


                Order o = new Order();
                o.Username = HttpContext.Session.GetString("uid");
                o.Itemid = TempData["i"].ToString();
                o.Price = Convert.ToInt32(TempData["p"]);
                o.Qty = Convert.ToInt32(c["t1"]);

                dc.Orders.Add(o);
                int i = dc.SaveChanges();

                if (i > 0)
                {
                    ViewData["a"] = "Your order placed successfully";
                }
                else
                {
                    ViewData["a"] = "Error occured try after some time";
                }

                return View();

            }


        }
        [HttpGet]
        public ActionResult Addtocart(string myitemid)
        {
            //  var result = dc.Menus.ToList().Find(c => c.Itemid == myitemid);

            //  li.Add(result);

            Mycart m = new Mycart();
            m.Username = HttpContext.Session.GetString("uid");
            m.Itemid= myitemid;
            dc.Mycarts.Add(m);

            int i = dc.SaveChanges();
            if (i > 0)
            {
                ViewData["a"] = myitemid + "  Item Add successfully to cart";
            }
            else
            {
                ViewData["a"] = myitemid + "failed to add try again";
            }

            //TempData.Add(myitemid, myitemid);

            var res = dc.Menus.ToList().Join(dc.Mycarts.ToList(), c => c.Itemid, w => w.Itemid, (c, w) => new { c.Itemid, c.Itemname, c.Price, c.Images, c.Itemdesc });

            int? sum = 0;

            foreach (var item in res)
            {
                sum = sum + item.Price;


            }

            ViewData["total"] = sum;


            return View(res);



        }






        public ViewResult contactus ()
        {
            // logic for register page goes here
            return View();

        }

        public ViewResult mypage()
        {
            // logic for register page goes here
            return View();

        }
        [HttpGet] // run for first time
        public ViewResult testing()
        {

            
            

          return View();


        }

            // this method has to called after click on button

            //[HttpPost] // dont run for 1st time 
            //public ViewResult Addnums(string t1, string t2)
            //{

            //    int res = int.Parse(t1) + int.Parse(t2);

            //    ViewData["r"] = res;

            //    // this method will read value of texbox
            //    return View();


            //}

            [HttpPost] // dont run for 1st time 
            public ViewResult testing(IFormCollection f)
            {

                int res = int.Parse(f["t1"]) + int.Parse(f["t2"]);

                ViewData["r"] = res;

                // this method will read value of texbox
                return View();


            }


            [HttpPost] // dont run for 1st time 
            public ViewResult multiply(IFormCollection f)
            {

                int res = int.Parse(f["t1"]) * int.Parse(f["t2"]);

                ViewData["r"] = res;

                // this method will read value of texbox
                return View("testing");


            }
           

        
    }
}
