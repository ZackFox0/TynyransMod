using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Projectiles
{
  public abstract class Note : ModProjectile
  {
    public Vector2[] posQueue = new Vector2[60];
    public int noteType = -1;
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Musical Note");
    }

    public override void SetDefaults()
    {
      projectile.friendly = true;
      projectile.tileCollide = false;
      projectile.ignoreWater = true;
      projectile.scale = 1f;
      projectile.Tyn().note = true;
      projectile.minion = true;
    }

    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) => false;
    public override void AI()
    {
      Player player = Main.player[projectile.owner];
      posQueue[0] = player.position;
      projectile.position = posQueue[59];
    }
    public override void PostAI()
    {
      for (int i = 59; i >= 0; i--)
      {
        if (i != 0) posQueue[i] = posQueue[i - 1];
      }
    }
  }
}