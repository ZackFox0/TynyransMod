using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod
{
  public class TynGlobalItem : GlobalItem
  {
    public override bool InstancePerEntity => true;
    public override bool CloneNewInstances => true;
    public bool test = true;
    public override void SetDefaults(Item item)
    {
      switch(item.type)
      {
        case ItemID.CopperShortsword:
          break;
      }
    }
    public override void OnHitNPC(Item item, Player player, NPC target, int damage, float knockBack, bool crit)
    {
      if (player.Tyn().bloodAmp)
      {
        damage = (int)(damage * player.Tyn().hemoDamage);
        player.Tyn().bloodAmp = false;
      }
    }
  }
}