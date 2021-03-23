using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static TynyransMod.TynUtils;
using System.Collections.Generic;

namespace TynyransMod.Items
{
	public class HuntingHorn : ModItem
	{
    public override string Texture => $"Terraria/Item_{ItemID.TheAxe}";
    private bool madeNoteAlready;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hunting Horn"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Attack enemies to generate notes\nYou provide yourself with buffs based on how many unique notes you have\nPlay notes you have with alt-fire");
		}
		public override void SetDefaults()
		{
			item.damage = 51;
			item.crit = 5;
			item.melee = true;
			item.width = 30;
			item.height = 30;
			item.scale = 2.25f;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.useTurn = true;
		}

    public override bool AltFunctionUse(Player player) => true;
    public override bool CanUseItem(Player player)
    {
      if (player.altFunctionUse == 2) return player.Tyn().NoteCount > 0;
      else return true;
    }
    public override bool UseItem(Player player)
    {
      List<int> uniqueNotes = new List<int>();
      if (player.altFunctionUse == 2)
      {
        foreach (byte b in player.Tyn().noteList)
        {
          if (!uniqueNotes.Contains(b)) uniqueNotes.Add(b);
        }
        switch (uniqueNotes.Count)
        {
          case 1:
            player.AddBuff(BuffID.Regeneration, 120.InTicks());
            break;
          case 2:
            player.AddBuff(BuffID.Endurance, 60.InTicks());
            break;
          case 3:
            player.AddBuff(BuffID.Wrath, 30.InTicks());
            break;
        }
        player.Tyn().noteList = new byte[4] {0, 0, 0, 0};
      }
      return true;
    }
    public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
    {
      if (!madeNoteAlready)
      {
        player.Tyn().GenerateRandomNextNote();
        madeNoteAlready = true;
      }
    }
    public override void UpdateInventory(Player player)
    {
      if (player.itemAnimation == 0 && madeNoteAlready) madeNoteAlready = false;
    }
	}
}