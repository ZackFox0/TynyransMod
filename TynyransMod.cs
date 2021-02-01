using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using TynyransMod.UI;

namespace TynyransMod
{
  public class TynyransMod : Mod
  {
    public static ModHotKey UseBlood;
    internal BloodLevel bloodLevel;
    private UserInterface bloodLevelUI;

    public override void Load()
    {
      bloodLevel = new BloodLevel();
      bloodLevel.Initialize();
      bloodLevelUI = new UserInterface();
      bloodLevelUI.SetState(bloodLevel);

      UseBlood = RegisterHotKey("Use Blood Magic", "G");
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
  }
}