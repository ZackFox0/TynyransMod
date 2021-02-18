using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TynyransMod.Buffs;
using Terraria.Localization;

namespace TynyransMod
{
  public static class TynUtils
  {
    public static Tynyran Tyn(this Player player) => player.GetModPlayer<Tynyran>();
    public static TynGlobalNPC Tyn(this NPC npc) => npc.GetGlobalNPC<TynGlobalNPC>();
    public static TynGlobalItem Tyn(this Item item) => item.GetGlobalItem<TynGlobalItem>();
    public static TynGlobalProj Tyn(this Projectile proj) => proj.GetGlobalProjectile<TynGlobalProj>();

    public static float InRadians(this float degrees) => MathHelper.ToRadians(degrees);
    public static float InDegrees(this float radians) => MathHelper.ToDegrees(radians);

    public static Vector2 RandomPointInHitbox(this Rectangle hitbox)
    {
      Vector2 v = new Vector2();
      int semiAxisX = Main.rand.Next(hitbox.Left, hitbox.Right),
          semiAxisY = Main.rand.Next(hitbox.Top, hitbox.Bottom);
      v.X = semiAxisX;
      v.Y = semiAxisY;
      return v;
    }
    public static bool PercentChance(this int chance) => Main.rand.Next(100) <= chance;
    public static bool PercentChance(this float chance) => Main.rand.NextFloat(100f) <= chance;
    public static Vector2 RotateTo(this Vector2 v, float rotation)
    {
      float oldVRotation = v.ToRotation();
      return v.RotatedBy(rotation - oldVRotation);
    }
    public static bool IsInRadius(this Vector2 targetPos, Vector2 center, float radius) => Vector2.Distance(center, targetPos) <= radius;
    public static int GrabProjCount(int type) {
      int count = 0;
      foreach (Projectile proj in Main.projectile)
      {
        if (proj.type == type)
          count++;
      }
      return count;
    }
    public static void Parry(Player player, Rectangle hitbox)
    {
      int NoOfProj = Main.projectile.Length;
      int affectedProjs = 0;
      for (int i = 0; i < NoOfProj; i++)
      {
        Projectile currProj = Main.projectile[i];
        if (!player.HasBuff(ModContent.BuffType<CantDeflect>()) && currProj.active && currProj.hostile && hitbox.Intersects(currProj.Hitbox))
        {
          // Add your melee damage multiplier to the damage so it has a little more oomph
          currProj.damage = (int)(currProj.damage * player.meleeDamageMult);

          // If Micit Bangle is equipped, add that multiplier.
          currProj.damage = player.Tyn().micitBangle ? (int)(currProj.damage * 2.5) : currProj.damage;
          // Convert the proj so you own it and reverse its trajectory
          currProj.owner = player.whoAmI;
          currProj.hostile = false;
          currProj.friendly = true;
          currProj.Tyn().deflected = true;
          currProj.velocity.X = -currProj.velocity.X;
          currProj.velocity.Y = -currProj.velocity.Y;
          affectedProjs++;
        }
      }
      if (affectedProjs > 0)
      {
        // Give a cooldown; 1 second per projectile reflected
        // CantDeflect is a debuff, separate from this code block
        player.AddBuff(ModContent.BuffType<CantDeflect>(), affectedProjs * 60, true);
      }
    }

    public static void AddWithCondition<T>(this List<T> list, T type, bool condition)
    {
      if (!condition)
        return;
      list.Add(type);
    }
    public static void Talk(string message)
    {
      if (Main.netMode != NetmodeID.Server)
      {
        string text = Language.GetTextValue(message);
        Main.NewText(text, 241, 127, 82);
      }
      else
      {
        NetworkText text = NetworkText.FromKey(message);
        NetMessage.BroadcastChatMessage(text, new Color(241, 127, 82));
      }
    }
    public static int ArmorCalculation(NPC npc, ref int damage, ref bool crit)
    {
      int armorDamage = 0;
      // If the NPC is armored
      if (npc.Tyn().Armored)
      {
        crit = false;
        // Deduct the damage from the armor
        armorDamage += (int)(damage * npc.Tyn().armorEfficiency);
        npc.Tyn().armor -= armorDamage;
        damage = (int)(damage * (1f - npc.Tyn().armorEfficiency));
        // If the armor ends up being less than 0
        if (npc.Tyn().armor < 0)
        {
          // Signify that as "overflow damage" by deducting the abs of the remainder from the NPC's life
          armorDamage += npc.Tyn().armor;
          // Subtracting negative == adding positive
          npc.life += npc.Tyn().armor;
          damage -= npc.Tyn().armor;
          npc.Tyn().armor = 0;
        }
        CombatText.NewText(npc.Hitbox, Color.White, armorDamage);
      }
      return damage;
    }
  }
}