using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TutorialMod.Content.Projectiles.Weapons
{
	public class CommBullet : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Commissar's Bullet"); 
		}

		public override void SetDefaults() {
			Projectile.width = 10; 
			Projectile.height = 10; 
			Projectile.aiStyle = -1; 
			Projectile.friendly = true; 
			Projectile.hostile = true;
			Projectile.DamageType = DamageClass.Ranged; 
			Projectile.penetrate = 1; 
			Projectile.timeLeft = 600; 
			Projectile.light = 0.5f; 
			Projectile.ignoreWater = true; 
			Projectile.tileCollide = true; 
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(100,10f,-1);
        }
	
	}
}