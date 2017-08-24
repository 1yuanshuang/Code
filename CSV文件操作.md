# 1 CSV文件操作

## 1.1 什么是CSV文件

CSV，全称Comma-Separated Values，即逗号分隔值（或字符分隔值），它是一种以逗号等符号间隔的数据文件格式，可用于存放不带公式和格式的电子表格。CSV文件可以使用Excel软件打开和编辑。CSV文件的本质是TXT文件，在 CSV 文件中，数据“栏”以逗号分隔，可允许程序通过读取文件为数据重新创建正确的栏结构，并在每次遇到逗号时开始新的一栏。  创建 CSV 文件有许多方法。最常用的方法是用电子表格程序，如 Microsoft Excel，在 Microsoft Excel 中，选择“文件”>“另存为”，然后在“文件类型”下拉选择框中选择 "CSV （逗号分隔） (*.csv)"。  csv格式（即文件后缀为.csv，属于用excel软件可编辑的逗号分隔的一种文件格式）。

## 1.2 解析CSV文件

解析CSV文件时，首先打开这个CSV文件，每一行用逗号分割出不同的字段，然后逐行读取CSV文件中的数据，如果读取到第一行，则把表头这行记录的各字段内容添加到DataTable中，每个字段之间使用逗号分隔的。然后接着读取后面的每一行，每读取一行首先判断这一行中是否包含双引号，如果不包含双引号，则把这行记录的各字段内容添加到DataTable中，如果包含双引号，则分情况处理。CSV的格式就是用行来分隔不同的记录，记录中用“，”逗号分隔不同的字段域。

FileStream对象表示在磁盘或网络路径上指向文件的流。这个类提供了在文件中读写字节的方法，但经常使用StreamReader或StreamWriter执行这些功能。这是因为FileStream类操作的是字节和字节数组，而Stream类操作的是字符数据。字符数据易于使用，但是有些操作，比如随机文件访问(访问文件中间某点的数据)，就必须由FileStream对象执行。 FileMode枚举有几个成员，规定了如何打开或创建文件，                                                                                                                                                        第三个参数是FileAccess枚举的一个成员，它指定了流的作用。

读取CSV文件

```c#
public static DataTable ReadCSV(string filePath)
{
    DataTable dt = new DataTable();  //创建表
    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
    StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("GB2312"));
    string strLine = "";            //记录每次读取的一行记录
    string[] aryLine = null;            //记录每行记录中的各字段内容
    string[] tableHead = null;
    string temp  "";
    int columnCount = 0;            //标示列数
    bool IsFirst = true;            //标示是否是读取的第一行

    while ((strLine = sr.ReadLine()) != null)            //逐行读取CSV中的数据
    {
        if (IsFirst == true) //如果是读取的第一行
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
        {   //读取的这一行不为空且不包含双引号
            while (strLine != null && !strLine.Contains('"'))
            {
              aryLine = strLine.Split(',');
              DataRow dr = dt.NewRow(); //添加数据行
              for (int j = 0; j < columnCount; j++)
              {
                dr[j] = aryLine[j];
              }
              dt.Rows.Add(dr);
              strLine = sr.ReadLine();
          }
		//读取的这一行不为空且包含双引号
        if (strLine != null && strLine.Contains('"'))
        {
            int j = 0;
            DataRow dr = dt.NewRow();
            for (j = 0; j < columnCount; j++)
            {
              for (int i = 0; i < strLine.Length; i++)//依次读取这行数据的每一个字符
              {   //如果读取到的字符为逗号，且下一个为双引号，则截取逗号之前的字符串
                  if (i < strLine.Length-1 && strLine[i] == ','&& strLine[i + 1] == '"')
                  {
                         dr[j] = strLine.Substring(0, strLine.IndexOf(','));
                  }
 		   //如果读取到的字符为双引号且下一个字符不是逗号，则依次遍历直到找到下一个双引号，然后截取两个双引号之间的字符串
                  else if (i < strLine.Length-1 && strLine[i] == '"' && strLine[i + 1] != ',')
                  {
                      while(i<strLine.Length-1&&strLine[i+1]!='"')
                      {
                          i++;
                      }
                      if(i < strLine.Length - 2 && strLine[i + 1] == '"'&&strLine[i+2]==',') 
                      {
                          temp = strLine.Substring(strLine.IndexOf("\"")+1 , strLine.LastIndexOf("\"") - strLine.IndexOf("\"")-1);
                          j++;
                          dr[j] = temp;
                      }          
                      else if(i==strLine.Length-1&&strLine[i]!='"')
                      {
                           break;
                      }
                  }
         //如果读取到的字符为双引号且下一个字符是逗号，就截取这两个逗号之间的字符串        
                else if(i < strLine.Length - 1 && strLine[i] == '"' && strLine[i + 1] == ',')
                {
                      j++;            
                      if(strLine.LastIndexOf("\"") + 2 <strLine.Length)
                      {
                        dr[j] = strLine.Substring(strLine.LastIndexOf("\"") + 2, strLine.LastIndexOf(",") - strLine.LastIndexOf("\"") - 2);
                      }
                }
       //如果读取到的字符为逗号且下一个字符不是双引号，则截取逗号的下一个字符到结尾的字符串
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
    sr.Close();
    fs.Close();
    return dt;
}
```
## 1.3 DataTable用法

