using Microsoft.AspNetCore.Mvc;

namespace webAccFroshHamkar.Controllers
{
    public class Seller : Controller
    {
        public IActionResult Index()
        {


            webDb.dbContext db = new webDb.dbContext();
            var x = db.tblSeller.ToList();
            return View(x);

        }
        public IActionResult Create(Guid? id)
        {
            webDb.dbContext db = new webDb.dbContext();
            var x = db.tblSeller.SingleOrDefault(a => a.Id == id);
            if (x == null) x = new webDb.tblSeller();
            return View(x);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(webDb.tblSeller model)
        {


            if (ModelState.IsValid)
            {
                webDb.dbContext db = new webDb.dbContext();
                var x = db.tblSeller.SingleOrDefault(a => a.Id == model.Id);
                if (x == null)
                {
                    x = new webDb.tblSeller()
                    {
                        Id = Guid.NewGuid()
                    };
                    db.tblSeller.Add(x);


                }
                x.Title = model.Title;
                x.Darsad = model.Darsad;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(Guid id)
        {
            webDb.dbContext db = new webDb.dbContext();
            var x = db.tblSeller.Find(id);
            if (db.tblSales.Any(a => a.tblSellerId == id) == false)
            {
                db.tblSeller.Remove(x);
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
    }
}
