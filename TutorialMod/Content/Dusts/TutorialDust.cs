using Terraria;
using Terraria.ModLoader;

namespace TutorialMod.Content.Dusts
{
    internal class TutorialDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            Lighting.AddLight(dust.position, 0.75f, 0.75f, 0.75f);

            return false;
        }
    }
}
