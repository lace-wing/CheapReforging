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

        public override void PostUpdate()
        {
            if (refundValue > 0)
            {
                int platinumNum = refundValue / 1000000;
                int goldNum = refundValue % 1000000 / 10000;
                int silverNum = refundValue % 10000 / 100;
                int copperNum = refundValue % 100;

                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.CopperCoin, copperNum);
                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.SilverCoin, silverNum);
                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.GoldCoin, goldNum);
                Player.QuickSpawnItem(Item.GetSource_TownSpawn(), ItemID.PlatinumCoin, platinumNum);

                refundValue = 0;
            }
        }
    }
}
