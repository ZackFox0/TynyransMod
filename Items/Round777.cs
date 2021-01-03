using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod.Items
{
  public class Round777 : ModItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault(".777 Round");
      Tooltip.SetDefault("\"Destroys your hand and the enemy alike!\"");
    }

    public override void SetDefaults()
    {
      item.ranged = true;
      item.consumable = true;
      item.width = 12;
      item.height = 32;
      item.rare = 12;
      item.scale = 1.0f;
      item.ammo = AmmoID.Bullet;
      item.maxStack = 99;
      item.shoot = mod.ProjectileType("Shot777");
    }
    public override void AddRecipes()
    {
      // Recipes here. See Basic Recipe Guide2
      ModRecipe recipe = new ModRecipe(mod);

      recipe.AddTile(TileID.Anvils); //The tile you craft this sword at
      recipe.SetResult(this); //Sets the result of this recipe to this item
      recipe.AddRecipe(); //Adds the recipe to the mod
    }
  }
}