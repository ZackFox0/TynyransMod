using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using TynyransMod.Projectiles;

namespace TynyransMod.Items
{
  public class ScrollWaterBoltUp : Scroll
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Water Bolt Scroll (Upgrade)");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.WaterBolt);
      base.SetDefaults();
      item.damage *= 3;
      item.shoot = ProjectileType<DrillingWaterBolt>();
      item.shootSpeed *= 2;
    }

    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
      foreach (NPC target in Main.npc)
      {
        if (target.active && !target.friendly && !target.townNPC && target.IsInRadius(player.position, 600f))
        {
          Vector2 s = new Vector2(item.shootSpeed, 0f).RotateTo(player.AngleTo(target.position));
          _ = Projectile.NewProjectile(position, s, item.shoot, damage, knockBack, player.whoAmI);
        }
      }
      return false;
    }
  }
}