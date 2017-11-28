namespace Excercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuetionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(nullable: false, maxLength: 4000),
                        Hints = c.String(maxLength: 4000),
                        Answer = c.String(maxLength: 4000),
                        Score = c.Int(nullable: false),
                        Exam_ExamID = c.Int(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.Exam", t => t.Exam_ExamID)
                .Index(t => t.Exam_ExamID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "Exam_ExamID", "dbo.Exam");
            DropIndex("dbo.Question", new[] { "Exam_ExamID" });
            DropTable("dbo.Question");
        }
    }
}
