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
      _ = Dust.NewDust(projectile.position, 6, 6, DustID.Fire, default, default, 90);
      _ = Dust.NewDust(projectile.position, 6, 6, DustID.Fire, default, default, 90);
    }
    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
      for (float rotation = 0f; rotation < 360f; rotation += 8f)
      {
        Dust d = Dust.NewDustPerfect(projectile.position, DustID.Fire, new Vector2(0f, 10f).RotatedBy(rotation.InRadians()), 90, new Color(255, 255, 255), 1f);
        d.noGravity = true;
      }
      foreach (NPC npc in Main.npc)
      {
        if (npc.active && !npc.friendly && !npc.townNPC && !npc.Equals(target) && npc.IsInRadius(projectile.position, 75f))
        {
          float angle = projectile.AngleTo(npc.position);
          npc.StrikeNPC(damage, knockback, angle >= 180f.InRadians() ? -1 : 1, crit);
        }
      }
    }
    public override bool OnTileCollide(Vector2 oldVelocity)
    {
      for (float rotation = 0f; rotation < 360f; rotation += 8f)
      {
        Dust d = Dust.NewDustPerfect(projectile.position, DustID.Fire, new Vector2(0f, 10f).RotatedBy(rotation.InRadians()), 180, new Color(255, 255, 255), 1.5f);
        d.noGravity = true;
      }
      foreach (NPC npc in Main.npc)
      {
        if (npc.active && !npc.friendly && !npc.townNPC && npc.IsInRadius(projectile.position, 50f))
        {
          float angle = projectile.AngleTo(npc.position);
          npc.StrikeNPC(projectile.damage, projectile.knockBack, angle >= 180f.InRadians() ? -1 : 1);
        }
      }
      return true;
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
      _ = Dust.NewDust(projectile.position, 6, 6, DustID.Ice, default, default, 90);
      _ = Dust.NewDust(projectile.position, 6, 6, DustID.Ice, default, default, 90);
    }
  }
}