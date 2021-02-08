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
using Terraria.GameInput;

namespace TynyransMod
{
  public class Tynyran : ModPlayer
  {
    public bool deflectable,
                micitBangle,
                micitEarrings1,
                micitEarrings2,
                stalwartDome,
                hemomancy,
                bloodAmp;
    public float tynyran, hemoDamage;
    public int tynyranCrit, hemoCrit;
    public int bloodLevel, maxBloodLevel = 100, bloodGained, bloodCollectionCooldown, bloodConsumedOnUse = 25;
    public int noteCount, maxNotes = 4;
    public readonly int maxGainPerSecond = 10;

    private float startingR;
    private float stalwartBurnout;

    public override void ResetEffects()
    {
      bloodLevel = hemomancy ? bloodLevel : 0;
      bloodConsumedOnUse = 25;
      deflectable = false;
      hemoCrit = 0;
      hemoDamage = 1f;
      hemomancy = false;
      maxBloodLevel = 100;
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
    public override void ProcessTriggers(TriggersSet triggersSet)
    {
      if (hemomancy && !bloodAmp && TynyransMod.UseBlood.JustPressed && bloodLevel >= bloodConsumedOnUse)
      {
        bloodLevel -= bloodConsumedOnUse;
        bloodAmp = true;
      }
    }
    public override void PostUpdate()
    {
      if (bloodCollectionCooldown > 0) bloodCollectionCooldown--;
      if (bloodCollectionCooldown is 0) bloodGained = 0;
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
    public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
    {
      if (target.active && !target.townNPC && !target.friendly && hemomancy && bloodGained < maxGainPerSecond)
      {
        bloodLevel++;
        bloodGained++;
        if (bloodCollectionCooldown is 0) bloodCollectionCooldown = 60;

        if (bloodLevel > maxBloodLevel) bloodLevel = maxBloodLevel;
      }
    }
    public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
    {
      if (player.Tyn().bloodAmp)
      {
        player.Tyn().bloodAmp = false;
        damage = (int)(damage * hemoDamage);
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