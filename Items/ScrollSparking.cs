using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TynyransMod.Projectiles;

namespace TynyransMod.Items
{
  public class ScrollSparking : Scroll
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Sparking Scroll");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.WandofSparking);
      base.SetDefaults();
      item.damage = (int)(item.damage * 1.25);
      item.shoot = ModContent.ProjectileType<SplittingSpark>();
    }
  }
}