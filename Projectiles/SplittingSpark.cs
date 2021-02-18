using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TynyransMod.Projectiles
{
  public class SplittingSpark : ModProjectile
  {
    public override string Texture => "Terraria/Projectile_" + ProjectileID.Spark;
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Splitting Spark");
    }

    public override void SetDefaults()
    {
      projectile.CloneDefaults(ProjectileID.Spark);
      projectile.penetrate = -1;
      projectile.hide = false;
      aiType = ProjectileID.Spark;
    }
    public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
    {
      for (float rotation = 0f; rotation <= 360f; rotation += 45f)
      {
        Vector2 perturbedSpeed = new Vector2(0, 10f).RotatedBy(rotation.InRadians());
        Projectile.NewProjectile(target.position, perturbedSpeed, ProjectileID.Spark, damage, knockBack, projectile.owner);
      }
    }
    public override void Kill(int timeLeft)
    {
      Main.PlaySound(SoundID.DD2_BetsyFireballShot, projectile.position);
      for (float rotation = 0f; rotation <= 360f; rotation += 45f)
      {
        Vector2 perturbedSpeed = new Vector2(0, 10f).RotatedBy(rotation.InRadians());
        Projectile.NewProjectile(projectile.position, perturbedSpeed, ProjectileID.Spark, projectile.damage, projectile.knockBack, projectile.owner);
      }
    }
  }
}