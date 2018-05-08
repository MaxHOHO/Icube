namespace U8Interface
{
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class F_MAIN : Form
    {
        private Button b_Item;
        private Button b_set;
        private Button b_xsck;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private IContainer components = null;
        private NotifyIcon notifyIcon1;

        public F_MAIN()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new F_INIT().Show();
            base.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void F_MAIN_Load(object sender, EventArgs e)
        {
            string innerText = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string connectionString = "";
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load("StockSet.xml");
                XmlNodeList childNodes = document.SelectSingleNode("ServerSet").ChildNodes;
                foreach (XmlNode node in childNodes)
                {
                    XmlElement element = (XmlElement) node;
                    XmlNodeList list2 = element.ChildNodes;
                    foreach (XmlNode node2 in list2)
                    {
                        XmlElement element2 = (XmlElement) node2;
                        if (element2.LocalName == "Server")
                        {
                            innerText = element2.InnerText;
                        }
                        if (element2.LocalName == "Database")
                        {
                            str2 = element2.InnerText;
                        }
                        if (element2.LocalName == "User")
                        {
                            str3 = element2.InnerText;
                        }
                        if (element2.LocalName == "Password")
                        {
                            str4 = element2.InnerText;
                            if (str4 == null)
                            {
                                str4 = "";
                            }
                        }
                        if (element2.LocalName == "CLWHOUSE")
                        {
                            init.swhcode_clck = init.f_get_whcode(element2.InnerText);
                        }
                        if (element2.LocalName == "XSWHOUSE")
                        {
                            init.swhcode_xsfh = init.f_get_whcode(element2.InnerText);
                        }
                    }
                }
                if (init.conn == null)
                {
                    connectionString = "user id=" + str3 + ";data source=" + innerText + ";Connect Timeout=300;initial catalog=" + str2 + ";password=" + str4;
                    try
                    {
                        init.conn = new SqlConnection(connectionString);
                        init.conn.Open();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("无法连接帐套数据库！", "提示", MessageBoxButtons.OK);
                        new F_INIT().Show();
                    }
                }
                init.f_set_ckd();
                init.f_set_xsfh();
            }
            catch (Exception)
            {
                new F_INIT().Show();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Minimized)
            {
                base.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(F_MAIN));
            this.notifyIcon1 = new NotifyIcon(this.components);
            this.b_set = new Button();
            this.b_Item = new Button();
            this.b_xsck = new Button();
            this.button1 = new Button();
            this.button2 = new Button();
            this.button3 = new Button();
            this.button4 = new Button();
            this.button5 = new Button();
            base.SuspendLayout();
            this.notifyIcon1.Icon = (Icon) manager.GetObject("notifyIcon1.Icon");
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new EventHandler(this.notifyIcon1_Click);
            this.b_set.Location = new Point(0x73, 0x1a);
            this.b_set.Name = "b_set";
            this.b_set.Size = new Size(170, 0x23);
            this.b_set.TabIndex = 0;
            this.b_set.Text = "设置";
            this.b_set.UseVisualStyleBackColor = true;
            this.b_set.Click += new EventHandler(this.button1_Click);
            this.b_Item.Location = new Point(0x73, 0x4d);
            this.b_Item.Name = "b_Item";
            this.b_Item.Size = new Size(170, 0x23);
            this.b_Item.TabIndex = 1;
            this.b_Item.Text = "存货档案导出";
            this.b_Item.UseVisualStyleBackColor = true;
            this.b_xsck.Location = new Point(0x73, 0x84);
            this.b_xsck.Name = "b_xsck";
            this.b_xsck.Size = new Size(170, 0x23);
            this.b_xsck.TabIndex = 2;
            this.b_xsck.Text = "客户档案导出";
            this.b_xsck.UseVisualStyleBackColor = true;
            this.button1.Location = new Point(0x73, 0x197);
            this.button1.Name = "button1";
            this.button1.Size = new Size(170, 0x23);
            this.button1.TabIndex = 3;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click_1);
            this.button2.Location = new Point(0x73, 0xbb);
            this.button2.Name = "button2";
            this.button2.Size = new Size(170, 0x23);
            this.button2.TabIndex = 4;
            this.button2.Text = "产品现存量";
            this.button2.UseVisualStyleBackColor = true;
            this.button3.Location = new Point(0x73, 0xf1);
            this.button3.Name = "button3";
            this.button3.Size = new Size(170, 0x23);
            this.button3.TabIndex = 5;
            this.button3.Text = "产品入库信息";
            this.button3.UseVisualStyleBackColor = true;
            this.button4.Location = new Point(0x73, 0x125);
            this.button4.Name = "button4";
            this.button4.Size = new Size(170, 0x23);
            this.button4.TabIndex = 6;
            this.button4.Text = "产品出库信息";
            this.button4.UseVisualStyleBackColor = true;
            this.button5.Location = new Point(0x73, 0x15d);
            this.button5.Name = "button5";
            this.button5.Size = new Size(170, 0x23);
            this.button5.TabIndex = 7;
            this.button5.Text = "销售月报信息";
            this.button5.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1e3, 0x1c6);
            base.Controls.Add(this.button5);
            base.Controls.Add(this.button4);
            base.Controls.Add(this.button3);
            base.Controls.Add(this.button2);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.b_xsck);
            base.Controls.Add(this.b_Item);
            base.Controls.Add(this.b_set);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "F_MAIN";
            base.ShowInTaskbar = false;
            this.Text = "材料出库提醒";
            base.Load += new EventHandler(this.F_MAIN_Load);
            base.SizeChanged += new EventHandler(this.Form1_SizeChanged);
            base.ResumeLayout(false);
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            base.Visible = true;
            base.WindowState = FormWindowState.Normal;
            this.notifyIcon1.Visible = false;
        }
    }
}

