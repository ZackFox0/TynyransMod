using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using TynyransMod.Buffs;
using TynyransMod.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace TynyransMod.Items
{
  public class ThaumaturgesStaff : ModItem
  {
    public override string Texture => $"Terraria/Item_{ItemID.DiamondStaff}";
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Thaumaturge's Staff");
      Tooltip.SetDefault("Primary attack releases fire, secondary attack releases ice\nConsecutive castings of the same type gain special effects\nFire increases mana cost and halts regen but also increases damage\nIce increases mana regen but lowers damage\nCasting the opposite element cancels your current buff\n\"An ensorcelled staff of yore\"");
      Item.staff[item.type] = true;
    }

    public override void SetDefaults()
    {
      item.damage = 150;
      item.width = 46;
      item.height = 24;
      item.rare = ItemRarityID.Lime;
      item.useTime = 40;
      item.useAnimation = 40;
      item.useTurn = false;
      item.useStyle = ItemUseStyleID.HoldingOut;
      item.magic = true;
      item.mana = 16;
      item.noMelee = true;
      item.autoReuse = true;
      item.knockBack = 3f;
      item.shootSpeed = 24f;
      item.UseSound = SoundID.DD2_BetsyFireballShot;
    }
    public override bool AltFunctionUse(Player player) => true;
    public override bool CanUseItem(Player player)
    {
      // Right click
      if (player.altFunctionUse == 2)
        item.shoot = ProjectileType<ThaumaturgeIce>();
      else
        item.shoot = ProjectileType<ThaumaturgeFire>();
      return true;
    }
    public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
    {
      if (player.Tyn().AForUI == 1)
      {
        if (type == ProjectileType<ThaumaturgeIce>())
        {
          switch(player.Tyn().AForUIcharges)
          {
            case 1:
              player.ClearBuff(BuffType<AstralFireI>());
              break;
            case 2:
              player.ClearBuff(BuffType<AstralFireII>());
              break;
            case 3:
              player.ClearBuff(BuffType<AstralFireIII>());
              player.AddBuff(BuffType<UmbralIceI>(), 15 * 60);
              break;
          }
        }
        else if (type == ProjectileType<ThaumaturgeFire>())
        {
          switch(player.Tyn().AForUIcharges)
          {
            case 1:
              player.ClearBuff(BuffType<AstralFireI>());
              player.AddBuff(BuffType<AstralFireII>(), 15 * 60);
              break;
            case 2:
              player.ClearBuff(BuffType<AstralFireII>());
              player.AddBuff(BuffType<AstralFireIII>(), 15 * 60);
              break;
            case 3:
              player.AddBuff(BuffType<AstralFireIII>(), 15 * 60);
              break;
          }
        }
      }
      else if (player.Tyn().AForUI == -1)
      {
        if (type == ProjectileType<ThaumaturgeFire>())
        {
          switch(player.Tyn().AForUIcharges)
          {
            case -1:
              player.ClearBuff(BuffType<UmbralIceI>());
              break;
            case -2:
              player.ClearBuff(BuffType<UmbralIceII>());
              break;
            case -3:
              player.ClearBuff(BuffType<UmbralIceIII>());
              player.AddBuff(BuffType<AstralFireI>(), 15 * 60);
              break;
          }
        }
        else if (type == ProjectileType<ThaumaturgeIce>())
        {
          switch(player.Tyn().AForUIcharges)
          {
            case -1:
              player.ClearBuff(BuffType<UmbralIceI>());
              player.AddBuff(BuffType<UmbralIceII>(), 15 * 60);
              break;
            case -2:
              player.ClearBuff(BuffType<UmbralIceII>());
              player.AddBuff(BuffType<UmbralIceIII>(), 15 * 60);
              break;
            case -3:
              player.AddBuff(BuffType<UmbralIceIII>(), 15 * 60);
              break;
          }
        }
      }
      else
      {
        if (type == ProjectileType<ThaumaturgeFire>())
          player.AddBuff(BuffType<AstralFireI>(), 15 * 60);
        else if (type == ProjectileType<ThaumaturgeIce>())
          player.AddBuff(BuffType<UmbralIceI>(), 15 * 60);
      }
      return true;
    }
  }
}