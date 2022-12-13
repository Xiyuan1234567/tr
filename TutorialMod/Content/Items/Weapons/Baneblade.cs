using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;


namespace TutorialMod.Content.Items.Weapons
{
	public class Baneblade : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baneblade!");
			Tooltip.SetDefault("Drive me closer, I want to hit them with my sword!");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.width = 50;
			Item.height = 50;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(gold: 3);
			Item.rare = 5;
			Item.noMelee = true;
			Item.UseSound = SoundID.Item79;
			Item.mountType = ModContent.MountType<Mounts.BanebladeMount>();
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
