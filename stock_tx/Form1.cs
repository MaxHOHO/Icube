namespace stock_tx
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Xml;
    using U8Interface;

    public class Form1 : Form
    {
        private DataGridViewTextBoxColumn AllocatedQuantity;
        private DataGridViewTextBoxColumn AvailableDate;
        private IContainer components = null;
        private DataGridViewTextBoxColumn Currency;
        private DataGridViewTextBoxColumn CustomerCode;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn DataType;
        private DataGridViewTextBoxColumn dateofmanufacture;
        private DataGridView DGV_DATA_FActualInventoryExport;
        private DataGridView DGV_DATA_FActualReceivingExport;
        private DataGridView DGV_DATA_FActualShippingExport;
        private DataGridView DGV_DATA_FActualShippingMonthlyExport;
        private DataGridView DGV_DATA_FCustomerExport;
        private DataGridView DGV_DATA_FInvExport;
        private DataGridViewTextBoxColumn ETA;
        private DataGridViewTextBoxColumn FreeQuantity;
        private DataGridViewTextBoxColumn GlobalKPSCode;
        private DataGridViewTextBoxColumn Intransitflag;
        private DataGridViewTextBoxColumn InventoryCheckDate;
        private DataGridViewTextBoxColumn inventorystatus;
        private DataGridViewTextBoxColumn InvoiceNumber;
        private DataGridViewTextBoxColumn ItemCode;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Itemtype;
        private DataGridViewTextBoxColumn LocationCode;
        private DataGridViewTextBoxColumn LocationName;
        private DataGridViewTextBoxColumn lotnumber;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn RecognizeDate;
        private DataGridViewTextBoxColumn RepresentativeCode;
        private DataGridViewTextBoxColumn RepresentativeName;
        private DataGridViewTextBoxColumn SALESAMOUNT;
        private DataGridViewTextBoxColumn SalesLocationCode;
        private DataGridViewTextBoxColumn SalesLocationName;
        private DataGridViewTextBoxColumn Salesregognizedmonth;
        private DataGridViewTextBoxColumn ShippingDate;
        private DataGridViewTextBoxColumn ShippingLocationCode;
        private DataGridViewTextBoxColumn ShippingLocationName;
        private DataGridViewTextBoxColumn ShippingType;
        private DataGridViewTextBoxColumn SlipNumber;
        private DataGridViewTextBoxColumn Sourcesystem;
        private DataGridViewTextBoxColumn StockedDate;
        private DataGridViewTextBoxColumn Storingtype;
        private DataGridViewTextBoxColumn Unit;

        public Form1()
        {
            Import();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private static void fGetItemValue_FActualInventoryExport()
        {
            string strFileName = "";
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
                        if (element2.LocalName == "InvStock")
                        {
                            strFileName = element2.InnerText;
                        }
                    }
                }
                //string str2 = "select 'INVE' DataType,'SK' Sourcesystem,'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,A.cinvcode ItemCode,max(B.cinvname + B.cinvstd)  ItemName,\n case when  left(cinvccode,3) in ('212','112')  then  isnull(sum(iquantity),0) else isnull(sum(iquantity),0) end  FreeQuantity , 'KG' Unit,\n dateofmanufacture= (case when  left(cinvccode,3) not in ('212','112')  then NULL else  (select MAX( RD.dVeriDate)  from rdrecord10 RD \n left join rdrecords10 RDS on RD.ID = RDS.ID where A.cinvcode = RDS.cinvcode and A.cbatch = RDS.cbatch )  end ) ,\n A.cBatch lotnumber , case when A.cwhcode = '13' then '2'  else '1' end inventorystatus ,\n InventoryCheckDate =(convert(varchar(10),getdate(),121)) \n from Currentstock A left join Inventory B on A.cinvcode = B.cinvcode \n left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \n where(B.cinvccode like '212%' or B.cinvccode like '112%') or B.cInvCCode like '130%' or B.cInvCCode like '230%' \n or B.cInvCCode like '101%' or B.cInvCCode like '201%' or B.cInvCCode like '12002%' or B.cInvCCode like '22002%' \n  group by A.cinvcode,B.cinvname, C.cEnSingular ,left(cinvccode,3),A.cBatch,A.cwhcode \n having isnull(sum(iquantity),0) <> 0  ";
                //str2 = str2 + " \n Union \n" + " select 'INVE' DataType,'SK' Sourcesystem,'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,A.cinvcode ItemCode,max(B.cinvname + B.cinvstd)  ItemName,\n isnull(sum(FQUANTITY),0)  FreeQuantity,'KG' Unit,\n dateofmanufacture= (case when  left(cinvccode,3) not in ('212','112')  then NULL else (select MAX( RD.dVeriDate)  from rdrecord10 RD \n left join rdrecords10 RDS on RD.ID = RDS.ID and A.cinvcode = RDS.cinvcode and A.cbatch = RDS.cbatch )  end ) ,\n A.cBatch lotnumber , '0' inventorystatus ,\n InventoryCheckDate =(convert(varchar(10),getdate(),121)) \n from QMCHECKVOUCHER  A left join Inventory B on A.cinvcode = B.cinvcode \n left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \n where (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \n or B.cInvCCode like '101%' or B.cInvCCode like '201%' or B.cInvCCode like '12002%' or B.cInvCCode like '22002%') \n  and A.BPUINFLAG = 0 and BPROINFLAG  = 0 and BREJFLAG  = 0   \n group by A.cinvcode,B.cinvname, C.cEnSingular ,left(cinvccode,3),A.cBatch,A.cwhcode";

                //SqlDataAdapter adapter = new SqlDataAdapter(str2 + " \n Union \n" + " select 'INVE' DataType,'SK' Sourcesystem,'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,A.cinvcode ItemCode,max(B.cinvname + B.cinvstd)  ItemName,\n isnull(sum(FQUANTITY),0)  FreeQuantity,'KG' Unit,\n dateofmanufacture= (case when  left(cinvccode,3) not in ('212','112')  then NULL else (select MAX( RD.dVeriDate)  from rdrecord10 RD \n left join rdrecords10 RDS on RD.ID = RDS.ID and A.cinvcode = RDS.cinvcode and A.cbatch = RDS.cbatch )  end ) ,\n A.cBatch lotnumber , '0' inventorystatus ,\n InventoryCheckDate =(convert(varchar(10),getdate(),121)) \n from QMCHECKVOUCHER  A left join Inventory B on A.cinvcode = B.cinvcode \n left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \n where (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \n or B.cInvCCode like '101%' or B.cInvCCode like '201%' or B.cInvCCode like '12002%' or B.cInvCCode like '22002%') \n  and A.BPUINFLAG = 0 and BPROINFLAG  = 0 and BREJFLAG  = 0   \n group by A.cinvcode,B.cinvname, C.cEnSingular ,left(cinvccode,3),A.cBatch,A.cwhcode", init.conn);
                string str2 = @"SELECT 'INVE' DataType,'SK' Sourcesystem,'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,A.cinvcode ItemCode,max(B.cinvname + B.cinvstd) ItemName,
                        CASE
                        WHEN left(cinvccode,3) IN ('271','171') THEN
                        isnull(sum(iquantity),0)
                        ELSE isnull(sum(iquantity),0)
                        END FreeQuantity , 'KG' Unit, dateofmanufacture= (case
                        WHEN left(cinvccode,3) NOT IN ('271','171') THEN
                        NULL
                        ELSE 
                        (SELECT MAX( RD.dVeriDate)
                        FROM rdrecord10 RD    --产成品入库单主表
                        LEFT JOIN rdrecords10 RDS  --产成品入库单子表
                            ON RD.ID = RDS.ID
                        WHERE A.cinvcode = RDS.cinvcode 
                                AND A.cbatch = RDS.cbatch )
                            END ) , A.cBatch lotnumber ,
                        CASE
                        WHEN A.cwhcode = '13' THEN  --仓库编码
                        '2'
                        ELSE '1'
                        END inventorystatus , InventoryCheckDate =(convert(varchar(10),getdate(),121))
                    FROM Currentstock A  --现存量汇总表
                    LEFT JOIN Inventory B
                        ON A.cinvcode = B.cinvcode
                    LEFT JOIN ComputationUnit C  --计量单位
                        ON B.cGroupCode = C.cGroupCode
                            AND B.cComunitCode = C.cComunitCode where(B.cinvccode LIKE '271%'
                            OR B.cinvccode LIKE '171%'
                            OR B.cInvCCode LIKE '181%'
                            OR B.cInvCCode LIKE '281%'
                            OR B.cInvCCode LIKE '131%'
                            OR B.cInvCCode LIKE '231%'
                            OR B.cInvCCode LIKE '152%'
                            OR B.cInvCCode LIKE '252%') 
                    GROUP BY  A.cinvcode,B.cinvname, C.cEnSingular ,left(cinvccode,3),A.cBatch,A.cwhcode
                    HAVING isnull(sum(iquantity),0) <> 0
                    union
                    SELECT 'INVE' DataType,'SK' Sourcesystem,'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,A.cinvcode ItemCode,max(B.cinvname + B.cinvstd) ItemName, isnull(sum(FQUANTITY),0) FreeQuantity,'KG' Unit, dateofmanufacture= (case
                        WHEN left(cinvccode,3) NOT IN ('271','171') THEN
                        NULL
                        ELSE 
                        (SELECT MAX( RD.dVeriDate)
                        FROM rdrecord10 RD
                        LEFT JOIN rdrecords10 RDS
                            ON RD.ID = RDS.ID
                                AND A.cinvcode = RDS.cinvcode
                                AND A.cbatch = RDS.cbatch )
                            END ) , A.cBatch lotnumber , '0' inventorystatus , InventoryCheckDate =(convert(varchar(10),getdate(),121))
                    FROM QMCHECKVOUCHER A  --检验单主表
                    LEFT JOIN Inventory B
                        ON A.cinvcode = B.cinvcode
                    LEFT JOIN ComputationUnit C
                        ON B.cGroupCode = C.cGroupCode
                            AND B.cComunitCode = C.cComunitCode
                    WHERE (B.cinvccode LIKE '271%'
                            OR B.cinvccode LIKE '171%'
                            OR B.cInvCCode LIKE '181%'
                            OR B.cInvCCode LIKE '281%'
                            OR B.cInvCCode LIKE '131%'
                            OR B.cInvCCode LIKE '231%'
                            OR B.cInvCCode LIKE '152%'
                            OR B.cInvCCode LIKE '252%')
                            AND A.BPUINFLAG = 0
                            AND BPROINFLAG = 0
                            AND BREJFLAG = 0
                            and CCHECKTYPECODE = 'ARR'
                    GROUP BY  A.cinvcode,B.cinvname, C.cEnSingular ,left(cinvccode,3),A.cBatch,A.cwhcode ";

                SqlDataAdapter adapter = new SqlDataAdapter(str2, init.conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                init.ExportDataGridViewToTSV(dataSet.Tables[0], strFileName);
            }
            catch (Exception)
            {
            }
        }

        private static void fGetItemValue_FActualReceivingExport()
        {
            string strFileName = "";
            string innerText = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
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
                        if (element2.LocalName == "InvRK")
                        {
                            strFileName = element2.InnerText;
                        }
                        if (element2.LocalName == "HKVendor")
                        {
                            innerText = element2.InnerText;
                        }
                        if (element2.LocalName == "HKCustomer")
                        {
                            str3 = element2.InnerText;
                        }
                        if (element2.LocalName == "ShippingExportStartTime")
                        {
                            str4 = element2.InnerText;
                        }
                        if (element2.LocalName == "ShippingExportEndTime")
                        {
                            str5 = element2.InnerText;
                        }
                    }
                }
                //string str6 = ("select 'RECE' DataType,'SK' Sourcesystem,(A.cCode + B.cinvcode + AA.cbatch) SlipNumber , \n A.cDefine10 InvoiceNumber,  case when A.cVencode in ( " + innerText + ") then '2' else '3' end Storingtype ,\n 'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,\n  convert(varchar(10),A.dVeriDate,121)   StockedDate ,\n  convert(varchar(10),A.dVeriDate,121) AvailableDate, \n '' ETA,'' ETD,   AA.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,\n  AA.cBatch lotnumber ,\n '' changeitemcode,'' changeitemname,  AA.iquantity  Quantity, \n    'KG'   Unit,   \n  case when v.cVenDefine2 is null then v.cVenCode else v.cVenDefine2 end VenCode,v.cVenName VenName,AA.ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate   from RdRecord01  A left join  RdRecords01  AA on A.ID = AA.ID  left join Inventory B on AA.cinvcode = B.cinvcode \n  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \n left join Vendor v on a.cVenCode=v.cVenCode  where( B.cInvCCode like '130%' or B.cInvCCode like '230%' \n or B.cInvCCode like '101%' or B.cInvCCode like '201%' or B.cInvCCode like '12002%' or B.cInvCCode like '22002%'\n ) and A.dDate between '" + str4 + "' and '" + str5 + "' ") + " \n Union \n";
                //str6 = (str6 + "select 'RECE' DataType,'SK' Sourcesystem,(A.cCode + B.cinvcode + AA.cbatch) SlipNumber , \n '' InvoiceNumber  , '1' Storingtype ,\n 'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,\n  convert(varchar(10),A.dVeriDate,121)   StockedDate ,\n  convert(varchar(10),A.dVeriDate,121) AvailableDate, \n '' ETA,'' ETD,   AA.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,\n  AA.cBatch lotnumber ,\n '' changeitemcode,'' changeitemname,  AA.iquantity   Quantity, \n    'KG'   Unit,   \n  '' VenCode,'' VenName,0 ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate   from RdRecord10  A left join  RdRecords10  AA on A.ID = AA.ID  left join Inventory B on AA.cinvcode = B.cinvcode \n  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \n where (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \t or B.cInvCCode like '12002%' or B.cInvCCode like '22002%') and A.dDate between '" + str4 + "' and '" + str5 + "'  ") + " \n Union \n";
                //str6 = str6 + "select 'RECE' DataType,'SK' Sourcesystem,(v.cAVCode + B.cinvcode + vs.cAVBatch) SlipNumber , \r\n\t             '' InvoiceNumber  , '4' Storingtype ,\r\n\t             'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t              convert(varchar(10),rd.dVeriDate,121) StockedDate ,\r\n\t              convert(varchar(10),rd.dVeriDate,121) AvailableDate, \r\n\t             '' ETA,'' ETD, \r\n\t              vs.cinvcode ItemCode,(B.cinvname + isnull(B.cinvstd,''))  ItemName,\r\n\t              vs.cAVBatch lotnumber ,\r\n\t             m.cInvCode changeitemcode,(m.cinvname + isnull(m.cinvstd,'')) changeitemname,\r\n\t              vs.iAVQuantity Quantity, \r\n\t               'KG'   Unit,  \r\n\t             '' VenCode,'' VenName,0 ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate \r\n\t              from AssemVouch v\r\n\t              left join AssemVouchs vs on v.ID=vs.ID \r\n\t              left join (\r\n\t               select v.ID,vs.cInvCode,b.cInvName,b.cInvStd from AssemVouch v\r\n\t               left join AssemVouchs vs on v.ID=vs.ID \r\n\t               left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t               where cVouchType = 15 and bavtype ='转换前'\r\n\t              ) m on m.ID=v.ID\r\n\t              left join\r\n\t              (select cbuscode,dveridate from RdRecord08 rd\r\n\t\t            left join rdrecords08 rds on rd.ID =rds.ID\r\n\t\t            where cbustype = '转换入库') rd on rd.cBusCode = v.cAVCode\r\n                  left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t              left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t             where cVouchType = 15 and bavtype ='转换后' and rd.dVeriDate is not null and \r\n\t              (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n\t             or B.cInvCCode like '12002%' or B.cInvCCode like '22002%') \r\n                   and rd.dVeriDate between '" + str4 + "' and '" + str5 + "' \r\n            ";

                string str6 = @" SELECT 'RECE' DataType,'SK' Sourcesystem,(A.cCode + B.cinvcode + AA.cbatch) SlipNumber , A.cDefine10 InvoiceNumber,
                        CASE
                        WHEN A.cVencode IN ( '344001','392001','840001') THEN   --供应商编码
                        '2'
                        ELSE '3'
                        END Storingtype , 'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName, convert(varchar(10),A.dVeriDate,121) StockedDate , convert(varchar(10),A.dVeriDate,121) AvailableDate, '' ETA,'' ETD, AA.cinvcode ItemCode,(B.cinvname + B.cinvstd) ItemName, AA.cBatch lotnumber , '' changeitemcode,'' changeitemname, AA.iquantity Quantity, 'KG' Unit,
                        CASE
                        WHEN v.cVenDefine2 is NULL THEN
                        v.cVenCode
                        ELSE v.cVenDefine2
                        END VenCode,v.cVenName VenName,AA.ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate
                    FROM RdRecord01 A  --采购入库单主表
                    LEFT JOIN RdRecords01 AA
                        ON A.ID = AA.ID
                    LEFT JOIN Inventory B
                        ON AA.cinvcode = B.cinvcode
                    LEFT JOIN ComputationUnit C
                        ON B.cGroupCode = C.cGroupCode
                            AND B.cComunitCode = C.cComunitCode
                    LEFT JOIN Vendor v  --供应商档案
                        ON a.cVenCode=v.cVenCode where( B.cInvCCode LIKE '181%'
                            OR B.cInvCCode LIKE '281%'
                            OR B.cInvCCode LIKE '131%'
                            OR B.cInvCCode LIKE '231%'
                            OR B.cInvCCode LIKE '152%'
                            OR B.cInvCCode LIKE '252%' )
                            AND A.dDate
                        BETWEEN '2013-10-01'
                            AND '2099-01-01'
                    UNION
                    SELECT 'RECE' DataType,'SK' Sourcesystem,(A.cCode + B.cinvcode + AA.cbatch) SlipNumber , '' InvoiceNumber , '1' Storingtype , 'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName, convert(varchar(10),A.dVeriDate,121) StockedDate , convert(varchar(10),A.dVeriDate,121) AvailableDate, '' ETA,'' ETD, AA.cinvcode ItemCode,(B.cinvname + B.cinvstd) ItemName, AA.cBatch lotnumber , '' changeitemcode,'' changeitemname, AA.iquantity Quantity, 'KG' Unit, '' VenCode,'' VenName,0 ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate
                    FROM RdRecord10 A  --产成品入库单主表取母液入库
                    LEFT JOIN RdRecords10 AA
                        ON A.ID = AA.ID
                    LEFT JOIN Inventory B
                        ON AA.cinvcode = B.cinvcode
                    LEFT JOIN ComputationUnit C
                        ON B.cGroupCode = C.cGroupCode
                            AND B.cComunitCode = C.cComunitCode
                    WHERE (substring(B.cinvccode,2,2) = '41')
                            AND A.dDate
                        BETWEEN '2013-10-01'
                            AND '2099-01-01'
        
                    union 
                    select 'RECE' DataType,'SK' Sourcesystem,(Rd.cCode + Rds.cinvcode + Rds.cbatch) SlipNumber ,'' InvoiceNumber ,'1' Storingtype ,'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,convert(varchar(10),Rd.dnverifytime,121) StockedDate ,convert(varchar(10),Rd.dnverifytime,121) AvailableDate,'' ETA,'' ETD,Rds.cInvCode ItemCode,(It.cinvname + It.cinvstd) ItemName,Rds.cBatch lotnumber , '' changeitemcode,'' changeitemname,Rds.iquantity Quantity, 'KG' Unit, '' VenCode,'' VenName,0 ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate 
                    from RdRecord08 Rd   --其他入库单
                    left join RdRecords08 Rds on Rd.ID = Rds.ID
                    left join Inventory It on Rds.cInvCode = It.cInvCode
                    where ( Rds.cinvcode LIKE '171%'
                            OR Rds.cinvcode LIKE '271%'
                            OR Rds.cinvcode LIKE '181%'
                            OR Rds.cinvcode LIKE '281%' ) and
                     (Rd.cRdCode = '1X')  --检验合格入库

                    UNION
                    SELECT 'RECE' DataType,'SK' Sourcesystem,(v.cAVCode + B.cinvcode + vs.cAVBatch) SlipNumber , '' InvoiceNumber , '4' Storingtype , 'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName, convert(varchar(10),rd.dVeriDate,121) StockedDate , convert(varchar(10),rd.dVeriDate,121) AvailableDate, '' ETA,'' ETD, vs.cinvcode ItemCode,(B.cinvname + isnull(B.cinvstd,'')) ItemName, vs.cAVBatch lotnumber , m.cInvCode changeitemcode,(m.cinvname + isnull(m.cinvstd,'')) changeitemname, vs.iAVQuantity Quantity, 'KG' Unit, '' VenCode,'' VenName,0 ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate
                    FROM AssemVouch v  --组装拆卸形态转换单主表
                    LEFT JOIN AssemVouchs vs
                        ON v.ID=vs.ID
                    LEFT JOIN 
                        (SELECT v.ID,
                            vs.cInvCode,
                            b.cInvName,
                            b.cInvStd
                        FROM AssemVouch v
                        LEFT JOIN AssemVouchs vs
                            ON v.ID=vs.ID
                        LEFT JOIN Inventory B
                            ON vs.cinvcode = B.cinvcode
                        WHERE cVouchType = 15
                                AND bavtype ='转换前' ) m
                        ON m.ID=v.ID
                    LEFT JOIN 
                        (SELECT cbuscode,
                            dveridate
                        FROM RdRecord08 rd
                        LEFT JOIN rdrecords08 rds
                            ON rd.ID =rds.ID
                        WHERE  crdcode = '17') rd  --入库类型内外销转换
                        ON rd.cBusCode = v.cAVCode
                    LEFT JOIN Inventory B
                        ON vs.cinvcode = B.cinvcode
                    LEFT JOIN ComputationUnit C
                        ON B.cGroupCode = C.cGroupCode
                            AND B.cComunitCode = C.cComunitCode
                    WHERE cVouchType = 15
                            AND bavtype ='转换后'
                            AND rd.dVeriDate is NOT null
                            AND (B.cinvccode LIKE '212%'
                            OR B.cinvccode LIKE '112%'
                            OR B.cInvCCode LIKE '130%'
                            OR B.cInvCCode LIKE '230%'
                            OR B.cInvCCode LIKE '12002%'
                            OR B.cInvCCode LIKE '22002%')
                            AND rd.dVeriDate
                        BETWEEN '2013-10-01'
                            AND '2099-01-01'  ";

                SqlDataAdapter adapter = new SqlDataAdapter(str6,init.conn);
                //SqlDataAdapter adapter = new SqlDataAdapter(str6 + "select 'RECE' DataType,'SK' Sourcesystem,(v.cAVCode + B.cinvcode + vs.cAVBatch) SlipNumber , \r\n\t             '' InvoiceNumber  , '4' Storingtype ,\r\n\t             'SK-SP' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t              convert(varchar(10),rd.dVeriDate,121) StockedDate ,\r\n\t              convert(varchar(10),rd.dVeriDate,121) AvailableDate, \r\n\t             '' ETA,'' ETD, \r\n\t              vs.cinvcode ItemCode,(B.cinvname + isnull(B.cinvstd,''))  ItemName,\r\n\t              vs.cAVBatch lotnumber ,\r\n\t             m.cInvCode changeitemcode,(m.cinvname + isnull(m.cinvstd,'')) changeitemname,\r\n\t              vs.iAVQuantity Quantity, \r\n\t               'KG'   Unit,  \r\n\t             '' VenCode,'' VenName,0 ioriSum,'RMB' Currency,(convert(varchar(10),getdate(),121)) RECECheckDate \r\n\t              from AssemVouch v\r\n\t              left join AssemVouchs vs on v.ID=vs.ID \r\n\t              left join (\r\n\t               select v.ID,vs.cInvCode,b.cInvName,b.cInvStd from AssemVouch v\r\n\t               left join AssemVouchs vs on v.ID=vs.ID \r\n\t               left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t               where cVouchType = 15 and bavtype ='转换前'\r\n\t              ) m on m.ID=v.ID\r\n\t              left join\r\n\t              (select cbuscode,dveridate from RdRecord08 rd\r\n\t\t            left join rdrecords08 rds on rd.ID =rds.ID\r\n\t\t            where cbustype = '转换入库') rd on rd.cBusCode = v.cAVCode\r\n                  left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t              left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t             where cVouchType = 15 and bavtype ='转换后' and rd.dVeriDate is not null and \r\n\t              (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n\t             or B.cInvCCode like '12002%' or B.cInvCCode like '22002%') \r\n                   and rd.dVeriDate between '" + str4 + "' and '" + str5 + "' \r\n            ", init.conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                init.ExportDataGridViewToTSV(dataSet.Tables[0], strFileName);
            }
            catch (Exception)
            {
            }
        }

        private static void fGetItemValue_FActualShippingExport()
        {
            string strFileName = "";
            string innerText = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
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
                        if (element2.LocalName == "InvCK")
                        {
                            strFileName = element2.InnerText;
                        }
                        if (element2.LocalName == "HKVendor")
                        {
                            innerText = element2.InnerText;
                        }
                        if (element2.LocalName == "HKCustomer")
                        {
                            str3 = element2.InnerText;
                        }
                        if (element2.LocalName == "ShippingExportStartTime")
                        {
                            str4 = element2.InnerText;
                        }
                        if (element2.LocalName == "ShippingExportEndTime")
                        {
                            str5 = element2.InnerText;
                        }
                    }
                }
                //string strsql = "-----------------------------------------\r\n\t\t select  *from(select  max(DataType) DataType, max(Sourcesystem) Sourcesystem, SlipNumber, max(InvoiceNumber) InvoiceNumber, ShippingType,\r\n                                        max(ShippingLocationCode) ShippingLocationCode,\r\n\t\t                                MAX(ShippingLocationName) ShippingLocationName, max(ShippingDate) ShippingDate,\r\n\t\t                                MAX(RecognizeDate) RecognizeDate, max(ETA) ETA, max(ETD) ETD, ItemCode, max(ItemName) ItemName, lotnumber,\r\n                                       changeitemcode, changeitemname,\r\n\t\t                                SUM(Quantity) Quantity, max(Unit) Unit, CustomerCode, max(CustomerName) CustomerName, \r\n                                        Sum(SALESAMOUNT) SALESAMOUNT, MAX(Currency) Currency, (convert(varchar(10), getdate(), 121)) RECECheckDate, max(salestock) salestock,\r\n                                        max(wherecode) wherecode, max(wherename) wherename, max(EndCustomerCode) EndCustomerCode,\r\n                                        max(EndCustomerName) EndCustomerName, max(csocode) csocode\r\n------------------------------------------\r\n                                     from(select 'SHIP' DataType, 'SK' Sourcesystem, (replace(A.ccode, '、', '') + convert(varchar(10), AA.irowno, 121) + AA.cBatch) SlipNumber,\r\nA.cdefine1 InvoiceNumber,\r\n\t                                    A.cPersonCode  RepresentativeCode,\r\n\t                                    Person.cPersonName  RepresentativeName,\r\n\t\t                                'SK' LocationCode, 'SHANGHAI KYOWA' LocationName,\r\n\t                                    Customer.cCusCode  CustomerCode,\r\n\t                                    Customer.cCusName  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 case when left(Customer.cCusName, 5) = 'KYOWA' or left(Customer.cCusName, 2) = '协和' then '3' else '1' end ShippingType,\r\n\t\t                                 case when A.dVeriDate is null then convert(varchar(10), d.dDate, 121) else convert(varchar(10), A.dVeriDate, 121) end ShippingDate,\r\n\t\t                                 case when SABILL.dDate is null then(case when A.dVeriDate is null then convert(varchar(10), d.dDate, 121) else convert(varchar(10), A.dVeriDate, 121) end) else convert(varchar(10), SABILL.dDate, 121) end RecognizeDate,\r\n\t\t                                 case when A.cCusCode = '' then  convert(varchar(10), A.cDefine4, 121)  else '' end  ETA, --取最迟装船日期\r\n\t\t                                 '' ETD, ds.cinvcode ItemCode, (B.cinvname + B.cinvstd)  ItemName,\r\n\t\t                                  ds.cBatch lotnumber,\r\n\t\t                                  AA.iquantity Quantity,\r\n\t\t                                  C.cEnSingular Unit,\r\n\t\t                                  convert(decimal(12, 2), ss.iNatUnitPrice * AA.iquantity) SALESAMOUNT, 'RMB' Currency,\r\n                                          case when Customer.cCusDefine1 is null then '2' else '1' end salestock,\r\n                                          case when Customer.cCusDefine1 is null then Customer.cCusCode else Customer.cCusDefine1 end wherecode,\r\n                                          case when A.cShipAddress is null then Customer.cCusName else A.cShipAddress end wherename,\r\n                                          Customer.cCusCode  EndCustomerCode, Customer.cCusName EndCustomerName, s.csocode, '' changeitemcode, '' changeitemname\r\n\t\t                                  from DispatchList d\r\n                                          left join DispatchLists ds on d.DLID = ds.DLID\r\n                                          left join Inventory B on ds.cinvcode = B.cinvcode\r\n                                          left join Customer on d.cCusCode = Customer.cCusCode \r\n                                          left join SO_SODetails SS on ds.iSOsID = SS.iSOsID\r\n                                          left join SO_SOMain s on ss.ID = s.ID \r\n                                          left join RdRecords32  AA on AA.iDLsID = ds.iDLsID \r\n                                          left join RdRecord32 A on A.ID = AA.ID   \r\n\t\t                                  left join Person on Person.cPersonCode = A.cPersonCode  \r\n\t\t                                  left join SaleBillVouchs SABILLS on  SABILLS.iDLSID = AA.iDLSID \r\n                                          left join  SaleBillVouch SABILL on SABILL.SBVID = SABILLS.SBVID \r\n\t\t                                  left join ComputationUnit  C on B.cGroupCode = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t\t                                  where(B.cInvCCode like '112%' or B.cInvCCode like '212%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n                                          or B.cInvCCode like '12002%' or B.cInvCCode like '22002%' or B.cInvCCode like '101%' or B.cInvCCode like '201%') \r\n                                          and isnull(A.bIsSTQc, 0) = 0 and isnull(SABILL.bIAFirst, 0) = 0 \r\n                                          and d.dDate between '" + str4 + "' and '" + str5 + "'\r\n\t\t                                  and ds.cBatch is not null \r\n\t\t                                 union\r\n------------------------------------------------------------------------------------------------ -\r\n                                     select 'SHIP' DataType, 'SK' Sourcesystem, (replace(A.ccode, '、', '') + convert(varchar(10), AA.iRowno, 121) + AA.cBatch) SlipNumber, '' InvoiceNumber, ---内贸\r\n\t                                    A.cPersonCode  RepresentativeCode,\r\n\t                                    Person.cPersonName  RepresentativeName,\r\n\t\t                                'SK' LocationCode, 'SHANGHAI KYOWA' LocationName,\r\n\t                                    ''  CustomerCode,\r\n\t                                    ''  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 '2' ShippingType,\r\n\t\t                                 convert(varchar(10), A.dVeriDate, 121) ShippingDate,\r\n\t\t                                 convert(varchar(10), A.dVeriDate, 121) RecognizeDate,\r\n\t\t                                 case when A.cCusCode = '' then  convert(varchar(10), A.cDefine4, 121)  else '' end  ETA, '' ETD,\r\n\t\t                                  AA.cinvcode ItemCode, (B.cinvname + B.cinvstd)  ItemName,\r\n\t\t                                  AA.cBatch lotnumber ,\r\n\t\t                                  AA.iquantity   Quantity ,\r\n\t\t                                  'KG'  Unit,\r\n\t\t                                  0 SALESAMOUNT,  'RMB' Currency,'' salestock,\r\n                                          '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,'' changeitemcode,'' changeitemname\r\n\t\t                                  from RdRecord11  A inner join  RdRecords11  AA on A.ID = AA.ID  left join Inventory B on AA.cinvcode = B.cinvcode \r\n\t\t                                  left join Person on Person.cPersonCode  = A.cPersonCode  \t\t                                \r\n\t\t                                  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t\t                                  where (B.cInvCCode like '112%' or B.cInvCCode like '212%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n                                          or B.cInvCCode like '12002%' or B.cInvCCode like '22002%' or B.cInvCCode like '101%' or B.cInvCCode like '201%')\r\n                                          and A.bIsSTQc=0 and A.dDate between '" + str4 + "' and '" + str5 + "' \r\n\t\t                                  and AA.cBatch is not null \r\n                                     union\r\n                                    ----------------------------------------------------------------------------------------------------\r\n                                        select 'SHIP' DataType,'SK' Sourcesystem,v.cAVCode + cast(vs.autoID as nvarchar(15)) SlipNumber ,'' InvoiceNumber, ---内贸\r\n\t                                    ''  RepresentativeCode ,\r\n\t                                    ''  RepresentativeName,\r\n\t\t                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t                                    ''  CustomerCode,\r\n\t                                    ''  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 '4' ShippingType ,\r\n\t\t                                 rd.dVeriDate  ShippingDate ,\r\n\t\t                                 rd.dVeriDate RecognizeDate ,\r\n\t\t                                 ''  ETA ,'' ETD,\r\n\t\t                                 vs.cinvcode ItemCode,(B.cinvname + isnull(B.cinvstd,''))  ItemName,\r\n\t\t                                 vs.cAVBatch lotnumber ,\r\n\t\t                                 vs.iAVQuantity  Quantity ,\r\n\t\t                                  'KG'  Unit,\r\n\t\t                                  0 iAmount,  'RMB'   Currency,'' salestock,\r\n                                          '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,\r\n\t\t\t\t\t\t\t\t\t\t  m.cinvcode changeitemcode,(m.cinvname + isnull(m.cinvstd,''))  changeitemname\r\n\t\t                                 from AssemVouch v\r\n\t\t\t\t\t\t\t\t\t  left join AssemVouchs vs on v.ID=vs.ID \r\n\t\t\t\t\t\t\t\t\t  left join (\r\n\t\t\t\t\t\t\t\t\t   select v.ID,vs.cInvCode,b.cInvName,b.cInvStd from AssemVouch v\r\n\t\t\t\t\t\t\t\t\t   left join AssemVouchs vs on v.ID=vs.ID \r\n\t\t\t\t\t\t\t\t\t   left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t\t\t\t\t\t\t\t\t   where cVouchType = 15 and bavtype ='转换后'\r\n\t\t\t\t\t\t\t\t\t  ) m on m.ID=v.ID\r\n\t\t\t\t\t\t\t\t\t  left join\r\n\t\t\t\t\t\t\t\t\t  (select cbuscode,dveridate from RdRecord09 rd\r\n\t\t\t\t\t\t\t\t\t\tleft join rdrecords09 rds on rd.ID =rds.ID\r\n\t\t\t\t\t\t\t\t\t\twhere cbustype = '转换出库') rd on rd.cBusCode = v.cAVCode\r\n\t\t\t\t\t\t\t\t\t  left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t\t\t\t\t\t\t\t\t  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t\t\t\t\t\t\t\t\t where cVouchType = 15 and bavtype ='转换前' and rd.dVeriDate is not null and \r\n\t\t\t\t\t\t\t\t\t  (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n\t\t\t\t\t\t\t\t\t or B.cInvCCode like '12002%' or B.cInvCCode like '22002%')\r\n                                         and rd.dVeriDate between '" + str4 + "' and '" + str5 + "' \r\n                                      \r\n                                     union\r\n                                    ----------------------------------------------------------------------------------------------------\r\n                                        select 'SHIP' DataType,'SK' Sourcesystem,(replace(A.cVouchID,'、','') + convert(varchar(10),AA.Auto_ID,121)) SlipNumber ,'' InvoiceNumber, ---内贸\r\n\t                                    Person.cPersonCode  RepresentativeCode ,\r\n\t                                    Person.cPersonName  RepresentativeName,\r\n\t\t                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t                                    A.cDwCode  CustomerCode,\r\n\t                                    Customer.cCusName  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 '4' ShippingType ,\r\n\t\t                                 A.dCreditStart  ShippingDate ,\r\n\t\t                                 A.dCreditStart RecognizeDate ,\r\n\t\t                                 ''  ETA ,'' ETD,\r\n\t\t                                  'Item_Dummy' ItemCode,'' ItemName,\r\n\t\t                                  '' lotnumber ,\r\n\t\t                                  '0'   Quantity ,\r\n\t\t                                  ''  Unit,\r\n\t\t                                  AA.iAmount,  'RMB'   Currency,'' salestock,\r\n                                          '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,'' changeitemcode,'' changeitemname\r\n\t\t                                  from Ap_Vouch  A inner join  Ap_Vouchs  AA on A.cLink = AA.cLink  \r\n\t\t                                  left join Person on Person.cPersonName  = A.cOperator  \t\t                                \r\n\t\t                                  left join Customer on A.cDwCode=Customer.cCusCode\r\n\t\t                                  where A.bd_c=0 and isnull(A.cDefine9,'') <> '退货' and AA.bd_c=0 and isnull(A.bStartFlag ,0)=0 and  A.dVouchDate between '" + str4 + "' and '" + str5 + "'  \r\n                                         union\r\n\t                                ----------------------------------------------------------------------------------------------------\r\n                                select 'SHIP' DataType,'SK' Sourcesystem,(replace(AR.ccode,'、','') +convert(varchar(10), ARS.irowno,121)+ ARS.cBatch) SlipNumber ,AR.cdefine1 InvoiceNumber,---外贸\r\n\t                                     A.cPersonCode  RepresentativeCode ,\r\n\t\t                                 Person.cPersonName  RepresentativeName,\r\n\t\t                                 'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t\t                                 Customer.cCusCode  CustomerCode,\r\n\t\t                                 Customer.cCusName  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 case when left(Customer.cCusName,5)='KYOWA' or left(Customer.cCusName,2)='协和' then '3' else '1' end ShippingType ,\r\n\t\t                                 case when AR.dVeriDate is null then convert(varchar(10),A.ddate,121) else convert(varchar(10),AR.dVeriDate,121) end ShippingDate ,--取销货单据日期 \r\n\t\t                                 case when SABILL.dDate is null then (case when AR.dVeriDate is null then convert(varchar(10),A.ddate,121) else convert(varchar(10),AR.dVeriDate,121) end) else convert(varchar(10),SABILL.dDate,121) end RecognizeDate ,\r\n\t\t                                 isnull(convert(varchar(10),A.dlastedshippingdate,121),'')  ETA ,--取最迟装船日期\r\n                                         isnull(convert(varchar(10),A.cDefine4,121),'') ETD,\r\n\t\t                                 AA.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,\r\n\t\t                                 ARS.cBatch lotnumber ,ARS.iQuantity Quantity ,C.cEnSingular Unit,\r\n\t\t                                 convert(decimal(12,2),AA.fnatprice*ARS.iQuantity) SALESAMOUNT,'RMB' Currency,\r\n                                         case when Customer.cCusDefine1 is null then '2' else '1' end salestock,\r\n                                         case when Customer.cCusDefine1 is null then Customer.cCusCode else Customer.cCusDefine1 end wherecode,\r\n                                         case when AR.cShipAddress is null then Customer.cCusName else AR.cShipAddress end wherename,\r\n                                         Customer.cCusCode  EndCustomerCode,Customer.cCusName EndCustomerName,A.ccusordercode csocode,\r\n                                         '' changeitemcode,'' changeitemname\r\n\t\t                                 from ex_consignment A inner join ex_consignmentdetail AA on A.id=AA.id \r\n                                         left join Inventory B on AA.cinvcode=B.cInvCode\r\n\t\t                                 left join rdrecords32 ARS on ARS.iDLsID=AA.autoid \r\n                                         left join rdrecord32 AR on ARS.ID=AR.ID \r\n\t\t                                 left join Person on Person.cPersonCode=A.cPersonCode \r\n\t\t                                 left join Customer on A.ccuscode=Customer.cCusCode\r\n\t\t                                 left join ex_invoicedetail SABILLS on SABILLS.guid_source=AA.guids \r\n                                         left join ex_invoice SABILL on SABILL.id=SABILLS.id\r\n\t\t                                 left join ComputationUnit C on B.cGroupCode =C.cGroupCode and B.cComUnitCode =C.cComunitCode\r\n\t\t                                 left join foreigncurrency on foreigncurrency.cexch_name=A.cexch_name \r\n\t\t                                 where (B.cInvCCode like '112%' or B.cInvCCode like '212%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n                                         or B.cInvCCode like '12002%' or B.cInvCCode like '22002%'  or B.cInvCCode like '101%' or B.cInvCCode like '201%') \r\n                                         and isnull(AR.bpufirst,0) =0 and isnull(AR.biafirst,0)=0 and A.ddate between  '" + str4 + "' and '" + str5 + "'   \r\n\t\t                                 and isnull(SABILL.bexinit,0)=0 and AR.csource='出口销货单') as table1 group by  \r\n                                         SlipNumber,CustomerCode,lotnumber,\r\n\t\t                                 ShippingType ,ItemCode,changeitemcode,changeitemname ) as dd where 1=1 order by ShippingType  ";

                string strsql = @"  select  *from(select  max(DataType) DataType, max(Sourcesystem) Sourcesystem, SlipNumber, max(InvoiceNumber) InvoiceNumber, ShippingType,
                                max(ShippingLocationCode) ShippingLocationCode,
                                MAX(ShippingLocationName) ShippingLocationName, max(ShippingDate) ShippingDate,
                                MAX(RecognizeDate) RecognizeDate, max(ETA) ETA, max(ETD) ETD, ItemCode, max(ItemName) ItemName, lotnumber,
                                changeitemcode, changeitemname,
                                SUM(Quantity) Quantity, max(Unit) Unit, CustomerCode, max(CustomerName) CustomerName, 
                                Sum(SALESAMOUNT) SALESAMOUNT, MAX(Currency) Currency, (convert(varchar(10), getdate(), 121)) RECECheckDate, max(salestock) salestock,
                                max(wherecode) wherecode, max(wherename) wherename, max(EndCustomerCode) EndCustomerCode,
                                max(EndCustomerName) EndCustomerName, max(csocode) csocode
                                from(select 'SHIP' DataType, 'SK' Sourcesystem, (replace(A.ccode, '、', '') + convert(varchar(10), AA.irowno, 121) + AA.cBatch) SlipNumber,
                                A.cdefine1 InvoiceNumber,
                                A.cPersonCode  RepresentativeCode,
                                Person.cPersonName  RepresentativeName,
                                'SK' LocationCode, 'SHANGHAI KYOWA' LocationName,
                                Customer.cCusCode  CustomerCode,
                                Customer.cCusName  CustomerName,
                                 'SK-SP'  ShippingLocationCode,
                                 'SHANGHAI KYOWA' ShippingLocationName,
                                 case when left(Customer.cCusName, 5) = 'KYOWA' or left(Customer.cCusName, 2) = '协和' then '3' else '1' end ShippingType,
                                 case when A.dVeriDate is null then convert(varchar(10), d.dDate, 121) else convert(varchar(10), A.dVeriDate, 121) end ShippingDate,
                                 case when SABILL.dDate is null then(case when A.dVeriDate is null then convert(varchar(10), d.dDate, 121) else convert(varchar(10), A.dVeriDate, 121) end) else convert(varchar(10), SABILL.dDate, 121) end RecognizeDate,
                                 case when A.cCusCode = '' then  convert(varchar(10), A.cDefine4, 121)  else '' end  ETA, --取最迟装船日期
                                 '' ETD, ds.cinvcode ItemCode, (B.cinvname + B.cinvstd)  ItemName,
                                  ds.cBatch lotnumber,
                                  AA.iquantity Quantity,
                                  C.cEnSingular Unit,
                                  convert(decimal(12, 2), ss.iNatUnitPrice * AA.iquantity) SALESAMOUNT, 'RMB' Currency,
                                  case when Customer.cCusDefine1 is null then '2' else '1' end salestock,
                                  case when Customer.cCusDefine1 is null then Customer.cCusCode else Customer.cCusDefine1 end wherecode,
                                  case when A.cShipAddress is null then Customer.cCusName else A.cShipAddress end wherename,
                                  Customer.cCusCode  EndCustomerCode, Customer.cCusName EndCustomerName, s.csocode, '' changeitemcode, '' changeitemname
                                  from DispatchList d  --发货退货单主表
                                  left join DispatchLists ds on d.DLID = ds.DLID  --发货退货单子表
                                  left join Inventory B on ds.cinvcode = B.cinvcode
                                  left join Customer on d.cCusCode = Customer.cCusCode 
                                  left join SO_SODetails SS on ds.iSOsID = SS.iSOsID  --销售订单子表
                                  left join SO_SOMain s on ss.ID = s.ID   --销售订单主表
                                  left join RdRecords32  AA on AA.iDLsID = ds.iDLsID  --销售出库单子表
                                  left join RdRecord32 A on A.ID = AA.ID   ----销售出库单主表
                                  left join Person on Person.cPersonCode = A.cPersonCode  --职员档案
                                  left join SaleBillVouchs SABILLS on  SABILLS.iDLSID = AA.iDLSID   --销售发票子表
                                  left join  SaleBillVouch SABILL on SABILL.SBVID = SABILLS.SBVID   --销售发票主表
                                  left join ComputationUnit  C on B.cGroupCode = C.cGroupCode  and B.cComunitCode = C.cComunitCode   --计量单位
                                  where(B.cInvCCode like '171%' or B.cInvCCode like '271%' or B.cInvCCode like '181%' or B.cInvCCode like '281%' 
                                  or B.cInvCCode like '152%' or B.cInvCCode like '252%' or B.cInvCCode like '131%' or B.cInvCCode like '231%') 
                                  and isnull(A.bIsSTQc, 0) = 0 and isnull(SABILL.bIAFirst, 0) = 0 
                                  and d.dDate between '2013-10-01' and '2099-01-01'
                                  and ds.cBatch is not null 
                                 union

                                select 'SHIP' DataType, 'SK' Sourcesystem, (replace(A.ccode, '、', '') + convert(varchar(10), AA.iRowno, 121) + AA.cBatch) SlipNumber, '' InvoiceNumber, ---内贸
                                A.cPersonCode  RepresentativeCode,
                                Person.cPersonName  RepresentativeName,
                                'SK' LocationCode, 'SHANGHAI KYOWA' LocationName,
                                ''  CustomerCode,
                                ''  CustomerName,
                                 'SK-SP'  ShippingLocationCode,
                                 'SHANGHAI KYOWA' ShippingLocationName,
                                 '2' ShippingType,
                                 convert(varchar(10), A.dVeriDate, 121) ShippingDate,
                                 convert(varchar(10), A.dVeriDate, 121) RecognizeDate,
                                 case when A.cCusCode = '' then  convert(varchar(10), A.cDefine4, 121)  else '' end  ETA, '' ETD,
                                  AA.cinvcode ItemCode, (B.cinvname + B.cinvstd)  ItemName,
                                  AA.cBatch lotnumber ,
                                  AA.iquantity   Quantity ,
                                  'KG'  Unit,
                                  0 SALESAMOUNT,  'RMB' Currency,'' salestock,
                                  '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,'' changeitemcode,'' changeitemname
                                  from RdRecord11  A inner join  RdRecords11  AA on A.ID = AA.ID   --材料出库单主表
                                  left join Inventory B on AA.cinvcode = B.cinvcode  
                                  left join Person on Person.cPersonCode  = A.cPersonCode  		--职员档案                             
                                  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  
                                  where (B.cInvCCode like '171%' or B.cInvCCode like '271%' or B.cInvCCode like '181%' or B.cInvCCode like '281%' 
                                  or B.cInvCCode like '152%' or B.cInvCCode like '252%' or B.cInvCCode like '131%' or B.cInvCCode like '231%')
                                  and A.bIsSTQc=0 and A.dDate between '2013-10-01' and '2099-01-01' 
                                  and AA.cBatch is not null 
                                union

                                select 'SHIP' DataType,'SK' Sourcesystem,v.cAVCode + cast(vs.autoID as nvarchar(15)) SlipNumber ,'' InvoiceNumber, ---内贸
                                ''  RepresentativeCode ,
                                ''  RepresentativeName,
                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,
                                ''  CustomerCode,
                                ''  CustomerName,
                                 'SK-SP'  ShippingLocationCode,
                                 'SHANGHAI KYOWA' ShippingLocationName,
                                 '4' ShippingType ,
                                 rd.dVeriDate  ShippingDate ,
                                 rd.dVeriDate RecognizeDate ,
                                 ''  ETA ,'' ETD,
                                 vs.cinvcode ItemCode,(B.cinvname + isnull(B.cinvstd,''))  ItemName,
                                 vs.cAVBatch lotnumber ,
                                 vs.iAVQuantity  Quantity ,
                                  'KG'  Unit,
                                  0 iAmount,  'RMB'   Currency,'' salestock,
                                  '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,
                                  m.cinvcode changeitemcode,(m.cinvname + isnull(m.cinvstd,''))  changeitemname
                                 from AssemVouch v  --组装拆卸形态转换单主表
                                left join AssemVouchs vs on v.ID=vs.ID 
                                left join (
                                select v.ID,vs.cInvCode,b.cInvName,b.cInvStd from AssemVouch v
                                left join AssemVouchs vs on v.ID=vs.ID 
                                left join Inventory B on vs.cinvcode = B.cinvcode 
                                where cVouchType = 15 and bavtype ='转换后'
                                ) m on m.ID=v.ID
                                left join
                                (select cbuscode,dveridate from RdRecord09 rd
                                left join rdrecords09 rds on rd.ID =rds.ID
                                where crdcode = '2B') rd on rd.cBusCode = v.cAVCode  --转换类型编码内外销调整出库
                                left join Inventory B on vs.cinvcode = B.cinvcode 
                                left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  
                                where cVouchType = 15 and bavtype ='转换前' and rd.dVeriDate is not null and 
                                (B.cinvccode like '271%' or B.cinvccode like '171%' or B.cInvCCode like '181%' or B.cInvCCode like '281%' 
                                or B.cInvCCode like '152%' or B.cInvCCode like '252%')
                                 and rd.dVeriDate between '2013-10-01' and '2099-01-01' 
                                union

                                select 'SHIP' DataType,  --1
                                'SK' Sourcesystem,   --2
                                Rd.cBusCode + cast(Rds.AutoID as nvarchar(15)) SlipNumber ,  --3
                                '' InvoiceNumber, ---内贸  --4
                                ''  RepresentativeCode ,
                                ''  RepresentativeName,
                                'SK' LocationCode,  
                                'SHANGHAI KYOWA' LocationName,
                                ''  CustomerCode,  --19
                                ''  CustomerName,  --20
                                 'SK-SP'  ShippingLocationCode,  --6
                                 'SHANGHAI KYOWA' ShippingLocationName,  --7
                                 '4' ShippingType ,  --5
                                  rd.dVeriDate  ShippingDate ,   --8
                                 rd.dVeriDate RecognizeDate ,  --9
                                 ''  ETA ,  --10
                                 '' ETD,  --11
                                 Rds.cinvcode ItemCode,   --12
                                 (It.cinvname + isnull(It.cinvstd,''))  ItemName,   --13
                                 Rds.cBatch lotnumber ,  --14
                                 Rds.iQuantity   Quantity ,  --17
                                  'KG'  Unit,  --18
                                  0 iAmount,  --23
                                  'RMB'   Currency,   --22
                                  '' salestock,  --24
                                  '' wherecode,  --25
                                  '' wherename,  --26
                                  '' EndCustomerCode,  --27
                                  '' EndCustomerName,  --28
                                  '' csocode,  --29
                                  Rds.cinvcode changeitemcode,  --15
                                  (It.cinvname + isnull(It.cinvstd,''))  changeitemname  --16
                                from AssemVouch v  --组装拆卸形态转换单主表
                                LEFT JOIN AssemVouchs vs ON v.ID=vs.ID
                                left join RdRecord09 Rd on Rd.cBusCode = v.cAVCode
                                left join rdrecords09 Rds on Rd.id = Rds.id
                                left join Inventory It on Rds.cInvCode = It.cInvCode
                                where Rd.cRdCode = '2Z'  --出库类型检验不良出库
                                and SUBSTRING(Rds.cInvCode,2,2) = '55'
                                and vs.bAVType = '转换后'

                                union

                                select distinct 'SHIP' DataType,  --1
                                'SK' Sourcesystem,   --2
                                Rd.cBusCode + cast(Rds.AutoID as nvarchar(15)) SlipNumber ,  --3
                                '' InvoiceNumber, ---内贸  --4
                                ''  RepresentativeCode ,
                                ''  RepresentativeName,
                                'SK' LocationCode,  
                                'SHANGHAI KYOWA' LocationName,
                                ''  CustomerCode,  --19
                                ''  CustomerName,  --20
                                 'SK-SP'  ShippingLocationCode,  --6
                                 'SHANGHAI KYOWA' ShippingLocationName,  --7
                                 '4' ShippingType ,  --5
                                  rd.dVeriDate  ShippingDate ,   --8
                                 rd.dVeriDate RecognizeDate ,  --9
                                 ''  ETA ,  --10
                                 '' ETD,  --11
                                 Rds.cinvcode ItemCode,   --12
                                 (It.cinvname + isnull(It.cinvstd,''))  ItemName,   --13
                                 Rds.cBatch lotnumber ,  --14
                                 Rds.iQuantity   Quantity ,  --17
                                  'KG'  Unit,  --18
                                  0 iAmount,  --23
                                  'RMB'   Currency,   --22
                                  '' salestock,  --24
                                  '' wherecode,  --25
                                  '' wherename,  --26
                                  '' EndCustomerCode,  --27
                                  '' EndCustomerName,  --28
                                  '' csocode,  --29
                                  Rds.cinvcode changeitemcode,  --15
                                  (It.cinvname + isnull(It.cinvstd,''))  changeitemname  --16
                                from rdrecord32 Rd   --销售出库单
                                left join rdrecords32 Rds on Rd.id = Rds.id
                                left join QM_QRETINSPECTB Qmi on Rd.cCode = Qmi.CSOURCECODE  --发退货报检单
                                left join QM_QRETCHECKB Qmc on Qmi.CINSPECTCODE = Qmc.CINSPECTCODE  --发退货检验单
                                left join Inventory It on Rds.cInvCode = It.cInvCode
                                where 1=1 and Qmc.IDISBREAKQTYDEALTYPE = '0'    --检验单字段为0表示做合格处理

                                union

                                select 'SHIP' DataType,'SK' Sourcesystem,(replace(AR.ccode,'、','') +convert(varchar(10), ARS.irowno,121)+ ARS.cBatch) SlipNumber ,AR.cdefine1 InvoiceNumber,---外贸
                                 A.cPersonCode  RepresentativeCode ,
                                 Person.cPersonName  RepresentativeName,
                                 'SK' LocationCode,'SHANGHAI KYOWA' LocationName,
                                 Customer.cCusCode  CustomerCode,
                                 Customer.cCusName  CustomerName,
                                 'SK-SP'  ShippingLocationCode,
                                 'SHANGHAI KYOWA' ShippingLocationName,
                                 case when left(Customer.cCusName,5)='KYOWA' or left(Customer.cCusName,2)='协和' then '3' else '1' end ShippingType ,
                                 case when AR.dVeriDate is null then convert(varchar(10),A.ddate,121) else convert(varchar(10),AR.dVeriDate,121) end ShippingDate ,--取销货单据日期 
                                 case when SABILL.dDate is null then (case when AR.dVeriDate is null then convert(varchar(10),A.ddate,121) else convert(varchar(10),AR.dVeriDate,121) end) else convert(varchar(10),SABILL.dDate,121) end RecognizeDate ,
                                 isnull(convert(varchar(10),A.dlastedshippingdate,121),'')  ETA ,--取最迟装船日期
                                 isnull(convert(varchar(10),A.cDefine4,121),'') ETD,
                                 AA.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,
                                 ARS.cBatch lotnumber ,ARS.iQuantity Quantity ,C.cEnSingular Unit,
                                 convert(decimal(12,2),AA.fnatprice*ARS.iQuantity) SALESAMOUNT,'RMB' Currency,
                                 case when Customer.cCusDefine1 is null then '2' else '1' end salestock,
                                 case when Customer.cCusDefine1 is null then Customer.cCusCode else Customer.cCusDefine1 end wherecode,
                                 case when AR.cShipAddress is null then Customer.cCusName else AR.cShipAddress end wherename,
                                 Customer.cCusCode  EndCustomerCode,Customer.cCusName EndCustomerName,A.ccusordercode csocode,
                                 '' changeitemcode,'' changeitemname
                                 from ex_consignment A inner join ex_consignmentdetail AA on A.id=AA.id   --销货单表头
                                 left join Inventory B on AA.cinvcode=B.cInvCode
                                 left join rdrecords32 ARS on ARS.iDLsID=AA.autoid   --销售出库单子表
                                 left join rdrecord32 AR on ARS.ID=AR.ID   --销售出库单主表
                                 left join Person on Person.cPersonCode=A.cPersonCode 
                                 left join Customer on A.ccuscode=Customer.cCusCode
                                 left join ex_invoicedetail SABILLS on SABILLS.guid_source=AA.guids   --出口发票表体
                                 left join ex_invoice SABILL on SABILL.id=SABILLS.id   --出口发票表头
                                 left join ComputationUnit C on B.cGroupCode =C.cGroupCode and B.cComUnitCode =C.cComunitCode
                                 left join foreigncurrency on foreigncurrency.cexch_name=A.cexch_name   --币种档案
                                 where (B.cInvCCode like '171%' or B.cInvCCode like '271%' or B.cInvCCode like '181%' or B.cInvCCode like '281%' 
                                 or B.cInvCCode like '152%' or B.cInvCCode like '252%'  or B.cInvCCode like '131%' or B.cInvCCode like '231%') 
                                 and isnull(AR.bpufirst,0) =0 and isnull(AR.biafirst,0)=0 and A.ddate between  '2013-10-01' and '2099-01-01'   
                                 and isnull(SABILL.bexinit,0)=0 and AR.csource='出口销货单') as table1 group by  
                                 SlipNumber,CustomerCode,lotnumber,
                                 ShippingType ,ItemCode,changeitemcode,changeitemname ) as dd where 1=1 order by ShippingType    ";

                SqlDataAdapter adapter = new SqlDataAdapter(strsql,init.conn);
                //SqlDataAdapter adapter = new SqlDataAdapter(" -----------------------------------------\r\n\t\t                       select  * from  ( select  max(DataType) DataType,max(Sourcesystem) Sourcesystem, SlipNumber,max(InvoiceNumber) InvoiceNumber,ShippingType,\r\n                                        max(ShippingLocationCode) ShippingLocationCode,\r\n\t\t                                MAX( ShippingLocationName) ShippingLocationName,max(ShippingDate) ShippingDate ,\r\n\t\t                                MAX( RecognizeDate) RecognizeDate,max(ETA) ETA,max(ETD) ETD, ItemCode, max(ItemName) ItemName,lotnumber ,\r\n                                       changeitemcode,changeitemname,\r\n\t\t                                SUM( Quantity) Quantity ,max(Unit) Unit,CustomerCode,max(CustomerName) CustomerName, \r\n                                        Sum(SALESAMOUNT) SALESAMOUNT, MAX(Currency) Currency,(convert(varchar(10),getdate(),121)) RECECheckDate,max(salestock) salestock,\r\n                                        max(wherecode) wherecode,max(wherename) wherename,max(EndCustomerCode) EndCustomerCode,\r\n                                        max(EndCustomerName) EndCustomerName,max(csocode) csocode\r\n                                  ------------------------------------------\r\n                                     from (select 'SHIP' DataType,'SK' Sourcesystem,(replace(A.ccode,'、','') + convert(varchar(10),AA.irowno,121)+AA.cBatch  ) SlipNumber ,\r\nA.cdefine1 InvoiceNumber,\r\n\t                                    A.cPersonCode  RepresentativeCode ,\r\n\t                                    Person.cPersonName  RepresentativeName,\r\n\t\t                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t                                    Customer.cCusCode  CustomerCode,\r\n\t                                    Customer.cCusName  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 case when left(Customer.cCusName,5)='KYOWA' or left(Customer.cCusName,2)='协和' then '3' else '1' end ShippingType ,\r\n\t\t                                 case when A.dVeriDate is null then convert(varchar(10),d.dDate,121) else convert(varchar(10),A.dVeriDate,121) end ShippingDate ,\r\n\t\t                                 case when SABILL.dDate is null then (case when A.dVeriDate is null then convert(varchar(10),d.dDate,121) else convert(varchar(10),A.dVeriDate,121) end) else convert(varchar(10),SABILL.dDate,121) end RecognizeDate ,\r\n\t\t                                 case when A.cCusCode = '' then  convert(varchar(10),A.cDefine4,121)  else '' end  ETA , --取最迟装船日期\r\n\t\t                                 '' ETD, ds.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,\r\n\t\t                                  ds.cBatch lotnumber ,\r\n\t\t                                  AA.iquantity Quantity ,\r\n\t\t                                  C.cEnSingular Unit,\r\n\t\t                                  convert(decimal(12,2),ss.iNatUnitPrice*AA.iquantity) SALESAMOUNT,'RMB' Currency,\r\n                                          case when Customer.cCusDefine1 is null then '2' else '1' end salestock,\r\n                                          case when Customer.cCusDefine1 is null then Customer.cCusCode else Customer.cCusDefine1 end wherecode,\r\n                                          case when A.cShipAddress is null then Customer.cCusName else A.cShipAddress end wherename,\r\n                                          Customer.cCusCode  EndCustomerCode,Customer.cCusName EndCustomerName,s.csocode,'' changeitemcode,'' changeitemname\r\n\t\t                                  from DispatchList d\r\n                                          left join DispatchLists ds on d.DLID=ds.DLID\r\n                                          left join Inventory B on ds.cinvcode = B.cinvcode\r\n                                          left join Customer on d.cCusCode = Customer.cCusCode \r\n                                          left join SO_SODetails SS on ds.iSOsID=SS.iSOsID\r\n                                          left join SO_SOMain s on ss.ID=s.ID \r\n                                          left join RdRecords32  AA on AA.iDLsID=ds.iDLsID \r\n                                          left join RdRecord32 A on A.ID = AA.ID   \r\n\t\t                                  left join Person on Person.cPersonCode  = A.cPersonCode  \r\n\t\t                                  left join SaleBillVouchs SABILLS on  SABILLS.iDLSID = AA.iDLSID \r\n                                          left join  SaleBillVouch SABILL on SABILL.SBVID  =  SABILLS.SBVID \r\n\t\t                                  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t\t                                  where (B.cInvCCode like '112%' or B.cInvCCode like '212%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n                                          or B.cInvCCode like '12002%' or B.cInvCCode like '22002%' or B.cInvCCode like '101%' or B.cInvCCode like '201%') \r\n                                          and isnull(A.bIsSTQc,0)=0 and isnull(SABILL.bIAFirst,0)=0 \r\n                                          and d.dDate between '" + str4 + "' and '" + str5 + "'\r\n\t\t                                  and ds.cBatch is not null \r\n\t\t                                 union\r\n                                     -------------------------------------------------------------------------------------------------\r\n                                     select 'SHIP' DataType,'SK' Sourcesystem,(replace(A.ccode,'、','') + convert(varchar(10),AA.iRowno,121)+ AA.cBatch) SlipNumber ,'' InvoiceNumber, ---内贸\r\n\t                                    A.cPersonCode  RepresentativeCode ,\r\n\t                                    Person.cPersonName  RepresentativeName,\r\n\t\t                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t                                    ''  CustomerCode,\r\n\t                                    ''  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 '2' ShippingType ,\r\n\t\t                                 convert(varchar(10),A.dVeriDate,121) ShippingDate ,\r\n\t\t                                 convert(varchar(10),A.dVeriDate,121) RecognizeDate ,\r\n\t\t                                 case when A.cCusCode = '' then  convert(varchar(10),A.cDefine4,121)  else '' end  ETA ,'' ETD,\r\n\t\t                                  AA.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,\r\n\t\t                                  AA.cBatch lotnumber ,\r\n\t\t                                  AA.iquantity   Quantity ,\r\n\t\t                                  'KG'  Unit,\r\n\t\t                                  0 SALESAMOUNT,  'RMB' Currency,'' salestock,\r\n                                          '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,'' changeitemcode,'' changeitemname\r\n\t\t                                  from RdRecord11  A inner join  RdRecords11  AA on A.ID = AA.ID  left join Inventory B on AA.cinvcode = B.cinvcode \r\n\t\t                                  left join Person on Person.cPersonCode  = A.cPersonCode  \t\t                                \r\n\t\t                                  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t\t                                  where (B.cInvCCode like '112%' or B.cInvCCode like '212%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n                                          or B.cInvCCode like '12002%' or B.cInvCCode like '22002%' or B.cInvCCode like '101%' or B.cInvCCode like '201%')\r\n                                          and A.bIsSTQc=0 and A.dDate between '" + str4 + "' and '" + str5 + "' \r\n\t\t                                  and AA.cBatch is not null \r\n                                     union\r\n                                    ----------------------------------------------------------------------------------------------------\r\n                                        select 'SHIP' DataType,'SK' Sourcesystem,v.cAVCode + cast(vs.autoID as nvarchar(15)) SlipNumber ,'' InvoiceNumber, ---内贸\r\n\t                                    ''  RepresentativeCode ,\r\n\t                                    ''  RepresentativeName,\r\n\t\t                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t                                    ''  CustomerCode,\r\n\t                                    ''  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 '4' ShippingType ,\r\n\t\t                                 rd.dVeriDate  ShippingDate ,\r\n\t\t                                 rd.dVeriDate RecognizeDate ,\r\n\t\t                                 ''  ETA ,'' ETD,\r\n\t\t                                 vs.cinvcode ItemCode,(B.cinvname + isnull(B.cinvstd,''))  ItemName,\r\n\t\t                                 vs.cAVBatch lotnumber ,\r\n\t\t                                 vs.iAVQuantity  Quantity ,\r\n\t\t                                  'KG'  Unit,\r\n\t\t                                  0 iAmount,  'RMB'   Currency,'' salestock,\r\n                                          '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,\r\n\t\t\t\t\t\t\t\t\t\t  m.cinvcode changeitemcode,(m.cinvname + isnull(m.cinvstd,''))  changeitemname\r\n\t\t                                 from AssemVouch v\r\n\t\t\t\t\t\t\t\t\t  left join AssemVouchs vs on v.ID=vs.ID \r\n\t\t\t\t\t\t\t\t\t  left join (\r\n\t\t\t\t\t\t\t\t\t   select v.ID,vs.cInvCode,b.cInvName,b.cInvStd from AssemVouch v\r\n\t\t\t\t\t\t\t\t\t   left join AssemVouchs vs on v.ID=vs.ID \r\n\t\t\t\t\t\t\t\t\t   left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t\t\t\t\t\t\t\t\t   where cVouchType = 15 and bavtype ='转换后'\r\n\t\t\t\t\t\t\t\t\t  ) m on m.ID=v.ID\r\n\t\t\t\t\t\t\t\t\t  left join\r\n\t\t\t\t\t\t\t\t\t  (select cbuscode,dveridate from RdRecord09 rd\r\n\t\t\t\t\t\t\t\t\t\tleft join rdrecords09 rds on rd.ID =rds.ID\r\n\t\t\t\t\t\t\t\t\t\twhere cbustype = '转换出库') rd on rd.cBusCode = v.cAVCode\r\n\t\t\t\t\t\t\t\t\t  left join Inventory B on vs.cinvcode = B.cinvcode \r\n\t\t\t\t\t\t\t\t\t  left join ComputationUnit  C on B.cGroupCode  = C.cGroupCode  and B.cComunitCode = C.cComunitCode  \r\n\t\t\t\t\t\t\t\t\t where cVouchType = 15 and bavtype ='转换前' and rd.dVeriDate is not null and \r\n\t\t\t\t\t\t\t\t\t  (B.cinvccode like '212%' or B.cinvccode like '112%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n\t\t\t\t\t\t\t\t\t or B.cInvCCode like '12002%' or B.cInvCCode like '22002%')\r\n                                         and rd.dVeriDate between '" + str4 + "' and '" + str5 + "' \r\n                                      \r\n                                     union\r\n                                    ----------------------------------------------------------------------------------------------------\r\n                                        select 'SHIP' DataType,'SK' Sourcesystem,(replace(A.cVouchID,'、','') + convert(varchar(10),AA.Auto_ID,121)) SlipNumber ,'' InvoiceNumber, ---内贸\r\n\t                                    Person.cPersonCode  RepresentativeCode ,\r\n\t                                    Person.cPersonName  RepresentativeName,\r\n\t\t                                'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t                                    A.cDwCode  CustomerCode,\r\n\t                                    Customer.cCusName  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 '4' ShippingType ,\r\n\t\t                                 A.dCreditStart  ShippingDate ,\r\n\t\t                                 A.dCreditStart RecognizeDate ,\r\n\t\t                                 ''  ETA ,'' ETD,\r\n\t\t                                  'Item_Dummy' ItemCode,'' ItemName,\r\n\t\t                                  '' lotnumber ,\r\n\t\t                                  '0'   Quantity ,\r\n\t\t                                  ''  Unit,\r\n\t\t                                  AA.iAmount,  'RMB'   Currency,'' salestock,\r\n                                          '' wherecode,'' wherename,'' EndCustomerCode,'' EndCustomerName,'' csocode,'' changeitemcode,'' changeitemname\r\n\t\t                                  from Ap_Vouch  A inner join  Ap_Vouchs  AA on A.cLink = AA.cLink  \r\n\t\t                                  left join Person on Person.cPersonName  = A.cOperator  \t\t                                \r\n\t\t                                  left join Customer on A.cDwCode=Customer.cCusCode\r\n\t\t                                  where A.bd_c=0 and isnull(A.cDefine9,'') <> '退货' and AA.bd_c=0 and isnull(A.bStartFlag ,0)=0 and  A.dVouchDate between '" + str4 + "' and '" + str5 + "'  \r\n                                         union\r\n\t                                ----------------------------------------------------------------------------------------------------\r\n                                select 'SHIP' DataType,'SK' Sourcesystem,(replace(AR.ccode,'、','') +convert(varchar(10), ARS.irowno,121)+ ARS.cBatch) SlipNumber ,AR.cdefine1 InvoiceNumber,---外贸\r\n\t                                     A.cPersonCode  RepresentativeCode ,\r\n\t\t                                 Person.cPersonName  RepresentativeName,\r\n\t\t                                 'SK' LocationCode,'SHANGHAI KYOWA' LocationName,\r\n\t\t                                 Customer.cCusCode  CustomerCode,\r\n\t\t                                 Customer.cCusName  CustomerName,\r\n\t\t                                 'SK-SP'  ShippingLocationCode,\r\n\t\t                                 'SHANGHAI KYOWA' ShippingLocationName,\r\n\t\t                                 case when left(Customer.cCusName,5)='KYOWA' or left(Customer.cCusName,2)='协和' then '3' else '1' end ShippingType ,\r\n\t\t                                 case when AR.dVeriDate is null then convert(varchar(10),A.ddate,121) else convert(varchar(10),AR.dVeriDate,121) end ShippingDate ,--取销货单据日期 \r\n\t\t                                 case when SABILL.dDate is null then (case when AR.dVeriDate is null then convert(varchar(10),A.ddate,121) else convert(varchar(10),AR.dVeriDate,121) end) else convert(varchar(10),SABILL.dDate,121) end RecognizeDate ,\r\n\t\t                                 isnull(convert(varchar(10),A.dlastedshippingdate,121),'')  ETA ,--取最迟装船日期\r\n                                         isnull(convert(varchar(10),A.cDefine4,121),'') ETD,\r\n\t\t                                 AA.cinvcode ItemCode,(B.cinvname + B.cinvstd)  ItemName,\r\n\t\t                                 ARS.cBatch lotnumber ,ARS.iQuantity Quantity ,C.cEnSingular Unit,\r\n\t\t                                 convert(decimal(12,2),AA.fnatprice*ARS.iQuantity) SALESAMOUNT,'RMB' Currency,\r\n                                         case when Customer.cCusDefine1 is null then '2' else '1' end salestock,\r\n                                         case when Customer.cCusDefine1 is null then Customer.cCusCode else Customer.cCusDefine1 end wherecode,\r\n                                         case when AR.cShipAddress is null then Customer.cCusName else AR.cShipAddress end wherename,\r\n                                         Customer.cCusCode  EndCustomerCode,Customer.cCusName EndCustomerName,A.ccusordercode csocode,\r\n                                         '' changeitemcode,'' changeitemname\r\n\t\t                                 from ex_consignment A inner join ex_consignmentdetail AA on A.id=AA.id \r\n                                         left join Inventory B on AA.cinvcode=B.cInvCode\r\n\t\t                                 left join rdrecords32 ARS on ARS.iDLsID=AA.autoid \r\n                                         left join rdrecord32 AR on ARS.ID=AR.ID \r\n\t\t                                 left join Person on Person.cPersonCode=A.cPersonCode \r\n\t\t                                 left join Customer on A.ccuscode=Customer.cCusCode\r\n\t\t                                 left join ex_invoicedetail SABILLS on SABILLS.guid_source=AA.guids \r\n                                         left join ex_invoice SABILL on SABILL.id=SABILLS.id\r\n\t\t                                 left join ComputationUnit C on B.cGroupCode =C.cGroupCode and B.cComUnitCode =C.cComunitCode\r\n\t\t                                 left join foreigncurrency on foreigncurrency.cexch_name=A.cexch_name \r\n\t\t                                 where (B.cInvCCode like '112%' or B.cInvCCode like '212%' or B.cInvCCode like '130%' or B.cInvCCode like '230%' \r\n                                         or B.cInvCCode like '12002%' or B.cInvCCode like '22002%'  or B.cInvCCode like '101%' or B.cInvCCode like '201%') \r\n                                         and isnull(AR.bpufirst,0) =0 and isnull(AR.biafirst,0)=0 and A.ddate between  '" + str4 + "' and '" + str5 + "'   \r\n\t\t                                 and isnull(SABILL.bexinit,0)=0 and AR.csource='出口销货单') as table1 group by  \r\n                                         SlipNumber,CustomerCode,lotnumber,\r\n\t\t                                 ShippingType ,ItemCode,changeitemcode,changeitemname ) as dd where 1=1 order by ShippingType  ", init.conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                init.ExportDataGridViewToTSV(dataSet.Tables[0], strFileName);
            }
            catch (Exception)
            {
            }
        }

        private static void fGetItemValue_FInvExport()
        {
            string strFileName = "";
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
                        if (element2.LocalName == "ItemMaster")
                        {
                            strFileName = element2.InnerText;
                        }
                    }
                }
                string selectCommandText = "select 'ITEM' DataType,'SK' Sourcesystem,cinvcode ItemCode,(cinvname + cinvstd)  ItemName, case when  left(cinvccode,3) in ('212','112') then  1 else 2 end  Itemtype ,'' GlobalKPSCode from Inventory where (cinvccode like '212%' or cinvccode like '112%') or cInvCCode like '13003%' or cInvCCode like '23003%'  or cInvCCode like '101%' or cInvCCode like '201%' or cInvCCode like '12002%' or cInvCCode like '22002%'  or cInvCCode like '13002%' or cInvCCode like '23002%'";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, init.conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                init.ExportDataGridViewToTSV(dataSet.Tables[0], strFileName);
            }
            catch (Exception)
            {
            }
        }

        private static void fGetItemValue_FCustomerExport()
        {
            string strFileName = "";
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load("StockSet.xml");
                XmlNodeList childNodes = document.SelectSingleNode("ServerSet").ChildNodes;
                foreach (XmlNode node in childNodes)
                {
                    XmlElement element = (XmlElement)node;
                    XmlNodeList list2 = element.ChildNodes;
                    foreach (XmlNode node2 in list2)
                    {
                        XmlElement element2 = (XmlElement)node2;
                        if (element2.LocalName == "ItemCustomerMaster")
                        {
                            strFileName = element2.InnerText;
                        }
                    }
                }
                //string selectCommandText = "select 'CUST' DataType,'SK' Sourcesystem,cCusCode CustomerCode,cCusName CustomerName from Customer ";
                string selectCommandText = @"
                        SELECT 'CUST' DataType,'SK' Sourcesystem,cinvcode ItemCode,(cinvname + cinvstd) ItemName,
                            CASE
                            WHEN left(cinvccode, 3) IN('212', '112') THEN
                            1
                            ELSE 2
                            END Itemtype,'' GlobalKPSCode
                        FROM Inventory
                        WHERE(cinvccode LIKE '271%'
                                OR cinvccode LIKE '171%')
                                OR cInvCCode LIKE '181%'
                                OR cInvCCode LIKE '281%'
                                OR cInvCCode LIKE '131%'
                                OR cInvCCode LIKE '231%'
                                OR cInvCCode LIKE '152%'
                                OR cInvCCode LIKE '252%'
                                OR cInvCCode LIKE '152%'
                                OR cInvCCode LIKE '152%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(selectCommandText, init.conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                init.ExportDataGridViewToTSV(dataSet.Tables[0], strFileName);
            }
            catch (Exception)
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Import();
        }

        public static void Import()
        {
            init.WriteLog("TSV导出开始:");
            try
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
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "提示", MessageBoxButtons.OK);
                    new F_INIT().Show();
                }
                fGetItemValue_FInvExport();
                fGetItemValue_FCustomerExport();
                fGetItemValue_FActualInventoryExport();
                fGetItemValue_FActualReceivingExport();
                fGetItemValue_FActualShippingExport();
            }
            catch (Exception)
            {
            }
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.DGV_DATA_FInvExport = new DataGridView();
            this.DataType = new DataGridViewTextBoxColumn();
            this.Sourcesystem = new DataGridViewTextBoxColumn();
            this.ItemCode = new DataGridViewTextBoxColumn();
            this.ItemName = new DataGridViewTextBoxColumn();
            this.Itemtype = new DataGridViewTextBoxColumn();
            this.GlobalKPSCode = new DataGridViewTextBoxColumn();
            this.DGV_DATA_FCustomerExport = new DataGridView();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.CustomerCode = new DataGridViewTextBoxColumn();
            this.CustomerName = new DataGridViewTextBoxColumn();
            this.DGV_DATA_FActualInventoryExport = new DataGridView();
            this.dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            this.LocationCode = new DataGridViewTextBoxColumn();
            this.LocationName = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            this.FreeQuantity = new DataGridViewTextBoxColumn();
            this.AllocatedQuantity = new DataGridViewTextBoxColumn();
            this.Unit = new DataGridViewTextBoxColumn();
            this.dateofmanufacture = new DataGridViewTextBoxColumn();
            this.lotnumber = new DataGridViewTextBoxColumn();
            this.Intransitflag = new DataGridViewTextBoxColumn();
            this.inventorystatus = new DataGridViewTextBoxColumn();
            this.InventoryCheckDate = new DataGridViewTextBoxColumn();
            this.DGV_DATA_FActualReceivingExport = new DataGridView();
            this.dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            this.SlipNumber = new DataGridViewTextBoxColumn();
            this.InvoiceNumber = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new DataGridViewTextBoxColumn();
            this.Storingtype = new DataGridViewTextBoxColumn();
            this.StockedDate = new DataGridViewTextBoxColumn();
            this.AvailableDate = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new DataGridViewTextBoxColumn();
            this.Quantity = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            this.DGV_DATA_FActualShippingExport = new DataGridView();
            this.dataGridViewTextBoxColumn15 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            this.RepresentativeCode = new DataGridViewTextBoxColumn();
            this.RepresentativeName = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new DataGridViewTextBoxColumn();
            this.ShippingLocationCode = new DataGridViewTextBoxColumn();
            this.ShippingLocationName = new DataGridViewTextBoxColumn();
            this.ShippingType = new DataGridViewTextBoxColumn();
            this.ShippingDate = new DataGridViewTextBoxColumn();
            this.RecognizeDate = new DataGridViewTextBoxColumn();
            this.ETA = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new DataGridViewTextBoxColumn();
            this.SALESAMOUNT = new DataGridViewTextBoxColumn();
            this.Currency = new DataGridViewTextBoxColumn();
            this.DGV_DATA_FActualShippingMonthlyExport = new DataGridView();
            this.dataGridViewTextBoxColumn27 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new DataGridViewTextBoxColumn();
            this.SalesLocationCode = new DataGridViewTextBoxColumn();
            this.SalesLocationName = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new DataGridViewTextBoxColumn();
            this.Salesregognizedmonth = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.DGV_DATA_FInvExport).BeginInit();
            ((ISupportInitialize) this.DGV_DATA_FCustomerExport).BeginInit();
            ((ISupportInitialize) this.DGV_DATA_FActualInventoryExport).BeginInit();
            ((ISupportInitialize) this.DGV_DATA_FActualReceivingExport).BeginInit();
            ((ISupportInitialize) this.DGV_DATA_FActualShippingExport).BeginInit();
            ((ISupportInitialize) this.DGV_DATA_FActualShippingMonthlyExport).BeginInit();
            base.SuspendLayout();
            this.DGV_DATA_FInvExport.AllowUserToAddRows = false;
            this.DGV_DATA_FInvExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DATA_FInvExport.Columns.AddRange(new DataGridViewColumn[] { this.DataType, this.Sourcesystem, this.ItemCode, this.ItemName, this.Itemtype, this.GlobalKPSCode });
            this.DGV_DATA_FInvExport.Location = new Point(12, 12);
            this.DGV_DATA_FInvExport.Name = "DGV_DATA_FInvExport";
            this.DGV_DATA_FInvExport.RowTemplate.Height = 0x17;
            this.DGV_DATA_FInvExport.Size = new Size(0x60, 0x74);
            this.DGV_DATA_FInvExport.TabIndex = 1;
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "DATATYPE";
            this.DataType.Name = "DataType";
            this.Sourcesystem.DataPropertyName = "Sourcesystem";
            this.Sourcesystem.HeaderText = "SOURCESYSTEM";
            this.Sourcesystem.Name = "Sourcesystem";
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "ITEMCD";
            this.ItemCode.Name = "ItemCode";
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "ITEMNAME";
            this.ItemName.Name = "ItemName";
            this.Itemtype.DataPropertyName = "Itemtype";
            this.Itemtype.HeaderText = "ITEMTYPE";
            this.Itemtype.Name = "Itemtype";
            this.GlobalKPSCode.DataPropertyName = "GlobalKPSCode";
            this.GlobalKPSCode.HeaderText = "GLOBALKPSCD";
            this.GlobalKPSCode.Name = "GlobalKPSCode";
            this.DGV_DATA_FCustomerExport.AllowUserToAddRows = false;
            this.DGV_DATA_FCustomerExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DATA_FCustomerExport.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.CustomerCode, this.CustomerName });
            this.DGV_DATA_FCustomerExport.Location = new Point(0x72, 12);
            this.DGV_DATA_FCustomerExport.Name = "DGV_DATA_FCustomerExport";
            this.DGV_DATA_FCustomerExport.RowTemplate.Height = 0x17;
            this.DGV_DATA_FCustomerExport.Size = new Size(0x54, 0x74);
            this.DGV_DATA_FCustomerExport.TabIndex = 2;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DataType";
            this.dataGridViewTextBoxColumn1.HeaderText = "DATATYPE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Sourcesystem";
            this.dataGridViewTextBoxColumn2.HeaderText = "SOURCE_SYSTEM";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.CustomerCode.DataPropertyName = "CustomerCode";
            this.CustomerCode.HeaderText = "CUSTOMERCODE";
            this.CustomerCode.Name = "CustomerCode";
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "CUSTOMERNAME";
            this.CustomerName.Name = "CustomerName";
            this.DGV_DATA_FActualInventoryExport.AllowUserToAddRows = false;
            this.DGV_DATA_FActualInventoryExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DATA_FActualInventoryExport.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.LocationCode, this.LocationName, this.dataGridViewTextBoxColumn5, this.dataGridViewTextBoxColumn6, this.FreeQuantity, this.AllocatedQuantity, this.Unit, this.dateofmanufacture, this.lotnumber, this.Intransitflag, this.inventorystatus, this.InventoryCheckDate });
            this.DGV_DATA_FActualInventoryExport.Location = new Point(0xcc, 12);
            this.DGV_DATA_FActualInventoryExport.Name = "DGV_DATA_FActualInventoryExport";
            this.DGV_DATA_FActualInventoryExport.RowTemplate.Height = 0x17;
            this.DGV_DATA_FActualInventoryExport.Size = new Size(0x4a, 0x74);
            this.DGV_DATA_FActualInventoryExport.TabIndex = 3;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DataType";
            this.dataGridViewTextBoxColumn3.HeaderText = "DATATYPE";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Sourcesystem";
            this.dataGridViewTextBoxColumn4.HeaderText = "SOURCESYSTEM";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.LocationCode.DataPropertyName = "LocationCode";
            this.LocationCode.HeaderText = "LOCATIONCD";
            this.LocationCode.Name = "LocationCode";
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.HeaderText = "LOCATIONNAME";
            this.LocationName.Name = "LocationName";
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn5.HeaderText = "ITEMCD";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn6.HeaderText = "ITEMNAME";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.FreeQuantity.DataPropertyName = "FreeQuantity";
            style.Format = "N4";
            style.NullValue = null;
            this.FreeQuantity.DefaultCellStyle = style;
            this.FreeQuantity.HeaderText = "FREEQUANTITY";
            this.FreeQuantity.Name = "FreeQuantity";
            this.AllocatedQuantity.DataPropertyName = "AllocatedQuantity";
            this.AllocatedQuantity.HeaderText = "ALLOCATEDQUANTITY";
            this.AllocatedQuantity.Name = "AllocatedQuantity";
            this.Unit.DataPropertyName = "Unit";
            this.Unit.HeaderText = "UNIT";
            this.Unit.Name = "Unit";
            this.dateofmanufacture.DataPropertyName = "dateofmanufacture";
            this.dateofmanufacture.HeaderText = "MANUFACTUREDATE";
            this.dateofmanufacture.Name = "dateofmanufacture";
            this.lotnumber.DataPropertyName = "lotnumber";
            this.lotnumber.HeaderText = "LOTNUMBER";
            this.lotnumber.Name = "lotnumber";
            this.Intransitflag.DataPropertyName = "Intransitflag";
            this.Intransitflag.HeaderText = "INTRANSITFLAG";
            this.Intransitflag.Name = "Intransitflag";
            this.inventorystatus.DataPropertyName = "inventorystatus";
            this.inventorystatus.HeaderText = "INVENTORYSTATUS";
            this.inventorystatus.Name = "inventorystatus";
            this.InventoryCheckDate.DataPropertyName = "InventoryCheckDate";
            this.InventoryCheckDate.HeaderText = "INVENTORYCHECKDATE";
            this.InventoryCheckDate.Name = "InventoryCheckDate";
            this.DGV_DATA_FActualReceivingExport.AllowUserToAddRows = false;
            this.DGV_DATA_FActualReceivingExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DATA_FActualReceivingExport.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn7, this.dataGridViewTextBoxColumn8, this.SlipNumber, this.InvoiceNumber, this.dataGridViewTextBoxColumn9, this.dataGridViewTextBoxColumn10, this.Storingtype, this.StockedDate, this.AvailableDate, this.dataGridViewTextBoxColumn11, this.dataGridViewTextBoxColumn12, this.dataGridViewTextBoxColumn13, this.Quantity, this.dataGridViewTextBoxColumn14 });
            this.DGV_DATA_FActualReceivingExport.Location = new Point(0x11c, 12);
            this.DGV_DATA_FActualReceivingExport.Name = "DGV_DATA_FActualReceivingExport";
            this.DGV_DATA_FActualReceivingExport.RowTemplate.Height = 0x17;
            this.DGV_DATA_FActualReceivingExport.Size = new Size(0x57, 0x74);
            this.DGV_DATA_FActualReceivingExport.TabIndex = 4;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DataType";
            this.dataGridViewTextBoxColumn7.HeaderText = "DATATYPE";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Sourcesystem";
            this.dataGridViewTextBoxColumn8.HeaderText = "SOURCESYSTEM";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.SlipNumber.DataPropertyName = "SlipNumber";
            this.SlipNumber.HeaderText = "SLIPNUMBER";
            this.SlipNumber.Name = "SlipNumber";
            this.InvoiceNumber.DataPropertyName = "InvoiceNumber";
            this.InvoiceNumber.HeaderText = "INVOICENUMBER";
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.dataGridViewTextBoxColumn9.DataPropertyName = "LocationCode";
            this.dataGridViewTextBoxColumn9.HeaderText = "LOCATIONCD";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn10.DataPropertyName = "LocationName";
            this.dataGridViewTextBoxColumn10.HeaderText = "LOCATIONNAME";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.Storingtype.DataPropertyName = "Storingtype";
            this.Storingtype.HeaderText = "STORINGTYPE";
            this.Storingtype.Name = "Storingtype";
            this.StockedDate.DataPropertyName = "StockedDate";
            this.StockedDate.HeaderText = "STOCKEDDATE";
            this.StockedDate.Name = "StockedDate";
            this.AvailableDate.DataPropertyName = "AvailableDate";
            this.AvailableDate.HeaderText = "AVAILABLEDATE";
            this.AvailableDate.Name = "AvailableDate";
            this.dataGridViewTextBoxColumn11.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn11.HeaderText = "ITEMCD";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn12.HeaderText = "ITEMNAME";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn13.DataPropertyName = "lotnumber";
            this.dataGridViewTextBoxColumn13.HeaderText = "LOTNUMBER";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "QUANTITY";
            this.Quantity.Name = "Quantity";
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Unit";
            this.dataGridViewTextBoxColumn14.HeaderText = "UNIT";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.DGV_DATA_FActualShippingExport.AllowUserToAddRows = false;
            this.DGV_DATA_FActualShippingExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DATA_FActualShippingExport.Columns.AddRange(new DataGridViewColumn[] { 
                this.dataGridViewTextBoxColumn15, this.dataGridViewTextBoxColumn16, this.dataGridViewTextBoxColumn17, this.RepresentativeCode, this.RepresentativeName, this.dataGridViewTextBoxColumn18, this.dataGridViewTextBoxColumn19, this.dataGridViewTextBoxColumn20, this.dataGridViewTextBoxColumn21, this.ShippingLocationCode, this.ShippingLocationName, this.ShippingType, this.ShippingDate, this.RecognizeDate, this.ETA, this.dataGridViewTextBoxColumn22,
                this.dataGridViewTextBoxColumn23, this.dataGridViewTextBoxColumn24, this.dataGridViewTextBoxColumn25, this.dataGridViewTextBoxColumn26, this.SALESAMOUNT, this.Currency
            });
            this.DGV_DATA_FActualShippingExport.Location = new Point(0x179, 12);
            this.DGV_DATA_FActualShippingExport.Name = "DGV_DATA_FActualShippingExport";
            this.DGV_DATA_FActualShippingExport.RowTemplate.Height = 0x17;
            this.DGV_DATA_FActualShippingExport.Size = new Size(90, 0x74);
            this.DGV_DATA_FActualShippingExport.TabIndex = 5;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DataType";
            this.dataGridViewTextBoxColumn15.HeaderText = "DATATYPE";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Sourcesystem";
            this.dataGridViewTextBoxColumn16.HeaderText = "SOURCESYSTEM";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn17.DataPropertyName = "SlipNumber";
            this.dataGridViewTextBoxColumn17.HeaderText = "SLIPNUMBER";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.RepresentativeCode.DataPropertyName = "RepresentativeCode";
            this.RepresentativeCode.HeaderText = "REPRESENTATIVECD";
            this.RepresentativeCode.Name = "RepresentativeCode";
            this.RepresentativeName.DataPropertyName = "RepresentativeName";
            this.RepresentativeName.HeaderText = "REPRESENTATIVENAME";
            this.RepresentativeName.Name = "RepresentativeName";
            this.dataGridViewTextBoxColumn18.DataPropertyName = "LocationCode";
            this.dataGridViewTextBoxColumn18.HeaderText = "SALESLOCATIONCD";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn19.DataPropertyName = "LocationName";
            this.dataGridViewTextBoxColumn19.HeaderText = "SALESLOCATIONNAME";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn20.DataPropertyName = "CustomerCode";
            this.dataGridViewTextBoxColumn20.HeaderText = "CUSTOMERCD";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn21.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn21.HeaderText = "CUSTOMERNAME";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.ShippingLocationCode.DataPropertyName = "ShippingLocationCode";
            this.ShippingLocationCode.HeaderText = "SHIPPINGLOCATIONCD";
            this.ShippingLocationCode.Name = "ShippingLocationCode";
            this.ShippingLocationName.DataPropertyName = "ShippingLocationName";
            this.ShippingLocationName.HeaderText = "SHIPPINGLOCATIONNAME";
            this.ShippingLocationName.Name = "ShippingLocationName";
            this.ShippingType.DataPropertyName = "ShippingType";
            this.ShippingType.HeaderText = "SHIPPINGTYPE";
            this.ShippingType.Name = "ShippingType";
            this.ShippingDate.DataPropertyName = "ShippingDate";
            this.ShippingDate.HeaderText = "SHIPPINGDATE";
            this.ShippingDate.Name = "ShippingDate";
            this.RecognizeDate.DataPropertyName = "RecognizeDate";
            this.RecognizeDate.HeaderText = "RECOGNIZEDATE";
            this.RecognizeDate.Name = "RecognizeDate";
            this.ETA.DataPropertyName = "ETA";
            this.ETA.HeaderText = "ETA";
            this.ETA.Name = "ETA";
            this.dataGridViewTextBoxColumn22.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn22.HeaderText = "ITEMCD";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn23.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn23.HeaderText = "ITEMNAME";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn24.DataPropertyName = "lotnumber";
            this.dataGridViewTextBoxColumn24.HeaderText = "LOTNUMBER";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn25.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn25.HeaderText = "QUANTITY";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Unit";
            this.dataGridViewTextBoxColumn26.HeaderText = "UNIT";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.SALESAMOUNT.DataPropertyName = "SALESAMOUNT";
            this.SALESAMOUNT.HeaderText = "SALESAMOUNT";
            this.SALESAMOUNT.Name = "SALESAMOUNT";
            this.Currency.DataPropertyName = "Currency";
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            this.DGV_DATA_FActualShippingMonthlyExport.AllowUserToAddRows = false;
            this.DGV_DATA_FActualShippingMonthlyExport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DATA_FActualShippingMonthlyExport.Columns.AddRange(new DataGridViewColumn[] { this.dataGridViewTextBoxColumn27, this.dataGridViewTextBoxColumn28, this.SalesLocationCode, this.SalesLocationName, this.dataGridViewTextBoxColumn29, this.dataGridViewTextBoxColumn30, this.dataGridViewTextBoxColumn31, this.dataGridViewTextBoxColumn32, this.dataGridViewTextBoxColumn33, this.Salesregognizedmonth, this.dataGridViewTextBoxColumn34, this.dataGridViewTextBoxColumn35, this.dataGridViewTextBoxColumn36, this.dataGridViewTextBoxColumn37, this.dataGridViewTextBoxColumn38, this.dataGridViewTextBoxColumn39 });
            this.DGV_DATA_FActualShippingMonthlyExport.Location = new Point(0x1d9, 12);
            this.DGV_DATA_FActualShippingMonthlyExport.Name = "DGV_DATA_FActualShippingMonthlyExport";
            this.DGV_DATA_FActualShippingMonthlyExport.RowTemplate.Height = 0x17;
            this.DGV_DATA_FActualShippingMonthlyExport.Size = new Size(0x6a, 0x74);
            this.DGV_DATA_FActualShippingMonthlyExport.TabIndex = 6;
            this.dataGridViewTextBoxColumn27.DataPropertyName = "DataType";
            this.dataGridViewTextBoxColumn27.HeaderText = "DATATYPE";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn28.DataPropertyName = "Sourcesystem";
            this.dataGridViewTextBoxColumn28.HeaderText = "SOURCESYSTEM";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.SalesLocationCode.DataPropertyName = "SalesLocationCode";
            this.SalesLocationCode.HeaderText = "SalesLocationCode";
            this.SalesLocationCode.Name = "SalesLocationCode";
            this.SalesLocationCode.ReadOnly = true;
            this.SalesLocationName.DataPropertyName = "SalesLocationName";
            this.SalesLocationName.HeaderText = "SalesLocationName";
            this.SalesLocationName.Name = "SalesLocationName";
            this.SalesLocationName.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "CustomerCode";
            this.dataGridViewTextBoxColumn29.HeaderText = "CUSTOMERCD";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn30.DataPropertyName = "CustomerName";
            this.dataGridViewTextBoxColumn30.HeaderText = "CUSTOMERNAME";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn31.DataPropertyName = "ShippingLocationCode";
            this.dataGridViewTextBoxColumn31.HeaderText = "SHIPPINGLOCATIONCD";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn32.DataPropertyName = "ShippingLocationName";
            this.dataGridViewTextBoxColumn32.HeaderText = "SHIPPINGLOCATIONNAME";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn33.DataPropertyName = "ShippingType";
            this.dataGridViewTextBoxColumn33.HeaderText = "SHIPPINGTYPE";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.Salesregognizedmonth.DataPropertyName = "Salesregognizedmonth";
            this.Salesregognizedmonth.HeaderText = "Salesregognizedmonth";
            this.Salesregognizedmonth.Name = "Salesregognizedmonth";
            this.dataGridViewTextBoxColumn34.DataPropertyName = "ItemCode";
            this.dataGridViewTextBoxColumn34.HeaderText = "ItemCode";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn35.HeaderText = "ITEMNAME";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Quantity";
            this.dataGridViewTextBoxColumn36.HeaderText = "QUANTITY";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn37.DataPropertyName = "cEnSingular";
            this.dataGridViewTextBoxColumn37.HeaderText = "UNIT";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn38.DataPropertyName = "SalesAmount";
            this.dataGridViewTextBoxColumn38.HeaderText = "SALESAMOUNT";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Currency";
            this.dataGridViewTextBoxColumn39.HeaderText = "Currency";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x290, 210);
            base.Controls.Add(this.DGV_DATA_FActualShippingMonthlyExport);
            base.Controls.Add(this.DGV_DATA_FActualShippingExport);
            base.Controls.Add(this.DGV_DATA_FActualReceivingExport);
            base.Controls.Add(this.DGV_DATA_FActualInventoryExport);
            base.Controls.Add(this.DGV_DATA_FCustomerExport);
            base.Controls.Add(this.DGV_DATA_FInvExport);
            base.Name = "Form1";
            this.Text = "Form1";
            base.Load += new EventHandler(this.Form1_Load);
            ((ISupportInitialize) this.DGV_DATA_FInvExport).EndInit();
            ((ISupportInitialize) this.DGV_DATA_FCustomerExport).EndInit();
            ((ISupportInitialize) this.DGV_DATA_FActualInventoryExport).EndInit();
            ((ISupportInitialize) this.DGV_DATA_FActualReceivingExport).EndInit();
            ((ISupportInitialize) this.DGV_DATA_FActualShippingExport).EndInit();
            ((ISupportInitialize) this.DGV_DATA_FActualShippingMonthlyExport).EndInit();
            base.ResumeLayout(false);
        }
    }
}

