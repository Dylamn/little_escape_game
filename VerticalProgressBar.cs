using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EscapeGame
{
    public enum Styles
    {
        Classic,
        Solid
    }

    public enum BorderStyles
    {
        Classic,
        None
    }

    public partial class VerticalProgressBar : UserControl
    {
        private int m_Value = 50;
        private int m_Minimum = 0;
        private int m_Maximum = 100;
        private int m_Step = 10;

        private Styles m_Style = Styles.Solid; // Bar Style
        private BorderStyles m_BorderStyle = BorderStyles.None;
        private Color m_Color = Color.Green; // Bar Color

        public VerticalProgressBar()
        {
            InitializeComponent();

            // ***** avoid flickering
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.Name = "VerticalProgressBar";
            this.Size = new Size(10, 120);
        }

        [Description("VerticalProgressBar Maximum Value")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Maximum
        {
            get
            {
                return m_Maximum;
            }
            set
            {
                m_Maximum = value;
                if (m_Maximum < m_Minimum)
                    m_Minimum = m_Maximum;
                if (m_Maximum < m_Value)
                    m_Value = m_Maximum;
                Invalidate();
            }
        }

        [Description("VerticalProgressBar Minimum Value")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Minimum
        {
            get
            {
                return m_Minimum;
            }
            set
            {
                m_Minimum = value;
                if (m_Minimum > m_Maximum)
                    m_Maximum = m_Minimum;
                if (m_Minimum > m_Value)
                    m_Value = m_Minimum;
                Invalidate();
            }
        }

        [Description("VerticalProgressBar Step")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public int Step
        {
            get
            {
                return m_Step;
            }
            set
            {
                m_Step = value;
            }
        }

        [Description("VerticalProgressBar Current Value")]
        [Category("VerticalProgressBar")]
        public int Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                m_Value = value;
                if (m_Value > m_Maximum)
                    m_Value = m_Maximum;
                if (m_Value < m_Minimum)
                    m_Value = m_Minimum;
                Invalidate();
            }
        }

        [Description("VerticalProgressBar Color")]
        [Category("VerticalProgressBar")]
        [RefreshProperties(RefreshProperties.All)]
        public Color Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        [Description("VerticalProgressBar Border Style")]
        [Category("VerticalProgressBar")]
        public new BorderStyles BorderStyle
        {
            get
            {
                return m_BorderStyle;
            }
            set
            {
                m_BorderStyle = value;
                Invalidate();
            }
        }

        [Description("VerticalProgressBar Style")]
        [Category("VerticalProgressBar")]
        public Styles Style
        {
            get
            {
                return m_Style;
            }
            set
            {
                m_Style = value;
                Invalidate();
            }
        }

        public void PerformStep()
        {
            m_Value += m_Step;

            if (m_Value > m_Maximum)
                m_Value = m_Maximum;
            if (m_Value < m_Minimum)
                m_Value = m_Minimum;

            Invalidate();
            return;
        }

        public void Increment(int value)
        {
            m_Value += value;

            if (m_Value > m_Maximum)
                m_Value = m_Maximum;
            if (m_Value < m_Minimum)
                m_Value = m_Minimum;

            Invalidate();
            return;
        }

        private void DrawBorder(Graphics gfx)
        {
            if (m_BorderStyle == BorderStyles.Classic)
            {
                Color darkColor = ControlPaint.Dark(this.BackColor);
                Color brightColor = ControlPaint.Dark(this.BackColor);
                Pen p = new Pen(darkColor, 1);
                gfx.DrawLine(p, this.Width, 0, 0, 0);
                gfx.DrawLine(p, 0, 0, 0, this.Height);
                p = new Pen(brightColor, 1);
                gfx.DrawLine(p, 0, this.Height, this.Width, this.Height);
                gfx.DrawLine(p, this.Width, this.Height, this.Width, 0);
            }
        }

        private void DrawBar(Graphics gfx)
        {
            if (m_Minimum == m_Maximum || (m_Value - m_Minimum) == 0)
                return;

            int width; // The bar width
            int height; // The bar height
            int x; // The bottom-left x position of the bar
            int y; // The bottom-left y position of the bar

            if (m_BorderStyle == BorderStyles.None)
            {
                width = this.Width;
                x = 0;
                y = this.Height;
            }
            else
            {
                if (this.Width > 4 || this.Height > 2)
                {
                    width = this.Width - 4;
                    x = 2;
                    y = this.Height - 1;
                }
                else
                    return; // Cannot draw
            }

            height = (m_Value - m_Minimum) * this.Height / (m_Maximum - m_Minimum); // The bar height

            if (m_Style == Styles.Solid)
            {
                DrawSolidBar(gfx, x, y, width, height);
            }
            if (m_Style == Styles.Classic)
            {
                DrawClassicBar(gfx, x, y, width, height);
            }
        }

        private void DrawSolidBar(Graphics gfx, int x, int y, int width, int height)
        {
            Rectangle rect = new Rectangle(0, 0, Width, Height);
            if (ProgressBarRenderer.IsSupported)
            {
                ProgressBarRenderer.DrawVerticalBar(gfx, rect);
            }

            LinearGradientBrush topBrush = new LinearGradientBrush(new Point(0, 0), new Point(1, 1), Color.FromArgb(255, 240, 250, 255), Color.FromArgb(255, 80, 215, 245));
            LinearGradientBrush botBrush = new LinearGradientBrush(new Point(1, 1), new Point(2, 2), Color.FromArgb(150, 80, 200, 210), Color.FromArgb(255, 210, 240, 255));
            //gfx.FillRectangle(topBrush, x, y - height, width, height);
            //gfx.FillRectangle(botBrush, x, y - height, width, height);

            gfx.FillRectangle(new SolidBrush(m_Color), x, y - height, width, height);
        }

        private void DrawClassicBar(Graphics gfx, int x, int y, int width, int height)
        {
            int valuePos_y = y - height; // The position y of value

            int blockHeight = width * 3 / 4; // The height of the block

            if (blockHeight <= -1) return; // Make sure blockHeight is langer than -1 in order not to have the infinite loop

            for (int currentPos = y; currentPos > valuePos_y; currentPos -= blockHeight + 1)
            {
                gfx.FillRectangle(new SolidBrush(m_Color), x, currentPos - blockHeight, width, blockHeight);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;

            DrawBar(gfx);

            DrawBorder(gfx);

            base.OnPaint(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
