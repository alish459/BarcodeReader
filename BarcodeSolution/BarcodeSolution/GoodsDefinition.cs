using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeSolution
{
    class GoodsDefinition : System.Windows.Forms.Form
    {
        public GoodsDefinition()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GoodsDefinition
            // 
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "GoodsDefinition";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "تعريف كالا";
            this.ResumeLayout(false);

        }
    }
}
