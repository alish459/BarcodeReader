using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeSolution
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadButtons();
        }
        private void GoodsDefine_Click(object sender, EventArgs e)
        {
            GoodsDefinition MyForm = new GoodsDefinition();
            MyForm.ShowDialog();
            LoadButtons();
        }
        private void LoadButtons()
        {
            flowLayoutPanel1.Controls.Clear();
            var Result = Connection.CrudService.InventoryCrud.ReturnAllGoods();
            int i = 0;
            foreach (var item in Result)
            {
                i++;
                Button btn = new Button
                {
                    Tag = item.Shka,
                    Text = item.Name,
                    AutoSize = true,
                    BackColor = i % 2 == 0 ? System.Drawing.Color.BurlyWood : System.Drawing.Color.DarkKhaki,
                };
                btn.Click += BtnKala_Click; ;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }
        private void BtnKala_Click(object sender, EventArgs e)
        {
            BarcodeDefinition MyForm = new BarcodeDefinition(int.Parse(((System.Windows.Forms.Button)sender).Tag.ToString()), ((System.Windows.Forms.Button)sender).Text);
            MyForm.ShowDialog();
        }
    }
}
