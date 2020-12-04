using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TynyransMod.Items;

namespace TynyransMod
{
  public class TynGlobalNPC : GlobalNPC
  {
    public static bool dungeonDrops = false;
    public override bool InstancePerEntity => true;
    public override bool CloneNewInstances => true;

    public override void SetDefaults(NPC npc)
    {
    }
    public override void ResetEffects(NPC npc)
    {
      dungeonDrops = false;
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