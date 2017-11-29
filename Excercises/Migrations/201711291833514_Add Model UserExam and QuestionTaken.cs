namespace Excercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelUserExamandQuestionTaken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserExam",
                c => new
                    {
                        UserExamID = c.Int(nullable: false, identity: true),
                        StartExamDateTime = c.DateTime(nullable: false),
                        LatestExamDateTime = c.DateTime(nullable: false),
                        FinalScore = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        Exam_ExamID = c.Int(),
                    })
                .PrimaryKey(t => t.UserExamID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Exam", t => t.Exam_ExamID)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Exam_ExamID);
            
            CreateTable(
                "dbo.QuestionTaken",
                c => new
                    {
                        QuestionTakenID = c.Int(nullable: false, identity: true),
                        MyAnswer = c.String(),
                        Question_QuestionID = c.Int(),
                        UserExam_UserExamID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionTakenID)
                .ForeignKey("dbo.Question", t => t.Question_QuestionID)
                .ForeignKey("dbo.UserExam", t => t.UserExam_UserExamID)
                .Index(t => t.Question_QuestionID)
                .Index(t => t.UserExam_UserExamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuestionTaken", "UserExam_UserExamID", "dbo.UserExam");
            DropForeignKey("dbo.QuestionTaken", "Question_QuestionID", "dbo.Question");
            DropForeignKey("dbo.UserExam", "Exam_ExamID", "dbo.Exam");
            DropForeignKey("dbo.UserExam", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.QuestionTaken", new[] { "UserExam_UserExamID" });
            DropIndex("dbo.QuestionTaken", new[] { "Question_QuestionID" });
            DropIndex("dbo.UserExam", new[] { "Exam_ExamID" });
            DropIndex("dbo.UserExam", new[] { "ApplicationUser_Id" });
            DropTable("dbo.QuestionTaken");
            DropTable("dbo.UserExam");
        }
    }
}
