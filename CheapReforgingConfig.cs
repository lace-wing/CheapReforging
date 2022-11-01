using IL.Terraria.GameContent;
using On.Terraria.GameContent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CheapReforging
{
    [Label("Mods.CheapReforging.Config.CRConfig.Label")]
    public class CheapReforgingConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        public static CheapReforgingConfig Instance => ModContent.GetInstance<CheapReforgingConfig>();

        //public override void OnLoaded() => Config = this;

        private const string PriceKey = "Mods.CheapReforging.Config.ReforgePrice.";
        private const string RefundKey = "Mods.CheapReforging.Config.ReforgeRefund.";

        [Header(PriceKey + "Header")]

        [Label(PriceKey + "UseFixed.Label")]
        [Tooltip(PriceKey + "UseFixed.Tooltip")]
        [DefaultValue(true)]
        public bool useFixedPrice;

        [Label(PriceKey + "Fixed.Label")]
        [Tooltip(PriceKey + "Fixed.Tooltip")]
        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int fixedPrice;

        [Label(PriceKey + "Add.Label")]
        [Tooltip(PriceKey + "Add.Tooltip")]
        [Range(int.MinValue, int.MaxValue)]
        [DefaultValue(0)]
        public int priceAdd;

        [Label(PriceKey + "Mult.Label")]
        [Tooltip(PriceKey + "Mult.Tooltip")]
        [Range(0.01f, 100f)]
        [DefaultValue(1f)]
        public float priceMult;

        [Header(RefundKey + "Header")]

        [Label(RefundKey + "UseRefund.Label")]
        [Tooltip(RefundKey + "UseRefund.Tooltip")]
        [DefaultValue(false)]
        public bool useRefund;

        [Label(RefundKey + "Mult.Label")]
        [Tooltip(RefundKey + "Mult.Tooltip")]
        [Range(0.01f, 100)]
        [DefaultValue(100f)]
        public float refundMult;
    }
}
