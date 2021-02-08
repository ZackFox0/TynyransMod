using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Projectiles
{
  public class PurpleNote : Note
  {
    new public int noteType = 3;
    public override void SetDefaults()
    {
      base.SetDefaults();
      projectile.width = 16;
      projectile.height = 24;
    }
  }
}