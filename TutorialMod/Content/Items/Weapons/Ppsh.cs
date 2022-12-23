using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;

namespace TutorialMod.Content.Items.Weapons
{
    internal class Ppsh : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ppsh 41");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.DamageType = DamageClass.Ranged;
            Item.value = Item.sellPrice(gold: 20);
            Item.rare = ItemRarityID.Cyan;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item11;
            Item.autoReuse = true;
            Item.damage = 1000;
            Item.knockBack = 2f;
            Item.useTime = 2;
            Item.useAnimation = 2;
            Item.crit = 21;
            Item.shootSpeed = 20.0f;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = AmmoID.Bullet;
            //Item.scale = 0.17f;
        }
        	
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(RecipeGroupID.Wood, 10)
                .AddTile(TileID.WorkBenches)
                .Register();
        }

        public override Vector2? HoldoutOffset() {
            return new Vector2(-5f, 5f);
        }

        public override bool CanConsumeAmmo(Item ammo, Player player) {
            return Main.rand.NextFloat() >= 0.90f;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            
            if (type == ProjectileID.Bullet) { 
                type = ProjectileID.BulletHighVelocity; 
            }
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(20));
        }
    }
}
