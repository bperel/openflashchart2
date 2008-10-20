﻿using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OpenFlashChart;
public partial class datafile_HBar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OpenFlashChart.OpenFlashChart chart = new OpenFlashChart.OpenFlashChart();
        chart.Title = new Title("Bar Chart");

        HBar bar = new OpenFlashChart.HBar();
        bar.Colour = "#345";

        bar.Fillalpha = 0.4;
        bar.Text = "Test";

        bar.Fontsize = 10;
        bar.AppendValue(new HBarValue(0,5));
        bar.AppendValue(new HBarValue(6,8));
        bar.AppendValue(new HBarValue(8,10));
        chart.AddElement(bar);
         chart.Y_Axis.SetLabels(new string[] { "hbar1", "hbar2", "hbar3" });
        chart.Tooltip = new ToolTip("提示:#val#");
        string s = chart.ToPrettyString();

        Response.Clear();
        Response.CacheControl = "no-cache";
        Response.Write(s);
        Response.End();
    }
}