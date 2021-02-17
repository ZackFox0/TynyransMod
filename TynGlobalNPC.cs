using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TynyransMod.Items;
using static TynyransMod.TynUtils;

namespace TynyransMod
{
  public class TynGlobalNPC : GlobalNPC
  {
    public int armorMax = 1000;
    public int armor = 1000;
    public float armorEfficiency = 0.5f;
    public bool Armored {
      get => armor > 0;
    }
    public static bool dungeonDrops;
    public override bool InstancePerEntity => true;
    public override bool CloneNewInstances => true;
    public override void SetDefaults(NPC npc)
    {
      if (!npc.friendly && !npc.townNPC)
      {
        npc.Tyn().armorMax = npc.lifeMax;
        npc.Tyn().armor = npc.Tyn().armorMax;
      }
    }
    public override void ResetEffects(NPC npc)
    {
      dungeonDrops = false;
    }
    public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
    {
      damage = ArmorCalculation(npc, ref damage, ref crit);
    }
    public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
    {
      damage = ArmorCalculation(npc, ref damage, ref crit);
    }
    public override void ModifyHitNPC(NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
    {
      damage = ArmorCalculation(target, ref damage, ref crit);
    }
    // TODO: Figure this shit out
    // public override void NPCLoot(NPC npc)
    // {
    //   for (int i = 0; i < Main.player.Length; i++)
    //   {
    //     Player currPC = Main.player[i];
    //     if (currPC.ZoneDungeon)
    //     {
    //       // if (Main.rand.Next(1, 100) >= 95) // 5%
    //       // {
    //         int sWBID = ModContent.ItemType<ScrollWaterBolt>();
    //         Item sWB = Main.item[sWBID];
    //         Item.NewItem((int)npc.position.X, (int)npc.position.Y, sWB.width, sWB.height, sWBID);
    //       // }
    //     }
    //   }
    // }
  }
}