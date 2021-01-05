using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Buffs
{
	public class StalDome : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Stalwart Dome");
			Description.SetDefault("Draining your health for everyone's protection!");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}
		public override void Update(Player player, ref int buffIndex) {
      player.Tyn().stalwartDome = true;
		}
	}
}