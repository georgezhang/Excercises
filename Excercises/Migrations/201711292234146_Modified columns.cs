namespace Excercises.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifiedcolumns : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.QuestionTaken", "MyAnswer", c => c.String(maxLength: 4000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.QuestionTaken", "MyAnswer", c => c.String());
        }
    }
}
