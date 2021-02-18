using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static TynyransMod.TynUtils;
using Terraria.UI;
using TynyransMod.UI;
using TynyransMod.Items;

namespace TynyransMod
{
  public class TynyransMod : Mod
  {
    public static ModHotKey UseBlood;
    public static int TynCoinID;
    internal BloodLevel bloodLevel;
    private UserInterface bloodLevelUI;

    public override void Load()
    {
      bloodLevel = new BloodLevel();
      bloodLevel.Initialize();
      bloodLevelUI = new UserInterface();
      bloodLevelUI.SetState(bloodLevel);

      UseBlood = RegisterHotKey("Use Blood Magic", "G");
      TynCoinID = CustomCurrencyManager.RegisterCurrency(new TynCoin(ModContent.ItemType<Items.TynCoin>(), 999L));
    }
    public override void Unload()
    {
      bloodLevel = null;
      bloodLevelUI = null;
      UseBlood = null;
      TynCoinID = default;
    }

    private bool DrawBloodLevelUI()
    {
      if (BloodLevel.visible) bloodLevelUI.Draw(Main.spriteBatch, new GameTime());
      return true;
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
      int accbarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Builder Accessories Bar"));
      if (accbarIndex != -1)
      {
        layers.Insert(accbarIndex, new LegacyGameInterfaceLayer("TynyransMod: Blood Level", DrawBloodLevelUI, InterfaceScaleType.UI));
      }
    }

    public override void UpdateUI(GameTime gameTime)
    {
      base.UpdateUI(gameTime);
      bloodLevelUI?.Update(gameTime);
    }
    public override void UpdateMusic(ref int music, ref MusicPriority priority)
    {
      int saku = GetSoundSlot(SoundType.Music, "Sounds/Music/SakuzyoSlam"),
          tng = GetSoundSlot(SoundType.Music, "Sounds/Music/TouchNGo");
      if (IsThereABoss().Item1 && music != saku && music != tng)
      {
        music = Main.rand.NextBool() ? saku : tng;
        priority = MusicPriority.BossMedium;
      }
    }
  }
}