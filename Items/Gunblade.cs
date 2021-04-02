using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static TynyransMod.TynUtils;

namespace TynyransMod.Items
{
	public class Gunblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gunblade"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Deal damage and gain aether\nAlt-fire to unleash an aether-charged shot, piercing all targets.\n\"Royal Guardsmen pride themselves on mixing sword and gun.\"");
		}
		public override void SetDefaults()
		{
			item.damage = 150;
			item.crit = 10;
			item.melee = true;
			item.width = 191;
			item.height = 218;
			item.scale = 0.5f;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
			// Run the parry util (In TynUtils)
			Parry(player, hitbox);
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<MicitBar>(), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}