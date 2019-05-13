using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeSolution
{
    class GoodsDefinition : System.Windows.Forms.Form, IDisposable
    {
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBarcode1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNaka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.TextBox txtBarcodeEdit1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNakaEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlMain;
        private List<Connection.Services.GoodsService> Result = new List<Connection.Services.GoodsService>();
        private Connection.Services.GoodsService Instance = new Connection.Services.GoodsService();
        private Panel panel3;
        private Button button3;
        private Button button4;
        private TextBox txtBarcode2;
        private Label label5;
        private TextBox txtBarcodeEdit2;
        private Label label6;
        private bool isBusyProcessing = false;
        public GoodsDefinition()
        {
            InitializeComponent();
            LoadData();
            SetGrid();
        }
        private void LoadData()
        {
            Result = Connection.CrudService.InventoryCrud.ReturnAllGoodsByService();
            Result.ForEach(a => a.Total = GetTotal(a.GoodsBarcode1, a.GoodsBarcode2));
            string GetTotal(string GoodsBarcode1, string GoodsBarcode2)
            {
                if (GoodsBarcode2 == null) return "--";
                var FirstName = GoodsBarcode1.Split('-');
                var Second = GoodsBarcode2.Split('-');
                var Total = (FirstName.Count() == 3 ? FirstName[1] : "--") + "-" + (Second.Count() == 3 ? Second[1] : "--");
                return Total;
            }
            txtBarcode1.Text = txtBarcode2.Text = txtNaka.Text = string.Empty;
            txtNaka.Focus();
            dataGridView1.DataSource = Result;
            SetPnlFooter();
        }
        private void SetPnlFooter()
        {
            pnlFooter.Visible = false;
        }
        private void SetGrid()
        {
            foreach (DataGridViewColumn item in dataGridView1.Columns)
            {
                item.Visible = false;
            }
            dataGridView1.Columns["GoodsName"].Visible = true;
            dataGridView1.Columns["GoodsBarcode1"].Visible = true;
            dataGridView1.Columns["GoodsBarcode2"].Visible = true;
            dataGridView1.Columns["Total"].Visible = true;
            dataGridView1.Columns["GoodsName"].Width = 200;
            dataGridView1.Columns["GoodsBarcode1"].Width = 200;
            dataGridView1.Columns["GoodsBarcode2"].Width = 200;
            dataGridView1.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["GoodsName"].HeaderText = "Name";
            dataGridView1.Columns["GoodsBarcode1"].HeaderText = "Production NO.";
            dataGridView1.Columns["GoodsBarcode2"].HeaderText = "Serial NO.";
            dataGridView1.Columns["Total"].HeaderText = "Total";
            dataGridView1.AutoGenerateColumns = false;
        }
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.txtBarcode2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBarcode1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.txtBarcodeEdit2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.txtBarcodeEdit1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNakaEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtBarcode2);
            this.pnlTop.Controls.Add(this.label5);
            this.pnlTop.Controls.Add(this.panel3);
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Controls.Add(this.txtBarcode1);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txtNaka);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(684, 108);
            this.pnlTop.TabIndex = 0;
            // 
            // txtBarcode2
            // 
            this.txtBarcode2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode2.Location = new System.Drawing.Point(58, 41);
            this.txtBarcode2.Name = "txtBarcode2";
            this.txtBarcode2.Size = new System.Drawing.Size(245, 26);
            this.txtBarcode2.TabIndex = 2;
            this.txtBarcode2.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtBarcode2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNaka_KeyDown);
            this.txtBarcode2.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "باركد2 :";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(12, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 29);
            this.panel3.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.button3.ForeColor = System.Drawing.Color.Snow;
            this.button3.Location = new System.Drawing.Point(-1, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(105, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "ارسال به اكسل";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Excell_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button4.Location = new System.Drawing.Point(103, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 29);
            this.button4.TabIndex = 2;
            this.button4.Text = "چاپ";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.Print_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(484, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(195, 33);
            this.panel1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Crimson;
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Location = new System.Drawing.Point(17, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "انصراف";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Delete_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LimeGreen;
            this.button1.Location = new System.Drawing.Point(105, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "ثبت";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Save_Click);
            // 
            // txtBarcode1
            // 
            this.txtBarcode1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode1.Location = new System.Drawing.Point(365, 40);
            this.txtBarcode1.Name = "txtBarcode1";
            this.txtBarcode1.Size = new System.Drawing.Size(245, 26);
            this.txtBarcode1.TabIndex = 1;
            this.txtBarcode1.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtBarcode1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNaka_KeyDown);
            this.txtBarcode1.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(616, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "باركد1 :";
            // 
            // txtNaka
            // 
            this.txtNaka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNaka.Location = new System.Drawing.Point(365, 8);
            this.txtNaka.Name = "txtNaka";
            this.txtNaka.Size = new System.Drawing.Size(245, 26);
            this.txtNaka.TabIndex = 0;
            this.txtNaka.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtNaka.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNaka_KeyDown);
            this.txtNaka.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(616, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام كالا :";
            // 
            // pnlFooter
            // 
            this.pnlFooter.Controls.Add(this.txtBarcodeEdit2);
            this.pnlFooter.Controls.Add(this.label6);
            this.pnlFooter.Controls.Add(this.panel2);
            this.pnlFooter.Controls.Add(this.txtBarcodeEdit1);
            this.pnlFooter.Controls.Add(this.label3);
            this.pnlFooter.Controls.Add(this.txtNakaEdit);
            this.pnlFooter.Controls.Add(this.label4);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 255);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(684, 106);
            this.pnlFooter.TabIndex = 1;
            this.pnlFooter.Visible = false;
            // 
            // txtBarcodeEdit2
            // 
            this.txtBarcodeEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeEdit2.Location = new System.Drawing.Point(58, 39);
            this.txtBarcodeEdit2.Name = "txtBarcodeEdit2";
            this.txtBarcodeEdit2.Size = new System.Drawing.Size(245, 26);
            this.txtBarcodeEdit2.TabIndex = 2;
            this.txtBarcodeEdit2.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtBarcodeEdit2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNaka_KeyDown);
            this.txtBarcodeEdit2.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "باركد2 :";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnCancelEdit);
            this.panel2.Controls.Add(this.btnSaveEdit);
            this.panel2.Location = new System.Drawing.Point(481, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(195, 33);
            this.panel2.TabIndex = 3;
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelEdit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelEdit.Location = new System.Drawing.Point(17, 1);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(82, 29);
            this.btnCancelEdit.TabIndex = 1;
            this.btnCancelEdit.Text = "انصراف";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.CancelEdit_Click);
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSaveEdit.Location = new System.Drawing.Point(105, 1);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(82, 29);
            this.btnSaveEdit.TabIndex = 0;
            this.btnSaveEdit.Text = "ثبت";
            this.btnSaveEdit.UseVisualStyleBackColor = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.BtnSaveEdit_Click);
            // 
            // txtBarcodeEdit1
            // 
            this.txtBarcodeEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcodeEdit1.Location = new System.Drawing.Point(362, 38);
            this.txtBarcodeEdit1.Name = "txtBarcodeEdit1";
            this.txtBarcodeEdit1.Size = new System.Drawing.Size(245, 26);
            this.txtBarcodeEdit1.TabIndex = 1;
            this.txtBarcodeEdit1.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtBarcodeEdit1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNaka_KeyDown);
            this.txtBarcodeEdit1.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(613, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "باركد1 :";
            // 
            // txtNakaEdit
            // 
            this.txtNakaEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNakaEdit.Location = new System.Drawing.Point(362, 5);
            this.txtNakaEdit.Name = "txtNakaEdit";
            this.txtNakaEdit.Size = new System.Drawing.Size(245, 26);
            this.txtNakaEdit.TabIndex = 0;
            this.txtNakaEdit.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtNakaEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtNaka_KeyDown);
            this.txtNakaEdit.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(613, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "نام كالا :";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dataGridView1);
            this.pnlMain.Controls.Add(this.txtSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 108);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(684, 147);
            this.pnlMain.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(684, 121);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView1_KeyDown);
            // 
            // txtSearch
            // 
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Location = new System.Drawing.Point(0, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(684, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.Txtsearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.TxtNaka_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtsearch_KeyDown);
            this.txtSearch.Leave += new System.EventHandler(this.TxtNaka_Leave);
            // 
            // GoodsDefinition
            // 
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "GoodsDefinition";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تعريف كالا";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        private void Delete_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (txtNaka.Text.Trim() == string.Empty)
            {
                MessageBox.Show("نام كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtNaka.Focus();
                return;
            }
            if (txtBarcode1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("كد كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtBarcode1.Focus();
                return;
            }
            if (txtBarcode2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("كد كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtBarcode2.Focus();
                return;
            }
            if (Connection.CrudService.InventoryCrud.CheckForRepetitive(txtBarcode1.Text.Trim(), txtBarcode2.Text.Trim()))
            {
                string naka = Connection.CrudService.InventoryCrud.ReadByBarcode(txtBarcode1.Text.Trim(), txtBarcode2.Text.Trim());
                if (MessageBox.Show($"اين باركد براي كالاي {naka} قبلا تعريف شده است، آيا ميخواهيد مجددا اين باركد را تعريف كنيد؟", "پيغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == (DialogResult.No))
                {
                    return;
                }
            }
            if (Connection.CrudService.InventoryCrud.Create(new Connection.Model.Inventory() { Barcode1 = txtBarcode1.Text.Trim(), Name = txtNaka.Text.Trim(), Barcode2 = txtBarcode2.Text.Trim() }))
            {
                MessageBox.Show("ثبت با موفقيت انجام شد");
                LoadData();
            }
            else
            {
                MessageBox.Show("ثبت با خطا مواجه شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadEdit()
        {
            if (dataGridView1.RowCount > 0)
            {
                if (dataGridView1.CurrentRow == null)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells["GoodsBarcode"];
                }
                Instance = (Connection.Services.GoodsService)dataGridView1.CurrentRow.DataBoundItem;
                pnlFooter.Visible = true;
                txtNakaEdit.Text = Instance.GoodsName;
                txtBarcodeEdit1.Text = Instance.GoodsBarcode1;
                txtBarcodeEdit2.Text = Instance.GoodsBarcode2;
                txtNakaEdit.Focus();
            }
        }
        private void CancelEdit_Click(object sender, EventArgs e)
        {
            SetPnlFooter();
        }
        private void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"آيا از ويرايش اطمينان داريد؟", "پيغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == (DialogResult.No))
            {
                return;
            }
            if (txtNakaEdit.Text.Trim() == string.Empty)
            {
                MessageBox.Show("نام كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error,MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtNakaEdit.Focus();
                return;
            }
            if (txtBarcodeEdit1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("كد كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtBarcodeEdit1.Focus();
                return;
            }
            if (txtBarcodeEdit2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("كد كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtBarcodeEdit2.Focus();
                return;
            }
            if (Connection.CrudService.InventoryCrud.CheckForRepetitive(txtBarcode1.Text.Trim(), txtBarcodeEdit2.Text.Trim(), Instance.GoodsID))
            {
                string naka = Connection.CrudService.InventoryCrud.ReadByBarcode(txtBarcode1.Text, txtBarcodeEdit2.Text.Trim(), Instance.GoodsID);
                if (MessageBox.Show($"اين باركد براي كالاي {naka} قبلا تعريف شده است، آيا ميخواهيد مجددا اين باركد را تعريف كنيد؟", "پيغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == (DialogResult.No))
                {
                    return;
                }
            }
            if (Connection.CrudService.InventoryCrud.Update(new Connection.Model.Inventory() { GoodsID = Instance.GoodsID, Barcode1 = txtBarcodeEdit1.Text.Trim(), Name = txtNakaEdit.Text.Trim(), Barcode2 = txtBarcodeEdit2.Text.Trim()}))
            {
                MessageBox.Show("ويرايش با موفقيت انجام شد");
                LoadData();
            }
            else
            {
                MessageBox.Show("ويرايش با خطا مواجه شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void Txtsearch_TextChanged(object sender, EventArgs e)
        {
            while (isBusyProcessing)
                await Task.Delay(50);
            try
            {
                isBusyProcessing = true;
                string ResStr = txtSearch.Text.Trim();
                dataGridView1.DataSource = await System.Threading.Tasks.Task.Run(() => ResStr == string.Empty ? Result : Result.Where(a => a.GoodsBarcode1.Contains(ResStr) || a.GoodsName.Contains(ResStr) || a.Total.Contains(ResStr)).ToList());

            }
            finally
            {
                isBusyProcessing = false;
            }
        }
        private void SetActiveRow(DataGridView DG, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                string ColName = "GoodsName";
                int selected = 0;
                if (DG.RowCount > 0)
                {
                    if (DG.CurrentRow == null)
                    {
                        DG.CurrentCell = DG.Rows[0].Cells[ColName];
                    }
                    else
                    {
                        selected = DG.CurrentRow.Index;
                    }
                }

                if (txtSearch.Text.StartsWith(" "))
                {
                    txtSearch.Text = "";
                }
                if (e.KeyCode == System.Windows.Forms.Keys.Down && DG.RowCount > 0)
                {
                    if (selected < DG.Rows.Count - 1)
                        DG.CurrentCell = DG.Rows[selected + 1].Cells[ColName];
                    else
                        DG.CurrentCell = DG.Rows[0].Cells[ColName];
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.Up && DG.RowCount > 0)
                {
                    if (selected > 0)
                        DG.CurrentCell = DG.Rows[selected - 1].Cells[ColName];
                    else
                        DG.CurrentCell = DG.Rows[DG.Rows.Count - 1].Cells[ColName];
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.PageDown)
                {
                    DG.Focus();
                    txtSearch.Focus();
                    if (DG.RowCount > 0)
                    {
                        int CountRows = DG.RowCount;
                        int CurrentPosition = DG.CurrentRow.Index;
                        int NextPosition = CurrentPosition + 10;
                        int RemainTolast = (CountRows - 1) - CurrentPosition;
                        if (CurrentPosition < CountRows - 1)
                        {
                            if (NextPosition < CountRows - 1)
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index + 10].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index + 10].Cells[ColName];
                            }
                            else
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index + RemainTolast].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index + RemainTolast].Cells[ColName];
                            }

                        }
                    }
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.PageUp)
                {
                    DG.Focus();
                    txtSearch.Focus();
                    if (DG.RowCount > 0)
                    {
                        int CountRows = DG.RowCount;
                        int CurrentPosition = DG.CurrentRow.Index;
                        int NextPosition = CurrentPosition - 10;
                        int RemainToFirst = CurrentPosition;
                        if (CurrentPosition > 0)
                        {
                            if (RemainToFirst > 10)
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index - 10].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index - 10].Cells[ColName];
                            }
                            else
                            {
                                DG.Rows[DG.CurrentRow.Index].Selected = false;
                                DG.Rows[DG.CurrentRow.Index - RemainToFirst].Selected = true;
                                DG.CurrentCell = DG.Rows[DG.CurrentRow.Index - RemainToFirst].Cells[ColName];
                            }

                        }
                    }
                    System.Windows.Forms.SendKeys.Send("{END}");
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    LoadEdit();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        private void Txtsearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            SetActiveRow(dataGridView1, e);
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadEdit();
            }
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadEdit();
        }
        private void Excell_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application
                {
                    Visible = true
                };
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;
                //Write Headers
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGridView1.Columns[j].HeaderText;
                }
                StartRow++;
                //Write datagridview content
                for (i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGridView1[j, i].Value == null ? "" : dataGridView1[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Print_Click(object sender, EventArgs e)
        {
            try
            {
                Stimulsoft.Report.StiReport rpt = new Stimulsoft.Report.StiReport();
                string startupPath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
                rpt.Load(startupPath + "\\Reports\\GoodsReport.mrt");
                rpt.Dictionary.Variables["today"].Value = DateTodayFullChar();
                rpt.RegBusinessObject("Goods", (List<Connection.Services.GoodsService>)dataGridView1.DataSource);
                rpt.Render();
                rpt.Show();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        public string DateTodayFullChar()
        {
            string today;
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            int M = pc.GetMonth(DateTime.Now);
            int d = pc.GetDayOfMonth(DateTime.Now);
            today = pc.GetYear(DateTime.Now).ToString() + "/";
            if (M < 10)
                today += "0" + M.ToString() + "/";
            else
                today += M.ToString() + "/";
            if (d < 10)
                today += "0" + d.ToString();
            else
                today += d.ToString();
            return today;
        }
        private void TxtNaka_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TxtNaka_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = System.Drawing.Color.YellowGreen;
        }
        private void TxtNaka_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = System.Drawing.Color.White;
        }
    }
}
