using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;
using WebClient.ServiceProduct;

namespace WebClient.Controllers
{
    public class HomeController : Controller
    {
        
        ProductServiceClient ps = new ProductServiceClient();
        ProductsModel data = new ProductsModel();
        [UserAuthentication]
        public ActionResult Index()
        {
            data.plist = ps.GetProductsBySupplier(Convert.ToInt32(Session["SupplierID"])).ToList();
            return View(data);
        }
        public ActionResult TumUrunler()
        {
            data.plist = ps.GetProducts().ToList();
            return View(data);
        }
        public ActionResult Guncelle(int id)
        {
            data.pdto = ps.GetOneProduct(id, Convert.ToInt32(Session["SupplierID"]));
            if (data.pdto.UrunAd != null)
            {
                return View(data);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Guncelle(ProductsModel m)
        {
            bool sonuc = ps.ProductUpdate(m.pdto);
            return RedirectToAction("Index");

        }
    }
}