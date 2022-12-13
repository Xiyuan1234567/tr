using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using System;

namespace TutorialMod.Content.Projectiles.Weapons
{
    internal class TutorialWandProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 2;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(195, 30, false);
        }

        public override void AI()
        {
            //Making player variable "p" set as the projectile's owner
            Player p = Main.player[Projectile.owner];

            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 300)
            {
                Projectile.Kill();
            }
            // Projectile.velocity.X = Projectile.velocity.X * 1.05f;
            // Projectile.velocity.Y = Projectile.velocity.Y * 1.05f;

            for (int i = 0; i < 200; i++)
            {   
                NPC target = Main.npc[i];
        
                //Get the shoot trajectory from the projectile and target
                float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
                float shootToY = target.position.Y - Projectile.Center.Y;
                float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                //If the distance between the live targeted npc and the projectile is less than 480 pixels
                if (!target.friendly && target.lifeMax > 5 && !target.dontTakeDamage && target.active && distance < 600f)
                {
                    //Divide the factor, 3f, which is the desired velocity
                    distance = 3f/distance;

                    //Multiply the distance by a multiplier if you wish the projectile to have go faster
                    shootToX *= distance * 5;
                    shootToY *= distance * 5;

                    //Set the velocities to the shoot values
                    Projectile.velocity.X = shootToX;
                    Projectile.velocity.Y = shootToY;
                    //Projectile.spriteDirection = Projectile.direction;
                    Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
                    //Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
                    Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
            
                    break; // discontinue looping enemies
                }
                else
                {
                    Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
                    //Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 15, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
                    Lighting.AddLight(Projectile.Center, 0.75f, 0.75f, 0.75f);
                }
             }
        }
    }
}
