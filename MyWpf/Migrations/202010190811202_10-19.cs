namespace MyWpf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Store", "ProductName", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Store", "ProductName");
        }
    }
}
