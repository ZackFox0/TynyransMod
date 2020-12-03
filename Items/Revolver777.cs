using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TynyransMod.Items
{
  public class Revolver777 : ModItem
  {

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault(".777 Revolver");
      Tooltip.SetDefault("\"Hell of a kick!\"");
    }

    public override void SetDefaults()
    {
      item.damage = 205;
      item.width = 46;
      item.height = 24;
      item.rare = 12;
      item.useTime = 75;
      item.useAnimation = 75;
      item.useTurn = false;
      item.useStyle = 5;
      item.scale = 1.0f;
      item.ranged = true;
      item.noMelee = true;
      item.autoReuse = false;
      item.knockBack = 3f;
      item.useAmmo = mod.ItemType("Round777");
      item.shootSpeed = 75f;
      item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/Shot777");
    }


    public override void AddRecipes()
    {
      // Recipes here. See Basic Recipe Guide2
      ModRecipe recipe = new ModRecipe(mod);

      recipe.AddIngredient(ItemID.IceTorch, 1);
      recipe.AddIngredient(ItemID.Switch, 1);
      recipe.AddIngredient(ItemID.CobaltBar, 10);
      recipe.AddIngredient(ItemID.IllegalGunParts, 1);
      recipe.AddTile(TileID.Anvils); //The tile you craft this sword at
      recipe.SetResult(this); //Sets the result of this recipe to this item
      recipe.AddRecipe(); //Adds the recipe to the mod
    }


    /*public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
    {
        Texture2D tex = ModContent.GetTexture("Items/Weapons/MoonCleaver/MoonCleaverGlow"); //loads our glowmask
        spriteBatch.Draw(tex, position, tex.Frame(), Color.White, 0, origin, scale, 0, 0); //draws our glowmask in the inventory. To see how to draw it in the world, see the ModifyDrawLayers method in ExamplePlayer.
    }*/
  }
}