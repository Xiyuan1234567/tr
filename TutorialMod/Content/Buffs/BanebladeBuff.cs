using System;
using Terraria;
using Terraria.ModLoader;

namespace TutorialMod.Content.Buffs
{
	public class BanebladeBuff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Baneblade!");
			Description.SetDefault("Drive me closer...");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			player.mount.SetMount(ModContent.MountType<Mounts.BanebladeMount>(), player);
			player.buffTime[buffIndex] = 10;
		}
	}
}
