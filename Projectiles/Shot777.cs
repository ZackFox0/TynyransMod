using Terraria;
using Terraria.ModLoader;

namespace TynyransMod.Projectiles
{
    public class Shot777 : ModProjectile
    {
        private bool determinedRotation = false;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault(".777 Shot");
        }

        public override void SetDefaults()
        {
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
        }

        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            if (!determinedRotation)
            {
                projectile.rotation = player.DirectionTo(Main.MouseWorld).ToRotation();
                determinedRotation = true;
            }
        }
    }
}