using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using Terraria.Audio;
using TynyransMod.Projectiles;
using Microsoft.Xna.Framework;
using TynyransMod.Buffs;

namespace TynyransMod.Items
{
  public class StalwartDome : ModItem
  {
    public override string Texture => "Terraria/Item_" + ItemID.SquireShield;

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Stalwart's Shield");
      Tooltip.SetDefault("Summons a dome that protects you from enemy projectiles!\nWhen active, drain your health to protect infinitely!");
    }

    public override void SetDefaults()
    {
      item.autoReuse = true;
      item.width = 38;
      item.height = 38;
      item.scale = 1f;
      item.maxStack = 1;
      item.useTime = 1;
      item.useAnimation = 1;
      item.knockBack = 4f;
      item.noMelee = true;
      item.noUseGraphic = true;
      item.useTurn = true;
      item.useStyle = ItemUseStyleID.HoldingOut;
      item.value = Item.sellPrice(1, 0, 0, 0);
      item.rare = ItemRarityID.Orange;
      item.channel = true;
    }

    public override bool UseItem(Player player)
    {
      player.AddBuff(BuffType<StalDome>(), 2);
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

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
      //Making sure the player channels
      player.channel = true;
      //Makes sure original projectile doesn't spawn
      return false;
    }
  }
}