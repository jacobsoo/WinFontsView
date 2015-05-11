using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;

namespace WinFontsView
{
    public partial class frmMain : Form
    {
        public frmMain(){
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e){
            int iFonts = 0;
            DataTable table = new DataTable();
            dgvFonts.DataSource = table;
            table.Columns.Add("Fonts", typeof(string));
            table.Columns.Add("Sample", typeof(string));

            InstalledFontCollection fonts = new InstalledFontCollection();
            iFonts = fonts.Families.Length;
            while (table.Rows.Count < iFonts){
                table.Rows.Add();
            }
            List<string> list = new List<string>();
            try{
                foreach (FontFamily font in fonts.Families){
                    list.Add(font.Name);
                }
            }catch{
            }

            for (int a = 0; a < iFonts; a++){
                table.Rows[a][0] = list[a];
                FontFamily currentFont = new FontFamily(list[a].ToString());
                if (currentFont.IsStyleAvailable(FontStyle.Regular)){
                    dgvFonts.Rows[a].Cells[1].Style.Font = new Font(list[a].ToString(), 14, FontStyle.Regular, GraphicsUnit.Point);
                }else if (currentFont.IsStyleAvailable(FontStyle.Bold)){
                    dgvFonts.Rows[a].Cells[1].Style.Font = new Font(list[a].ToString(), 14, FontStyle.Bold, GraphicsUnit.Point);
                }else if (currentFont.IsStyleAvailable(FontStyle.Italic)){
                    dgvFonts.Rows[a].Cells[1].Style.Font = new Font(list[a].ToString(), 14, FontStyle.Italic, GraphicsUnit.Point);
                }
                table.Rows[a][1] = "Hello World! The font size is 14.";
            }
            dgvFonts.AutoResizeColumns();
            tslFonts.Text = iFonts + " fonts installed";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e){
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("WinFontsView by Jacob Soo", "About");
        }
    }
}
