using Terraria.ID;
using Terraria;

namespace TynyransMod.Items
{
  public class TynCoin : TynItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Tynyran Coin");
      Tooltip.SetDefault("\"A coin made of micit, minted with a strange symbol...\"");
    }

    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.PlatinumCoin);
      base.SetDefaults();
      item.damage = 0;
      item.shoot = ProjectileID.None;
      item.value = Item.buyPrice(100);
    }
    public override bool CanBurnInLava() => false;
    public override bool CanUseItem(Player player) => false;
  }
}