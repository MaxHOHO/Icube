namespace U8Interface
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class F_wait : Form
    {
        private IContainer components = null;
        private ProgressBar pbr_pos;

        public F_wait()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void f_set_max(int ipos)
        {
            this.pbr_pos.Maximum = ipos;
        }

        public void f_set_pos(int ipos)
        {
            this.pbr_pos.Value = ipos;
        }

        private void F_wait_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            this.pbr_pos = new ProgressBar();
            base.SuspendLayout();
            this.pbr_pos.Location = new Point(13, 20);
            this.pbr_pos.Name = "pbr_pos";
            this.pbr_pos.Size = new Size(560, 0x1a);
            this.pbr_pos.TabIndex = 0;
            this.pbr_pos.UseWaitCursor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x263, 0x41);
            base.ControlBox = false;
            base.Controls.Add(this.pbr_pos);
            base.Name = "F_wait";
            this.Text = "F_wait";
            base.Load += new EventHandler(this.F_wait_Load);
            base.ResumeLayout(false);
        }
    }
}