**创建表**

```c#
//创建一个空表
DataTable dt = new DataTable();
//创建一个名为"Table_New"的空表
DataTable dt = new DataTable("Table_New");
```

**创建列**

```c#
//1.创建空列
DataColumn dc = new DataColumn();
dt.Columns.Add(dc);
//2.创建带列名和类型名的列(两种方式任选其一)
dt.Columns.Add("column0", System.Type.GetType("System.String"));
dt.Columns.Add("column0", typeof(String));
```

**创建行**

```c#
//1.创建空行
DataRow dr = dt.NewRow();
dt.Rows.Add(dr);
//2.创建空行
dt.Rows.Add();
//3.通过行框架创建并赋值
dt.Rows.Add("张三",DateTime.Now);//Add里面参数的数据顺序要和dt中的列的顺序对应 
//4.通过复制dt2表的某一行来创建
dt.Rows.Add(dt2.Rows[i].ItemArray);
```

**赋值和取值**

```c#
//新建行的赋值
DataRow dr = dt.NewRow();
dr[0] = "张三";//通过索引赋值
dr["column1"] = DateTime.Now; //通过名称赋值
//对表已有行进行赋值
dt.Rows[0][0] = "张三"; //通过索引赋值
dt.Rows[0]["column1"] = DateTime.Now;//通过名称赋值
//取值
string name=dt.Rows[0][0].ToString();
string time=dt.Rows[0]["column1"].ToString();
```

**筛选行**

```c#
//选择column1列值为空的行的集合
DataRow[] drs = dt.Select("column1 is null");
//选择column0列值为"李四"的行的集合
DataRow[] drs = dt.Select("column0 = '李四'");
//筛选column0列值中有"张"的行的集合(模糊查询)
DataRow[] drs = dt.Select("column0 like '张%'");//如果的多条件筛选，可以加 and 或 or
//筛选column0列值中有"张"的行的集合并按column1降序排序
DataRow[] drs = dt.Select("column0 like '张%'", "column1 DESC");
```

**删除行**

```c#
//使用DataTable.Rows.Remove(DataRow)方法
dt.Rows.Remove(dt.Rows[0]);
//使用DataTable.Rows.RemoveAt(index)方法
dt.Rows.RemoveAt(0);
//使用DataRow.Delete()方法
dt.Row[0].Delete();
dt.AcceptChanges();

//-----区别和注意点-----
//Remove()和RemoveAt()方法是直接删除
//Delete()方法只是将该行标记为deleted，但是还存在，还可DataTable.RejectChanges()回滚，使该行取消删除。
//用Rows.Count来获取行数时，还是删除之前的行数，需要使用DataTable.AcceptChanges()方法来提交修改。
//如果要删除DataTable中的多行，应该采用倒序循环DataTable.Rows，而且不能用foreach进行循环删除，因为正序删除时索引会发生变化，程式发生异常，很难预料后果。
for (int i = dt.Rows.Count - 1; i >= 0; i--)
{
　　dt.Rows.RemoveAt(i);
}
```

