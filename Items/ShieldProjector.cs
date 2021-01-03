using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.Audio;

namespace TynyransMod.Items
{
  public class ShieldProjector : ModItem
  {
    private LegacySoundStyle defaultSound;
    public override string Texture => "Terraria/Item_" + ItemID.SpectreStaff;

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Shield Projector");
      Tooltip.SetDefault("Summon shields to protect you, boosting your defense.\nAlt-fire to summon a large panel shield, blocking non-boss projectiles.");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.SpectreStaff);
      defaultSound = item.UseSound;
    }

    public override bool AltFunctionUse(Player player)
    {
      return true;
    }

    public override bool ConsumeAmmo(Player player)
    {
      return player.altFunctionUse != 2;
    }
    public override bool CanUseItem(Player player)
    {
      if (player.altFunctionUse == 2)
      {
        item.shoot = ProjectileID.None;
        item.UseSound = new LegacySoundStyle(38, 1, Terraria.Audio.SoundType.Sound); // Coin Pickup sound
      }
      else
      {
        item.UseSound = defaultSound;
      }
      return true;
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