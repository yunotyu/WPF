namespace MyWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1021 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Token", c => c.String(maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Token");
        }
    }
}
