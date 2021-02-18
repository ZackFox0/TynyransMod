using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using TynyransMod.Projectiles;

namespace TynyransMod.Items
{
  public class ScrollSparkingUpgrade : Scroll
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sparking Scroll (Upgrade)");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.WandofSparking);
      base.SetDefaults();
      item.damage = (int)(item.damage * 1.25);
      item.shoot = ProjectileType<SplittingSpark>();
      item.autoReuse = true;
      item.useTime = 15;
      item.useAnimation = 20;
      item.maxStack = 1;
      item.mana = 5;
      item.consumable = false;
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
      for (int i = 0; i < 5; i++)
      {
        Vector2 pS = new Vector2(speedX, speedY).RotatedByRandom(10f);
        _ = Projectile.NewProjectile(position, pS, type, damage, knockBack, player.whoAmI);
      }
      return false;
    }
  }
}