using Microsoft.AspNetCore.Mvc;
using System;

namespace webAccFroshHamkar.Controllers
{
    public class Sales : Controller
    {
        public IActionResult Index(Guid idSeler)
        {
            ViewBag.idSeler = idSeler;
            webDb.dbContext db = new webDb.dbContext();

            var x = db.tblSales.Where(a => a.tblSellerId == idSeler).OrderByDescending(a => a.Time).ToList();

            return View(x);
        }

        public IActionResult Create(Guid? id, Guid idSeler)
        {
            webDb.dbContext db = new webDb.dbContext();
            var x = db.tblSales.SingleOrDefault(a => a.Id == id);



            if (x == null)
            {


                var s = db.tblSeller.Find(idSeler);
                x = new webDb.tblSales() { tblSellerId = idSeler, Darsad = s.Darsad, Time = DateTime.Now };
            }
            return View(x);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(webDb.tblSales model)
        {


            if (ModelState.IsValid)
            {
                webDb.dbContext db = new webDb.dbContext();
                var x = db.tblSales.SingleOrDefault(a => a.Id == model.Id);
                if (x == null)
                {
                    x = new webDb.tblSales()
                    {
                        Id = Guid.NewGuid(),
                        tblSellerId = model.tblSellerId
                    };
                    db.tblSales.Add(x);

                }


                x.Time = model.Time;
                x.Des = model.Des;



                if (model.MabFrosh > 0)
                {

                    x.MabFrosh = model.MabFrosh;
                    x.MabH = model.MabH;
                    // decimal? mabHashie = model.MabHashie;
                    x.Darsad = model.Darsad;


                    x.Bed = (model.MabHashie) * ((decimal)(100 - x.Darsad ?? 0)) / 100;
                }
                else
                {

                    x.Bes = model.Bes;
                }

                //x.Mande = model.Mande;

                db.SaveChanges();



                refreshSales(x.tblSellerId);

                 


                return RedirectToAction("Index", new { idSeler = x.tblSellerId });

            }
            return View(model);
        }



        private void refreshSales(Guid idSeler)
        {
            webDb.dbContext db = new webDb.dbContext();


            var x = 0m;
            foreach (var item in db.tblSales.Where(a => a.tblSellerId == idSeler).OrderBy(a => a.Time))
            {
                x = x + item.Bed.GetValueOrDefault() - item.Bes.GetValueOrDefault();

                item.Mande = x;
            }


            db.SaveChanges();


        }
        public IActionResult Delete(Guid id)
        {
            webDb.dbContext db = new webDb.dbContext();
            var x = db.tblSales.Find(id);
            db.tblSales.Remove(x);
            db.SaveChanges();
            refreshSales(x.tblSellerId);
            return RedirectToAction("Index", new { idSeler = x.tblSellerId });

        }






    }








}
