#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-06-02 PM 4:17:12
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public partial class BoolField : DrawingElement<bool, BoolField>
    {
        public static BoolField Default => ThemeDict[EzEditorUtility.DefaultColorTheme];
        public static readonly Dictionary<EColor, BoolField> ThemeDict = new Dictionary<EColor, BoolField>()
        {
            { EColor.Gray   , Gray    },
            { EColor.White  , White   },
            { EColor.Black  , Black   },
            { EColor.Red    , Red     },
            { EColor.Green  , Green   },
            { EColor.Blue   , Blue    },
            { EColor.Pink   , Pink    },
            { EColor.Magenta, Magenta },
            { EColor.Violet , Violet  },
            { EColor.Purple , Purple  },
            { EColor.Brown  , Brown   },
            { EColor.Gold   , Gold    },
            { EColor.Orange , Orange  },
            { EColor.Yellow , Yellow  },
            { EColor.Lime   , Lime    },
            { EColor.Mint   , Mint    },
            { EColor.Cyan   , Cyan    },
        };
        protected GUIStyle labelStyle;

        // Data
        protected GUIContent labelContent;
        protected float widthThreshold = 0.4f;
        protected bool toggleLeft = false;

        // Styles - Label
        public Color labelColor = Color.white;
        public int labelFontSize = 12;
        public FontStyle labelFontStyle = FontStyle.Normal;
        public TextAnchor labelAlignment = TextAnchor.MiddleLeft;

        // Styles - Toggle
        public Color toggleColor = Color.white;

        public override BoolField Clone()
        {
            return new BoolField
            {
                labelColor = labelColor,
                labelFontSize = labelFontSize,
                labelFontStyle = labelFontStyle,
                labelAlignment = labelAlignment,
                toggleColor = toggleColor
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .

        public BoolField SetLabelColor(Color color)
        {
            this.labelColor = color;
            return this;
        }
        public BoolField SetLabelFontSize(int fontSize)
        {
            this.labelFontSize = fontSize;
            return this;
        }
        public BoolField SetLabelFontStyle(FontStyle fontStyle)
        {
            this.labelFontStyle = fontStyle;
            return this;
        }
        public BoolField SetLabelTextAlignment(TextAnchor allignment)
        {
            this.labelAlignment = allignment;
            return this;
        }

        public BoolField SetToggleColor(Color color)
        {
            this.toggleColor = color;
            return this;
        }

        #endregion

        public BoolField SetData(string label, bool value, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.value = value;
            this.widthThreshold = widthThreshold;
            this.toggleLeft = false;

            return this;
        }

        public BoolField SetData(string label, bool value, bool toggleLeft, float widthThreshold = 0.4f)
        {
            this.labelContent = new GUIContent(label);
            this.value = value;
            this.widthThreshold = widthThreshold;
            this.toggleLeft = toggleLeft;

            return this;
        }

        public override BoolField Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            if (labelStyle == null)
                labelStyle = new GUIStyle(GUI.skin.label);

            labelStyle.normal.textColor = labelColor;
            labelStyle.hover.textColor = labelColor.AddRGB(0.25f);
            labelStyle.focused.textColor = labelColor.AddRGB(0.25f);
            labelStyle.fontSize = labelFontSize;
            labelStyle.fontStyle = labelFontStyle;
            labelStyle.alignment = labelAlignment;

            ref float t = ref widthThreshold;
            float omt = 1f - t;
            Rect leftRect = new Rect(rect.x, rect.y, rect.width * t, rect.height);
            Rect rightRect = new Rect(rect.x + rect.width * t, rect.y, rect.width * omt, rect.height);

            // 1. Label
            EditorGUI.PrefixLabel(!toggleLeft ? leftRect : rightRect, labelContent, labelStyle);

            // 2. Toggle
            var oldToggleColor = GUI.color;
            GUI.color = toggleColor;

            EditorGUI.BeginChangeCheck();

            value = EditorGUI.Toggle(toggleLeft ? leftRect : rightRect, "", value);

            isChanged = EditorGUI.EndChangeCheck();

            GUI.color = oldToggleColor;

            CheckDebugs();
            EndDraw();
            return this;
        }
    }
    public partial class Toggle : DrawingElement<bool, Toggle>
    {
        public static Toggle Default => ThemeDict[EzEditorUtility.DefaultColorTheme];
        public static readonly Dictionary<EColor, Toggle> ThemeDict = new Dictionary<EColor, Toggle>()
        {
            { EColor.Gray   , Gray    },
            { EColor.White  , White   },
            { EColor.Black  , Black   },
            { EColor.Red    , Red     },
            { EColor.Green  , Green   },
            { EColor.Blue   , Blue    },
            { EColor.Pink   , Pink    },
            { EColor.Magenta, Magenta },
            { EColor.Violet , Violet  },
            { EColor.Purple , Purple  },
            { EColor.Brown  , Brown   },
            { EColor.Gold   , Gold    },
            { EColor.Orange , Orange  },
            { EColor.Yellow , Yellow  },
            { EColor.Lime   , Lime    },
            { EColor.Mint   , Mint    },
            { EColor.Cyan   , Cyan    },
        };

        // Style
        public Color color = Color.white;

        public override Toggle Clone()
        {
            return new Toggle
            {
                color = color
            };
        }

        /***********************************************************************
        *                               Style Setters
        ***********************************************************************/
        #region .
        public Toggle SetColor(Color color)
        {
            this.color = color;
            return this;
        }

        #endregion

        public Toggle SetData(bool value)
        {
            this.value = value;
            return this;
        }

        public override Toggle Draw(float xLeft, float xRight, float yOffset, float height,
            float xLeftOffset = 0f, float xRightOffset = 0f)
        {
            if (CheckDrawErrors()) return this;
            SetRect(xLeft, xRight, yOffset, height, xLeftOffset, xRightOffset);

            // NOTE : backgroundColor, contentColor 적용 안됨

            var oldColor = GUI.color;
            GUI.color = color;

            EditorGUI.BeginChangeCheck();

            value = EditorGUI.Toggle(rect, "", value);

            isChanged = EditorGUI.EndChangeCheck();

            GUI.color = oldColor;

            CheckDebugs();
            EndDraw();
            return this;
        }
    }
}

#endif