using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace TynyransMod.UI
{
  internal class BloodLevel : UIState
  {
    public static bool visible = true;
    public float oldScale = Main.inventoryScale;
    private BLElement area;
    private UIImage bLFrame, bLBG;
    private UIImageFramed bLFill;
    private Rectangle frame;
    private byte aniFrameCounter = 12;
    private byte aniFrame = 1;

    public override void OnInitialize()
    {
      area = new BLElement();
      area.Left.Set(-228, 1f);
      area.Top.Set(-176 * 2, 1f);
      area.Width.Set(44, 0f);
      area.Height.Set(130, 0f);

      bLFrame = new UIImage(GetTexture("TynyransMod/UI/BloodLevelFrame"));
      bLFrame.Width.Set(44, 0f);
      bLFrame.Height.Set(130, 0f);

      bLBG = new UIImage(GetTexture("TynyransMod/UI/BloodLevelBG"));
      bLBG.Width.Set(44, 0f);
      bLBG.Height.Set(130, 0f);

      frame = new Rectangle(0, 0, 44, 130);
      bLFill = new UIImageFramed(GetTexture("TynyransMod/UI/BloodLevelEmpty1"), frame);
      bLFill.Height.Set(0f, 0f);
      bLFill.Width.Set(44, 0f);
      bLFill.Height.Set(130, 0f);

      area.Append(bLBG);
      area.Append(bLFill);
      area.Append(bLFrame);

      Append(area);
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (oldScale != Main.inventoryScale) { oldScale = Main.inventoryScale; Recalculate(); }

      Player p = Main.player[0];
      Tynyran tyn = p.Tyn();
      visible = tyn.hemomancy;
      if (visible)
      {
        if (aniFrameCounter > 0) { aniFrameCounter--; }
        else { aniFrameCounter = 12; aniFrame++; }
        if (aniFrame > 3) aniFrame = 1;

        int bL = tyn.bloodLevel;
        if (bL <= 13) bLFill.SetImage(GetTexture($"TynyransMod/UI/BloodLevelEmpty{aniFrame}"), frame);
        else if (bL <= 38) bLFill.SetImage(GetTexture($"TynyransMod/UI/BloodLevel25_{aniFrame}"), frame);
        else if (bL <= 63) bLFill.SetImage(GetTexture($"TynyransMod/UI/BloodLevel50_{aniFrame}"), frame);
        else if (bL <= 88) bLFill.SetImage(GetTexture($"TynyransMod/UI/BloodLevel75_{aniFrame}"), frame);
        else bLFill.SetImage(GetTexture($"TynyransMod/UI/BloodLevelFull{aniFrame}"), frame);

        if (tyn.bloodAmp) bLFrame.SetImage(GetTexture("TynyransMod/UI/BloodLevelFrameAmp"));
        else bLFrame.SetImage(GetTexture("TynyransMod/UI/BloodLevelFrame"));
      }
    }
  }
}