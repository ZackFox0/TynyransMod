using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
using static TynyransMod.TynUtils;

namespace TynyransMod.Projectiles
{
  public class ProjectorShield : ModProjectile
  {
    private const float radius = 100f;
    private float startingR = 0f;
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Projector Shield");
    }

    public override void SetDefaults()
    {
      projectile.friendly = true;
      projectile.width = 30;
      projectile.height = 28;
      projectile.aiStyle = 0;
      projectile.tileCollide = true;
      projectile.ignoreWater = true;
      projectile.penetrate = 5;
      projectile.scale = 1f;
      projectile.damage = 0;
      projectile.sentry = true;
    }
    private void CreateShieldField()
    {
      for (float rotation = startingR; rotation < 360f + startingR; rotation += 45f)
      {
        Vector2 spawnPosition = projectile.Center + new Vector2(0f, radius).RotatedBy(rotation.InRadians());
        Dust d = Dust.NewDustPerfect(spawnPosition, 16, new Vector2(0f, 0f), 90, new Color(255, 255, 255), 1f);
        d.noLight = true;
        d.noGravity = true;
      }
    }
    public override void AI()
    {
      CreateShieldField();
      startingR = startingR + 2 >= 360f ? 0 : startingR + 2;

      if (GrabProjCount(projectile.type) > 1)
        Main.player[projectile.owner].WipeOldestTurret();

      foreach (Projectile proj in Main.projectile)
      {
        if (proj.active && proj.hostile && proj.IsInRadius(projectile.position, radius))
        {
          for (int i = 0; i < 10; i++)
            _ = Dust.NewDust(proj.position, 3, 3, 16, -proj.velocity.X, -proj.velocity.Y, 90, new Color(255,255,255), 1f);
          proj.active = false;
          projectile.penetrate--;
        }
      }
    }

    public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
    {
      return false;
    }
  }
}