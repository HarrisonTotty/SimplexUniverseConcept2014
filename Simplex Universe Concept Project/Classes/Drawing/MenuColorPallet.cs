using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Drawing;

namespace SimplexUniverse.Drawing
{
    class MenuColorPallet : ProfessionalColorTable
    {
        private MetroFramework.MetroThemeStyle Theme;
        private MetroFramework.MetroColorStyle Style;

        public MenuColorPallet(MetroFramework.MetroThemeStyle Theme, MetroFramework.MetroColorStyle Style)
        {
            this.Theme = Theme;
            this.Style = Style;
        }

        public override Color ButtonCheckedGradientBegin { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the end color of the gradient used when the button is checked.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used when the
        //     button is checked.
        public override Color ButtonCheckedGradientEnd { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used when the button is checked.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used when
        //     the button is checked.
        public override Color ButtonCheckedGradientMiddle { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the solid color used when the button is checked.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color used when the button is checked.
        public override Color ButtonCheckedHighlight { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonCheckedHighlight.
        public override Color ButtonCheckedHighlightBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle,
        //     and System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd
        //     colors.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle,
        //     and System.Windows.Forms.ProfessionalColorTable.ButtonPressedGradientEnd
        //     colors.
        public override Color ButtonPressedBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used when the button is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used when
        //     the button is pressed.
        public override Color ButtonPressedGradientBegin { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the end color of the gradient used when the button is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used when the
        //     button is pressed.
        public override Color ButtonPressedGradientEnd { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used when the button is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used when
        //     the button is pressed.
        public override Color ButtonPressedGradientMiddle { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the solid color used when the button is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color used when the button is pressed.
        public override Color ButtonPressedHighlight { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonPressedHighlight.
        public override Color ButtonPressedHighlightBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle,
        //     and System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd
        //     colors.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with the System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin,
        //     System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle,
        //     and System.Windows.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd
        //     colors.
        public override Color ButtonSelectedBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used when the button is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used when
        //     the button is selected.
        public override Color ButtonSelectedGradientBegin { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the end color of the gradient used when the button is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used when the
        //     button is selected.
        public override Color ButtonSelectedGradientEnd { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used when the button is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used when
        //     the button is selected.
        public override Color ButtonSelectedGradientMiddle { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the solid color used when the button is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color used when the button is selected.
        public override Color ButtonSelectedHighlight { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with System.Windows.Forms.ProfessionalColorTable.ButtonSelectedHighlight.
        public override Color ButtonSelectedHighlightBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the solid color to use when the button is checked and gradients are
        //     being used.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when the button is
        //     checked and gradients are being used.
        public override Color CheckBackground { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the solid color to use when the button is checked and selected and gradients
        //     are being used.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when the button is
        //     checked and selected and gradients are being used.
        public override Color CheckPressedBackground { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the solid color to use when the button is checked and selected and gradients
        //     are being used.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when the button is
        //     checked and selected and gradients are being used.
        public override Color CheckSelectedBackground { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the color to use for shadow effects on the grip (move handle).
        //
        // Returns:
        //     A System.Drawing.Color that is the color to use for shadow effects on the
        //     grip (move handle).
        public override Color GripDark { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the color to use for highlight effects on the grip (move handle).
        //
        // Returns:
        //     A System.Drawing.Color that is the color to use for highlight effects on
        //     the grip (move handle).
        public override Color GripLight { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
        public override Color ImageMarginGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     image margin of a System.Windows.Forms.ToolStripDropDownMenu.
        public override Color ImageMarginGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used in the
        //     image margin of a System.Windows.Forms.ToolStripDropDownMenu.
        public override Color ImageMarginGradientMiddle { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu
        //     when an item is revealed.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the image margin of a System.Windows.Forms.ToolStripDropDownMenu when an
        //     item is revealed.
        public override Color ImageMarginRevealedGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu
        //     when an item is revealed.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     image margin of a System.Windows.Forms.ToolStripDropDownMenu when an item
        //     is revealed.
        public override Color ImageMarginRevealedGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used in the image margin of a System.Windows.Forms.ToolStripDropDownMenu
        //     when an item is revealed.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used in the
        //     image margin of a System.Windows.Forms.ToolStripDropDownMenu when an item
        //     is revealed.
        public override Color ImageMarginRevealedGradientMiddle { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the color that is the border color to use on a System.Windows.Forms.MenuStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use on a System.Windows.Forms.MenuStrip.
        public override Color MenuBorder { get { return MetroPaint.BorderColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the border color to use with a System.Windows.Forms.ToolStripMenuItem.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use with a System.Windows.Forms.ToolStripMenuItem.
        public override Color MenuItemBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem
        //     is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used when
        //     a top-level System.Windows.Forms.ToolStripMenuItem is pressed.
        public override Color MenuItemPressedGradientBegin { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the end color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem
        //     is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used when a
        //     top-level System.Windows.Forms.ToolStripMenuItem is pressed.
        public override Color MenuItemPressedGradientEnd { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used when a top-level System.Windows.Forms.ToolStripMenuItem
        //     is pressed.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used when
        //     a top-level System.Windows.Forms.ToolStripMenuItem is pressed.
        public override Color MenuItemPressedGradientMiddle { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the solid color to use when a System.Windows.Forms.ToolStripMenuItem
        //     other than the top-level System.Windows.Forms.ToolStripMenuItem is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid color to use when a System.Windows.Forms.ToolStripMenuItem
        //     other than the top-level System.Windows.Forms.ToolStripMenuItem is selected.
        public override Color MenuItemSelected { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used when the System.Windows.Forms.ToolStripMenuItem
        //     is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used when
        //     the System.Windows.Forms.ToolStripMenuItem is selected.
        public override Color MenuItemSelectedGradientBegin { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the end color of the gradient used when the System.Windows.Forms.ToolStripMenuItem
        //     is selected.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used when the
        //     System.Windows.Forms.ToolStripMenuItem is selected.
        public override Color MenuItemSelectedGradientEnd { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.MenuStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the System.Windows.Forms.MenuStrip.
        public override Color MenuStripGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.MenuStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     System.Windows.Forms.MenuStrip.
        public override Color MenuStripGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the System.Windows.Forms.ToolStripOverflowButton.
        public override Color OverflowButtonGradientBegin { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     System.Windows.Forms.ToolStripOverflowButton.
        public override Color OverflowButtonGradientEnd { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used in the System.Windows.Forms.ToolStripOverflowButton.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used in the
        //     System.Windows.Forms.ToolStripOverflowButton.
        public override Color OverflowButtonGradientMiddle { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripContainer.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the System.Windows.Forms.ToolStripContainer.
        public override Color RaftingContainerGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripContainer.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     System.Windows.Forms.ToolStripContainer.
        public override Color RaftingContainerGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the color to use to for shadow effects on the System.Windows.Forms.ToolStripSeparator.
        //
        // Returns:
        //     A System.Drawing.Color that is the color to use to for shadow effects on
        //     the System.Windows.Forms.ToolStripSeparator.
        public override Color SeparatorDark { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the color to use to for highlight effects on the System.Windows.Forms.ToolStripSeparator.
        //
        // Returns:
        //     A System.Drawing.Color that is the color to use to for highlight effects
        //     on the System.Windows.Forms.ToolStripSeparator.
        public override Color SeparatorLight { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used on the System.Windows.Forms.StatusStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used on
        //     the System.Windows.Forms.StatusStrip.
        public override Color StatusStripGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used on the System.Windows.Forms.StatusStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used on the
        //     System.Windows.Forms.StatusStrip.
        public override Color StatusStripGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the border color to use on the bottom edge of the System.Windows.Forms.ToolStrip.
        //
        // Returns:
        //     A System.Drawing.Color that is the border color to use on the bottom edge
        //     of the System.Windows.Forms.ToolStrip.
        public override Color ToolStripBorder { get { return MetroPaint.GetStyleColor(Style); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripContentPanel.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the System.Windows.Forms.ToolStripContentPanel.
        public override Color ToolStripContentPanelGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripContentPanel.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     System.Windows.Forms.ToolStripContentPanel.
        public override Color ToolStripContentPanelGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the solid background color of the System.Windows.Forms.ToolStripDropDown.
        //
        // Returns:
        //     A System.Drawing.Color that is the solid background color of the System.Windows.Forms.ToolStripDropDown.
        public override Color ToolStripDropDownBackground { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStrip
        //     background.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the System.Windows.Forms.ToolStrip background.
        public override Color ToolStripGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStrip
        //     background.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     System.Windows.Forms.ToolStrip background.
        public override Color ToolStripGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the middle color of the gradient used in the System.Windows.Forms.ToolStrip
        //     background.
        //
        // Returns:
        //     A System.Drawing.Color that is the middle color of the gradient used in the
        //     System.Windows.Forms.ToolStrip background.
        public override Color ToolStripGradientMiddle { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the starting color of the gradient used in the System.Windows.Forms.ToolStripPanel.
        //
        // Returns:
        //     A System.Drawing.Color that is the starting color of the gradient used in
        //     the System.Windows.Forms.ToolStripPanel.
        public override Color ToolStripPanelGradientBegin { get { return MetroPaint.BackColor.Form(Theme); } }
        //
        // Summary:
        //     Gets the end color of the gradient used in the System.Windows.Forms.ToolStripPanel.
        //
        // Returns:
        //     A System.Drawing.Color that is the end color of the gradient used in the
        //     System.Windows.Forms.ToolStripPanel.
        public override Color ToolStripPanelGradientEnd { get { return MetroPaint.BackColor.Form(Theme); } }
    }
}
