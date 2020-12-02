using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wedrowki.Models;

namespace Wedrowki.Controllers
{
    public class WedrowkaController : Controller
    {
        private WedrowkiDB db = new WedrowkiDB();

        // GET: Wedrowka
        public ActionResult Index()
        {
            return View(db.Piesze_Wedrowki.ToList());
        }

        // GET: Wedrowka/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WedrowkaModel wedrowkaModel = db.Piesze_Wedrowki.Find(id);
            if (wedrowkaModel == null)
            {
                return HttpNotFound();
            }
            return View(wedrowkaModel);
        }

        // GET: Wedrowka/Create
        public ActionResult Create()
        {

            Int16 idW;

            if (!db.Piesze_Wedrowki.Any())
            {
                idW = 0;
            }
            else
            {
                idW = db.Piesze_Wedrowki.OrderByDescending(w => w.IdWedrowki).FirstOrDefault().IdWedrowki;
            }

            idW += 1;
            ViewBag.idW = idW;
            WedrowkaModel wedrowkaModel = new WedrowkaModel();
            wedrowkaModel.IdWedrowki = idW;
            return View(wedrowkaModel);
        }

        // POST: Wedrowka/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WedrowkaModel wedrowkaModel)
        {

            if (ModelState.IsValid)
            {
                int liczba_zdjec = 0;

                if (wedrowkaModel.Zdjecie1 != null)
                {
                    liczba_zdjec++;
                    string z1 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie1.FileName);
                    string r1 = Path.GetExtension(wedrowkaModel.Zdjecie1.FileName);
                    z1 = wedrowkaModel.IdWedrowki.ToString() + "_z" + r1;
                    wedrowkaModel.Zdj1 = "~/Images/" + z1;
                    z1 = Path.Combine(Server.MapPath("~/Images/"), z1);
                    wedrowkaModel.Zdjecie1.SaveAs(z1);
                }

                if (wedrowkaModel.Zdjecie2 != null)
                {
                    liczba_zdjec++;
                    string z2 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie2.FileName);
                    string r2 = Path.GetExtension(wedrowkaModel.Zdjecie2.FileName);
                    z2 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r2;
                    wedrowkaModel.Zdj2 = "~/Images/" + z2;
                    z2 = Path.Combine(Server.MapPath("~/Images/"), z2);
                    wedrowkaModel.Zdjecie2.SaveAs(z2);
                }

