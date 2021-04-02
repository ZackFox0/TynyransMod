using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using TynyransMod;
using static Terraria.ModLoader.ModContent;
using static TynyransMod.TynUtils;

namespace TynyransMod.UI
{
  internal class AetherUI : UIState
  {
    public static bool visible = true;
    public float oldScale = Main.inventoryScale;
    private UIElement area;
    private UIImage aetherBackground, aetherFrame;
    private UIImageFramed AetherBar;
    private Rectangle aetherOrbRect;
    public override void OnInitialize()
    {
      area = new UIElement();
      area.Left.Set(-250f, 1f);
      area.Top.Set(100f, 0f);
      area.Width.Set(52, 0f);
      area.Height.Set(52, 0f);

      aetherBackground = new UIImage(GetTexture("TynyransMod/UI/AetherUIBG"));
      aetherBackground.Width.Set(52, 0f);
      aetherBackground.Height.Set(52, 0f);

      aetherFrame = new UIImage(GetTexture("TynyransMod/UI/AetherUIFrame"));
      aetherFrame.Width.Set(52, 0f);
      aetherFrame.Height.Set(52, 0f);

      aetherOrbRect = new Rectangle(0, 0, 52, 52);
      AetherBar = new UIImageFramed(GetTexture("TynyransMod/UI/AetherUIOrb"), aetherOrbRect);
      AetherBar.Top.Set(52, 0f);
      AetherBar.Left.Set(0, 0f);
      AetherBar.Width.Set(52, 0f);
      AetherBar.Height.Set(52, 0f);

      area.Append(aetherBackground);
      area.Append(aetherFrame);
      area.Append(AetherBar);
      Append(area);
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (oldScale != Main.inventoryScale) { oldScale = Main.inventoryScale; Recalculate(); }
      Tynyran tyn = Main.LocalPlayer.Tyn();
      visible = tyn.aether;
      if (visible)
      {
        float quotient = (float)Main.LocalPlayer.Tyn().aetherCharges / (float)Main.LocalPlayer.Tyn().maxAetherCharges;
        quotient = Utils.Clamp(quotient, 0f, 1f);
        aetherOrbRect.Width = aetherOrbRect.Y = (int)(52 * quotient);
        AetherBar.SetFrame(aetherOrbRect);
      }
    }
  }
}