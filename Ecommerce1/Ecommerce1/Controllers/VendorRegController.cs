using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ecommerce1.Models;

namespace Ecommerce1.Controllers
{
    public class VendorRegController : Controller
    {
        private new_ecommerceEntities db = new new_ecommerceEntities();
        // GET: VendorReg
        public ActionResult Index()
        {
            return View();
        }

      
        // GET: VendorReg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorReg/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "BusinessId,BusinessName,Latitude,Longitude")] Business reg)
        {
            if (ModelState.IsValid)
            {
                db.Businesses.Add(reg);

                db.SaveChanges();
                ViewBag.SuccessMessage = "Registration Successfull";
            }

            return View(reg);
        }

        public ActionResult addproduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addproduct(StoreId addProduct)
        {
            if (ModelState.IsValid)
            {
                if (db.Businesses.Any(x => x.BusinessId == addProduct.BusinessId))
                {
                    return RedirectToAction("Add","VendorReg");
                }
            }
            ModelState.AddModelError("", "Your store is not registerd");
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase file, StoreId addProduct)
        {

            if (Request.Files.Count > 0)
            {
                var file1 = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    file.SaveAs(path);
                    ViewBag.message = "File uploaded sucessfully";

                    List<Products> products = new List<Products>();
                    char[] ch = { ',' };

                    StreamReader sr = new StreamReader(path);
                    string constring = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                    SqlConnection conn = new SqlConnection(constring);
                    conn.Open();

                    while (!sr.EndOfStream)
                    {
                        string str = sr.ReadLine();

                        string[] str1 = str.Split(ch, StringSplitOptions.RemoveEmptyEntries);
                        // var quntity= Int32.Parse(str1[1]);
                        //var price = Int32.Parse(str1[2]);
                        //prod.Add(new ProductsDetail() { Product_name = str1[0]});

                        SqlCommand cmd1 = new SqlCommand("insert into Products(ProductId,ProductName,BusinessId,ProductPrice,ProductDescription,ProductImg)" +
                                                           "values(@productid,@productname,@businessid,@price,@productdes,@productimg)");
                        cmd1.CommandType = CommandType.Text;
                        cmd1.Connection = conn;
                        cmd1.Parameters.AddWithValue("@productid", str1[0]);
                        cmd1.Parameters.AddWithValue("@productname", str1[1]);
                        cmd1.Parameters.AddWithValue("@businessid", str1[2]);
                        cmd1.Parameters.AddWithValue("@price", double.Parse(str1[3]));
                        cmd1.Parameters.AddWithValue("@productdes", str1[4]);
                        cmd1.Parameters.AddWithValue("@productimg", str1[5]);

                        cmd1.ExecuteNonQuery();
                    }

                }
                else
                {
                    ViewBag.message = "File upload failed";
                }

            }

            return View();

        }

    }
}
