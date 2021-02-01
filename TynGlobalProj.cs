using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod
{
  public class TynGlobalProj : GlobalProjectile
  {
    public bool bloodAmpBoosted;
    public bool deflected;
    public override bool InstancePerEntity => true;
    public override bool CloneNewInstances => true;
    public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
    {
      Player player = Main.player[projectile.owner];
      if (player.Tyn().bloodAmp)
      {
        projectile.velocity *= 1.5f;
        damage = (int)(damage * player.Tyn().hemoDamage);
      }
    }
  }
}