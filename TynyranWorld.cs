using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Audio;

namespace TynyransMod
{
  public class TynyranWorld : ModWorld
  {
    public override void Initialize()
    {
      for (int i = 0; i < Main.music.Length; i++)
      {
        switch (i)
        {
          case MusicID.OverworldDay:
            Main.music[i] = mod.GetMusic("Sounds/Music/5FloorGoodbye");
            break;
          case MusicID.AltOverworldDay:
            Main.music[i] = mod.GetMusic("Sounds/Music/5FloorGoodbye");
            break;
          case MusicID.Title:
            Main.music[i] = mod.GetMusic("Sounds/Music/5FloorGoodbye");
            break;
        }
      }
    }
  }
}