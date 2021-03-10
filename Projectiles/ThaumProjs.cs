using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace TynyransMod.Projectiles
{
  public class ThaumaturgeFire : ModProjectile
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Thaumaturge Fire");
    }

    public override void SetDefaults()
    {
      projectile.friendly = true;
      projectile.width = 24;
      projectile.height = 24;
      projectile.tileCollide = true;
      projectile.ignoreWater = true;
      projectile.timeLeft = 180;
      projectile.penetrate = 1;
      projectile.scale = 1f;
      projectile.damage = 150;
    }
    public override void AI()
    {
      _ = Dust.NewDust(projectile.position, 6, 6, DustID.Fire, default, default, 90);
    }
  }
  public class ThaumaturgeIce : ModProjectile
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Thaumaturge Ice");
    }

    public override void SetDefaults()
    {
      projectile.friendly = true;
      projectile.width = 24;
      projectile.height = 24;
      projectile.tileCollide = true;
      projectile.ignoreWater = true;
      projectile.timeLeft = 180;
      projectile.penetrate = 1;
      projectile.scale = 1f;
      projectile.damage = 150;
    }
    public override void AI()
    {
      _ = Dust.NewDust(projectile.position, 6, 6, DustID.Ice, default, default, 90);
    }
  }
}