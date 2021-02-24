using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace QuantumConcepts.Common.Forms.UI.Controls
{
    internal class ProgressBarEx : ProgressBar
    {
        //public ProgressBarEx()
        //{
        //    this.SetStyle(ControlStyles.UserPaint, true);
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    LinearGradientBrush brush = null;
        //    Rectangle rec = new Rectangle(0, 0, this.Width, this.Height);

        //    if (ProgressBarRenderer.IsSupported)
        //        ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec);

        //    rec.Width = (int)(rec.Width * ((double)base.Value / Maximum)) - 4;
        //    rec.Height -= 4;
        //    //brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
        //    brush = new LinearGradientBrush(rec, this.ForeColor, this.BackColor, LinearGradientMode.Vertical);
        //    e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height);
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor

        ////////////////////////////////////////////////////////////////////////////////////////// Public
        #region 생성자 - StateProgressBar()
        /// <summary>
        /// 생성자
        /// </summary>
        public ProgressBarEx()
        {
            if (ProgressBarRenderer.IsSupported)
            {
                SetStyle(ControlStyles.UserPaint, true);
            }
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////////////// Method

        ////////////////////////////////////////////////////////////////////////////////////////// Protected
        #region 배경 페인트시 처리하기 - OnPaintBackground(e)
        /// <summary>
        /// 배경 페인트시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }
        #endregion
        #region 페인트시 처리하기 - OnPaint(e)
        /// <summary>
        /// 페인트시 처리하기
        /// </summary>
        /// <param name="e">이벤트 인자</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            using (Image image = new Bitmap(Width, Height))
            {
                using (Graphics imageGraphics = Graphics.FromImage(image))
                {
                    #region 외곽선을 그린다.
                    Rectangle outlineRectangle = new Rectangle(Point.Empty, Size);
                    if (ProgressBarRenderer.IsSupported)
                    {
                        ProgressBarRenderer.DrawHorizontalBar(imageGraphics, outlineRectangle);
                    }
                    #endregion
                    #region 배경바를 칠한다.
                    outlineRectangle.Inflate(new Size(-2, -2));
                    SolidBrush backgroundBrush = new SolidBrush(Color.FromArgb(251, 251, 251));
                    imageGraphics.FillRectangle(backgroundBrush, outlineRectangle);
                    #endregion
                    #region 메인바(수직 그라데이션)를 칠한다
                    Rectangle mainRectangle = new Rectangle(Point.Empty, Size);
                    mainRectangle.Inflate(new Size(-1, -1));
                    mainRectangle.Width = (int)Math.Truncate((double)mainRectangle.Width * Value / Maximum);
                    if (mainRectangle.Width == 0)
                    {
                        mainRectangle.Width = 1;
                    }
                    LinearGradientBrush verticalMainBrush = new LinearGradientBrush(mainRectangle, this.BackColor, this.ForeColor,
                        LinearGradientMode.Vertical);
                    ColorBlend verticalMainColorBlend = new ColorBlend
                    {
                        Positions = new float[]
                        {
                            0.0f,
                            0.55f,
                            1.0f
                        },
                        Colors = new Color[]
                        {
                            this.BackColor,
                            this.ForeColor,
                            this.BackColor
                        }
                    };
                    verticalMainBrush.InterpolationColors = verticalMainColorBlend;
                    imageGraphics.FillRectangle(verticalMainBrush, mainRectangle);
                    #endregion
                    #region 메인바(수평 그라데이션)를 칠한다.
                    LinearGradientBrush horizontalMainBrush = new LinearGradientBrush(mainRectangle, this.ForeColor, this.BackColor,
                        LinearGradientMode.Horizontal);
                    ColorBlend horizontalMainColorBlend = new ColorBlend
                    {
                        Positions = new float[]
                        {
                            0.0f,
                            0.35f,
                            0.65f,
                            1.0f
                        },
                        Colors = new Color[]
                        {
                            Color.FromArgb(200, this.ForeColor),
                            Color.FromArgb(100, this.BackColor),
                            Color.FromArgb(100, this.BackColor),
                            Color.FromArgb(200, this.ForeColor)
                        }
                    };
                    horizontalMainBrush.InterpolationColors = horizontalMainColorBlend;
                    horizontalMainBrush.GammaCorrection = true;
                    imageGraphics.FillRectangle(horizontalMainBrush, mainRectangle);
                    #endregion
                    #region 사이드 엣지(투명)를 그린다.
                    Pen sideEdgePen = new Pen(Color.FromArgb(80, Color.White));
                    imageGraphics.DrawLine(sideEdgePen, 1, 1, 1, mainRectangle.Height); // 왼쪽
                    imageGraphics.DrawLine(sideEdgePen, mainRectangle.Width, 1, mainRectangle.Width, mainRectangle.Height); // 오른쪽
                    #endregion
                    #region 하이라이트(투명)를 그린다.
                    Rectangle highlightRectangle = new Rectangle(1, 1, mainRectangle.Width,
                        (int)(Math.Truncate(mainRectangle.Height * 0.45)));
                    LinearGradientBrush highlightBrush = new LinearGradientBrush(highlightRectangle, Color.White, Color.White,
                        LinearGradientMode.Vertical);
                    ColorBlend highlightColorBlend = new ColorBlend
                    {
                        Positions = new float[]
                        {
                            0.0f,
                            0.3f,
                            1.0f
                        },
                        Colors = new Color[]
                        {
                            Color.FromArgb(120, Color.White),
                            Color.FromArgb(110, Color.White),
                            Color.FromArgb(80, Color.White)
                        }
                    };
                    highlightBrush.InterpolationColors = highlightColorBlend;
                    highlightBrush.GammaCorrection = true;
                    imageGraphics.FillRectangle(highlightBrush, highlightRectangle);
                    #endregion
                    // 이미지를 그린다.
                    e.Graphics.DrawImage(image, Point.Empty);
                }
            }
        }
        #endregion
    }
}