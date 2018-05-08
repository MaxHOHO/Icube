namespace U8Interface
{
    using System;
    using System.Data;
    using System.Text;
    using System.Xml;

    internal class ClsXML
    {
        public static void addElement(string strFilePath, DataSet ds)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(strFilePath);
                XmlElement documentElement = document.DocumentElement;
                for (int i = 0; i <= (ds.Tables[0].Rows.Count - 1); i++)
                {
                    XmlElement newChild = document.CreateElement("第" + (i + 1) + "条");
                    for (int j = 0; j <= (ds.Tables[0].Columns.Count - 1); j++)
                    {
                        XmlElement element3 = document.CreateElement(ds.Tables[0].Columns[j].ColumnName);
                        XmlText text = document.CreateTextNode(ds.Tables[0].Rows[i][j].ToString());
                        element3.AppendChild(text);
                        newChild.AppendChild(element3);
                    }
                    documentElement.AppendChild(newChild);
                }
                document.Save(strFilePath);
            }
            catch (InvalidOperationException exception)
            {
                throw exception;
            }
            catch (XmlException exception2)
            {
                throw exception2;
            }
        }

        public static void addElement(string strFilePath, string strElement, string strText)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(strFilePath);
                XmlElement documentElement = document.DocumentElement;
                XmlElement newChild = document.CreateElement(strElement);
                XmlText text = document.CreateTextNode(strText);
                newChild.AppendChild(text);
                documentElement.AppendChild(newChild);
                document.Save(strFilePath);
            }
            catch (InvalidOperationException exception)
            {
                throw exception;
            }
            catch (XmlException exception2)
            {
                throw exception2;
            }
        }

        public static void creatXML(string strFilePath, string strRootElement)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(strFilePath, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.Indentation = 4;
                    writer.WriteStartDocument();
                    writer.WriteStartElement(strRootElement);
                }
            }
            catch (InvalidOperationException exception)
            {
                throw exception;
            }
            catch (XmlException exception2)
            {
                throw exception2;
            }
        }

        public static void removeAllElement(string strFilePath)
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(strFilePath);
                document.DocumentElement.RemoveAll();
                document.Save(strFilePath);
            }
            catch (XmlException exception)
            {
                throw exception;
            }
        }
    }
}

