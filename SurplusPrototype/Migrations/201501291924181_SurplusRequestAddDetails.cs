namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SurplusRequestAddDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SurplusRequest", "AddressLine1", c => c.String(nullable: false));
            AddColumn("dbo.SurplusRequest", "AddressLine2", c => c.String());
            AddColumn("dbo.SurplusRequest", "Building", c => c.String(nullable: false));
            AddColumn("dbo.SurplusRequest", "FloorLevel", c => c.String(nullable: false));
            AddColumn("dbo.SurplusRequest", "City", c => c.String(nullable: false));
            AlterColumn("dbo.SurplusRequest", "VTBarcode", c => c.String(nullable: false, maxLength: 9));
            AlterColumn("dbo.SurplusRequest", "ContactPhone", c => c.String(nullable: false, maxLength: 10));
            DropColumn("dbo.SurplusRequest", "ItemLocation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurplusRequest", "ItemLocation", c => c.String(nullable: false));
            AlterColumn("dbo.SurplusRequest", "ContactPhone", c => c.String(nullable: false));
            AlterColumn("dbo.SurplusRequest", "VTBarcode", c => c.String(maxLength: 8));
            DropColumn("dbo.SurplusRequest", "City");
            DropColumn("dbo.SurplusRequest", "FloorLevel");
            DropColumn("dbo.SurplusRequest", "Building");
            DropColumn("dbo.SurplusRequest", "AddressLine2");
            DropColumn("dbo.SurplusRequest", "AddressLine1");
        }
    }
}
