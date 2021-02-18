using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TynyransMod.Projectiles
{
  public class DrillingWaterBolt : ModProjectile
  {
    public override string Texture => "Terraria/Projectile_" + ProjectileID.WaterBolt;
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Drilling Water Bolt");
    }

    public override void SetDefaults()
    {
      projectile.CloneDefaults(ProjectileID.WaterBolt);
      aiType = ProjectileID.WaterBolt;
    }
    public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
    {
      // Hits way more often
      target.immune[projectile.owner] = 4;
    }
  }
}