using System.Drawing;
using System.Windows.Forms;

namespace laptrinhNet
{
    public static class GiaoDien
    {
        public static Color PrimaryColor = Color.FromArgb(51, 153, 255); 
        public static Color SecondaryColor = Color.FromArgb(240, 242, 245);
        public static Color TextColor = Color.Black;
        public static Font MainFont = new Font("Segoe UI", 10, FontStyle.Regular);
        public static Font BoldFont = new Font("Segoe UI", 10, FontStyle.Bold);

        public static void ApplyTheme(Control container)
        {
            foreach (Control c in container.Controls)
            {
                if (c.HasChildren) ApplyTheme(c);
               
                if (c is Button) StyleButton((Button)c);
                else if (c is DataGridView) StyleGrid((DataGridView)c);
                else if (c is GroupBox) StyleGroupBox((GroupBox)c);
                else if (c is TextBox) StyleTextBox((TextBox)c);
                if (c.Tag != null && (c.Tag.ToString() == "Tittle"))
                {
                    continue;
                }
                else if (c is Label) StyleLabel((Label)c);
                if (c.HasChildren)
                {
                    ApplyTheme(c);
                }
            }

            if (container is Form || container is UserControl)
            {
                container.BackColor = Color.White;
            }
        }

        private static void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = BoldFont;
            btn.Cursor = Cursors.Hand;

            if (btn.BackColor == Control.DefaultBackColor || btn.BackColor == Color.Transparent || btn.BackColor == Color.White)
            {
                btn.BackColor = PrimaryColor;
            }

            if (btn.BackColor.GetBrightness() > 0.8f)
                btn.ForeColor = Color.Black;
            else
                btn.ForeColor = Color.White;

            Color originalColor = btn.BackColor;

            btn.MouseEnter -= OnBtnMouseEnter;
            btn.MouseLeave -= OnBtnMouseLeave;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = ControlPaint.Dark(originalColor, 0.2f);
            };

            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = originalColor;
            };
        }

        private static void OnBtnMouseEnter(object sender, System.EventArgs e) { }
        private static void OnBtnMouseLeave(object sender, System.EventArgs e) { }

        private static void StyleGrid(DataGridView grid)
        {
            grid.EnableHeadersVisualStyles = false;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.BackgroundColor = Color.White;

            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = BoldFont;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersHeight = 45;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = MainFont;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Padding = new Padding(5);
            grid.RowTemplate.Height = 35;
        }

        private static void StyleTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = MainFont;
        }

        private static void StyleLabel(Label lbl)
        {
            lbl.Font = MainFont;
            if (!(lbl.Parent is GroupBox))
            {
                lbl.ForeColor = TextColor;
            }
            lbl.BackColor = Color.Transparent;
        }

        private static void StyleGroupBox(GroupBox gb)
        {
            gb.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            gb.ForeColor = Color.Black;

            foreach (Control c in gb.Controls)
            {
                c.Font = MainFont;

                if (c is Label) c.ForeColor = TextColor;

                if (c is Button) StyleButton((Button)c);
                else if (c is TextBox) StyleTextBox((TextBox)c);
            }
        }
    }
}