using System;
using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CheapReforging
{
    public class CheapReforgingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static CheapReforgingConfig Instance => ModContent.GetInstance<CheapReforgingConfig>();

        //public override void OnLoaded() => Config = this;

        private const string PriceKey = "$Mods.CheapReforging.Config.ReforgePrice.";
        private const string RefundKey = "$Mods.CheapReforging.Config.ReforgeRefund.";

        [Header(PriceKey + "Header")]

        [DefaultValue(false)]
        public bool useFixedPrice;

        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int fixedPrice;

        [Range(int.MinValue, int.MaxValue)]
        [DefaultValue(-50)]
        public int priceAdd;

        [Range(0, 10000f)]
        [DefaultValue(90)]
        public int priceMult;

        [Header(RefundKey + "Header")]

        [DefaultValue(true)]
        public bool useRefund;

        [Range(0, 10000)]
        [DefaultValue(200)]
        public int refundMult;
    }
}
