using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

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
    }


    public override void AddRecipes()
    {
      // Recipes here. See Basic Recipe Guide2
      ModRecipe recipe = new ModRecipe(mod);

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