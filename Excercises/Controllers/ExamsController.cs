using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excercises.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Excercises.Controllers
{
    public class ExamsController : BaseAuthController
    {

        // GET: Exams
        public ActionResult Index(string SearchText)
        {
            var query = db.Exams.Where(m => m.ApplicationUser.Id == UserID);

            if (SearchText != null && SearchText.Length > 0)
            {
                query = query.Where(m => m.Name.Contains(SearchText) || m.Description.Contains(SearchText));
            }

            IEnumerable<Exam> exams = query.ToList();

            return View(exams);
        }

        // GET: Exams
        [AllowAnonymous]
        public ActionResult Public(string SearchText)
        {
            var query = db.Exams.Select(m => new ExamViewModel { ExamID = m.ExamID, Name = m.Name, Description = m.Description, Owner = m.ApplicationUser.NickName } );

            if (SearchText != null && SearchText.Length > 0)
            {
                query = query.Where(m => m.Name.Contains(SearchText) || m.Description.Contains(SearchText));
            }

            IEnumerable<ExamViewModel> exams = query
                                    .Take(100)
                                    .OrderByDescending(m => m.ExamID)
                                    .ToList();

            return View(exams);
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null || exam.ApplicationUser.Id != UserID)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamID,Name,Description")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                exam.ApplicationUser = ApplicationUser;
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null || exam.ApplicationUser.Id != UserID)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamID,Name,Description")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                Exam currentExam = db.Exams.Find(exam.ExamID);

                if (currentExam == null || currentExam.ApplicationUser.Id != UserID)
                {
                    return HttpNotFound();
                }

                currentExam.Name = exam.Name;
                currentExam.Description = exam.Description;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null || exam.ApplicationUser.Id != UserID)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            if (exam == null || exam.ApplicationUser.Id != UserID)
            {
                return HttpNotFound();
            }

            db.Exams.Remove(exam);
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
