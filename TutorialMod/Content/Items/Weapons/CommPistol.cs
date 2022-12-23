using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using TutorialMod.Content.Projectiles.Weapons;


namespace TutorialMod.Content.Items.Weapons
{
    internal class CommPistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Commissar's Sidearm");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.value = Item.sellPrice(gold: 20);
            Item.rare = ItemRarityID.Red;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = false;
            Item.damage = 1;
            Item.knockBack = 10f;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.crit = 1;
            Item.shootSpeed = 20.0f;
            Item.shoot = ModContent.ProjectileType<CommBullet>();
            Item.mana = 10;
            Item.scale = 0.9f;
        }
        	
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }


        // public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            


        //     return false;  
        // }

    }
}
