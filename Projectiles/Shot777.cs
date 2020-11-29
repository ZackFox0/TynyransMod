using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;

namespace TynyransMod.Projectiles
{
    public class Shot777 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(".777 Shot");
        }

        public override void SetDefaults()
        {
            Player player = Main.player[projectile.owner];
            projectile.friendly = true;
            projectile.width = 136;
            projectile.height = 6;
            projectile.aiStyle = 0;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.timeLeft = 180;
            projectile.penetrate = 6;
            projectile.scale = 1f;
            projectile.damage = 300;
            projectile.rotation = projectile.DirectionTo(Main.MouseWorld).ToRotation();
        }
    }
}