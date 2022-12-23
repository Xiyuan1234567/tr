using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using TutorialMod.Content.Projectiles.Weapons;
using System;
using Microsoft.Xna.Framework;

namespace TutorialMod.Content.Items.Weapons
{
    internal class TutorialWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Holy Bolter");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.value = Item.sellPrice(gold: 90);
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.mana = 1;
            Item.damage = 9000;
            Item.knockBack = 6f;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.UseSound = SoundID.Item71;
            Item.crit = 15;
            Item.shoot = ModContent.ProjectileType<TutorialWandProjectile>();
            Item.shootSpeed = 16.0f;
        }
        	
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
