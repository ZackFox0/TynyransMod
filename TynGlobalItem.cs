using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod
{
  public class TynGlobalItem : GlobalItem
  {
    public bool test = true;
    public override void SetDefaults(Item item)
    {
      switch(item.type)
      {
        case ItemID.CopperShortsword:
          break;
      }
    }
  }
}