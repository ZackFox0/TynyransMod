using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod.Items
{
  public class ScrollWaterBolt : Scroll
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Water Bolt Scroll");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.WaterBolt);
      base.SetDefaults();
      item.damage = (int)(item.damage * 1.25);
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
      Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(5));
      Projectile.NewProjectile(position, perturbedSpeed, item.shoot, damage, knockBack, player.whoAmI);
      return true;
    }
  }
}