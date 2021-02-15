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