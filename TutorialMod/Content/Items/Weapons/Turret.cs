using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace TutorialMod.Content.Items.Weapons
{
    public class Turret : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Turret");
            Tooltip.SetDefault("Spawns Turret");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.value = Item.sellPrice(gold: 3);
            Item.DamageType = DamageClass.Ranged;
            Item.rare = 5;
            Item.mana = 10;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item79;
            Item.shoot = 3;
            Item.shootSpeed = 0.0f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
            //NPC.NewNPC((int)player.position.X, (int)player.position.Y, ModContent.NPCType<NPCs.Turret0>());
            var entitySource = player.GetSource_FromAI();
            NPC.NewNPC(entitySource, (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<NPCs.Turret0>(), player.whoAmI);
            return false;  
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
