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
    internal BloodUI bloodLevel;
    internal NoteUI NoteUI;
    internal AetherUI AetherUI;
    private UserInterface bloodLevelUI, notesUI, aetherUI;
    public static int tng, alc;

    public override void Load()
    {
      bloodLevel = new BloodUI();
      bloodLevel.Initialize();
      bloodLevelUI = new UserInterface();
      bloodLevelUI.SetState(bloodLevel);

      NoteUI = new NoteUI();
      NoteUI.Initialize();
      notesUI = new UserInterface();
      notesUI.SetState(NoteUI);

      AetherUI = new AetherUI();
      AetherUI.Initialize();
      aetherUI = new UserInterface();
      aetherUI.SetState(AetherUI);

      UseBlood = RegisterHotKey("Use Blood Magic", "G");
      TynCoinID = CustomCurrencyManager.RegisterCurrency(new TynCoin(ModContent.ItemType<Items.TynCoin>(), 999L));

      tng = GetSoundSlot(SoundType.Music, "Sounds/Music/TouchNGo");
      alc = GetSoundSlot(SoundType.Music, "Sounds/Music/Alchemy");
    }
    public override void Unload()
    {
      bloodLevel = null;
      NoteUI = null;
      AetherUI = null;
      bloodLevelUI = notesUI = aetherUI = null;

      UseBlood = null;
      TynCoinID = tng = alc = default;
    }
    private bool DrawNotesUI()
    {
      if (NoteUI.visible) notesUI.Draw(Main.spriteBatch, new GameTime());
      return true;
    }
    private bool DrawBloodLevelUI()
    {
      if (BloodUI.visible) bloodLevelUI.Draw(Main.spriteBatch, new GameTime());
      return true;
    }
    private bool DrawAetherUI()
    {
      if (AetherUI.visible) aetherUI.Draw(Main.spriteBatch, new GameTime());
      return true;
    }

    public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
    {
      int accbarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Builder Accessories Bar"));
      if (accbarIndex != -1)
      {
        layers.Insert(accbarIndex, new LegacyGameInterfaceLayer("TynyransMod: Blood Level", DrawBloodLevelUI, InterfaceScaleType.UI));
        layers.Insert(accbarIndex, new LegacyGameInterfaceLayer("TynyransMod: Notes", DrawNotesUI, InterfaceScaleType.UI));
        layers.Insert(accbarIndex, new LegacyGameInterfaceLayer("TynyransMod: Aether", DrawAetherUI, InterfaceScaleType.UI));
      }
    }

    public override void UpdateUI(GameTime gameTime)
    {
      base.UpdateUI(gameTime);
      bloodLevelUI?.Update(gameTime);
      notesUI?.Update(gameTime);
      aetherUI?.Update(gameTime);
    }
    public override void UpdateMusic(ref int music, ref MusicPriority priority)
    {
      var boss = IsThereABoss();
      if (boss.Item1)
      {
        if (NPC.AnyNPCs(NPCID.Plantera))
          music = alc;
        else
          music = tng;

        priority = MusicPriority.BossMedium;
      }
    }
  }
}