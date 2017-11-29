using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Excercises.Models;

namespace Excercises.Controllers
{
    public class QuestionsController : BaseAuthController
    {
        Exam GetExam(int? ExamID)
        {
            if (ExamID == null)
            {
                return null;
            }

            //validate if exam is belong to current user
            Exam exam = db.Exams
                        .Find(ExamID);

            if (exam == null || exam.ApplicationUser.Id != UserID)
            {
                return null;
            }

            return exam;
        }
        // GET: Questions
        public ActionResult Index(int? ExamID)
        {
            //validate if exam is belong to current user
            Exam exam = GetExam(ExamID);

            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Get all questions belong to this user
            IEnumerable<Question> questions = db.Questions
                            .Where(m => m.Exam.ApplicationUser.Id == UserID)
                            .Where(m => m.Exam.ExamID == ExamID)
                            .ToList();

            //to view
            ViewBag.ExamID = exam.ExamID;
            ViewBag.ExamName = exam.Name;

            return View(questions);
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id, int? ExamID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //validate if exam is belong to current user
            Exam exam = GetExam(ExamID);

            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = db.Questions.Find(id);
            if (question == null || question.Exam.ExamID != ExamID)
            {
                return HttpNotFound();
            }

            ViewBag.ExamID = ExamID;

            return View(question);
        }

        // GET: Questions/Create
        public ActionResult Create(int? ExamID)
        {
            //validate if exam is belong to current user
            Exam exam = GetExam(ExamID);

            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.ExamID = ExamID;
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int? ExamID, [Bind(Include = "QuestionID,QuestionText,Hints,Answer,Score")] Question question)
        {
            if (ModelState.IsValid)
            {
                //validate if exam is belong to current user
                Exam exam = GetExam(ExamID);

                if (exam == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                question.Exam = exam;
                db.Questions.Add(question);
                db.SaveChanges();
                return RedirectToAction("Index", new { ExamID = ExamID });
            }

            return View(question);
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int? id, int? ExamID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //validate if exam is belong to current user
            Exam exam = GetExam(ExamID);

            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = db.Questions.Find(id);
            if (question == null || question.Exam.ExamID != ExamID)
            {
                return HttpNotFound();
            }

            ViewBag.ExamID = ExamID;
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? ExamID, [Bind(Include = "QuestionID,QuestionText,Hints,Answer,Score")] Question question)
        {
            if (ModelState.IsValid)
            {
                //validate if exam is belong to current user
                Exam exam = GetExam(ExamID);

                if (exam == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Question currentQuestion = db.Questions.Find(question.QuestionID);
                if (question == null || currentQuestion == null || currentQuestion.Exam.ExamID != ExamID)
                {
                    return HttpNotFound();
                }
                currentQuestion.QuestionText = question.QuestionText;
                currentQuestion.Hints = question.Hints;
                currentQuestion.Answer = question.Answer;
                currentQuestion.Score = question.Score;

                db.SaveChanges();
                return RedirectToAction("Index", new { ExamID = ExamID });
            }

            return View(question);
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int? id, int? ExamID)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //validate if exam is belong to current user
            Exam exam = GetExam(ExamID);

            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = db.Questions.Find(id);
            if (question == null || question.Exam.ExamID != ExamID)
            {
                return HttpNotFound();
            }

            ViewBag.ExamID = ExamID;
            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? ExamID, int id)
        {
            //validate if exam is belong to current user
            Exam exam = GetExam(ExamID);

            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Question question = db.Questions.Find(id);
            if (question == null || question.Exam.ExamID != ExamID)
            {
                return HttpNotFound();
            }

            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index", new { ExamID = ExamID });
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
