using Excercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Http;

namespace Excercises.Controllers
{
    public class TakeExamController : BaseAuthController
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

            if (exam == null)
            {
                return null;
            }

            return exam;
        }

        UserExam GetUserExam(int? ExamID)
        {
            if (ExamID == null)
            {
                return null;
            }

            //validate if exam is belong to current user
            UserExam userExam = db.UserExams
                        .SingleOrDefault(m => m.Exam.ExamID == ExamID && m.ApplicationUser.Id == UserID);

            if (userExam == null)
            {
                return null;
            }

            return userExam;
        }

        Question GetQuestion(int? ExamID, int? QuestionID)
        {
            if (ExamID == null)
            {
                return null;
            }

            var query = db.Questions
                            .Where(m => m.Exam.ExamID == ExamID);

            if (QuestionID != null)
            {
                query = query.Where(m => m.QuestionID == QuestionID);
            }

            Question question = query
                        .OrderBy(m => m.QuestionID)
                        .FirstOrDefault();

            return question;
        }

        Question GetNextQuestion(int? ExamID, int? QuestionID)
        {
            if (ExamID == null)
            {
                return null;
            }

            var query = db.Questions
                            .Where(m => m.Exam.ExamID == ExamID);

            if (QuestionID != null)
            {
                query = query.Where(m => m.QuestionID > QuestionID);
            }

            Question question = query
                        .OrderBy(m => m.QuestionID)
                        .FirstOrDefault();

            return question;
        }

        QuestionTaken GetQuestionTaken(int? UserExamID, int? QuestionID)
        {
            if (UserExamID == null && QuestionID == null)
            {
                return null;
            }

            return db.QuestionTakens
                            .SingleOrDefault(m => m.UserExam.UserExamID == UserExamID && m.Question.QuestionID == QuestionID);
        }

        // GET: TakeExam
        public ActionResult Index()
        {
            return View();
        }

        // GET: StartQuestion
        public ActionResult StartQuestion(int? ExamID, int? QuestionID)
        {
            //Check if Exam exists?
            Exam exam = GetExam(ExamID);
            if (exam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Check UserExam if current user has taken this exam
            //if not, we will create a UserExam; if yes, get UserExam
            UserExam userExam = GetUserExam(ExamID);
            if (userExam == null)
            {
                DateTime now = DateTime.Now;
                userExam = new UserExam {
                    StartExamDateTime = now,
                    LatestExamDateTime = now,
                    ApplicationUser = ApplicationUser,
                    Exam = exam
                };
                db.UserExams.Add(userExam);
                db.SaveChanges();
            }

            //Check if Question has been taken, if yes, we will load MyAnswer
            Question question = GetQuestion(ExamID, QuestionID);

            if (question == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            QuestionTaken questionTaken = GetQuestionTaken(userExam.UserExamID, question.QuestionID);

            TakeExamViewModels takeExamViewModels = new TakeExamViewModels
            {
                exam = exam,
                userExam = userExam,
                question = question,
                questionTaken = questionTaken
            };

            return View(takeExamViewModels);
        }

        // POST: TakeExam/SubmitAnswer
        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitAnswer([FromBody] int? ExamID, [FromBody] int? QuestionID, [FromBody] string MyAnswer)
        {
            if (ModelState.IsValid)
            {
                Exam exam = GetExam(ExamID);
                if (exam == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                //Check if Question has been taken, if yes, we will load MyAnswer
                Question question = GetQuestion(ExamID, QuestionID);

                if (question == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                UserExam userExam = GetUserExam(ExamID);
                if (userExam == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                QuestionTaken questionTaken = GetQuestionTaken(userExam.UserExamID, QuestionID);
                if (questionTaken == null)
                {
                    questionTaken = new QuestionTaken
                    {
                        MyAnswer = MyAnswer,
                        UserExam = userExam,
                        Question = question
                    };
                    db.QuestionTakens.Add(questionTaken);
                }
                else
                {
                    questionTaken.MyAnswer = MyAnswer;
                }

                userExam.LatestExamDateTime = DateTime.Now;
                db.SaveChanges();

                //find next question
                Question nextQuestion = GetNextQuestion(ExamID, QuestionID);

                if (nextQuestion == null) {
                    return RedirectToAction("TakeExamDone");
                }
                else
                {
                    return RedirectToAction("StartQuestion", new { ExamID = ExamID, QuestionID = nextQuestion.QuestionID });
                }
            }

            return RedirectToAction("StartQuestion", new { ExamID = ExamID, QuestionID = QuestionID });
        }


        // GET: TakeExamDone
        public ActionResult TakeExamDone()
        {
            return View();
        }

    }
}