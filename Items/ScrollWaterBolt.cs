using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TynyransMod.Projectiles;

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
      item.shoot = ProjectileType<DrillingWaterBolt>();
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
      Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(5f.InRadians());
      speedX = perturbedSpeed.X;
      speedY = perturbedSpeed.Y;
      return true;
    }
  }
}