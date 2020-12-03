using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static TynyransMod.TynUtils;

namespace TynyransMod.Items
{
	public class MicitSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Micit Sword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("\"A sword forged from the divine steel, Micit.\nIncredibly strong, sharp, light, and durable.\"");
		}
		public override void SetDefaults() 
		{
			item.damage = 150;
			item.crit = 45;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.scale = 2.25f;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
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