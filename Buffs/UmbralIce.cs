using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Buffs
{
  public class UmbralIceI : ModBuff
  {
    public override void SetDefaults()
    {
      DisplayName.SetDefault("Umbral Ice I");
      Description.SetDefault("25% increased mana regen and no regen delay");
      Main.debuff[Type] = true;
      Main.pvpBuff[Type] = true;
      Main.buffNoSave[Type] = true;
      longerExpertDebuff = false;
    }
    public override void Update(Player player, ref int buffIndex)
    {
      player.Tyn().AForUI = -1;
      player.Tyn().AForUIcharges = -1;
    }
  }
  public class UmbralIceII : ModBuff
  {
    public override void SetDefaults()
    {
      DisplayName.SetDefault("Umbral Ice II");
      Description.SetDefault("50% increased mana regen and no regen delay");
      Main.debuff[Type] = true;
      Main.pvpBuff[Type] = true;
      Main.buffNoSave[Type] = true;
      longerExpertDebuff = false;
    }
    public override void Update(Player player, ref int buffIndex)
    {
      player.Tyn().AForUI = -1;
      player.Tyn().AForUIcharges = -2;
    }
  }
  public class UmbralIceIII : ModBuff
  {
    public override void SetDefaults()
    {
      DisplayName.SetDefault("Umbral Ice III");
      Description.SetDefault("75% increased mana regen and no regen delay");
      Main.debuff[Type] = true;
      Main.pvpBuff[Type] = true;
      Main.buffNoSave[Type] = true;
      longerExpertDebuff = false;
    }
    public override void Update(Player player, ref int buffIndex)
    {
      player.Tyn().AForUI = -1;
      player.Tyn().AForUIcharges = -3;
    }
  }
}