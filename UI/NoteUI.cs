using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using TynyransMod;
using TynyransMod.Items;
using static Terraria.ModLoader.ModContent;
using static TynyransMod.TynUtils;

namespace TynyransMod.UI
{
  public class NoteUI : UIState
  {
    public static bool visible = true;
    private float oldScale = Main.inventoryScale;
    private UIElement area;
    private UIImageFramed note1, note2, note3, note4;
    private const string path = "TynyransMod/UI/Notes";

    public override void OnInitialize()
    {
      area = new UIElement();
      area.Width.Set(128, 0f);
      area.Height.Set(24, 0);
      area.Top.Set(100, 0f);
      area.Left.Set(-500, 1f);

      note1 = new UIImageFramed(GetTexture(path), new Rectangle(0, 0, 32, 24));
      note1.Width.Set(32, 0f);
      note1.Height.Set(24, 0);

      note2 = new UIImageFramed(GetTexture(path), new Rectangle(0, 0, 32, 24));
      note2.Width.Set(32, 0f);
      note2.Height.Set(24, 0);
      note2.Left.Set(32, 0);

      note3 = new UIImageFramed(GetTexture(path), new Rectangle(0, 0, 32, 24));
      note3.Width.Set(32, 0f);
      note3.Height.Set(24, 0);
      note3.Left.Set(64, 0);

      note4 = new UIImageFramed(GetTexture(path), new Rectangle(0, 0, 32, 24));
      note4.Width.Set(32, 0f);
      note4.Height.Set(24, 0);
      note4.Left.Set(96, 0);

      area.Append(note1);
      area.Append(note2);
      area.Append(note3);
      area.Append(note4);
      Append(area);
    }

    public override void Update(GameTime gameTime)
    {
      base.Update(gameTime);
      if (oldScale != Main.inventoryScale) { oldScale = Main.inventoryScale; Recalculate(); }
      if (!Main.dedServ)
      {
        Tynyran p = Main.LocalPlayer.Tyn();
        visible = Main.LocalPlayer.HeldItem.type == ItemType<HuntingHorn>();
        note1.SetFrame(new Rectangle(0, 24 * p.noteList[0], 32, 24));
        note2.SetFrame(new Rectangle(0, 24 * p.noteList[1], 32, 24));
        note3.SetFrame(new Rectangle(0, 24 * p.noteList[2], 32, 24));
        note4.SetFrame(new Rectangle(0, 24 * p.noteList[3], 32, 24));
      }
    }
  }
}