using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod.Items
{
	public abstract class Scroll : ModItem
	{
    public override string Texture => (GetType().Namespace + ".Scroll").Replace('.', '/');

		public override void SetDefaults()
		{
      item.magic = true;
      item.mana = 0;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.scale = 1f;
			item.UseSound = SoundID.DD2_BetsyFireballShot;
			item.noMelee = true;
			item.consumable = true;
			item.maxStack = 99;
		}
	}
}