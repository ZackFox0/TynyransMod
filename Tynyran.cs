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

    public override void ResetEffects()
    {
      deflectable = false;
      micitBangle = false;
    }
  }
}