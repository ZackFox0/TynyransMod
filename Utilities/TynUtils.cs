using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using TynyransMod.Buffs;

namespace TynyransMod
{
    public static class TynUtils
    {
        public static Tynyran Tyn(this Player player) => (Tynyran) player.GetModPlayer<Tynyran>();
        public static TynGlobalNPC Tyn(this NPC npc) => (TynGlobalNPC) npc.GetGlobalNPC<TynGlobalNPC>();
        public static TynGlobalItem Tyn(this Item item) => (TynGlobalItem) item.GetGlobalItem<TynGlobalItem>();
        public static TynGlobalProj Tyn(this Projectile proj) => (TynGlobalProj) proj.GetGlobalProjectile<TynGlobalProj>();

        public static Vector2 RandomPointInHitbox(this Rectangle hitbox) {
            Vector2 v = new Vector2();
            int semiAxisX = Main.rand.Next(hitbox.Left, hitbox.Right), 
                semiAxisY = Main.rand.Next(hitbox.Top, hitbox.Bottom);
            v.X = semiAxisX;
            v.Y = semiAxisY;
            return v;
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
    }
}