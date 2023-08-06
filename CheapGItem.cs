using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CheapReforging
{
    public class CheapGItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public int reforgeCost = 0;

        public override bool ReforgePrice(Item item, ref int reforgePrice, ref bool canApplyDiscount)
        {
            if (CheapReforgingConfig.Instance.useFixedPrice)
            {
                reforgePrice = CheapReforgingConfig.Instance.fixedPrice;
                reforgePrice = Math.Clamp(reforgePrice, 1, int.MaxValue);
                canApplyDiscount = false;
            }
            else
            {
                reforgePrice = (int)(reforgePrice * CheapReforgingConfig.Instance.priceMult * 0.01f);
                reforgePrice += CheapReforgingConfig.Instance.priceAdd;
                reforgePrice = Math.Clamp(reforgePrice, 1, int.MaxValue);
            }
            reforgeCost = reforgePrice;
            return false;
        }

        public override void PostReforge(Item item)
        {
            if (CheapReforgingConfig.Instance.useRefund)
            {
                Item origItem = ContentSamples.ItemsByType[item.type];

                float statMult = 0;
                float refundMult = CheapReforgingConfig.Instance.refundMult;

                if (origItem.damage >= 0)
                {
                    statMult += 1 - item.damage / (float)origItem.damage;
                }
                if (origItem.crit >= 0)
                {
                    statMult += 1 - item.crit / (float)origItem.crit;
                }
                if (item.useTime > 0)
                {
                    statMult += 1 - origItem.useTime / (float)item.useTime;
                }
                if (origItem.shootSpeed > 0)
                {
                    statMult += 1 - item.shootSpeed / (float)origItem.shootSpeed;
                }
                if (origItem.mana > 0)
                {
                    statMult += 1 - item.mana / (float)origItem.mana;
                }
                if (origItem.knockBack > 0)
                {
                    statMult += 0.5f * (1 - item.knockBack / origItem.knockBack);
                }

                statMult = Math.Clamp(statMult * refundMult * 0.01f, 0, 10);

                Player player = Main.player[item.whoAmI];
                player.GetModPlayer<CheapPlayer>().refundValue = (int)(reforgeCost * statMult);

                reforgeCost = 0;
            }
        }
    }
}
