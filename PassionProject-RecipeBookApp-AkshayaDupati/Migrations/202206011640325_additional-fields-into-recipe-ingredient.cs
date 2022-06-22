namespace PassionProject_RecipeBookApp_AkshayaDupati.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class additionalfieldsintorecipeingredient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeIngredients", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.RecipeIngredients", "Unit", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecipeIngredients", "Unit");
            DropColumn("dbo.RecipeIngredients", "Quantity");
        }
    }
}
