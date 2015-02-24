namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedAssetId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FixedAsset");
            AlterColumn("dbo.FixedAsset", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FixedAsset", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FixedAsset");
            AlterColumn("dbo.FixedAsset", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.FixedAsset", "Id");
        }
    }
}
