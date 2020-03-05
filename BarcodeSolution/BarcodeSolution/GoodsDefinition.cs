using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeSolution
{
    class GoodsDefinition : System.Windows.Forms.Form,IDisposable
    {
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtNaka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.TextBox txtNakaEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlMain;
        private List<Connection.Model.TblInventory> Result = new List<Connection.Model.TblInventory>();
        private Connection.Model.TblInventory Instance = new Connection.Model.TblInventory();
        private Button btnRemove;
        private bool isBusyProcessing = false;
        public GoodsDefinition()
        {
            InitializeComponent();
            LoadData();
            SetGrid();
        }
        private void LoadData()
        {
            Result = Connection.CrudService.InventoryCrud.ReturnAllGoods();
            txtNaka.Focus();
            dataGridView1.DataSource = Result;
            SetPnlFooter();
            txtNaka.Text = string.Empty;
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
            dataGridView1.Columns["shka"].Visible = true;
            dataGridView1.Columns["Name"].Visible = true;
            dataGridView1.Columns["shka"].Width = 60;
            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["shka"].HeaderText = "كد كالا";
            dataGridView1.Columns["Name"].HeaderText = "نام كالا";
            dataGridView1.AutoGenerateColumns = false;
        }
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNaka = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.txtNakaEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.panel1);
            this.pnlTop.Controls.Add(this.txtNaka);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(684, 42);
            this.pnlTop.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(155, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 33);
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
            this.pnlFooter.Controls.Add(this.panel2);
            this.pnlFooter.Controls.Add(this.txtNakaEdit);
            this.pnlFooter.Controls.Add(this.label4);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 312);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(684, 49);
            this.pnlFooter.TabIndex = 1;
            this.pnlFooter.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.btnCancelEdit);
            this.panel2.Controls.Add(this.btnSaveEdit);
            this.panel2.Location = new System.Drawing.Point(78, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(281, 33);
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
            this.btnSaveEdit.Location = new System.Drawing.Point(189, 1);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(82, 29);
            this.btnSaveEdit.TabIndex = 0;
            this.btnSaveEdit.Text = "ثبت";
            this.btnSaveEdit.UseVisualStyleBackColor = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.BtnSaveEdit_Click);
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
            this.pnlMain.Location = new System.Drawing.Point(0, 42);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(684, 270);
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
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(684, 244);
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
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Red;
            this.btnRemove.ForeColor = System.Drawing.Color.Transparent;
            this.btnRemove.Location = new System.Drawing.Point(102, 1);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 29);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "حذف";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
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
            if (Connection.CrudService.InventoryCrud.CheckForRepetitive(txtNaka.Text.Trim()))
            {
                string naka = Connection.CrudService.InventoryCrud.ReadByBarcode(txtNaka.Text.Trim());
                if (MessageBox.Show($"نام كالا قبلا تعريف شده است، آيا ميخواهيد مجددا كالا را تعريف كنيد؟", "پيغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == (DialogResult.No))
                {
                    return;
                }
            }
            if (Connection.CrudService.InventoryCrud.Create(new Connection.Model.TblInventory() { Name=txtNaka.Text.Trim() }))
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
                Instance = (Connection.Model.TblInventory)dataGridView1.CurrentRow.DataBoundItem;
                pnlFooter.Visible = true;
                txtNakaEdit.Text = Instance.Name;
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
                MessageBox.Show("نام كالا نميتواند خالي باشد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                txtNakaEdit.Focus();
                return;
            }
            if (Connection.CrudService.InventoryCrud.CheckForRepetitive(txtNakaEdit.Text.Trim(), Instance.Shka))
            {
                string naka = Connection.CrudService.InventoryCrud.ReadByBarcode(txtNakaEdit.Text.Trim(), Instance.Shka);
                if (MessageBox.Show($"نام كالا قبلا تعريف شده است، آيا ميخواهيد مجددا اين نام كالا را تعريف كنيد؟", "پيغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == (DialogResult.No))
                {
                    return;
                }
            }
            if (Connection.CrudService.InventoryCrud.Update(new Connection.Model.TblInventory() { Shka = Instance.Shka,Name = txtNakaEdit.Text.Trim() }))
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
                dataGridView1.DataSource = await System.Threading.Tasks.Task.Run(() => ResStr == string.Empty ? Result : Result.Where(a => a.Name.Contains(ResStr)).ToList());

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
                string ColName = "Name";
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

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"آيا از حذف اطمينان داريد؟", "پيغام", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) == (DialogResult.No))
                {
                    return;
                }
                if (Connection.CrudService.InventoryCrud.Delete(ID: Instance.Shka))
                {
                    MessageBox.Show("حذف با موفقيت انجام شد");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("حذف با خطا مواجه شد", "پيغام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }
    }
}
