using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVTesting
{
    class CSVFile
    {
        public static void SaveCSV(DataTable dt, string fullPath)
        {
            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            string data = "";
            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }

            sw.WriteLine(data);
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文引号
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n'))
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }


        public static DataTable ReadCSV(string filePath)
        {
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs, Encoding.Default);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GB2312"));
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine = null;
            string[] tableHead = null;

            string temp = "";
            //标示列数
            int columnCount = 0;
            int count = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;
            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                if (IsFirst == true)
                {
                    tableHead = strLine.Split(',');
                    IsFirst = false;
                    columnCount = tableHead.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(tableHead[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    while (strLine != null && !strLine.Contains('"'))
                    {
                        aryLine = strLine.Split(',');
                        DataRow dr = dt.NewRow();
                        for (int j = 0; j < columnCount; j++)
                        {
                            dr[j] = aryLine[j];
                        }
                        dt.Rows.Add(dr);
                        strLine = sr.ReadLine();
                    }

                    if (strLine != null && strLine.Contains('"'))
                    {
                        int j = 0;
                        DataRow dr = dt.NewRow();
                        for (j = 0; j < columnCount; j++)
                        {
                            for (int i = 0; i < strLine.Length; i++)
                            {
                                if (i < strLine.Length-1&&strLine[i] == ','&&strLine[i + 1] == '"')
                                {
                                    dr[j] = strLine.Substring(0, strLine.IndexOf(','));
                                }
                                else if (i < strLine.Length-1&&strLine[i] == '"' && strLine[i + 1] != ',')
                                {
                                    while(i<strLine.Length-1&&strLine[i+1]!='"')
                                    {
                                        i++;
                                    }
                                    if(i < strLine.Length - 2&&strLine[i + 1] == '"'&&strLine[i+2]==',')
                                    {
                                        temp = strLine.Substring(strLine.IndexOf("\"")+1 , strLine.LastIndexOf("\"") - strLine.IndexOf("\"")-1);
                                        j++;
                                        dr[j] = temp;
                                    }          
                                    else if(i==strLine.Length-1&&strLine[i]!='"')
                                    {
                                        //异常处理
                                        break;
                                    }
                                }
                                else if(i < strLine.Length - 1&&strLine[i] == '"' && strLine[i + 1] == ',')
                                {
                                    j++;            
                                    if(strLine.LastIndexOf("\"") + 2 <strLine.Length)
                                    {
                                        dr[j] = strLine.Substring(strLine.LastIndexOf("\"") + 2, strLine.LastIndexOf(",") - strLine.LastIndexOf("\"") - 2);
                                    }
                                }
                                else if(i < strLine.Length-1&&strLine[i]==','&&strLine[i+1]!='"')
                                {
                                    j++;
                                    if (j < columnCount)
                                    {
                                        dr[j] = strLine.Substring(strLine.LastIndexOf(",") + 1, strLine.Length - strLine.LastIndexOf(",") - 1);
                                    }
                                }
                               
                            }                       
                        }
                        dt.Rows.Add(dr);
                    }
                }
            }
            if (aryLine != null && aryLine.Length > 0)
            {
                dt.DefaultView.Sort = tableHead[0] + " " + "asc";
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        protected void DeleteRow(DataTable dt, string fullPath)
        {
            List<string> lines = new List<string>(File.ReadAllLines("fullPath"));//先读取到内存变量
            lines.RemoveAt(2);//指定删除的行
            File.WriteAllLines("fullPath", lines.ToArray());
        }

    
        public static DataTable DeleteColumn(DataTable dt, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GB2312"));

            dt.Columns.Remove("Part");
 
            return dt;
        }

        //public static DataTable MergeColumn(DataTable dt)
        //{
        //    string temp = dt.Rows[0][dt.Columns.Count - 1].ToString();
        //    int quantity = Convert.ToInt32(dt.Rows[0][0]);
        //    int tmp = quantity;
        //    DataRow dr = dt.NewRow();


        //    for (int i=1;i<dt.Rows.Count;i++)
        //    {          
        //        if (dt.Rows[i][dt.Columns.Count-1].ToString()==temp)
        //        {
        //            tmp += Convert.ToInt32(dt.Rows[i][0]);
        //            dt.Rows[i][0] = tmp;
        //            dt.Rows.RemoveAt(i);
        //            i--;
        //        }

        //        if (i==dt.Rows.Count-1&&dt.Rows.Count>2)
        //        {
        //            i = 0;
        //            int j = i + 1;                
        //            temp = dt.Rows[j][dt.Columns.Count - 1].ToString();
        //            quantity = Convert.ToInt32(dt.Rows[j][0]);
        //            tmp = quantity;
        //        }             
        //    }   
        //    return dt;
        //}
        //appoint为指定合并的标准，为自然排序的字段排序
        public static DataTable ReturnMergeData(DataTable dataTable, int appoint)
        {
            appoint = --appoint;

            if (dataTable.Rows.Count > 0)
            {
                //合并
                System.Collections.Hashtable ht = new System.Collections.Hashtable();
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    if (ht.ContainsKey(dataTable.Rows[i][appoint]))
                    {
                        //获取行索引
                        int index = (int)ht[dataTable.Rows[i][appoint]];

                        dataTable.Rows[index][0] = Convert.ToInt32(dataTable.Rows[index][0]) + Convert.ToInt32(dataTable.Rows[i][0]);

                        //if (!dataTable.Rows[i]["LocationID"].ToString().Contains(dataTable.Rows[index]["LocationID"].ToString()))
                        //{
                        //    //库位
                        //    dataTable.Rows[index]["LocationID"] = dataTable.Rows[index]["LocationID"] + "," + dataTable.Rows[i]["LocationID"];
                        //}

                        for (int j = 1; j < dataTable.Columns.Count; j++)
                        //for (int j = 1; j < selected.Length + 1; j++)
                        {
                            //Iselected = Array.IndexOf(selected, j);
                            //if (-1 == Iselected)
                            //    continue;
                            if (appoint == j)
                                continue;
                            if (!dataTable.Rows[i][j].ToString().Contains(dataTable.Rows[index][j].ToString()))
                            {
                                dataTable.Rows[index][j] = dataTable.Rows[index][j] + "," + dataTable.Rows[i][j];
                            }
                        }
                        //删除重复行  
                        dataTable.Rows.RemoveAt(i);
                        //调整索引减1  
                        i--;
                    }
                    else
                    {
                        //保存名称以及行索引
                        ht.Add(dataTable.Rows[i][appoint], i);
                    }
                }
            }
            //删除不需要的列，引号内为列名称
            //for (int p = 0; p < selected.Length; p++)
            //for (int p = 0; p < dataTable.Columns.Count; p++)
            //{
            //    if (selected.Contains(p))
            //    {
            //        continue;
            //    }
            //    string tmp_unselected = "";
            //    tmp_unselected = dataTable.Columns[p].ColumnName;
            //    dataTable.Columns.Remove(tmp_unselected);
            //}


            return dataTable;
        }

    }
}
