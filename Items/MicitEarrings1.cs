using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod.Items
{
	public class MicitEarrings1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Micit Earring (Left)"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("\"Earrings made from Micit. They radiate excessive magic power.\"\n+75% magic damage and 10% magic crit chance.\nSet bonus: Having both earrings on reduces mana cost by 35%.");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 28;
			item.value = 10000;
			item.rare = 12;
      item.accessory = true;
		}

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
			player.magicDamage += 0.75f;
			player.magicCrit += 10;
			player.Tyn().micitEarrings1 = true;
    }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentSolar, 10);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ItemID.FragmentStardust, 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}