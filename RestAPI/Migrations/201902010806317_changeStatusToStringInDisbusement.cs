namespace RestAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStatusToStringInDisbusement : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Disbursement", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Disbursement", "Status", c => c.String(maxLength: 10, unicode: false));
        }
    }
}
