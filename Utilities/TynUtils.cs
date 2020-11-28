using Terraria;
using System.Collections.Generic;

namespace TynyransMod
{
    public static class TynUtils
    {
        public static Tynyran Tyn(this Player player) => (Tynyran) player.GetModPlayer<Tynyran>();
        public static TynGlobalNPC Tyn(this NPC npc) => (TynGlobalNPC) npc.GetGlobalNPC<TynGlobalNPC>();
        public static TynGlobalItem Tyn(this Item item) => (TynGlobalItem) item.GetGlobalItem<TynGlobalItem>();
        public static TynGlobalProj Tyn(this Projectile proj) => (TynGlobalProj) proj.GetGlobalProjectile<TynGlobalProj>();


        public static void AddWithCondition<T>(this List<T> list, T type, bool condition)
        {
            if (!condition)
            return;
            list.Add(type);
        }
    }
}