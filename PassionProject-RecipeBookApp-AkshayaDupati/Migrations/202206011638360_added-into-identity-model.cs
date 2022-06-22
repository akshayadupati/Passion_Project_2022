namespace PassionProject_RecipeBookApp_AkshayaDupati.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedintoidentitymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        RecipeIngredientID = c.Int(nullable: false, identity: true),
                        RecipeID = c.Int(nullable: false),
                        IngredientID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeIngredientID)
                .ForeignKey("dbo.Ingredients", t => t.IngredientID, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.RecipeID, cascadeDelete: true)
                .Index(t => t.RecipeID)
                .Index(t => t.IngredientID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "RecipeID", "dbo.Recipes");
            DropForeignKey("dbo.RecipeIngredients", "IngredientID", "dbo.Ingredients");
            DropIndex("dbo.RecipeIngredients", new[] { "IngredientID" });
            DropIndex("dbo.RecipeIngredients", new[] { "RecipeID" });
            DropTable("dbo.RecipeIngredients");
        }
    }
}
