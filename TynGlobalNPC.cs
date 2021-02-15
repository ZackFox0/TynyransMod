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
    // public override void SetDefaults(NPC npc)
    // {
    //   switch (npc.type)
    //   {
    //     case NPCID.BlueSlime:
    //       npc.Tyn().armorMax = 5;
    //       npc.Tyn().armor = armorMax;
    //       break;
    //     case NPCID.GreenSlime:
    //       npc.Tyn().armorMax = 5;
    //       npc.Tyn().armor = armorMax;
    //       break;
    //     case NPCID.SandSlime:
    //       npc.Tyn().armorMax = 10;
    //       npc.Tyn().armor = armorMax;
    //       break;
    //   }
    // }
    public override void ResetEffects(NPC npc)
    {
      dungeonDrops = false;
    }
    public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
    {
      ArmorCalculation(npc, ref damage, ref crit);
    }
    public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
    {
      int armorDamage = 0;
      // If the NPC is armored
      if (npc.Tyn().Armored)
      {
        crit = false;
        // Deduct the damage from the armor
        armorDamage += (int)(damage * armorEfficiency);
        npc.Tyn().armor -= armorDamage;
        damage = (int)(damage * (1f - armorEfficiency));
        // If the armor ends up being less than 0
        if (npc.Tyn().armor < 0)
        {
          // Signify that as "overflow damage" by deducting the abs of the remainder from the NPC's life
          armorDamage += npc.Tyn().armor;
          // Subtracting negative == adding positive
          npc.life += npc.Tyn().armor;
          damage -= npc.Tyn().armor;
          npc.Tyn().armor = 0;
        }
        CombatText.NewText(npc.Hitbox, Color.White, armorDamage);
      }
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