using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Projectiles
{
  public class RedNote : Note
  {
    new public int noteType = 2;
    public override void SetDefaults()
    {
      base.SetDefaults();
      projectile.width = 16;
      projectile.height = 24;
    }
  }
}