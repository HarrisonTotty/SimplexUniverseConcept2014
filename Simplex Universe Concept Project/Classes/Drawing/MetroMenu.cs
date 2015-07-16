using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MetroFramework;
using System.Windows.Forms;

namespace SimplexUniverse.Drawing
{
    /// <summary>
    /// Represents a metro-styled varient of the winforms menustrip.
    /// </summary>
    public class MetroMenu : System.Windows.Forms.MenuStrip
    {
        /// <summary>
        /// Creates a new metro menu with the default theme and color
        /// </summary>
        public MetroMenu() : base()
        {
            this.RenderMode = ToolStripRenderMode.Professional;
            this.TabStop = false;
            this.Name = "MainMenu";
            this.ChangeStyle(MetroThemeStyle.Light, MetroColorStyle.Blue);

            this.ItemAdded += MetroMenu_ItemAdded;
            this.ItemRemoved += MetroMenu_ItemRemoved;
        }

        void MetroMenu_ItemRemoved(object sender, ToolStripItemEventArgs e)
        {
            this.ChangeStyle(this.MetroTheme, this.MetroColor);
        }

        void MetroMenu_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            this.ChangeStyle(this.MetroTheme, this.MetroColor);
        }

        /// <summary>
        /// Creates a new metro menu with a particular theme and color
        /// </summary>
        /// <param name="Theme">The metro theme</param>
        /// <param name="Color">The metro color pallet</param>
        public MetroMenu(MetroThemeStyle Theme, MetroColorStyle Color) : base()
        {
            this.RenderMode = ToolStripRenderMode.Professional;
            this.TabStop = false;
            this.Name = "MainMenu";
            this.ChangeStyle(Theme, Color);

            this.ItemAdded += MetroMenu_ItemAdded;
            this.ItemRemoved += MetroMenu_ItemRemoved;
        }

        /// <summary>
        /// Changes the theme and/or color of this menu to a particular value
        /// </summary>
        /// <param name="Theme">The theme to change to</param>
        /// <param name="Color">The color to change to</param>
        public void ChangeStyle(MetroThemeStyle Theme, MetroColorStyle Color)
        {
            this.MetroTheme = Theme;
            this.MetroColor = Color;
            this.Renderer = new ToolStripProfessionalRenderer(new Drawing.MenuColorPallet(this.MetroTheme, this.MetroColor));
            System.Drawing.Color BC = MetroFramework.Drawing.MetroPaint.BackColor.Form(this.MetroTheme);
            System.Drawing.Color FC = MetroFramework.Drawing.MetroPaint.ForeColor.Title(this.MetroTheme);
            System.Drawing.Color Border = MetroFramework.Drawing.MetroPaint.BorderColor.Form(this.MetroTheme);
            this.BackColor = BC;
            this.ForeColor = FC;
            foreach (var Item in this.Items) ApplyColorsToMenuItem(BC, FC, Item);
            this.Refresh();
        }

        /// <summary>
        /// Applies a certain forecolor and backcolor to a toolstripmenuitem and all sub-items
        /// </summary>
        private void ApplyColorsToMenuItem(System.Drawing.Color BC, System.Drawing.Color FC, object Item)
        {
            if (Item is ToolStripMenuItem)
            {
                (Item as ToolStripMenuItem).BackColor = BC;
                (Item as ToolStripMenuItem).ForeColor = FC;
                if ((Item as ToolStripMenuItem).HasDropDownItems)
                {
                    foreach (dynamic I in (Item as ToolStripMenuItem).DropDownItems)
                    {
                        ApplyColorsToMenuItem(BC, FC, (I as ToolStripMenuItem));
                    }
                }
            }
            else if (Item is ToolStripTextBox)
            {
                (Item as ToolStripTextBox).BackColor = BC;
                (Item as ToolStripTextBox).ForeColor = FC;
                (Item as ToolStripTextBox).TextBox.BackColor = BC;
                (Item as ToolStripTextBox).TextBox.ForeColor = FC;
            }
        }

        /// <summary>
        /// The theme of this menustrip
        /// </summary>
        public MetroThemeStyle MetroTheme
        {
            get;
            set;
        }

        /// <summary>
        /// The color style of this menustrip
        /// </summary>
        public MetroColorStyle MetroColor
        {
            get;
            set;
        }
    }
}
