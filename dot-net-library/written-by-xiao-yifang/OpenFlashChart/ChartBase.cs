using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using JsonFx.Json;

namespace OpenFlashChart
{
    public  abstract class ChartBase
    {
        private string type;
        protected IList values;
        private double fillalpha;
        private double? fontsize;
        private string colour;
        private string text;
        private string tooltip;
        private DotStyle dotstyle;
        private bool attachtorightaxis;
        protected ChartBase()
        {
            this.values = new ArrayList();
            FillAlpha = 0.35;
            attachtorightaxis = false;
        }
        public void AttachToRightAxis(bool attach)
        {
            attachtorightaxis = attach;
        }
        [JsonProperty("axis")]
        [Description("use AttachToRight(),this property only for json generate.")]
        public string axis
        {
            get
            {
               if (attachtorightaxis)
                    return "right";
               return null;
            }
            set//when json serialize,it'll check CanWrite Property.
            {
                ;
            }
        }
        [JsonProperty("colour")]
        public  string Colour
        {
            set { this.colour = value; }
            get { return this.colour; }
        }
        public virtual  int GetValueCount()
        {
            return values.Count;
        }
        [JsonProperty("tip")]
        public virtual string Tooltip
        {
            set { this.tooltip = value; }
            get { return this.tooltip; }
        }

        [JsonProperty("values")]
        public virtual IList Values
        {
            set
            {
                // foreach (T t in value)
                // {
                //     this.values.Add(t);
                // }
                this.values = value;
            }
            get { return this.values; }
        }

        [JsonProperty("font-size")]
        [System.ComponentModel.DefaultValue(12.0)]
        public double? FontSize
        {
            get { return fontsize; }
            set { fontsize = value; }
        }

        [JsonProperty("text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        [JsonProperty("fillalpha")]
        public double FillAlpha
        {
            get { return fillalpha; }
            set { fillalpha = value; }
        }

        [JsonProperty("type")]
        public string ChartType
        {
            get { return type; }
            set { type = value; }
        }
        [JsonProperty("dot-style")]
        public DotStyle DotStyleType
        {
            get
            {
                if(dotstyle==null)
                    dotstyle=new DotStyle();
                return dotstyle;
            }
            set
            {
                if(dotstyle==null)
                    dotstyle=new DotStyle();
                dotstyle = value;
            }
        }

        //public abstract Double GetMinValue();
        //public abstract Double GetMaxValue();
        
        public  void Set_Key(string key, double font_size)
        {
            this.Text = key;
            FontSize = font_size;
        }
        public void Add(object v)
        {
            this.values.Add(v);
        }
    }
}
