using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 날짜 : 2021-05-27 AM 2:00:54
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public static class RColor
    {
        /***********************************************************************
        *                               Basic Colors
        ***********************************************************************/
        #region .

        public static Color black { get; } = new Color(0.00f, 0.00f, 0.00f, 1.00f);
        public static Color gray { get; }  = new Color(0.50f, 0.50f, 0.50f, 1.00f);
        public static Color white { get; } = new Color(1.00f, 1.00f, 1.00f, 1.00f);

        // 원색
        public static Color red     => Red.Normal;
        public static Color green   => Green.Normal;
        public static Color blue    => Blue.Normal;

        // 혼합색 1 : 보라~핑크 계열
        public static Color pink => Pink.Normal;
        public static Color magenta => Magenta.Normal;
        public static Color violet => Violet.Normal;
        public static Color purple => Purple.Normal;

        // 혼합색 2 : 노랑 계열
        public static Color brown   => Brown.Normal;
        public static Color gold    => Gold.Normal;
        public static Color orange  => Orange.Normal;
        public static Color yellow => Yellow.Normal;

        // 혼합색 3 : 청록 계열
        public static Color lime    => Lime.Normal;
        public static Color mint    => Mint.Normal;
        public static Color cyan => Cyan.Normal;
        #endregion
        /***********************************************************************
        *                               Color Properties
        ***********************************************************************/
        #region .
        public static Color Black { get; } = new Color(0.00f, 0.00f, 0.00f, 1.00f);
        public static Color White { get; } = new Color(1.00f, 1.00f, 1.00f, 1.00f);

        public static GrayColor Gray { get; } = new GrayColor();
        public static RedColor Red { get; } = new RedColor();
        public static GreenColor Green { get; } = new GreenColor();
        public static BlueColor Blue { get; } = new BlueColor();

        public static PinkColor Pink { get; } = new PinkColor();
        public static MagentaColor Magenta { get; } = new MagentaColor();
        public static VioletColor Violet { get; } = new VioletColor();
        public static PurpleColor Purple { get; } = new PurpleColor();

        public static BrownColor Brown { get; } = new BrownColor();
        public static GoldColor Gold { get; } = new GoldColor();
        public static OrangeColor Orange { get; } = new OrangeColor();
        public static YellowColor Yellow { get; } = new YellowColor();

        public static LimeColor Lime { get; } = new LimeColor();
        public static MintColor Mint { get; } = new MintColor();
        public static CyanColor Cyan { get; } = new CyanColor();

        public static Color Gray1 { get; } = new Color(0.10f, 0.10f, 0.10f, 1.00f);
        public static Color Gray2 { get; } = new Color(0.20f, 0.20f, 0.20f, 1.00f);
        public static Color Gray3 { get; } = new Color(0.30f, 0.30f, 0.30f, 1.00f);
        public static Color Gray4 { get; } = new Color(0.40f, 0.40f, 0.40f, 1.00f);
        public static Color Gray5 { get; } = new Color(0.50f, 0.50f, 0.50f, 1.00f);
        public static Color Gray6 { get; } = new Color(0.60f, 0.60f, 0.60f, 1.00f);
        public static Color Gray7 { get; } = new Color(0.70f, 0.70f, 0.70f, 1.00f);
        public static Color Gray8 { get; } = new Color(0.80f, 0.80f, 0.80f, 1.00f);
        public static Color Gray9 { get; } = new Color(0.90f, 0.90f, 0.90f, 1.00f);
        #endregion
        /***********************************************************************
        *                               Color Definitions
        ***********************************************************************/
        #region .
        public abstract class SixGradedColor
        {
            public abstract Color Darker { get; }
            public abstract Color Dark { get; }
            public abstract Color Normal { get; }
            public abstract Color Soft { get; }
            public abstract Color Light { get; }
            public abstract Color Bright { get; }
        }

        public class GrayColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.15f, 0.15f, 0.15f, 1.00f);
            public override Color Dark   { get; } = new Color(0.33f, 0.33f, 0.33f, 1.00f);
            public override Color Normal { get; } = new Color(0.50f, 0.50f, 0.50f, 1.00f);
            public override Color Soft   { get; } = new Color(0.63f, 0.63f, 0.63f, 1.00f);
            public override Color Light  { get; } = new Color(0.75f, 0.75f, 0.75f, 1.00f);
            public override Color Bright { get; } = new Color(0.88f, 0.88f, 0.88f, 1.00f);

            public static implicit operator Color(GrayColor _) => Gray.Normal;
        }
        public class RedColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.50f, 0.00f, 0.00f, 1.00f);
            public override Color Dark { get; } = new Color(0.75f, 0.00f, 0.00f, 1.00f);
            public override Color Normal { get; } = new Color(1.00f, 0.00f, 0.00f, 1.00f);
            public override Color Soft { get; } = new Color(1.00f, 0.25f, 0.25f, 1.00f);
            public override Color Light { get; } = new Color(1.00f, 0.50f, 0.50f, 1.00f);
            public override Color Bright { get; } = new Color(1.00f, 0.75f, 0.75f, 1.00f);

            public static implicit operator Color(RedColor _) => Red.Normal;
        }
        public class GreenColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.00f, 0.50f, 0.00f, 1.00f);
            public override Color Dark   { get; } = new Color(0.00f, 0.75f, 0.00f, 1.00f);
            public override Color Normal { get; } = new Color(0.00f, 1.00f, 0.00f, 1.00f);
            public override Color Soft   { get; } = new Color(0.25f, 1.00f, 0.25f, 1.00f);
            public override Color Light  { get; } = new Color(0.50f, 1.00f, 0.50f, 1.00f);
            public override Color Bright { get; } = new Color(0.75f, 1.00f, 0.75f, 1.00f);

            public static implicit operator Color(GreenColor _) => Green.Normal;
        }
        public class BlueColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.00f, 0.00f, 0.50f, 1.00f);
            public override Color Dark   { get; } = new Color(0.00f, 0.00f, 0.75f, 1.00f);
            public override Color Normal { get; } = new Color(0.00f, 0.00f, 1.00f, 1.00f);
            public override Color Soft   { get; } = new Color(0.25f, 0.25f, 1.00f, 1.00f);
            public override Color Light  { get; } = new Color(0.50f, 0.50f, 1.00f, 1.00f);
            public override Color Bright { get; } = new Color(0.75f, 0.75f, 1.00f, 1.00f);

            public static implicit operator Color(BlueColor _) => Blue.Normal;
        }

        // 보라~핑크 계열
        public class PinkColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.50f, 0.00f, 0.25f, 1.00f);
            public override Color Dark { get; } = new Color(0.75f, 0.00f, 0.38f, 1.00f);
            public override Color Normal { get; } = new Color(1.00f, 0.00f, 0.50f, 1.00f);
            public override Color Soft { get; } = new Color(1.00f, 0.25f, 0.63f, 1.00f);
            public override Color Light { get; } = new Color(1.00f, 0.50f, 0.75f, 1.00f);
            public override Color Bright { get; } = new Color(1.00f, 0.75f, 0.88f, 1.00f);

            public static implicit operator Color(PinkColor _) => Pink.Normal;
        }
        public class MagentaColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.50f, 0.00f, 0.50f, 1.00f);
            public override Color Dark   { get; } = new Color(0.75f, 0.00f, 0.75f, 1.00f);
            public override Color Normal { get; } = new Color(1.00f, 0.00f, 1.00f, 1.00f);
            public override Color Soft   { get; } = new Color(1.00f, 0.25f, 1.00f, 1.00f);
            public override Color Light  { get; } = new Color(1.00f, 0.50f, 1.00f, 1.00f);
            public override Color Bright { get; } = new Color(1.00f, 0.75f, 1.00f, 1.00f);

            public static implicit operator Color(MagentaColor _) => Magenta.Normal;
        }
        public class VioletColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.25f, 0.00f, 0.50f, 1.00f);
            public override Color Dark { get; } = new Color(0.50f, 0.00f, 0.75f, 1.00f);
            public override Color Normal { get; } = new Color(0.75f, 0.00f, 1.00f, 1.00f);
            public override Color Soft { get; } = new Color(0.81f, 0.25f, 1.00f, 1.00f);
            public override Color Light { get; } = new Color(0.87f, 0.50f, 1.00f, 1.00f);
            public override Color Bright { get; } = new Color(0.93f, 0.75f, 1.00f, 1.00f);

            public static implicit operator Color(VioletColor _) => Violet.Normal;
        }
        public class PurpleColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.25f, 0.00f, 0.50f, 1.00f);
            public override Color Dark { get; } = new Color(0.38f, 0.00f, 0.75f, 1.00f);
            public override Color Normal { get; } = new Color(0.50f, 0.00f, 1.00f, 1.00f);
            public override Color Soft { get; } = new Color(0.63f, 0.25f, 1.00f, 1.00f);
            public override Color Light { get; } = new Color(0.75f, 0.50f, 1.00f, 1.00f);
            public override Color Bright { get; } = new Color(0.88f, 0.75f, 1.00f, 1.00f);

            public static implicit operator Color(PurpleColor _) => Purple.Normal;
        }

        // 노랑 계열
        public class BrownColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.20f, 0.00f, 0.00f, 1.00f);
            public override Color Dark   { get; } = new Color(0.35f, 0.00f, 0.00f, 1.00f);
            public override Color Normal { get; } = new Color(0.50f, 0.10f, 0.00f, 1.00f);
            public override Color Soft   { get; } = new Color(0.50f, 0.20f, 0.00f, 1.00f);
            public override Color Light  { get; } = new Color(0.55f, 0.30f, 0.15f, 1.00f);
            public override Color Bright { get; } = new Color(0.75f, 0.50f, 0.35f, 1.00f);

            public static implicit operator Color(BrownColor _) => Brown.Normal;
        }
        public class GoldColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.45f, 0.35f, 0.00f, 1.00f);
            public override Color Dark   { get; } = new Color(0.65f, 0.50f, 0.00f, 1.00f);
            public override Color Normal { get; } = new Color(1.00f, 0.75f, 0.00f, 1.00f);
            public override Color Soft   { get; } = new Color(1.00f, 0.85f, 0.40f, 1.00f);
            public override Color Light  { get; } = new Color(1.00f, 0.90f, 0.60f, 1.00f);
            public override Color Bright { get; } = new Color(1.00f, 0.95f, 0.75f, 1.00f);

            public static implicit operator Color(GoldColor _) => Gold.Normal;
        }
        public class OrangeColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.50f, 0.25f, 0.05f, 1.00f);
            public override Color Dark   { get; } = new Color(0.70f, 0.30f, 0.05f, 1.00f);
            public override Color Normal { get; } = new Color(1.00f, 0.40f, 0.00f, 1.00f);
            public override Color Soft   { get; } = new Color(1.00f, 0.55f, 0.25f, 1.00f);
            public override Color Light  { get; } = new Color(1.00f, 0.70f, 0.40f, 1.00f);
            public override Color Bright { get; } = new Color(1.00f, 0.85f, 0.55f, 1.00f);

            public static implicit operator Color(OrangeColor _) => Orange.Normal;
        }
        public class YellowColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.50f, 0.50f, 0.00f, 1.00f);
            public override Color Dark { get; } = new Color(0.75f, 0.75f, 0.00f, 1.00f);
            public override Color Normal { get; } = new Color(1.00f, 1.00f, 0.00f, 1.00f);
            public override Color Soft { get; } = new Color(1.00f, 1.00f, 0.25f, 1.00f);
            public override Color Light { get; } = new Color(1.00f, 1.00f, 0.50f, 1.00f);
            public override Color Bright { get; } = new Color(1.00f, 1.00f, 0.75f, 1.00f);

            public static implicit operator Color(YellowColor _) => Yellow.Normal;
        }

        // 청록 계열
        public class LimeColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.38f, 0.50f, 0.00f, 1.00f);
            public override Color Dark   { get; } = new Color(0.57f, 0.75f, 0.00f, 1.00f);
            public override Color Normal { get; } = new Color(0.75f, 1.00f, 0.00f, 1.00f);
            public override Color Soft   { get; } = new Color(0.81f, 1.00f, 0.25f, 1.00f);
            public override Color Light  { get; } = new Color(0.88f, 1.00f, 0.50f, 1.00f);
            public override Color Bright { get; } = new Color(0.93f, 1.00f, 0.75f, 1.00f);

            public static implicit operator Color(LimeColor _) => Lime.Normal;
        }
        public class MintColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.00f, 0.50f, 0.25f, 1.00f);
            public override Color Dark   { get; } = new Color(0.00f, 0.75f, 0.38f, 1.00f);
            public override Color Normal { get; } = new Color(0.00f, 1.00f, 0.50f, 1.00f);
            public override Color Soft   { get; } = new Color(0.25f, 1.00f, 0.63f, 1.00f);
            public override Color Light  { get; } = new Color(0.50f, 1.00f, 0.75f, 1.00f);
            public override Color Bright { get; } = new Color(0.75f, 1.00f, 0.88f, 1.00f);

            public static implicit operator Color(MintColor _) => Mint.Normal;
        }
        public class CyanColor : SixGradedColor
        {
            public override Color Darker { get; } = new Color(0.00f, 0.50f, 0.50f, 1.00f);
            public override Color Dark { get; } = new Color(0.00f, 0.75f, 0.75f, 1.00f);
            public override Color Normal { get; } = new Color(0.00f, 1.00f, 1.00f, 1.00f);
            public override Color Soft { get; } = new Color(0.25f, 1.00f, 1.00f, 1.00f);
            public override Color Light { get; } = new Color(0.50f, 1.00f, 1.00f, 1.00f);
            public override Color Bright { get; } = new Color(0.75f, 1.00f, 1.00f, 1.00f);

            public static implicit operator Color(CyanColor _) => Cyan.Normal;
        }

        #endregion
    }
}