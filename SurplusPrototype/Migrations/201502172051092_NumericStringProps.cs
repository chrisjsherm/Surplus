namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumericStringProps : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SurplusRequest", "DepartmentNumber", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SurplusRequest", "DepartmentNumber", c => c.String(nullable: false));
        }
    }
}
