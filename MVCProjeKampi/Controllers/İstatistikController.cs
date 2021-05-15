using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MVCProjeKampi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class İstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context db = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Istatistik()
        {
            //Istatistikleri tutacağımız sınıf
            Statistics istatistikler = new Statistics();

            //toplam kategori sayısı
            istatistikler.CategoryCount = cm.GetList().Count();

            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            istatistikler.YazilimHeadingCount = db.Headings.Where(x => x.CategoryID == 7).Count();

            //Yazar adında 'a' harfi geçen yazar sayısı
            istatistikler.WriterACount = db.Writers.Where(x => x.WriterName.Contains("a")).Count();

            //En fazla başlığa sahip kategori adı
            var baslikId = db.Headings
                                    .GroupBy(x=>x.CategoryID)
                                    .OrderByDescending(gp => gp.Count())
                                    .Take(1)
                                    .Select(g => g.Key).ToList();
            Category category = db.Categories.Find(baslikId[0]);
            istatistikler.MostHeadingCategory = category.CategoryName;

            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            var trueOlanlar = db.Categories.Where(x => x.CategoryStatus == true).Count();
            var falseOlanlar = db.Categories.Where(x => x.CategoryStatus == false).Count();

            istatistikler.SubCtgStatus = Math.Abs(trueOlanlar - falseOlanlar);

            return View("Istatistik", istatistikler);
        }
    }
}