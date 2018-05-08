namespace U8Interface
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;

    public class F_INIT : Form
    {
        private Button b_cancle;
        private Button cb_ok;
        private IContainer components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox TCustomer;
        private TextBox textBoxServer;
        private TextBox textDatabase;
        private TextBox textPassword;
        private TextBox textUser;
        private TextBox THKCustomer;
        private TextBox THKVendor;
        private TextBox TInvCK;
        private TextBox TInvCKMonth;
        private TextBox TInvRK;
        private TextBox TInvStock;
        private TextBox TItemMaster;

        public F_INIT()
        {
            this.InitializeComponent();
        }

        private void b_cancle_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cb_ok_Click(object sender, EventArgs e)
        {
            try
            {
                ClsXML.creatXML("StockSet.xml", "ServerSet");
                ClsXML.removeAllElement("StockSet.xml");
                DataSet ds = new DataSet();
                ds.Tables.Add();
                ds.Tables[0].Clear();
                ds.Tables[0].Columns.Add("Server");
                ds.Tables[0].Columns.Add("Database");
                ds.Tables[0].Columns.Add("User");
                ds.Tables[0].Columns.Add("Password");
                ds.Tables[0].Columns.Add("ItemMaster");
                ds.Tables[0].Columns.Add("Customer");
                ds.Tables[0].Columns.Add("InvStock");
                ds.Tables[0].Columns.Add("InvRK");
                ds.Tables[0].Columns.Add("InvCK");
                ds.Tables[0].Columns.Add("InvCKMonth");
                ds.Tables[0].Columns.Add("HKVendor");
                ds.Tables[0].Columns.Add("HKCustomer");
                ds.Tables[0].Rows.Add(new object[0]);
                ds.Tables[0].Rows[0]["Server"] = ClsSystem.gnvl(this.textBoxServer.Text, "");
                ds.Tables[0].Rows[0]["Database"] = ClsSystem.gnvl(this.textDatabase.Text, "");
                ds.Tables[0].Rows[0]["User"] = ClsSystem.gnvl(this.textUser.Text, "");
                ds.Tables[0].Rows[0]["Password"] = ClsSystem.gnvl(this.textPassword.Text, "");
                ds.Tables[0].Rows[0]["ItemMaster"] = ClsSystem.gnvl(this.TItemMaster.Text, "");
                ds.Tables[0].Rows[0]["Customer"] = ClsSystem.gnvl(this.TCustomer.Text, "");
                ds.Tables[0].Rows[0]["InvStock"] = ClsSystem.gnvl(this.TInvStock.Text, "");
                ds.Tables[0].Rows[0]["InvRK"] = ClsSystem.gnvl(this.TInvRK.Text, "");
                ds.Tables[0].Rows[0]["InvCK"] = ClsSystem.gnvl(this.TInvCK.Text, "");
                ds.Tables[0].Rows[0]["InvCKMonth"] = ClsSystem.gnvl(this.TInvCKMonth.Text, "");
                ds.Tables[0].Rows[0]["HKVendor"] = ClsSystem.gnvl(this.THKVendor.Text, "");
                ds.Tables[0].Rows[0]["HKCustomer"] = ClsSystem.gnvl(this.THKCustomer.Text, "");
                ClsXML.addElement("StockSet.xml", ds);
                MessageBox.Show("保存成功！", "", MessageBoxButtons.OK);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void F_INIT_Load(object sender, EventArgs e)
        {
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
                            this.textBoxServer.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "Database")
                        {
                            this.textDatabase.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "User")
                        {
                            this.textUser.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "Password")
                        {
                            this.textPassword.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "ItemMaster")
                        {
                            this.TItemMaster.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "Customer")
                        {
                            this.TCustomer.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "InvStock")
                        {
                            this.TInvStock.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "InvRK")
                        {
                            this.TInvRK.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "InvCK")
                        {
                            this.TInvCK.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "InvCKMonth")
                        {
                            this.TInvCKMonth.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "HKVendor")
                        {
                            this.THKVendor.Text = element2.InnerText;
                        }
                        if (element2.LocalName == "HKCustomer")
                        {
                            this.THKCustomer.Text = element2.InnerText;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void InitializeComponent()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(F_INIT));
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.textBoxServer = new TextBox();
            this.textDatabase = new TextBox();
            this.textUser = new TextBox();
            this.textPassword = new TextBox();
            this.TItemMaster = new TextBox();
            this.TCustomer = new TextBox();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.label6 = new Label();
            this.label5 = new Label();
            this.TInvCKMonth = new TextBox();
            this.TInvCK = new TextBox();
            this.label10 = new Label();
            this.label9 = new Label();
            this.label8 = new Label();
            this.label7 = new Label();
            this.TInvRK = new TextBox();
            this.TInvStock = new TextBox();
            this.cb_ok = new Button();
            this.b_cancle = new Button();
            this.label11 = new Label();
            this.THKVendor = new TextBox();
            this.label12 = new Label();
            this.THKCustomer = new TextBox();
            this.groupBox3 = new GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x13, 0x15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器名称:";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x13, 0x33);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x47, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库名称:";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x19, 0x54);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x3b, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "登录用户:";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1f, 0x75);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "密   码:";
            this.textBoxServer.Location = new Point(0x61, 0x15);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new Size(0xa1, 0x15);
            this.textBoxServer.TabIndex = 6;
            this.textDatabase.Location = new Point(0x60, 0x33);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new Size(0xa1, 0x15);
            this.textDatabase.TabIndex = 7;
            this.textUser.Location = new Point(0x61, 0x51);
            this.textUser.Name = "textUser";
            this.textUser.Size = new Size(0xa1, 0x15);
            this.textUser.TabIndex = 8;
            this.textPassword.Location = new Point(0x61, 0x72);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new Size(0xa1, 0x15);
            this.textPassword.TabIndex = 9;
            this.TItemMaster.Location = new Point(0x6c, 0xc6);
            this.TItemMaster.Name = "TItemMaster";
            this.TItemMaster.Size = new Size(0x134, 0x15);
            this.TItemMaster.TabIndex = 10;
            this.TCustomer.Location = new Point(0x6c, 0xe1);
            this.TCustomer.Name = "TCustomer";
            this.TCustomer.Size = new Size(0x134, 0x15);
            this.TCustomer.TabIndex = 11;
            this.groupBox1.Controls.Add(this.textPassword);
            this.groupBox1.Controls.Add(this.textUser);
            this.groupBox1.Controls.Add(this.textDatabase);
            this.groupBox1.Controls.Add(this.textBoxServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = Color.Blue;
            this.groupBox1.Location = new Point(12, 0x19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0x1a3, 0x8f);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库设定";
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TInvCKMonth);
            this.groupBox2.Controls.Add(this.TInvCK);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.TInvRK);
            this.groupBox2.Controls.Add(this.TInvStock);
            this.groupBox2.ForeColor = Color.Blue;
            this.groupBox2.Location = new Point(12, 0xae);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(420, 0xbc);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出文件位置设定";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x1d, 0x36);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x3b, 12);
            this.label6.TabIndex = 0x18;
            this.label6.Text = "客户档案:";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x1d, 0x1b);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x3b, 12);
            this.label5.TabIndex = 0x17;
            this.label5.Text = "产品档案:";
            this.TInvCKMonth.Location = new Point(0x60, 0xa3);
            this.TInvCKMonth.Name = "TInvCKMonth";
            this.TInvCKMonth.Size = new Size(0x134, 0x15);
            this.TInvCKMonth.TabIndex = 0x16;
            this.TInvCK.Location = new Point(0x60, 0x87);
            this.TInvCK.Name = "TInvCK";
            this.TInvCK.Size = new Size(0x134, 0x15);
            this.TInvCK.TabIndex = 0x15;
            this.label10.AutoSize = true;
            this.label10.Location = new Point(6, 0xa5);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x53, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "存货出库月报:";
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x1d, 140);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x3b, 12);
            this.label9.TabIndex = 0x13;
            this.label9.Text = "存货出库:";
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x1d, 0x72);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x3b, 12);
            this.label8.TabIndex = 0x12;
            this.label8.Text = "存货入库:";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x1d, 0x51);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x3b, 12);
            this.label7.TabIndex = 0x10;
            this.label7.Text = "产品库存:";
            this.TInvRK.Location = new Point(0x60, 0x6a);
            this.TInvRK.Name = "TInvRK";
            this.TInvRK.Size = new Size(0x134, 0x15);
            this.TInvRK.TabIndex = 0x11;
            this.TInvStock.Location = new Point(0x60, 0x4e);
            this.TInvStock.Name = "TInvStock";
            this.TInvStock.Size = new Size(0x134, 0x15);
            this.TInvStock.TabIndex = 0x10;
            this.cb_ok.Location = new Point(90, 0x1c8);
            this.cb_ok.Name = "cb_ok";
            this.cb_ok.Size = new Size(0x4b, 0x17);
            this.cb_ok.TabIndex = 14;
            this.cb_ok.Text = "确定";
            this.cb_ok.UseVisualStyleBackColor = true;
            this.cb_ok.Click += new EventHandler(this.cb_ok_Click);
            this.b_cancle.Location = new Point(0x12e, 0x1c8);
            this.b_cancle.Name = "b_cancle";
            this.b_cancle.Size = new Size(0x4b, 0x17);
            this.b_cancle.TabIndex = 15;
            this.b_cancle.Text = "取消";
            this.b_cancle.UseVisualStyleBackColor = true;
            this.b_cancle.Click += new EventHandler(this.b_cancle_Click);
            this.label11.AutoSize = true;
            this.label11.ForeColor = Color.Blue;
            this.label11.Location = new Point(0x15, 0x182);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x5f, 12);
            this.label11.TabIndex = 0x19;
            this.label11.Text = "协和香港供应商:";
            this.THKVendor.Location = new Point(0x79, 0x17f);
            this.THKVendor.Name = "THKVendor";
            this.THKVendor.Size = new Size(0x127, 0x15);
            this.THKVendor.TabIndex = 0x18;
            this.label12.AutoSize = true;
            this.label12.ForeColor = Color.Blue;
            this.label12.Location = new Point(0x1f, 0x19c);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x53, 12);
            this.label12.TabIndex = 0x1a;
            this.label12.Text = "协和香港客户:";
            this.THKCustomer.Location = new Point(0x79, 0x19c);
            this.THKCustomer.Name = "THKCustomer";
            this.THKCustomer.Size = new Size(0x127, 0x15);
            this.THKCustomer.TabIndex = 0x1b;
            this.groupBox3.Location = new Point(12, 0x170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x1a3, 0x52);
            this.groupBox3.TabIndex = 0x1c;
            this.groupBox3.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x21a, 0x1ee);
            base.Controls.Add(this.THKCustomer);
            base.Controls.Add(this.label12);
            base.Controls.Add(this.label11);
            base.Controls.Add(this.THKVendor);
            base.Controls.Add(this.b_cancle);
            base.Controls.Add(this.cb_ok);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.TCustomer);
            base.Controls.Add(this.TItemMaster);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox3);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "F_INIT";
            this.Text = "系统参数设置";
            base.Load += new EventHandler(this.F_INIT_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

