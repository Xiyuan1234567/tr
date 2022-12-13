using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace TutorialMod.Content.Mounts
{
	public class BanebladeMount : ModMount
	{
		public override void UpdateEffects(Player player)
		{
			player.noKnockback = true;
			player.lifeRegen += 6;
			player.aggro += 800;
			player.statDefense *= 80;
			player.statDefense /= 10;
			player.statLifeMax2 *= 10;
			player.statLifeMax2 /= 4;
			player.armorEffectDrawOutlines = false;
			player.armorEffectDrawOutlinesForbidden = false;
			player.armorEffectDrawShadow = false;
			player.maxFallSpeed *= 2f;
			player.noFallDmg = true;
			player.buffImmune[30] = true; 
			player.buffImmune[24] = true;
			player.buffImmune[67] = true;
			player.buffImmune[20] = true;
			player.buffImmune[36] = true;
			player.nightVision = true;
		}

		public bool checkFuel(){
			Player player = Main.player[Main.myPlayer];
            if(player.HasItem(75))
            {
                for(int i=0; i < player.inventory.GetLength(0); i++)
                {
                    if (player.inventory[i].type == 75)
                    {
                    	player.inventory[i].stack--;
                    	return true;
                    }
                }
                return false;
            }else{
            	return false;
            }
		}

		public override void SetStaticDefaults()
		{
			MountData.textureHeight = 172;
			MountData.textureWidth = 300;
			MountData.spawnDust = 261;
			MountData.buff = ModContent.BuffType<Buffs.BanebladeBuff>();
			MountData.heightBoost = 40;
			MountData.fallDamage = 0.1f;
			if (checkFuel()){
				MountData.runSpeed = 12f;
                MountData.dashSpeed = 12f;
			}else{
				MountData.runSpeed = 11f;
                MountData.dashSpeed = 11f;
			}
			MountData.flightTimeMax = 0;
			MountData.fatigueMax = 100000;
			MountData.jumpHeight = 10;
			MountData.acceleration = 0.2f;
			MountData.jumpSpeed = 10f;
			MountData.blockExtraJumps = false;
			MountData.totalFrames = 1;
			MountData.constantJump = true;
			int[] array = new int[MountData.totalFrames];
			MountData.playerYOffsets = Enumerable.Repeat(20, MountData.totalFrames).ToArray(); 
			MountData.xOffset = 0;
			MountData.bodyFrame = 0;
			MountData.yOffset = -40;
			MountData.playerHeadOffset = 20;
			MountData.standingFrameCount = 1;
			MountData.standingFrameDelay = 12;
			MountData.standingFrameStart = 0;
			MountData.runningFrameCount = 1;
			MountData.runningFrameDelay = 12;
			MountData.runningFrameStart = 0;
			MountData.flyingFrameCount = 0;
			MountData.flyingFrameDelay = 0;
			MountData.flyingFrameStart = 0;
			MountData.inAirFrameCount = 1;
			MountData.inAirFrameDelay = 12;
			MountData.inAirFrameStart = 0;
			MountData.idleFrameCount = 1;
			MountData.idleFrameDelay = 12;
			MountData.idleFrameStart = 0;
			MountData.idleFrameLoop = true;
			MountData.swimFrameCount = MountData.inAirFrameCount;
			MountData.swimFrameDelay = MountData.inAirFrameDelay;
			MountData.swimFrameStart = MountData.inAirFrameStart;

			if (!Main.dedServ) {
				MountData.textureWidth = MountData.backTexture.Width() + 20;
				MountData.textureHeight = MountData.backTexture.Height();
			}
		}
	}
}
