namespace U8Interface
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    internal class init
    {
        public static string code_sql = "";
        public static SqlConnection conn;
        public static string connStr = "";
        private static string logfilepath = @"D:\first.txt";
        public static string mom_clck_code_sql;
        public static string mom_clck_sql = "";
        public static string mom_clck_xql_sql = "";
        public static string s_query_flag = "M";
        public static string so_xsfh_code_sql = "";
        public static string so_xsfh_sql = "";
        public static string so_xsfh_xql_sql = "";
        public static string swhcode_clck = "";
        public static string swhcode_xsfh = "";
        public static string swhere = "";

        public static void ExportDataGridViewToExcel(DataGridView dataGridview1)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Execl   files   (*.xls)|*.xls",
                FilterIndex = 0,
                RestoreDirectory = true,
                CreatePrompt = true,
                Title = "导出Excel文件到"
            };
            dialog.ShowDialog();
            Stream stream = dialog.OpenFile();
            StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("gb2312"));
            try
            {
                for (int i = 0; i < dataGridview1.Rows.Count; i++)
                {
                    string str = "";
                    for (int j = 0; j < dataGridview1.Columns.Count; j++)
                    {
                        if (j > 0)
                        {
                            str = str + "\t";
                        }
                        str = str + ClsSystem.gnvl(dataGridview1.Rows[i].Cells[j].Value, "");
                    }
                    writer.WriteLine(str);
                }
                writer.Close();
                stream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                writer.Close();
                stream.Close();
            }
        }

        public static void ExportDataGridViewToTSV(DataTable DGV_Data, string strFileName)
        {
            try
            {
                string str = "";
                string caption = "";
                string s = "";
                FileStream stream = File.Open(strFileName, FileMode.Create, FileAccess.Write);
                for (int i = 0; i < DGV_Data.Rows.Count; i++)
                {
                    byte[] bytes;
                    for (int j = 0; j < DGV_Data.Columns.Count; j++)
                    {
                        caption = DGV_Data.Columns[j].Caption;
                        if (caption.ToLower().IndexOf("date") >= 0)
                        {
                            str = ClsSystem.gnvl(DGV_Data.Rows[i].ItemArray[j], "");
                            if (str != "")
                            {
                                str = Convert.ToDateTime(str).ToString("yyyy-MM-dd");
                            }
                        }
                        else if ((caption.ToLower().IndexOf("quantity") >= 0) || (caption.IndexOf("amount") >= 0))
                        {
                            str = Convert.ToDecimal(ClsSystem.gnvl(DGV_Data.Rows[i].ItemArray[j], "0")).ToString("0.000");
                        }
                        else
                        {
                            str = ClsSystem.gnvl(DGV_Data.Rows[i].ItemArray[j], "");
                        }
                        if (j == 0)
                        {
                            s = str;
                        }
                        else
                        {
                            s = s + "\t" + str;
                        }
                    }
                    if (i == (DGV_Data.Rows.Count - 1))
                    {
                        bytes = Encoding.UTF8.GetBytes(s);
                    }
                    else
                    {
                        bytes = Encoding.UTF8.GetBytes(s + "\r\n");
                    }
                    stream.Write(bytes, 0, bytes.Length);
                }
                stream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        public static void ExportDataGridViewToTSV(DataGridView DGV_Data, string strFileName)
        {
            try
            {
                string str = "";
                string headerText = "";
                string s = "";
                FileStream stream = File.Open(strFileName, FileMode.Create, FileAccess.Write);
                for (int i = 0; i < DGV_Data.Rows.Count; i++)
                {
                    byte[] bytes;
                    for (int j = 0; j < DGV_Data.Columns.Count; j++)
                    {
                        headerText = DGV_Data.Columns[j].HeaderText;
                        if (headerText.ToLower().IndexOf("date") >= 0)
                        {
                            str = ClsSystem.gnvl(DGV_Data.Rows[i].Cells[j].Value, "");
                            if (str != "")
                            {
                                str = Convert.ToDateTime(str).ToString("yyyy-MM-dd");
                            }
                        }
                        else if ((headerText.ToLower().IndexOf("quantity") >= 0) || (headerText.IndexOf("amount") >= 0))
                        {
                            str = Convert.ToDecimal(ClsSystem.gnvl(DGV_Data.Rows[i].Cells[j].Value, "0")).ToString("0.000");
                        }
                        else
                        {
                            str = ClsSystem.gnvl(DGV_Data.Rows[i].Cells[j].Value, "");
                        }
                        if (j == 0)
                        {
                            s = str;
                        }
                        else
                        {
                            s = s + "\t" + str;
                        }
                    }
                    if (i == (DGV_Data.Rows.Count - 1))
                    {
                        bytes = Encoding.UTF8.GetBytes(s);
                    }
                    else
                    {
                        bytes = Encoding.UTF8.GetBytes(s + "\r\n");
                    }
                    stream.Write(bytes, 0, bytes.Length);
                }
                stream.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        public static string f_get_whcode(string ls_whcode)
        {
            int num = 0;
            int length = 0;
            string str = "";
            string str2 = "";
            if ((ls_whcode == "") || (ls_whcode == null))
            {
                ls_whcode = "";
                return ls_whcode;
            }
            length = ls_whcode.Length;
            str2 = "'";
            for (num = 1; num < (length + 1); num++)
            {
                str = ls_whcode.Substring(num - 1, 1);
                if (str == ",")
                {
                    str2 = str2 + "','";
                }
                else
                {
                    str2 = str2 + str;
                }
            }
            return (str2 + "'");
        }

        public static string f_set_ckd()
        {
            s_query_flag = "M";
            mom_clck_sql = "select  A.MoCode     订单号,B.sortseq    订单行号,B.InvCode    产品编码,I.Cinvname   产品名称,I.Cinvstd    产品规格,B.define22  制造番号,convert(numeric(18,2),B.Qty )       生产数量,M.StartDate  开工日期,M.DueDate    完工日期,convert(numeric(18,2),B.QualifiedInQty) 生产入库数量,C.InvCode        材料编码,H.Cinvname       材料名称,H.Cinvstd        材料规格,H.cinvdefine3        特性,H.cinvdefine4        库位,convert(numeric(18,2),C.Qty)            应领数量,convert(numeric(18,2),C.IssQty)         已领数量,convert(numeric(18,2),C.QTY - ISNULL(C.IssQty,0)) 未领数量 ,(select  convert(numeric(18,2),sum(isnull(iquantity,0)))   from CURRENTSTOCK  S where S.cInvCode = C.Invcode and S.cwhcode in (" + swhcode_clck + ")) 现存量,(select  convert(numeric(18,2),sum(isnull(fOutQuantity,0)))    from CURRENTSTOCK  S where S.cInvCode = C.Invcode and S.cwhcode in (" + swhcode_clck + ")) 预计出库数,(select  convert(numeric(18,2),sum(isnull(fOutQuantity,0))) 预计入库数  from CURRENTSTOCK  S where S.cInvCode = C.Invcode and S.cwhcode in (" + swhcode_clck + ")) 预计入库数,0.00   as  可出库数量, ( select  sum(convert(numeric(18,2),T.QTY - ISNULL(T.IssQty,0)))  from mom_moallocate T ,mom_orderdetail,mom_order    where T.invcode = C.invcode and mom_orderdetail.modid= T.modid and mom_orderdetail.moid= mom_order.moid and    mom_order.MoCode in(" + swhere + ")) 需求量 , (select cvenabbname from pu_VenInvPriceList where id in(select max(id) from pu_VenInvPriceList   group by cinvcode ) and pu_VenInvPriceList.cinvcode = C.invcode and H.bPurchase=1 and H.bSelf =0) 供应商, (select convert(numeric(18,2),sum(W.iQuantity - isnull(W.fRetQuantity,0)-isnull(W.fValidInQuan,0) - isnull(W.fInValidInQuan,0)))  from PU_ArrivalVouchs W where  W.iQuantity > 0 and W.cinvcode = C.invcode) 到货未入库,  (select convert(numeric(18,2),sum(PO.iQuantity -  case when isnull(iArrQTY,0) > 0 then iArrQTY else isnull(PO.iReceivedQTY ,0) end  ))  from PO_Podetails PO,PO_Pomain POM where POM.POID = PO.POID and  PO.iQuantity > case when isnull(iArrQTY,0) > 0 then iArrQTY else isnull( PO.iReceivedQTY,0) end  and PO.cinvcode = C.invcode and isnull(POM.cVerifier,'') <> '' and isnull(cbCloser,'')= '' ) 采购在途数 , (select convert(numeric(18,2),sum(MO.QTY - isnull(MO.QualifiedInQty ,0) ))  from mom_orderdetail MO where   MO.QTY > isnull( MO.QualifiedInQty,0)   and MO.invcode = C.invcode  and isnull(MO.RelsUser ,'') <> ''  and isnull(Status,0) = 3 ) 生产在制数   from mom_order        A ,     mom_orderdetail  B,     mom_moallocate   C,     mom_morder       M,     Inventory        I,     Inventory        H where A.MoId  = B.MoId   AND      B.MODID = C.MODID  AND      B.MODID = M.MODID      AND      B.Status = 3       AND      B.InvCode = I.Cinvcode AND      C.Invcode = H.cinvcode AND      C.IssQty  <  C.Qty    ";
            mom_clck_code_sql = "select  distinct A.MoCode     订单号   from mom_order        A ,     mom_orderdetail  B,     mom_moallocate   C,     mom_morder       M,     Inventory        I,     Inventory        H where A.MoId  = B.MoId   AND      B.MODID = C.MODID  AND      B.MODID = M.MODID      AND      B.Status = 3       AND      B.InvCode = I.Cinvcode AND      C.Invcode = H.cinvcode AND      C.IssQty  <  C.Qty    ";
            return mom_clck_sql;
        }

        public static string f_set_xsfh()
        {
            s_query_flag = "S";
            so_xsfh_sql = "select A.cSOCode      订单号, A.ddate        订单日期,B.dPreDate    发货日期,B.iRowNo    订单行号, B.cInvCode    产品编码, I.Cinvname   产品名称, I.Cinvstd    产品规格, I.cinvdefine3        特性,I.cinvdefine4        库位,A.cdefine3  制造番号,convert(numeric(18,2),B.iQuantity)         销售数量, convert(numeric(18,2),isnull(B.iFHQuantity,0))   已发数量, convert(numeric(18,2),B.iQuantity - isnull(B.iFHQuantity,0))   未发数量 ,  (select cvenabbname from pu_VenInvPriceList where id in(select max(id) from pu_VenInvPriceList   group by cinvcode ) and pu_VenInvPriceList.cinvcode = B.cinvcode and I.bPurchase=1 and I.bSelf =0) 供应商, (select convert(numeric(18,2),sum(W.iQuantity - isnull(W.fRetQuantity,0)-isnull(W.fValidInQuan,0) - isnull(W.fInValidInQuan,0)))  from PU_ArrivalVouchs W where  W.iQuantity > 0 and W.cinvcode = B.cinvcode) 到货未入库 ,(select  convert(numeric(18,2),sum(isnull(iquantity,0)))   from CURRENTSTOCK  S where S.cInvCode = B.cInvcode and S.cwhcode in (" + swhcode_xsfh + ")) 现存量,(select  convert(numeric(18,2),sum(isnull(fOutQuantity,0)))    from CURRENTSTOCK  S where S.cInvCode = B.cInvcode and S.cwhcode in (" + swhcode_xsfh + ")) 预计出库数,(select  convert(numeric(18,2),sum(isnull(fOutQuantity,0))) 预计入库数  from CURRENTSTOCK  S where S.cInvCode = B.cInvcode and S.cwhcode in (" + swhcode_xsfh + ")) 预计入库数,0  可发货数量,  ( select sum(convert(numeric(18,2),T.iQuantity - isnull(T.iFHQuantity,0)))  from SO_SODetails T,SO_SOMAIN where T.cinvcode = B.cinvcode and T.ID = SO_SOMAIN.ID AND SO_SOMAIN.CSOCODE in(" + swhere + ") ) 需求量   from SO_SOMain        A ,      SO_SODetails  B    ,      Inventory        I where A.ID  = B.ID   AND      A.iStatus  = 1    AND      B.cInvCode = I.Cinvcode AND           B.iQuantity       > isnull(B.iFHQuantity,0)   ";
            so_xsfh_code_sql = "select  distinct A.cSOCode      订单号,A.cdefine3  制造番号   from SO_SOMain        A ,      SO_SODetails  B    ,      Inventory        I where A.ID  = B.ID   AND      A.iStatus  = 1    AND      B.cInvCode = I.Cinvcode AND           B.iQuantity       > isnull(B.iFHQuantity,0)   ";
            return so_xsfh_sql;
        }

        public static void WriteLog(string logText)
        {
            try
            {
                StreamWriter writer;
                FileStream stream;
                if (!File.Exists(logfilepath))
                {
                    stream = new FileStream(logfilepath, FileMode.Create);
                    writer = new StreamWriter(stream);
                }
                else
                {
                    stream = new FileStream(logfilepath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                    writer = new StreamWriter(stream);
                }
                writer.WriteLine(logText);
                writer.Flush();
                writer.Close();
                stream.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

