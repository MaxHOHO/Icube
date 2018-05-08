namespace U8Interface
{
    using System;

    public class ClsSystem
    {
        public static string ChangeComment(string strDat)
        {
            string str = "";
            for (int i = 0; i <= (strDat.Length - 1); i++)
            {
                if (strDat.Substring(i, 1).ToString() == "'")
                {
                    str = str + "''";
                }
                else
                {
                    str = str + strDat.Substring(i, 1).ToString();
                }
            }
            return str;
        }

        public static bool checkdate(string objdate)
        {
            try
            {
                DateTime time = Convert.ToDateTime(objdate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static double DateDiff(DateTime DateTime1, DateTime DateTime2, string Type)
        {
            double num2;
            double num = 0.0;
            try
            {
                TimeSpan span = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts = new TimeSpan(DateTime2.Ticks);
                TimeSpan span3 = span.Subtract(ts).Duration();
                string str = Type;
                if (str != null)
                {
                    if (str != "y")
                    {
                        if (str == "M")
                        {
                            goto Label_00B5;
                        }
                        if (str == "d")
                        {
                            goto Label_00EF;
                        }
                        if (str == "h")
                        {
                            goto Label_00F9;
                        }
                        if (str == "m")
                        {
                            goto Label_0103;
                        }
                        if (str == "s")
                        {
                            goto Label_010D;
                        }
                    }
                    else
                    {
                        num = Math.Floor((double) (span3.TotalDays / 365.0));
                    }
                }
                goto Label_0117;
            Label_00B5:
                num = Math.Floor((double) (((span3.TotalDays / 365.0) - Math.Floor((double) (span3.TotalDays / 365.0))) * 12.0));
                goto Label_0117;
            Label_00EF:
                num = span3.TotalDays;
                goto Label_0117;
            Label_00F9:
                num = span3.TotalHours;
                goto Label_0117;
            Label_0103:
                num = span3.TotalMinutes;
                goto Label_0117;
            Label_010D:
                num = span3.TotalSeconds;
            Label_0117:
                num2 = num;
            }
            catch (Exception)
            {
                num2 = 0.0;
            }
            return num2;
        }

        public static string getDatetime(DateTime objDateTime, double intspan, string Type)
        {
            string str2;
            string str = "";
            try
            {
                string str3 = Type;
                if (str3 != null)
                {
                    if (str3 != "y")
                    {
                        if (str3 == "M")
                        {
                            goto Label_008A;
                        }
                        if (str3 == "d")
                        {
                            goto Label_00A8;
                        }
                        if (str3 == "h")
                        {
                            goto Label_00C1;
                        }
                        if (str3 == "m")
                        {
                            goto Label_00DA;
                        }
                        if (str3 == "s")
                        {
                            goto Label_00F3;
                        }
                    }
                    else
                    {
                        str = objDateTime.AddYears(Convert.ToInt16(intspan)).ToString();
                    }
                }
                goto Label_010C;
            Label_008A:
                str = objDateTime.AddMonths(Convert.ToInt16(intspan)).ToString();
                goto Label_010C;
            Label_00A8:
                str = objDateTime.AddDays(intspan).ToString();
                goto Label_010C;
            Label_00C1:
                str = objDateTime.AddHours(intspan).ToString();
                goto Label_010C;
            Label_00DA:
                str = objDateTime.AddMinutes(intspan).ToString();
                goto Label_010C;
            Label_00F3:
                str = objDateTime.AddSeconds(intspan).ToString();
            Label_010C:
                str2 = str;
            }
            catch (Exception)
            {
                str2 = "";
            }
            return str2;
        }

        public static string gnvl(object objvalue1, object objvalue2)
        {
            try
            {
                if ((objvalue1.ToString() == "") || (objvalue1 == null))
                {
                    return ChangeComment(objvalue2.ToString());
                }
                return ChangeComment(objvalue1.ToString());
            }
            catch (Exception)
            {
                return objvalue2.ToString();
            }
        }

        public static bool isnull(object objvalue)
        {
            try
            {
                if (objvalue == null)
                {
                    return true;
                }
                if (objvalue.ToString() == "")
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}

