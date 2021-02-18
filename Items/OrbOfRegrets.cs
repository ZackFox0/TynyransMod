using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TynyransMod;
using static TynyransMod.TynUtils;

namespace TynyransMod.Items
{
  public class OrbOfRegrets : TynItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Orb of Regrets");
      Tooltip.SetDefault("Activates 'Tynyran' mode\n\"You feel like this is a terrible mistake...\"");
    }

    public override void SetDefaults()
    {
      item.consumable = true;
      item.width = 24;
      item.height = 24;
      item.rare = ItemRarityID.Expert;
      item.maxStack = 1;
      item.useStyle = ItemUseStyleID.HoldingUp;
    }

    public override bool ConsumeItem(Player player) => false;
    public override bool CanUseItem(Player player)
    {
      if (Main.expertMode && !TynyranWorld.DownedAnyBoss) { return true; }
      else
      {
        if (!Main.expertMode) Talk("You must be in a more unforgiving world. (Expert world only)");
        if (TynyranWorld.DownedAnyBoss) Talk("You must choose this fate before your journey begins. (No bosses killed yet)");
        return false;
      }
    }
    public override bool UseItem(Player player)
    {
      Main.PlaySound(SoundID.DD2_BetsyDeath);
      TynyranWorld.tynMode = !TynyranWorld.tynMode;
      if (TynyranWorld.tynMode) Talk("You just made a huge mistake...");
      else Talk("You lucked out. This time.");

      return true;
    }
  }
}