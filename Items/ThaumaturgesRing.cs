using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TynyransMod.Items
{
	public class ThaumaturgesRing : HemoItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thaumaturge's Ring");
			Tooltip.SetDefault("Increases max mana by 100 and magic damage by 20%");
		}

		public override void SetDefaults()
		{
			item.width = 28;
			item.height = 20;
			item.value = 10000;
			item.rare = ItemRarityID.Pink;
      item.accessory = true;
		}

    public override void UpdateAccessory(Player player, bool hideVisual)
    {
			player.magicDamage += 0.2f;
      player.statManaMax2 += 100;
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