using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        Data_Application_Layer.db dblayer = new Data_Application_Layer.db();
       
        public ActionResult Admin()
        {
            DataSet ds = dblayer.show_All();
            ViewBag.emp = ds.Tables[0];
            /// SHow data
            DataSet ds1 = dblayer.show_All_Brand();
            ViewBag.brand = ds1.Tables[0];

            DataSet ds2 = dblayer.Show_All_Category();
            ViewBag.Category = ds2.Tables[0];
            return View();
        }
        public ActionResult Index()
        {
            DataSet ds = dblayer.fetch();
            ViewBag.emp = ds.Tables[0];

            DataSet ds1 = dblayer.Show_All_Featured();
            ViewBag.pro = ds1.Tables[0];
            return View();
        }
        
        //public ActionResult Index(int id)
        //{
        //    Session["var4"] = id;
        //    TempData["var4"] = id;
        //    return View();
        //}
        public ActionResult Update_req(int id)
        {
            DataSet ds = dblayer.show_record(id);
            ViewBag.sliderRec = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult Update_req(int id, FormCollection fc)
        {
            Admin ad = new Admin();
            ad.sliderId = id;
            ad.ImageTitle = fc["ImageTitle"];
            ad.ImageDescription = fc["ImageDescription"];
            ad.ImagePath = fc["ImagePath"];
            dblayer.Update_record(ad);
            TempData["msg"] = "Is Updated";
            return RedirectToAction("Index");

        }
        public ActionResult MultiplePage(int id)
        {
            
            DataSet ds = dblayer.show_record_brand(id);
            ViewBag.brand = ds.Tables[0];
            return View();
          
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
            public ActionResult Insert(FormCollection fc)
        {
            product p = new product();
            p.ProductName = fc["ProductName"];
            p.CategoryId = fc["CategoryId"];
            p.IsActive = fc["IsActive"];
            p.Description = fc["Description"];
            p.ProductImage = fc["ProductImage"];
            p.Quantity = fc["Quantity"];
            p.Price = fc["Price"];
            p.Featured = fc["Featured"];
            dblayer.add_record_brand(p);
            TempData["msg"] = "Is instered";
            return View();

        }

        public ActionResult Update_Brand(int id)
        {
            DataSet ds = dblayer.show_brand_id(id);
            ViewBag.brandrecord = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult Update_Brand(int id, FormCollection fc)
        {
            product p = new product();
            p.ProductId = id;
            p.ProductName = fc["ProductName"];
            p.CategoryId = fc["CategoryId"];
            p.IsActive = fc["IsActive"];
            p.Description = fc["Description"];
            p.ProductImage = fc["ProductImage"];
            p.Quantity = fc["Quantity"];
            p.Price = fc["Price"];
            p.Featured = fc["Featured"];
            
            dblayer.Update_Brand(p);
            TempData["msg"] = "Is Updated";
            return RedirectToAction("Index");

        }
        public ActionResult DeleteRecord(int id)
        {
            dblayer.Delete_record(id);
            TempData["msg"] = "Deleted";
            return RedirectToAction("Index");
        }
        public ActionResult InsertCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCategory(FormCollection fc)
        {
            Category c = new Category();
            c.CategoryName = fc["CategoryName"];

            dblayer.add_record_category(c);

            return View();

        }

        public ActionResult Update_Category(int id)
        {
            DataSet ds = dblayer.show_record_Categroy(id);
            ViewBag.brandCate = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult Update_Category(int id, FormCollection fc)
        {
            Category c = new Category();
            c.CategoryId = id;
            c.CategoryName = fc["CategoryName"];


            dblayer.Update_Category(c);
            TempData["msg"] = "Is Updated";
            return RedirectToAction("Index");

        }
        public ActionResult Deletecategory(int id)
        {
            dblayer.Delete_Category(id);

            return RedirectToAction("Index");
        }
    }
} 