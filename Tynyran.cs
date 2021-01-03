using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace TynyransMod
{
  public class Tynyran : ModPlayer
  {
    public bool deflectable = false;
    public bool micitBangle = true;
    public bool micitEarrings1 = true;
    public bool micitEarrings2 = true;
    public float tynyran = 1f;
    public int tynyranCrit = 0;

    public override void ResetEffects()
    {
      deflectable = false;
      micitBangle = false;
      micitEarrings1 = false;
      micitEarrings2 = false;
      tynyran = 1f;
      tynyranCrit = 0;
    }

    public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
    {
      if (player.Tyn().micitEarrings1 && player.Tyn().micitEarrings2)
      {
        reduce -= 0.35f;
      }
    }
  }
}