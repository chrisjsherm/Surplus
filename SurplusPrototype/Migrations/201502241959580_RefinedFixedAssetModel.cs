namespace SurplusPrototype.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefinedFixedAssetModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.FixedAsset");
            AlterColumn("dbo.FixedAsset", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.FixedAsset", "AssetNumber", c => c.String(nullable: false, maxLength: 9));
            AddPrimaryKey("dbo.FixedAsset", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.FixedAsset");
            AlterColumn("dbo.FixedAsset", "AssetNumber", c => c.String());
            AlterColumn("dbo.FixedAsset", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.FixedAsset", "Id");
        }
    }
}
