using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Audio;
using Terraria.ModLoader.IO;

namespace TynyransMod
{
  public class TynyranWorld : ModWorld
  {
    public static bool tynMode;
    public static bool DownedAnyBoss
    {
      get
      {
        // If any of the mainline bosses are downed (not counting minibosses or invasions/events)
        return NPC.downedBoss1 || NPC.downedBoss2 || NPC.downedBoss3
        || NPC.downedSlimeKing || NPC.downedPlantBoss || NPC.downedQueenBee
        || NPC.downedAncientCultist || NPC.downedFishron || NPC.downedGolemBoss || NPC.downedMechBossAny || NPC.downedMoonlord;
      }
    }
    public override TagCompound Save()
    {
      return new TagCompound {
        {"tynMode", tynMode}
      };
    }
    public override void Load(TagCompound tag)
    {
      tynMode = tag.GetBool("tynMode");
    }
  }
}