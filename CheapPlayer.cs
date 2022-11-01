using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace CheapReforging
{
    public class CheapPlayer : ModPlayer
    {
        public int refundValue = 0;

        public override void ResetEffects()
        {
            //refundValue = 0;
        }

        public override void PostUpdate()
        {
            if (refundValue > 0)
            {
                int copperNum = 0;
                int silverNum = 0;
                int goldNum = 0;
                int platinumNum = 0;

                if (refundValue < 100)
                {
                    copperNum = refundValue;
                }
                else if (refundValue < 10000)
                {
                    silverNum = refundValue / 100;
                    copperNum = refundValue % 100;
                }
                else if (refundValue < 1000000)
                {
                    goldNum = refundValue / 10000;
                    silverNum = refundValue % 10000 / 100;
                    copperNum = refundValue % 100;
                }
                else
                {
                    platinumNum = refundValue / 1000000;
                    goldNum = refundValue % 1000000 / 10000;
                    silverNum = refundValue % 10000 / 100;
                    copperNum = refundValue % 100;
                }

                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.CopperCoin, copperNum);
                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.SilverCoin, silverNum);
                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.GoldCoin, goldNum);
                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.PlatinumCoin, platinumNum);

                refundValue = 0;
            }
        }
    }
}