                if (wedrowkaModel.Zdjecie3 != null)
                {
                    liczba_zdjec++;
                    string z3 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie3.FileName);
                    string r3 = Path.GetExtension(wedrowkaModel.Zdjecie3.FileName);
                    z3 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r3;
                    wedrowkaModel.Zdj3 = "~/Images/" + z3;
                    z3 = Path.Combine(Server.MapPath("~/Images/"), z3);
                    wedrowkaModel.Zdjecie3.SaveAs(z3);
                }

                if (wedrowkaModel.Zdjecie4 != null)
                {
                    liczba_zdjec++;
                    string z4 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie4.FileName);
                    string r4 = Path.GetExtension(wedrowkaModel.Zdjecie4.FileName);
                    z4 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r4;
                    wedrowkaModel.Zdj4 = "~/Images/" + z4;
                    z4 = Path.Combine(Server.MapPath("~/Images/"), z4);
                    wedrowkaModel.Zdjecie4.SaveAs(z4);
                }

                if (wedrowkaModel.Zdjecie5 != null)
                {
                    liczba_zdjec++;
                    string z5 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie5.FileName);
                    string r5 = Path.GetExtension(wedrowkaModel.Zdjecie5.FileName);
                    z5 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r5;
                    wedrowkaModel.Zdj5 = "~/Images/" + z5;
                    z5 = Path.Combine(Server.MapPath("~/Images/"), z5);
                    wedrowkaModel.Zdjecie5.SaveAs(z5);
                }

                if (wedrowkaModel.Zdjecie6 != null)
                {
                    liczba_zdjec++;
                    string z6 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie6.FileName);
                    string r6 = Path.GetExtension(wedrowkaModel.Zdjecie6.FileName);
                    z6 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r6;
                    wedrowkaModel.Zdj6 = "~/Images/" + z6;
                    z6 = Path.Combine(Server.MapPath("~/Images/"), z6);
                    wedrowkaModel.Zdjecie6.SaveAs(z6);
                }

                if (wedrowkaModel.Fil1 != null)
                {
                    string f1 = Path.GetFileNameWithoutExtension(wedrowkaModel.Fil1.FileName);
                    string r1 = Path.GetExtension(wedrowkaModel.Fil1.FileName);
                    f1 = wedrowkaModel.IdWedrowki.ToString() + "_f" + r1;
                    wedrowkaModel.Film1 = "~/Images/" + f1;
                    f1 = Path.Combine(Server.MapPath("~/Images/"), f1);
                    wedrowkaModel.Fil1.SaveAs(f1);
                }

                db.Piesze_Wedrowki.Add(wedrowkaModel);
                db.SaveChangesAsync();
                liczba_zdjec = 0;
                return RedirectToAction("Index");
            }

            return View(wedrowkaModel);
        }

        // GET: Wedrowka/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WedrowkaModel wedrowkaModel = db.Piesze_Wedrowki.Find(id);
            if (wedrowkaModel == null)
            {
                return HttpNotFound();
            }
            return View(wedrowkaModel);
        }

        // POST: Wedrowka/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(WedrowkaModel wedrowkaModel)
        {
            if (ModelState.IsValid)
            {
                int liczba_zdjec = 0;

                if (wedrowkaModel.Zdjecie1 != null)
                {
                    if (wedrowkaModel.Zdj1 != null) { 
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj1));
                        System.IO.File.Delete(path);
                    }

                    liczba_zdjec++;
                    string z1 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie1.FileName);
                    string r1 = Path.GetExtension(wedrowkaModel.Zdjecie1.FileName);
                    z1 = wedrowkaModel.IdWedrowki.ToString() + "_z" + r1;
                    wedrowkaModel.Zdj1 = "~/Images/" + z1;
                    z1 = Path.Combine(Server.MapPath("~/Images/"), z1);
                    wedrowkaModel.Zdjecie1.SaveAs(z1);
                }

                if (wedrowkaModel.Zdjecie2 != null)
                {
                    if (wedrowkaModel.Zdj2 != null)
                    {
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj2));
                        System.IO.File.Delete(path);
                    }

                    liczba_zdjec++;
                    string z2 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie2.FileName);
                    string r2 = Path.GetExtension(wedrowkaModel.Zdjecie2.FileName);
                    z2 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r2;
                    wedrowkaModel.Zdj2 = "~/Images/" + z2;
                    z2 = Path.Combine(Server.MapPath("~/Images/"), z2);
                    wedrowkaModel.Zdjecie2.SaveAs(z2);
                }

                if (wedrowkaModel.Zdjecie3 != null)
                {
                    if (wedrowkaModel.Zdj3 != null)
                    {
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj3));
                        System.IO.File.Delete(path);
                    }

                    liczba_zdjec++;
                    string z3 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie3.FileName);
                    string r3 = Path.GetExtension(wedrowkaModel.Zdjecie3.FileName);
                    z3 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r3;
                    wedrowkaModel.Zdj3 = "~/Images/" + z3;
                    z3 = Path.Combine(Server.MapPath("~/Images/"), z3);
                    wedrowkaModel.Zdjecie3.SaveAs(z3);
                }

                if (wedrowkaModel.Zdjecie4 != null)
                {
                    if (wedrowkaModel.Zdj4 != null)
                    {
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj4));
                        System.IO.File.Delete(path);
                    }

                    liczba_zdjec++;
                    string z4 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie4.FileName);
                    string r4 = Path.GetExtension(wedrowkaModel.Zdjecie4.FileName);
                    z4 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r4;
                    wedrowkaModel.Zdj4 = "~/Images/" + z4;
                    z4 = Path.Combine(Server.MapPath("~/Images/"), z4);
                    wedrowkaModel.Zdjecie4.SaveAs(z4);
                }

                if (wedrowkaModel.Zdjecie5 != null)
                {
                    if (wedrowkaModel.Zdj5 != null)
                    {
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj5));
                        System.IO.File.Delete(path);
                    }

                    liczba_zdjec++;
                    string z5 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie5.FileName);
                    string r5 = Path.GetExtension(wedrowkaModel.Zdjecie5.FileName);
                    z5 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r5;
                    wedrowkaModel.Zdj5 = "~/Images/" + z5;
                    z5 = Path.Combine(Server.MapPath("~/Images/"), z5);
                    wedrowkaModel.Zdjecie5.SaveAs(z5);
                }

                if (wedrowkaModel.Zdjecie6 != null)
                {
                    if (wedrowkaModel.Zdj6 != null)
                    {
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj6));
                        System.IO.File.Delete(path);
                    }

                    liczba_zdjec++;
                    string z6 = Path.GetFileNameWithoutExtension(wedrowkaModel.Zdjecie6.FileName);
                    string r6 = Path.GetExtension(wedrowkaModel.Zdjecie6.FileName);
                    z6 = wedrowkaModel.IdWedrowki.ToString() + "_z" + liczba_zdjec + r6;
                    wedrowkaModel.Zdj6 = "~/Images/" + z6;
                    z6 = Path.Combine(Server.MapPath("~/Images/"), z6);
                    wedrowkaModel.Zdjecie6.SaveAs(z6);
                }

                if (wedrowkaModel.Fil1 != null)
                {
                    if (wedrowkaModel.Film1 != null)
                    {
                        string path = Path.Combine(Server.MapPath(wedrowkaModel.Film1));
                        System.IO.File.Delete(path);
                    } 

                    string f1 = Path.GetFileNameWithoutExtension(wedrowkaModel.Fil1.FileName);
                    string r1 = Path.GetExtension(wedrowkaModel.Fil1.FileName);
                    f1 = wedrowkaModel.IdWedrowki.ToString() + "_f" + r1;
                    wedrowkaModel.Film1 = "~/Images/" + f1;
                    f1 = Path.Combine(Server.MapPath("~/Images/"), f1);
                    wedrowkaModel.Fil1.SaveAs(f1);
                }

                db.Entry(wedrowkaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wedrowkaModel);
        }

        // GET: Wedrowka/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WedrowkaModel wedrowkaModel = db.Piesze_Wedrowki.Find(id);
            if (wedrowkaModel == null)
            {
                return HttpNotFound();
            }
            return View(wedrowkaModel);
        }

        // POST: Wedrowka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WedrowkaModel wedrowkaModel = db.Piesze_Wedrowki.Find(id);
            

            if (wedrowkaModel.Zdj1 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj1));
                System.IO.File.Delete(path);
            }

            if (wedrowkaModel.Zdj2 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj2));
                System.IO.File.Delete(path);
            }

            if (wedrowkaModel.Zdj3 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj3));
                System.IO.File.Delete(path);
            }

            if (wedrowkaModel.Zdj4 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj4));
                System.IO.File.Delete(path);
            }

            if (wedrowkaModel.Zdj5 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj5));
                System.IO.File.Delete(path);
            }

            if (wedrowkaModel.Zdj6 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Zdj6));
                System.IO.File.Delete(path);
            }

            if (wedrowkaModel.Film1 != null)
            {
                string path = Path.Combine(Server.MapPath(wedrowkaModel.Film1));
                System.IO.File.Delete(path);
            }

            db.Piesze_Wedrowki.Remove(wedrowkaModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
