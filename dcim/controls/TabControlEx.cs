using dcim.dialogs;
using dcim.views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcim.controls
{
    public partial class TabControlEx : TabControl
    {
        protected ContextMenu m_pageMenu = new ContextMenu();
        public TabControlEx()
        {
            InitializeComponent();
            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            
        }
        protected override void OnControlAdded(ControlEventArgs e)
        {
            e.Control.Text = "   " + e.Control.Text + "         ";
            base.OnControlAdded(e);
        }
        protected virtual void TabClosed(int index)
        {

        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            if (e.Bounds != RectangleF.Empty)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                RectangleF tabTextArea = RectangleF.Empty;

                tabTextArea = (RectangleF)this.GetTabRect(e.Index);
                GraphicsPath _Path = new GraphicsPath();
                _Path.AddRectangle(tabTextArea);
                if (e.Index != this.SelectedIndex)
                {
                    using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        ColorBlend _ColorBlend = new ColorBlend(3);
                        _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight,
                                                      Color.FromArgb(255,SystemColors.Control),SystemColors.Control,
                                                      SystemColors.ControlLightLight};

                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;

                        e.Graphics.FillPath(_Brush, _Path);
                        using (Pen pen = new Pen(SystemColors.ActiveBorder))
                        {
                            e.Graphics.DrawPath(pen, _Path);
                        }
                        _ColorBlend.Colors = new Color[]{  SystemColors.ActiveBorder,
                                                        SystemColors.ActiveBorder,SystemColors.ActiveBorder,
                                                        SystemColors.ActiveBorder};

                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;
                        e.Graphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }

                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;
                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        // assign the color blend to the pathgradientbrush
                        _Brush.InterpolationColors = _ColorBlend;

                        e.Graphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 43, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        // e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, tabTextArea.X + tabTextArea.Width - 37, 7, 13, 13);
                        e.Graphics.DrawRectangle(new Pen(Color.White), tabTextArea.X + tabTextArea.Width - 41, 6, tabTextArea.Height - 7, tabTextArea.Height - 9);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 36, 11, tabTextArea.X + tabTextArea.Width - 33, 16);
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 33, 16, tabTextArea.X + tabTextArea.Width - 30, 11);
                        }

                    }
                    _Path.Dispose();
                    string str = this.TabPages[e.Index].Text;
                    StringFormat stringFormat = StringFormat.GenericDefault;
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                    //tabTextArea = new RectangleF(tabTextArea.X, tabTextArea.Y, tabTextArea.Width,
                    //               tabTextArea.Height);
                    e.Graphics.DrawString(str, this.Font, System.Drawing.SystemBrushes.ControlDark, tabTextArea, stringFormat);
                }
                else

                {
                    using (LinearGradientBrush _Brush = new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight, LinearGradientMode.Vertical))
                    {
                        ColorBlend _ColorBlend = new ColorBlend(3);
                        _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight,
                                                      Color.FromArgb(255,SystemColors.Control),SystemColors.ControlLight,
                                                      SystemColors.Control};
                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;
                        e.Graphics.FillPath(_Brush, _Path);
                        using (Pen pen = new Pen(SystemColors.ActiveBorder))
                        {
                            e.Graphics.DrawPath(pen, _Path);
                        }
                        //Drawing Close Button
                        _ColorBlend.Colors = new Color[]{Color.FromArgb(255,231,164,152),
                                                      Color.FromArgb(255,231,164,152),Color.FromArgb(255,197,98,79),
                                                      Color.FromArgb(255,197,98,79)};
                        _Brush.InterpolationColors = _ColorBlend;
                        e.Graphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 20, 6, tabTextArea.Height - 8, tabTextArea.Height - 9);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 9, tabTextArea.X + tabTextArea.Width - 7, 17);
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 16, 17, tabTextArea.X + tabTextArea.Width - 7, 9);
                        }

                        //Drawing menu button
                         _ColorBlend.Colors = new Color[]{SystemColors.ControlLightLight,
                                                      Color.FromArgb(255,SystemColors.ControlLight),SystemColors.ControlDark,
                                                      SystemColors.ControlLightLight};
                         _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                         _Brush.InterpolationColors = _ColorBlend;
                        _ColorBlend.Colors = new Color[]{Color.FromArgb(255,170,213,243),
                                                      Color.FromArgb(255,170,213,243),Color.FromArgb(255,44,137,191),
                                                      Color.FromArgb(255,44,137,191)};
                         _Brush.InterpolationColors = _ColorBlend;
                        e.Graphics.FillRectangle(_Brush, tabTextArea.X + tabTextArea.Width - 43, 4, tabTextArea.Height - 3, tabTextArea.Height - 5);
                        e.Graphics.DrawRectangle(Pens.White, tabTextArea.X + tabTextArea.Width - 41, 6, tabTextArea.Height - 7, tabTextArea.Height - 9);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 36, 11, tabTextArea.X + tabTextArea.Width - 33, 16);
                            e.Graphics.DrawLine(pen, tabTextArea.X + tabTextArea.Width - 33, 16, tabTextArea.X + tabTextArea.Width - 30, 11);
                        }

                    }
                    _Path.Dispose();
                    string str = this.TabPages[e.Index].Text;
                    StringFormat stringFormat = StringFormat.GenericDefault;
                    stringFormat.Alignment = StringAlignment.Near;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Trimming = StringTrimming.EllipsisCharacter;
                    //tabTextArea = new RectangleF(tabTextArea.X, tabTextArea.Y, tabTextArea.Width,
                    //               tabTextArea.Height);
                    e.Graphics.DrawString(str, this.Font, System.Drawing.SystemBrushes.ControlText, tabTextArea, stringFormat);
                }
                

            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                int nIndex = -1;
                Point pt = new Point(e.X, e.Y);
                RectangleF tabTextArea = RectangleF.Empty;
                for (int index = 0; index < this.TabCount; index++)
                {
                    tabTextArea = (RectangleF)this.GetTabRect(index);

                    if (tabTextArea.Contains(pt))
                    {
                        nIndex = index;
                        break;
                    }
                }
                if (nIndex < 0)
                    return;
                Graphics g = CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                //for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
                //{
                //RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);
                tabTextArea =
                    new RectangleF(tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3,
                                   tabTextArea.Height - 5);

                // Point pt = new Point(e.X, e.Y);
                if (tabTextArea.Contains(pt))
                {
                    using (
                        LinearGradientBrush _Brush =
                            new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight,
                                                    LinearGradientMode.Vertical))
                    {
                        ColorBlend _ColorBlend = new ColorBlend(3);
                        _ColorBlend.Colors = new Color[]
                            {
                                  Color.FromArgb(255, 252, 193, 183),
                                  Color.FromArgb(255, 252, 193, 183), Color.FromArgb(255, 210, 35, 2),
                                  Color.FromArgb(255, 210, 35, 2)
                            };
                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;

                        g.FillRectangle(_Brush, tabTextArea);
                        g.DrawRectangle(Pens.White, tabTextArea.X + 2, 6, tabTextArea.Height - 3,
                                        tabTextArea.Height - 4);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            g.DrawLine(pen, tabTextArea.X + 6, 9, tabTextArea.X + 15, 17);
                            g.DrawLine(pen, tabTextArea.X + 6, 17, tabTextArea.X + 15, 9);
                        }
                    }
                }
                else
                {
                    if (nIndex != SelectedIndex)
                    {
                        using (
                            LinearGradientBrush _Brush =
                                new LinearGradientBrush(tabTextArea, SystemColors.Control, SystemColors.ControlLight,
                                                        LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);
                            _ColorBlend.Colors = new Color[]
                                {
                                      SystemColors.ActiveBorder,
                                      SystemColors.ActiveBorder, SystemColors.ActiveBorder,
                                      SystemColors.ActiveBorder
                                };
                            _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                            _Brush.InterpolationColors = _ColorBlend;

                            g.FillRectangle(_Brush, tabTextArea);
                            g.DrawRectangle(Pens.White, tabTextArea.X + 2, 6, tabTextArea.Height - 3,
                                            tabTextArea.Height - 4);
                            using (Pen pen = new Pen(Color.White, 2))
                            {
                                g.DrawLine(pen, tabTextArea.X + 6, 9, tabTextArea.X + 15, 17);
                                g.DrawLine(pen, tabTextArea.X + 6, 17, tabTextArea.X + 15, 9);
                            }
                        }
                    }
                }

                RectangleF tabMenuArea = (RectangleF)this.GetTabRect(nIndex);
                tabMenuArea =
                    new RectangleF(tabMenuArea.X + tabMenuArea.Width - 43, 4, tabMenuArea.Height - 3,
                                   tabMenuArea.Height - 5);
                pt = new Point(e.X, e.Y);
                if (tabMenuArea.Contains(pt))
                {
                    using (
                        LinearGradientBrush _Brush =
                            new LinearGradientBrush(tabMenuArea, SystemColors.Control, SystemColors.ControlLight,
                                                    LinearGradientMode.Vertical))
                    {
                        ColorBlend _ColorBlend = new ColorBlend(3);
                        _ColorBlend.Colors = new Color[]
                            {
                                      Color.FromArgb(255, 170, 213, 255),
                                      Color.FromArgb(255, 170, 213, 255), Color.FromArgb(255, 44, 157, 250),
                                      Color.FromArgb(255, 44, 157, 250)
                            };
                        _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                        _Brush.InterpolationColors = _ColorBlend;

                        g.FillRectangle(_Brush, tabMenuArea);
                        g.DrawRectangle(Pens.White, tabMenuArea.X + 2, 6, tabMenuArea.Height - 2,
                                        tabMenuArea.Height - 4);
                        using (Pen pen = new Pen(Color.White, 2))
                        {
                            g.DrawLine(pen, tabMenuArea.X + 7, 11, tabMenuArea.X + 10, 16);
                            g.DrawLine(pen, tabMenuArea.X + 10, 16, tabMenuArea.X + 13, 11);
                        }
                    }
                }
                else
                {
                    if (nIndex != SelectedIndex)
                    {
                        using (
                            LinearGradientBrush _Brush =
                                new LinearGradientBrush(tabMenuArea, SystemColors.Control,
                                                        SystemColors.ControlLight, LinearGradientMode.Vertical))
                        {
                            ColorBlend _ColorBlend = new ColorBlend(3);
                            _ColorBlend.Colors = new Color[]
                                {
                                          SystemColors.ActiveBorder,
                                          SystemColors.ActiveBorder, SystemColors.ActiveBorder,
                                          SystemColors.ActiveBorder
                                };
                            _ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
                            _Brush.InterpolationColors = _ColorBlend;

                            g.FillRectangle(_Brush, tabMenuArea);
                            g.DrawRectangle(Pens.White, tabMenuArea.X + 2, 6, tabMenuArea.Height - 2,
                                            tabMenuArea.Height - 4);
                            using (Pen pen = new Pen(Color.White, 2))
                            {
                                g.DrawLine(pen, tabMenuArea.X + 7, 11, tabMenuArea.X + 10, 16);
                                g.DrawLine(pen, tabMenuArea.X + 10, 16, tabMenuArea.X + 13, 11);
                            }
                        }
                    }
                }


                // }
                g.Dispose();
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!DesignMode)
            {
                RectangleF tabTextArea = (RectangleF)this.GetTabRect(SelectedIndex);
                tabTextArea =
                    tabTextArea =
                    new RectangleF(tabTextArea.X + tabTextArea.Width - 22, 4, tabTextArea.Height - 3,
                                   tabTextArea.Height - 5);
                Point pt = new Point(e.X, e.Y);
                if (tabTextArea.Contains(pt))
                {
                    TabClosed(SelectedIndex);
                    return;
                }

                RectangleF tabMenuArea = (RectangleF)this.GetTabRect(SelectedIndex);
                tabMenuArea =
                    new RectangleF(tabMenuArea.X + tabMenuArea.Width - 43, 4, tabMenuArea.Height - 3,
                                   tabMenuArea.Height - 5);
                pt = new Point(e.X, e.Y);
                if (tabMenuArea.Contains(pt))
                {
                    this.m_pageMenu.Show(this, this.PointToClient(MousePosition));
                }

            }
        }

    }
}