**复制表**

```c#
//复制表，同时复制了表结构和表中的数据
DataTable dtNew = new DataTable();
dtNew = dt.Copy();
//复制表
DataTable dtNew = dt.Copy();  //复制dt表数据结构
dtNew.Clear()  //清空数据
for (int i = 0; i < dt.Rows.Count; i++)
{
    if (条件语句)
    {
         dtNew.Rows.Add(dt.Rows[i].ItemArray);  //添加数据行
    }
}
//克隆表，只是复制了表结构，不包括数据
DataTable dtNew = new DataTable();
dtNew = dt.Clone();
//如果只需要某个表中的某一行
DataTable dtNew = new DataTable();
dtNew = dt.Copy();
dtNew.Rows.Clear();//清空表数据
dtNew.ImportRow(dt.Rows[0]);//这时加入的是第一行
```

## 1.4 删除CSV文件的某一列

1.删除某一列
dt.Columns.Remove("Name");//Name为列名称

```c#
public static DataTable DeleteColumn(DataTable dt)
{
        dt.Columns.Remove("Part");
        return dt;
}
```
## 1.5 合并

问题：根据第四列厂家型号相同，来合并第二列，并且删除第三列，同时第一列数量还要累加。

思路：利用Hashtable这个临时容器存储DataTable中第四列厂家型号的值作为哈希表的键，该值对应的行索引作为哈希表的值，利用哈希表容器来更新DataTable表里面的数据，首先创建一个空的哈希表，然后依次遍历DataTable表每一行的第四列的值，如果哈希表里面不包含该值，则把该值作为键，同时把该值所对应的行索引作为值添加进哈希表，每遍历一行，如果哈希表里面包含该键（说明存在相同的厂家型号），则合并（获取该键对应的行索引，把刚遍历的这一行的第一列的值累加到该键对应的行索引第一列，然后遍历DataTable其他列，如果DataTable中该键对应的行不包含刚遍历的这一行其他列的值，则把这些值添加进该键对应的行相应的列），然后删除重复行。

哈希表(Hashtable)描述

用于处理和表现类似keyvalue的键值对，其中key通常可用来快速查找，同时key是区分大小写；value用于存储对应于key的值。Hashtable中keyvalue键值对均为object类型，所以Hashtable可以支持任何类型的keyvalue键值对. 

```c#
public static DataTable MergeColumn(DataTable dt,int col)
{
	 if (dt.Rows.Count > 0)
     {
          Hashtable ht = new Hashtable();//  创建哈希表
          for (int i = 0; i < dt.Rows.Count; i++)
          {
              if (ht.ContainsKey(dt.Rows[i][col])) //判断哈希表里是否包含该键
              {
                  int index = (int)ht[dt.Rows[i][col]]; //取哈希表里指定键的值
                  dt.Rows[index][0] = Convert.ToInt32(dt.Rows[index][0]) + Convert.ToInt32(dt.Rows[i][0]);

                  for (int j = 1; j < dt.Columns.Count; j++)
                  {
                      if (col == j)// 如果j等于要col，继续，不作任何处理
                          continue;
                      if (!dt.Rows[index][j].ToString().Contains(dt.Rows[i][j].ToString())) 
                      {
                          dt.Rows[index][j] = dt.Rows[index][j] + "," + dt.Rows[i][j];
                      }
                  }
                  dt.Rows.RemoveAt(i);//删除i所对应的这一行
                  i--;
              }

              else
              {
                  ht.Add(dt.Rows[i][col], i); //  往哈希表里添加键值对
              }
    }
    return dt;
}
```
