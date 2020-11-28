using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Buffs
{
	public class CantDeflect : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Can't Deflect");
			Description.SetDefault("So you can't spam the Micit Sword");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
		public override void Update(Player player, ref int buffIndex) {
      player.Tyn().deflectable = true;
		}
	}
}