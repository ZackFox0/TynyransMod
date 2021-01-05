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
    public bool deflectable,
                micitBangle,
                micitEarrings1,
                micitEarrings2,
                stalwartDome;
    public float tynyran;
    public int tynyranCrit;

    private float startingR;
    private float stalwartBurnout = 0f;

    public override void ResetEffects()
    {
      deflectable = false;
      micitBangle = false;
      micitEarrings1 = false;
      micitEarrings2 = false;
      tynyran = 1f;
      tynyranCrit = 0;
      stalwartDome = false;
      stalwartBurnout = stalwartBurnout - 1f <= 0f ? 0f : stalwartBurnout - 1f;
    }
    private void CreateShieldField()
    {
      for (float rotation = startingR; rotation < 360f + startingR; rotation += 45f)
      {
        Vector2 spawnPosition = player.MountedCenter + new Vector2(0f, 200f).RotatedBy(rotation.InRadians());
        Dust d = Dust.NewDustPerfect(spawnPosition, 16, new Vector2(0f, 0f), 90, new Color(255, 255, 255), 1f);
        d.noLight = true;
        d.noGravity = true;
      }
    }
    public override void PostUpdate()
    {
      if (stalwartDome)
      {
        CreateShieldField();
        startingR = startingR + 3 >= 360f ? 0 : startingR + 3;
        foreach (Projectile proj in Main.projectile)
        {
          if (proj.active && proj.hostile && proj.position.IsInRadius(player.position, 200f))
          {
            for (int i = 0; i < 10; i++)
              _ = Dust.NewDust(proj.position, 3, 3, 16, -proj.velocity.X, -proj.velocity.Y, 90, new Color(255, 255, 255), 1f);

            stalwartBurnout += proj.damage / 3;
            proj.active = false;
          }
        }
      }
    }

    public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
    {
      if (stalwartDome)
      {
        damageSource = PlayerDeathReason.ByCustomReason($"{player.name} died protecting his friends...maybe?");
      }
      return true;
    }
    public override void NaturalLifeRegen(ref float regen)
    {
      if (stalwartDome)
      {
        // Burnout mechanic. a flat 10 HP/sec isn't enough to compensate for the power this ability provides.
        regen = -10 - stalwartBurnout;
      }
    }
    public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
    {
      if (micitEarrings1 && micitEarrings2)
        reduce -= 0.35f;
    }
  }
}