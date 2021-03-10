using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Buffs
{
	public class AstralFireI : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Astral Fire I");
			Description.SetDefault("30% increased damage and mana cost");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
		public override void Update(Player player, ref int buffIndex) {
      player.Tyn().AForUI = 1;
      player.Tyn().AForUIcharges = 1;
		}
	}

	public class AstralFireII : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Astral Fire II");
			Description.SetDefault("60% increased damage and mana cost");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
		public override void Update(Player player, ref int buffIndex) {
      player.Tyn().AForUI = 1;
      player.Tyn().AForUIcharges = 2;
		}
	}

	public class AstralFireIII : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Astral Fire III");
			Description.SetDefault("90% increased damage and mana cost");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
		public override void Update(Player player, ref int buffIndex) {
      player.Tyn().AForUI = 1;
      player.Tyn().AForUIcharges = 3;
		}
	}
}