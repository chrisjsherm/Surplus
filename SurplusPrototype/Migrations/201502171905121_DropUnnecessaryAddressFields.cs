namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropUnnecessaryAddressFields : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SurplusRequest", "AddressLine1");
            DropColumn("dbo.SurplusRequest", "AddressLine2");
            DropColumn("dbo.SurplusRequest", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SurplusRequest", "City", c => c.String(nullable: false));
            AddColumn("dbo.SurplusRequest", "AddressLine2", c => c.String());
            AddColumn("dbo.SurplusRequest", "AddressLine1", c => c.String(nullable: false));
        }
    }
}
