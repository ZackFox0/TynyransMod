using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System;
using static TynyransMod.TynUtils;

namespace TynyransMod.Items
{
  public abstract class TynItem : ModItem
  {
    public override void SetDefaults()
    {
      item.melee = false;
      item.ranged = false;
      item.magic = false;
      item.summon = false;
      item.thrown = false;
    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
      var tt = tooltips.Find(x => x.Name == "Damage" && x.mod == "Terraria");
      if (tt != null)
      {
        string[] split = tt.text.Split(' ');
        tt.text = split[0] + " Tynyran " + split.Last();
      }
    }
    public virtual void ModifyWeaponDamage(Player player, ref int damage)
    {
      Tynyran modPlayer = player.Tyn();
      int originalDmg = damage;
      damage = (int)(damage * modPlayer.tynyran);
      float globalDmg = player.meleeDamage - 1;
      if (player.magicDamage - 1 < globalDmg) { globalDmg = player.magicDamage - 1; }
      if (player.rangedDamage - 1 < globalDmg) { globalDmg = player.rangedDamage - 1; }
      if (player.minionDamage - 1 < globalDmg) { globalDmg = player.minionDamage - 1; }
      if (player.thrownDamage - 1 < globalDmg) { globalDmg = player.thrownDamage - 1; }
      if (globalDmg > 1) { damage += (int)(originalDmg * globalDmg); }
    }
  }
}