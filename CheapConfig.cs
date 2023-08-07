using System;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CheapReforging
{
    public class CheapConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static CheapConfig Instance => ModContent.GetInstance<CheapConfig>();

        [Header("Price")]

        [DefaultValue(false)]
        public bool UseFixedPrice;

        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int FixedPrice;

        [Range(int.MinValue, int.MaxValue)]
        [DefaultValue(-50)]
        public int PriceAdd;

        [Range(0, 10000)]
        [DefaultValue(90)]
        public int PricePct;

        [Header("Refund")]

        [DefaultValue(true)]
        public bool UseRefund;

        [Range(0, 10000)]
        [DefaultValue(200)]
        public int RefundPct;
    }
}
