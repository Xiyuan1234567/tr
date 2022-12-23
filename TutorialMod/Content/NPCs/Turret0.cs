using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace TutorialMod.Content.NPCs
{
	public class Turret0 : ModNPC
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Turret0");
		}

		public override void SetDefaults() {
			NPC.friendly = true;
			NPC.width = 32;
			NPC.height = 32;
			NPC.defense = 70;
			NPC.lifeMax = 200;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath2;
			NPC.knockBackResist = 0.9f;
			NPC.aiStyle = -1; 
		}

		private int timer;
		Player player = Main.player[Main.myPlayer];
		public override void AI(){
			for (int i = 0; i < 200; i++){
				NPC target = Main.npc[i];

				if (!target.friendly && target.lifeMax > 5 && !target.dontTakeDamage && target.active){
					Vector2 toTarget = target.Center - NPC.Center;
					toTarget.Normalize();

					if (NPC.Distance(target.Center) < 600f){
						this.timer++;
						if (this.timer == 10)
						{
							Vector2 perturbedSpeed = Utils.RotatedByRandom(new Vector2(toTarget.X, toTarget.Y), (double)MathHelper.ToRadians(0.1f));
							
							var entitySource = NPC.GetSource_FromAI();
							Projectile.NewProjectile(entitySource, NPC.Center, perturbedSpeed * 10f, ProjectileID.BulletHighVelocity, 90, 3f, player.whoAmI);
							this.timer = 0;
						}
					}
                }

			}
		}


	}
}