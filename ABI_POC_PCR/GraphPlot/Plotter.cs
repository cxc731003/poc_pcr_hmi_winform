using ScottPlot;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABI_POC_PCR.GraphPlot
{
    
    public static class Plotter //Static으로 선언 (그래프와 관련된 함수 모음)
    {
        public static int OPT_VAL_CNT = 4;
        public static int CH_CNT = 4;
        public static int DYE_CNT = 4;
        public static int COL_CNT = 39; // base, 15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,45
        public static int CYCLE_CNT = 46; // 45 cycle = 46-1
        public static int optic_CycleCnt_ForBase = 8;

        public static int[] Optic_Measure_Idx = new int[39] // must be same with COL_CNT
        {
           //1, 2,
            3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,
            21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,
            37,38,39,40,45
            //41,42,43,44,45,
        };

        public static int[] isOpticData_buffer_filled = new int[39]//// must be same with COL_CNT
       {

            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, //9
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, //19
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, //29
            0, 0, 0, 0, 0, 0, 0, 0, 0 //39

       };


        public static bool isValueBase = false;
      
        public static PlottableScatterHighlight ch1FAMHL, ch1ROXHL, ch1HEXHL, ch1CY5HL;
        public static PlottableScatterHighlight ch2FAMHL, ch2ROXHL, ch2HEXHL, ch2CY5HL;
        public static PlottableScatterHighlight ch3FAMHL, ch3ROXHL, ch3HEXHL, ch3CY5HL;
        public static PlottableScatterHighlight ch4FAMHL, ch4ROXHL, ch4HEXHL, ch4CY5HL;

        public static PlottableScatterHighlight[] chFAMHLArray = new PlottableScatterHighlight[4] {ch1FAMHL, ch2FAMHL, ch3FAMHL, ch4FAMHL };
        public static PlottableScatterHighlight[] chROXHLArray = new PlottableScatterHighlight[4] {ch1ROXHL, ch2ROXHL, ch3ROXHL, ch4ROXHL };
        public static PlottableScatterHighlight[] chHEXHLArray = new PlottableScatterHighlight[4] {ch1HEXHL, ch2HEXHL, ch3HEXHL, ch4HEXHL };
        public static PlottableScatterHighlight[] chCY5HLArray = new PlottableScatterHighlight[4] {ch1CY5HL, ch2CY5HL, ch3CY5HL, ch4CY5HL };

        public static PlottableScatter ch1FAM, ch1ROX, ch1HEX, ch1CY5;
        public static PlottableScatter ch2FAM, ch2ROX, ch2HEX, ch2CY5;
        public static PlottableScatter ch3FAM, ch3ROX, ch3HEX, ch3CY5;
        public static PlottableScatter ch4FAM, ch4ROX, ch4HEX, ch4CY5;

        public static PlottableScatter[] chFAMArray = new PlottableScatter[4] { ch1FAM, ch2FAM, ch3FAM, ch4FAM };
        public static PlottableScatter[] chROXArray = new PlottableScatter[4] { ch1ROX, ch2ROX, ch3ROX, ch4ROX };
        public static PlottableScatter[] chHEXArray = new PlottableScatter[4] { ch1HEX, ch2HEX, ch3HEX, ch4HEX };
        public static PlottableScatter[] chCY5Array = new PlottableScatter[4] { ch1CY5, ch2CY5, ch3CY5, ch4CY5 };
        public static Dictionary<string, List<double>> ch1DataDic, ch2DataDic, ch3DataDic, ch4DataDic;

        private static bool[] chFAMIsCheck = new bool[4] { true, true, true, true };
        private static bool[] chROXIsCheck = new bool[4] { true, true, true, true };
        private static bool[] chHEXIsCheck = new bool[4] { true, true, true, true };
        private static bool[] chCY5IsCheck = new bool[4] { true, true, true, true };

        private static bool[] chFAMHLIsCheck = new bool[4] { true, true, true, true };
        private static bool[] chROXHLIsCheck = new bool[4] { true, true, true, true };
        private static bool[] chHEXHLIsCheck = new bool[4] { true, true, true, true };
        private static bool[] chCY5HLIsCheck = new bool[4] { true, true, true, true };

        private static List<string> labelTicks = new List<string>();
        //private static string[] labelTicksArray = new string[8] {"Base", "15", "20", "25", "30", "35", "40", "Final" };

        public static string[] labelTicksArray = new string[39]; // must be same with col_cnt 

        public static void Init()
        {
            ch1DataDic = new Dictionary<string, List<double>>();
            ch2DataDic = new Dictionary<string, List<double>>();
            ch3DataDic = new Dictionary<string, List<double>>();
            ch4DataDic = new Dictionary<string, List<double>>();

            ch1DataDic.Add("FAM", new List<double>());
            ch1DataDic.Add("ROX", new List<double>());
            ch1DataDic.Add("HEX", new List<double>());
            ch1DataDic.Add("CY5", new List<double>());

            ch2DataDic.Add("FAM", new List<double>());
            ch2DataDic.Add("ROX", new List<double>());
            ch2DataDic.Add("HEX", new List<double>());
            ch2DataDic.Add("CY5", new List<double>());

            ch3DataDic.Add("FAM", new List<double>());
            ch3DataDic.Add("ROX", new List<double>());
            ch3DataDic.Add("HEX", new List<double>());
            ch3DataDic.Add("CY5", new List<double>());

            ch4DataDic.Add("FAM", new List<double>());
            ch4DataDic.Add("ROX", new List<double>());
            ch4DataDic.Add("HEX", new List<double>());
            ch4DataDic.Add("CY5", new List<double>());
            

                    }

        public static void UpdatePlot(FormsPlot formsPlot, string title, int chamberNum
                                        , Dictionary<string, List<double>> chDataDic
                                        , CheckBox cBoxFAM, CheckBox cBoxROX, CheckBox cBoxHEX, CheckBox cBoxCYS, double Ct_FAM, double Ct_ROX, double Ct_HEX, double Ct_CY5)
        {
            labelTicks = new List<string>();
            formsPlot.plt.Clear();

            //formsPlot.Configure(enablePanning: false, enableZooming: false);
            //vLine = formsPlot1.plt.PlotVLine(0, color: Color.Red, lineStyle: LineStyle.Dash);
            //hLine = formsPlot1.plt.PlotHLine(0, color: Color.Red, lineStyle: LineStyle.Dash);

            var dataXList = new List<double>();
            //for (int i = 0; i < 30; i++)
            for (int i = 0; i < chDataDic["FAM"].Count; i++)
                dataXList.Add(i);

            if (chDataDic["FAM"].Count > 0)
            {
                chFAMArray[chamberNum] = formsPlot.plt.PlotScatter(dataXList.ToArray(), chDataDic["FAM"].ToArray(), label: "FAM", lineWidth:0); //ROX, HEX, CYS
                chFAMArray[chamberNum].visible = chFAMIsCheck[chamberNum];

            }
            if (chDataDic["ROX"].Count > 0)
            {
                chROXArray[chamberNum] = formsPlot.plt.PlotScatter(dataXList.ToArray(), chDataDic["ROX"].ToArray(), label: "ROX", lineWidth: 0); //ROX, HEX, CYS
                chROXArray[chamberNum].visible = chROXIsCheck[chamberNum];
            }
            if (chDataDic["HEX"].Count > 0)
            {
                chHEXArray[chamberNum] = formsPlot.plt.PlotScatter(dataXList.ToArray(), chDataDic["HEX"].ToArray(), label: "HEX", lineWidth: 0); //ROX, HEX, CYS
                chHEXArray[chamberNum].visible = chHEXIsCheck[chamberNum];
            }
            if (chDataDic["CY5"].Count > 0)
            {
                chCY5Array[chamberNum] = formsPlot.plt.PlotScatter(dataXList.ToArray(), chDataDic["CY5"].ToArray(), label: "CY5", lineWidth: 0); //ROX, HEX, CYS
                chCY5Array[chamberNum].visible = chCY5IsCheck[chamberNum];
            }

            if (chDataDic["FAM"].Count > 3)
            {
                var nsi = new ScottPlot.Statistics.Interpolation
                     .NaturalSpline(dataXList.ToArray(), chDataDic["FAM"].ToArray(), resolution: 20);
                chFAMHLArray[chamberNum] = formsPlot.plt.PlotScatterHighlight(nsi.interpolatedXs, nsi.interpolatedYs
                                                            , Color.Blue, markerSize: 0);

                chFAMHLArray[chamberNum].visible = chFAMHLIsCheck[chamberNum];
            }

            if (chDataDic["ROX"].Count > 3)
            {
                var nsi = new ScottPlot.Statistics.Interpolation
                    .NaturalSpline(dataXList.ToArray(), chDataDic["ROX"].ToArray(), resolution: 20);
                chROXHLArray[chamberNum] = formsPlot.plt.PlotScatterHighlight(nsi.interpolatedXs, nsi.interpolatedYs
                                                            , Color.Orange, markerSize: 0);
                chROXHLArray[chamberNum].visible = chROXHLIsCheck[chamberNum];
            }
            if (chDataDic["HEX"].Count > 3)
            {
                var nsi = new ScottPlot.Statistics.Interpolation
                     .NaturalSpline(dataXList.ToArray(), chDataDic["HEX"].ToArray(), resolution: 20);
                chHEXHLArray[chamberNum] = formsPlot.plt.PlotScatterHighlight(nsi.interpolatedXs, nsi.interpolatedYs
                                                            , Color.Green, markerSize: 0);
                chHEXHLArray[chamberNum].visible = chHEXHLIsCheck[chamberNum];
            }

            if (chDataDic["CY5"].Count > 3)
            {
                var nsi = new ScottPlot.Statistics.Interpolation
                   .NaturalSpline(dataXList.ToArray(), chDataDic["CY5"].ToArray(), resolution: 20);
                chCY5HLArray[chamberNum] = formsPlot.plt.PlotScatterHighlight(nsi.interpolatedXs, nsi.interpolatedYs
                                                            , Color.Red, markerSize: 0);
                chCY5HLArray[chamberNum].visible = chCY5HLIsCheck[chamberNum];
            }
            //formsPlot.plt.AxisAutoX(expandOnly: true);



            for (int i = 0; i < dataXList.Count; i++)
            {
                if (i < COL_CNT)
                    labelTicksArray[i] = Optic_Measure_Idx[i].ToString();
                    labelTicks.Add(labelTicksArray[i]);
            }
                
            //for (int i = 0; i < dataXList.Count; i++)


            formsPlot.plt.XTicks(dataXList.ToArray(), labelTicks.ToArray());
            formsPlot.plt.Title(title);
            formsPlot.plt.Legend(location: legendLocation.upperLeft);
            formsPlot.plt.Axis(0, COL_CNT-1, 0, 3000);
            formsPlot.plt.Layout(xLabelHeight:40);
            formsPlot.Configure(recalculateLayoutOnMouseUp: false);


            formsPlot.plt.PlotHLine(y: Ct_FAM, label: "FAM Ct");
            formsPlot.plt.PlotHLine(y: Ct_ROX, label: "ROX Ct");
            formsPlot.plt.PlotHLine(y: Ct_HEX, label: "HEX Ct");
            formsPlot.plt.PlotHLine(y: Ct_CY5, label: "CY5 Ct");
            //formsPlot.plt.TightenLayout(padding: 40);
            formsPlot.Render();
        }

        public static void ViewInit(FormsPlot formsPlot)
        {
            formsPlot.plt.Axis(0, COL_CNT - 1, 0, 2500);
            //formsPlot.plt.TightenLayout(padding: 40);
            formsPlot.Render();
        }


        public static void DrawHLine(FormsPlot formsPlot, int value)
        {
            formsPlot.plt.PlotHLine(y: value, draggable: true, dragLimitLower: 0, dragLimitUpper: 3000);
            formsPlot.Render();
        }

        public static void ResetAllPlots(FormsPlot formsPlot1, FormsPlot formsPlot2, FormsPlot formsPlot3, FormsPlot formsPlot4)
        {
            formsPlot1.plt.Clear();
            formsPlot2.plt.Clear();
            formsPlot3.plt.Clear();
            formsPlot4.plt.Clear();

            Plotter.ch1DataDic["FAM"] = new List<double>();
            Plotter.ch1DataDic["ROX"] = new List<double>();
            Plotter.ch1DataDic["HEX"] = new List<double>();
            Plotter.ch1DataDic["CY5"] = new List<double>();

            Plotter.ch2DataDic["FAM"] = new List<double>();
            Plotter.ch2DataDic["ROX"] = new List<double>();
            Plotter.ch2DataDic["HEX"] = new List<double>();
            Plotter.ch2DataDic["CY5"] = new List<double>();

            Plotter.ch3DataDic["FAM"] = new List<double>();
            Plotter.ch3DataDic["ROX"] = new List<double>();
            Plotter.ch3DataDic["HEX"] = new List<double>();
            Plotter.ch3DataDic["CY5"] = new List<double>();

            Plotter.ch4DataDic["FAM"] = new List<double>();
            Plotter.ch4DataDic["ROX"] = new List<double>();
            Plotter.ch4DataDic["HEX"] = new List<double>();
            Plotter.ch4DataDic["CY5"] = new List<double>();
        }

        public static void CheckBoxChecked(string getCBoxName, bool isChecked, FormsPlot formsplot1, FormsPlot formsplot2, FormsPlot formsplot3, FormsPlot formsplot4)
        {
            switch (getCBoxName)
            {
                case "cBoxCh1FAM":
                    var index = 0;
                    VisibleCtrl(chFAMArray[index], chFAMHLArray[index], isChecked, formsplot1);
                    chFAMIsCheck[index] = isChecked;
                    chFAMHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh1ROX":
                    index = 0;
                    VisibleCtrl(chROXArray[index], chROXHLArray[index], isChecked, formsplot1);
                    chROXIsCheck[index] = isChecked;
                    chROXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh1HEX":
                    index = 0;
                    VisibleCtrl(chHEXArray[index], chHEXHLArray[index], isChecked, formsplot1);
                    chHEXIsCheck[index] = isChecked;
                    chHEXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh1CY5":
                    index = 0;
                    VisibleCtrl(chCY5Array[index], chCY5HLArray[index], isChecked, formsplot1);
                    chCY5IsCheck[index] = isChecked;
                    chCY5HLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh2FAM":
                    index = 1;
                    VisibleCtrl(chFAMArray[index], chFAMHLArray[index], isChecked, formsplot2);
                    chFAMIsCheck[index] = isChecked;
                    chFAMHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh2ROX":
                    index = 1;
                    VisibleCtrl(chROXArray[index], chROXHLArray[index], isChecked, formsplot2);
                    chROXIsCheck[index] = isChecked;
                    chROXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh2HEX":
                    index = 1;
                    VisibleCtrl(chHEXArray[index], chHEXHLArray[index], isChecked, formsplot2);
                    chHEXIsCheck[index] = isChecked;
                    chHEXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh2CY5":
                    index = 1;
                    VisibleCtrl(chCY5Array[index], chCY5HLArray[index], isChecked, formsplot2);
                    chCY5IsCheck[index] = isChecked;
                    chCY5HLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh3FAM":
                    index = 2;
                    VisibleCtrl(chFAMArray[index], chFAMHLArray[index], isChecked, formsplot3);
                    chFAMIsCheck[index] = isChecked;
                    chFAMHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh3ROX":
                    index = 2;
                    VisibleCtrl(chROXArray[index], chROXHLArray[index], isChecked, formsplot3);
                    chROXIsCheck[index] = isChecked;
                    chROXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh3HEX":
                    index = 2;
                    VisibleCtrl(chHEXArray[index], chHEXHLArray[index], isChecked, formsplot3);
                    chHEXIsCheck[index] = isChecked;
                    chHEXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh3CY5":
                    index = 2;
                    VisibleCtrl(chCY5Array[index], chCY5HLArray[index], isChecked, formsplot3);
                    chCY5IsCheck[index] = isChecked;
                    chCY5HLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh4FAM":
                    index = 3;
                    VisibleCtrl(chFAMArray[index], chFAMHLArray[index], isChecked, formsplot4);
                    chFAMIsCheck[index] = isChecked;
                    chFAMHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh4ROX":
                    index = 3;
                    VisibleCtrl(chROXArray[index], chROXHLArray[index], isChecked, formsplot4);
                    chROXIsCheck[index] = isChecked;
                    chROXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh4HEX":
                    index = 3;
                    VisibleCtrl(chHEXArray[index], chHEXHLArray[index], isChecked, formsplot4);
                    chHEXIsCheck[index] = isChecked;
                    chHEXHLIsCheck[index] = isChecked;
                    break;
                case "cBoxCh4CY5":
                    index = 3;
                    VisibleCtrl(chCY5Array[index], chCY5HLArray[index], isChecked, formsplot4);
                    chCY5IsCheck[index] = isChecked;
                    chCY5HLIsCheck[index] = isChecked;
                    break;
                default:
                    break;
            }
        }
        public static void VisibleCtrl(PlottableScatter scatterPlot,
           PlottableScatterHighlight fittingHL, bool isChecked, FormsPlot plot)
        {
            if (scatterPlot != null && fittingHL != null)
            {
                scatterPlot.visible = isChecked;
                fittingHL.visible = isChecked;
                plot.Render();
            }
        }
    }
}
