using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.GameInput;
using TynyransMod.Items;
using static Terraria.ModLoader.ModContent;
using TynyransMod.Buffs;
using Terraria.ID;

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
    public byte NoteCount {
      get {
        byte v = 0;
        foreach (byte b in noteList)
        {
          if (b != 0) v++;
        }
        return v;
      }
    }
    public byte maxNotes = 4;
    public byte[] noteList = new byte[4] {0, 0, 0, 0};
    public readonly int maxGainPerSecond = 10;
    // Positive means AF, negative means UI
    public sbyte AForUI;
    public sbyte AForUIcharges;

    private float startingR;
    private float stalwartBurnout;
    private float startingRThaum;

    public override void ResetEffects()
    {
      AForUI = 0;
      AForUIcharges = 0;
      bloodLevel = hemomancy ? bloodLevel : 0;
      bloodConsumedOnUse = 25;
      deflectable = false;
      hemoCrit = 0;
      hemoDamage = 2f;
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
    public void GenerateRandomNextNote()
    {
      for (byte b = 0; b < noteList.Length; b++)
      {
        if (noteList[b] == 0)
        {
          noteList[b] = (byte)Main.rand.Next(1, 4);
          break;
        }
      }
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
    private void ThaumaturgeEffects()
    {
      if (AForUI != 0)
      {
        if (AForUIcharges > 0)
        {
          for (float rotation = startingRThaum; rotation < 360f + startingRThaum; rotation += 360f / AForUIcharges)
          {
            Vector2 spawnPosition = player.MountedCenter + new Vector2(0f, 50f).RotatedBy(rotation.InRadians());
            Dust d = Dust.NewDustPerfect(spawnPosition, DustID.Fire, new Vector2(0f, 0f), 90, new Color(255, 255, 255), 2f);
            d.noLight = true;
            d.noGravity = true;
          }
        }
        else if (AForUIcharges < 0)
        {
          for (float rotation = startingRThaum; rotation < 360f + startingRThaum; rotation += 360f / -AForUIcharges)
          {
            Vector2 spawnPosition = player.MountedCenter + new Vector2(0f, 50f).RotatedBy(rotation.InRadians());
            Dust d = Dust.NewDustPerfect(spawnPosition, DustID.Ice, new Vector2(0f, 0f), 90, new Color(255, 255, 255), 1f);
            d.noLight = true;
            d.noGravity = true;
          }
        }
      }
    }
    public override void SetupStartInventory(IList<Item> items, bool mediumCoreDeath)
    {
      items.Add(CreateItem(ItemType<OrbOfRegrets>()));

      Item CreateItem(int type)
      {
        Item obj = new Item();
        obj.SetDefaults(type, false);
        return obj;
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
      if (AForUI != 0)
      {
        startingRThaum = startingRThaum + 3 >= 360f ? 0 : startingRThaum + 3;
        ThaumaturgeEffects();
      }
      else { startingRThaum = 0; }
      // Perpetual delay when under AF
      if (AForUI == 1)
      {
        player.manaRegenDelay = 5;
        if (player.statMana == 0)
        {
          switch (AForUIcharges)
          {
            case 1:
              player.ClearBuff(BuffType<AstralFireI>());
              break;
            case 2:
              player.ClearBuff(BuffType<AstralFireII>());
              break;
            case 3:
              player.ClearBuff(BuffType<AstralFireIII>());
              break;
          }
        }
      }
      // Increased mana regen and no delay under UI
      if (AForUI == -1)
      {
        player.manaRegenCount += (int)(player.manaRegenCount * 0.50 * -AForUIcharges);
        player.manaRegenDelay = 0;
      }
      if (bloodCollectionCooldown > 0) bloodCollectionCooldown--;
      if (bloodCollectionCooldown is 0) bloodGained = 0;
      if (stalwartDome)
      {
        CreateShieldField();
        startingR = startingR + 3 >= 360f ? 0 : startingR + 3;
        foreach (Projectile proj in Main.projectile)
        {
          if (proj.active && proj.hostile && proj.IsInRadius(player.position, 200f))
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
      if (bloodAmp)
      {
        bloodAmp = false;
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
      if (TynyranWorld.tynMode) regen = 0;
      if (stalwartDome)
      {
        // Burnout mechanic. a flat 10 HP/sec isn't enough to compensate for the power this ability provides.
        regen = -10 - stalwartBurnout;
      }
    }
    public override void ModifyWeaponDamage(Item item, ref float add, ref float mult, ref float flat)
    {
      if (item.type == ItemType<ThaumaturgesStaff>())
      {
        if (AForUIcharges > 0)
          mult += 0.3f * AForUIcharges;
        else if (AForUIcharges < 0)
          mult += 0.1f * AForUIcharges;
      }
    }
    public override void ModifyManaCost(Item item, ref float reduce, ref float mult)
    {
      if (AForUIcharges > 0) mult += 0.3f * AForUIcharges;
      else if (AForUIcharges < 0) reduce += 0.15f * AForUIcharges;
      if (micitEarrings1 && micitEarrings2) reduce -= 0.35f;
    }
    public override void OnMissingMana(Item item, int neededMana)
    {
      // If using thaum staff and have at least a little bit of mana, give you the last one
      if (item.type == ItemType<ThaumaturgesStaff>() && player.statMana != 0)
      {
        player.statMana = neededMana;
      }
    }
    public override void ModifyHitByNPC(NPC npc, ref int damage, ref bool crit)
    {
      if (TynyranWorld.tynMode) damage = (int)(damage * 1.5f);
    }
    public override void ModifyHitByProjectile(Projectile proj, ref int damage, ref bool crit)
    {
      if (TynyranWorld.tynMode) damage = (int)(damage * 1.5f);
    }
    public override void PostUpdateRunSpeeds()
    {
      if (player.velocity.X != 0 && player.Tyn().AForUI == -1) player.manaRegenCount *= 2;
    }
  }
}