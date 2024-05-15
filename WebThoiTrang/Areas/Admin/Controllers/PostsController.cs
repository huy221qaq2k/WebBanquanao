using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;

namespace WebThoiTrang.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var items = db.Posts.ToList();
            return View(items);
        }

        public ActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Add(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.CategoryID = 7;
                model.ModifierdDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Tilte);
                db.Posts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.Posts.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Posts model)
        {
            if (ModelState.IsValid)
            {
                model.ModifierdDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Tilte);
                db.Posts.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Posts.Find(id);
            if (item != null)
            {
                db.Posts.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Posts.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isActive = item.IsActive });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult deleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                foreach (var item in items)
                {
                    var obj = db.Posts.Find(Convert.ToInt32(item));
                    if (obj != null)
                    {
                        db.Posts.Remove(obj);
                    }
                }

                // Gọi SaveChanges() ở cuối để lưu tất cả các thay đổi
                db.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

    }
}