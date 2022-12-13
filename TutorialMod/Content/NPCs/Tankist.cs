using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;

namespace TutorialMod.Content.NPCs
{
    [AutoloadHead]
    public class Tankist : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tankist");
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 20;
            NPC.height = 20;
            NPC.aiStyle = 7;
            NPC.defense = 76;
            NPC.lifeMax = 1945;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.7f;
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 0;
            NPCID.Sets.AttackFrameCount[NPC.type] = 1;
            NPCID.Sets.DangerDetectRange[NPC.type] = 700;
            NPCID.Sets.AttackType[NPC.type] = 1;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 90;
            NPCID.Sets.HatOffsetY[NPC.type] = 4;
            NPC.Happiness
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Like) // Example Person prefers the forest.
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike) // Example Person dislikes the snow.
                .SetNPCAffection(NPCID.Guide, AffectionLevel.Like) // Likes living near the guide.
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Love) // Hates living near the demolitionist.
            ;
            AnimationType = 22;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            for (var i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (!player.active) {
                    continue;
                }
                foreach (Item item in player.inventory)
                {
                    if (item.type == ModContent.ItemType<Items.Weapons.Baneblade>())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Dmitry",
                "Zinoviy",
                "Wittmann",
                "Fritz"
            };
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Shop";
            button2 = "Advice";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            //clockwork AR
            shop.item[nextSlot].SetDefaults(434, false);
            shop.item[nextSlot].value = 1000;
            nextSlot++;

            shop.item[nextSlot].SetDefaults(391, false);
            shop.item[nextSlot].value = 1000;          
            nextSlot++;

            shop.item[nextSlot].SetDefaults(174, false);
            shop.item[nextSlot].value = 50;          
            nextSlot++;

            if (NPC.downedMechBoss3 && NPC.downedMechBoss2 && NPC.downedMechBoss1)
            {
                shop.item[nextSlot].SetDefaults(1265, false);
                shop.item[nextSlot].value = 800000;
                nextSlot++;
            }
        }

        public override string GetChat()
        {
            NPC.FindFirstNPC(ModContent.NPCType<Tankist>());
            Player player = Main.player[Main.myPlayer];
            player.AddBuff(5, 30000);
            player.AddBuff(12, 30000);

            switch (Main.rand.Next(3))
            {
                case 0:
                    return "If the tanks succeed, then victory follows.";
                case 1:
                    return "My men can eat their belts, but my tanks have gotta have gas.";
                case 2:
                    return "If everyone is thinking alike, someone isn’t thinking.";
                default:
                    return "The nature of encounter operations required of the commanders limitless initiative and constant readiness to take the responsibility for military actions.";
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 91;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 5;
            randExtraCooldown = 5;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.BulletHighVelocity;
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 10f;
            randomOffset = 1f;
        }

    }
}