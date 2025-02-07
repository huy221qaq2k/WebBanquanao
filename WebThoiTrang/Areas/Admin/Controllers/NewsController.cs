﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebThoiTrang.Models;
using WebThoiTrang.Models.EF;

namespace WebThoiTrang.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index(string SearchText,int? page)
        {
            var pageSize = 10;
            if(page == null)
            {
                page = 1;

            }

            IEnumerable<News> items = db.News.OrderByDescending(x => x.Id);
            if (!string.IsNullOrEmpty(SearchText))
            {
               items = items.Where(x => x.Alias.Equals(SearchText) || x.Tilte1.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page): 1 ;
             items = items.ToPagedList(pageIndex,pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {

            return  View();
        }
        [HttpPost]
        public ActionResult Add(News model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.CategoryID = 7;
                model.ModifierdDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Tilte1);
                db.News.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                model.ModifierdDate = DateTime.Now;
                model.Alias = WebThoiTrang.Models.Common.Filter.FilterChar(model.Tilte1);
                db.News.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.News.Find(id);
            if(item != null)
            {
                db.News.Remove(item); 
                db.SaveChanges();
                return Json(new {success = true});
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.News.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true , isActive = item.IsActive });
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
                    var obj = db.News.Find(Convert.ToInt32(item));
                    if (obj != null)
                    {
                        db.News.Remove(obj);
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