using System;
using System.Drawing;
using System.Runtime.InteropServices; // Needed to use P/Invoke (Platform Invoke)
using System.Windows.Forms;

namespace EscapeGame
{
    class CustomTextBox : TextBox
    {
        public static Color DefaultColor { get; }

        private Color m_TopColor;
        private Color m_RightColor;
        private Color m_LeftColor;  
        private Color m_BottomColor;

        // Constant for the OnPaint method (0xF equals 15)
        private const int WM_PAINT = 0xF; 

        public Color BorderColor
        {
            get { return Color.Empty; }
            set
            {
                this.m_TopColor = value;
                this.m_RightColor = value;
                this.m_BottomColor = value;
                this.m_LeftColor = value;
            }
        }

        /// <summary>
        /// Allows you to define a color for the top border.
        /// All borders will take this color if the color of the borders is not specified
        /// </summary>
        public Color BorderColorTop
        {
            get { return this.m_TopColor; }
            set { this.m_TopColor = value; }
        }

        /// <summary>
        /// Allows you to define a color for the right border.
        /// </summary>
        public Color BorderColorRight 
        {
            get { return this.m_RightColor; }
            set { this.m_RightColor = value; }
        }

        /// <summary>
        /// Allows you to define a color for the bottom border.
        /// </summary>
        public Color BorderColorBottom
        {
            get { return this.m_BottomColor; }
            set { this.m_BottomColor = value; }
        }

        /// <summary>
        /// Allows you to define a color for the left border.
        /// </summary>
        public Color BorderColorLeft
        {
            get { return this.m_LeftColor; }
            set { this.m_LeftColor = value; }
        }

        [DllImport("user32", EntryPoint = "GetWindowDC")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd); // Recovery of the Handle

        protected override void WndProc(ref Message m)
        {
            // We get the message that Windows is giving us
            switch (m.Msg)
            {
                //If the message matches our constant, we execute our OnPaint() method
                case WM_PAINT:
                    base.WndProc(ref m);
                    OnPaint();
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
            
        }

        /// <summary>
        /// Drawing Method.
        /// </summary>
        private void OnPaint()
        {
            // Retrieving the size of the TextBox.
            Rectangle rcItem = new Rectangle(0, 0, this.Bounds.Width, this.Bounds.Height);

            IntPtr hDC = GetWindowDC(this.Handle);
            Graphics gfx = Graphics.FromHdc(hDC);

            //Allows to know if the property enabled by the button is active or not.
            if (!this.Enabled)
            {
                // Allows you to draw a dark grey outline by default.
                DrawBorder(gfx, rcItem);
            }
            else
            {
                // Allows you to draw a contour with the colors passed in parameter and not with the default dark grey.
                DrawBorder(gfx, rcItem, m_TopColor, m_RightColor, m_BottomColor, m_LeftColor);
            }
            gfx.Dispose();
        }

        /// <summary>
        ///    Method used to draw the borders with default dark grey border.
        /// </summary>
        /// <param name="gfx">Graphic to put on</param>
        /// <param name="rect"></param>
        private void DrawBorder(Graphics gfx, Rectangle rect)
        {
            Pen lpPen = new Pen(DefaultColor, 1);

            // Top Border
            gfx.DrawLine(lpPen, rect.X, rect.Y, rect.X + rect.Width - 1, rect.Y);

            // Right Border
            gfx.DrawLine(lpPen, rect.X + rect.Width - 1, rect.Y, rect.X + rect.Width - 1, rect.Top + rect.Height - 1);

            // Bottom Border
            gfx.DrawLine(lpPen, rect.X + rect.Width - 1, rect.Top + rect.Height - 1, rect.X, rect.Top + rect.Height - 1);

            // Left Border
            gfx.DrawLine(lpPen, rect.X, rect.Y + rect.Height - 1, rect.X, rect.Y);

            lpPen.Dispose();
        }

        /// <summary>
        ///     Method used to draw the borders with the specified colors.
        /// </summary>
        /// <param name="gfx">Graphic to put on</param>
        /// <param name="rect"></param>
        /// <param name="topColor">Top border color</param>
        /// <param name="rightColor">Right border color</param>
        /// <param name="bottomColor">Bottom border color</param>
        /// <param name="leftColor">Left border color</param>
        private void DrawBorder(Graphics gfx, Rectangle rect, Color topColor, Color rightColor, Color bottomColor, Color leftColor)
        {
            // Top Border
            Pen lpPen = new Pen(topColor, 1);
            gfx.DrawLine(lpPen, rect.X, rect.Y, rect.X + rect.Width - 1, rect.Y);
            lpPen.Dispose();

            // Right Border
            lpPen = new Pen(rightColor, 1);
            gfx.DrawLine(lpPen, rect.X + rect.Width - 1, rect.Y, rect.X + rect.Width - 1, rect.Top + rect.Height - 1);
            lpPen.Dispose();

            // Bottom Border
            lpPen = new Pen(bottomColor, 1);
            gfx.DrawLine(lpPen, rect.X + rect.Width - 1, rect.Top + rect.Height - 1, rect.X, rect.Top + rect.Height - 1);
            lpPen.Dispose();

            // Left Border
            lpPen = new Pen(leftColor, 1);
            gfx.DrawLine(lpPen, rect.X, rect.Y + rect.Height - 1, rect.X, rect.Y);
            lpPen.Dispose();
        }
    }
}
