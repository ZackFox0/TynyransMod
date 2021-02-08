using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Projectiles
{
  public class BlueNote : Note
  {
    new public int noteType = 1;
    public override void SetDefaults()
    {
      base.SetDefaults();
      projectile.width = 16;
      projectile.height = 24;
    }
  }
}