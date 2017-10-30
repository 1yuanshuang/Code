# 1 chart控件的用法

## 1.1 ChartAreas图表区域集合         

 Chart控件里每个Series都画在ChartArea上，Chart控件可以有多个ChartArea叠加在一起显示。比如第一个ChartArea绘制的是曲线，第二个画的是柱状图或者是其他类型的，这也就是Series的ChartType，我们可以把多个Series画在一个ChartArea上，但是如果有一个列数据单位范围在500~10000之间的数据浮动最大，有一列数据单位范围在0.1~2.0之间，有一列数据单位范围在50~100之间，那画在同一个ChartArea上显示的话，0.1到2.0的数据会变成一条直线。当只有1、2条这样的数据时，可以在Series中设置主轴和副轴，但当出现多条数据，多种类型的显示，就需要多个ChartArea来解决了。

ChartAreas可以理解为是一个图表的绘图区，例如，你想在一幅图上呈现两个不同属性的内容，一个是用户流量，另一个则是系统资源占用情况，那么你要在一个图形上绘制这两种情况，明显是不合理的，对于这种情况，可以建立两个ChartArea，一个用于呈现用户流量，另一个则用于呈现系统资源的占用情况。
当然了，图表控件并不限制你添加多少个绘图区域，你可以根据你的需要进行添加。对于每一个绘图区域，你可以设置各自的属性，如：X,Y轴属性、背景等。

需要注意的是，绘图区域只是一个可以作图的区域范围，它本身并不包含要作图形的各种属性数据。

## 1.2 Legends图例集合

Legends是一个图例的集合，即标注图形中各个线条或颜色的含义，同样，一个图片也可以包含多个图例说明，比如像上面说的多个图表区域的方式，则可以建立多个图例，分别说明各个绘图区域的信息。

## 1.3 Series图表序列

图表序列，应该是整个绘图中最关键的内容了，通俗点说，即是实际的绘图数据区域，实际呈现的图形形状，就是由此集合中的每一个图表来构成的，可以往集合里面添加多个图表，每一个图表可以有自己的绘制形状、样式、独立的数据等。
需要注意的是，每一个图表，你可以指定它的绘制区域，让此图表呈现在某个绘图区域，也可以让几个图表在同一个绘图区域叠加。

## 1.4  AddXY 方法

该方法将一个DataPoint对象添加到DataPointCollection;数据点总是添加到集合的末尾。必须提供至少一个y值，否则将抛出异常。该方法还检查该数据所属的DataPointCollection对象的YValueType属性;如果指定了太多的y值，则会抛出一个异常。为了使DateTime格式化具有效果，一个值必须是一个DateTime对象。如果你的数据点不需要x值——也就是说，如果您正在创建非分散的数据——使用AddY方法。

## 1.5 AxisX,AxisY,Axis Label, Axis Title

AxisX,AxisY,表示主坐标轴，每一个ChartArea都有对应的坐标轴，包括主坐标轴，辅坐标轴。Axis Label表示 横纵坐标的文字 。Axis Title表示 横纵坐标的代表什么。

## 1.6 Grid Lines,Plot Area                                          

 Grid Lines表示网格，Plot Area表示图区。

# 2 定时器

## 2.1 在C#里定时器类有3个

### 2.1.1 定义在System.Windows.Forms里

System.Windows.Forms.Timer是应用于WinForm中的，它是通过Windows消息机制实现的，类似于VB或Delphi中的Timer控件，内部使用API SetTimer实现的。它的主要缺点是计时不精确，而且必须有消息循环，Console Application(控制台应用程序)无法使用。
System.Timers.Timer和System.Threading.Timer非常类似，是通过.NET Thread Pool实现的，轻量，计时精确，对应用程序、消息没有特别的要求。System.Timers.Timer还可以应用于WinForm，完全取代上面的Timer控件。它们的缺点是不支持直接的拖放，需要手工编码。

### 2.1.2 定义在System.Threading.Timer类里

System.Threading.Timer 是一个使用回调方法的计时器，而且由线程池线程服务，简单且对资源要求不高。只要在使用 Timer，就必须保留对它的引用。对于任何托管对象，如果没有对 Timer 的引用，计时器会被垃圾回收。即使 Timer 仍处在活动状态，也会被回收。当不再需要计时器时，请使用 Dispose 方法释放计时器持有的资源。使用 TimerCallback 委托指定希望 Timer 执行的方法。计时器委托在构造计时器时指定，并且不能更改。此方法不在创建计时器的线程中执行，而是在系统提供的线程池线程中执行。

创建计时器时，可以指定在第一次执行方法之前等待的时间量（截止时间）以及此后的执行期间等待的时间量（时间周期）。可以使用 Change 方法更改这些值或禁用计时器。

### 2.1.3 定义在System.Timers.Timer类里

System.Timers.Timer t=new System.Timers.Timer(1000);//实例化Timer类设置间隔时间为1000毫秒；
t.Elapsed += new System.Timers.ElapsedEventHandler(theout);//到达时间的时候执行事件；
t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；

## 2.2 使用定时器引发的线程安全问题

C#Winform编程中，跨线程直接更新UI控件的做法是不正确的，会时常出现“线程间操作无效: 从不是创建控件的线程访问它”的异常。处理跨线程更新Winform UI控件常用的方法有4种：

（1） 通过UI线程的SynchronizationContext的Post/Send方法更新；

在线程执行过程中，需要更新到UI控件上的数据不再直接更新，而是通过UI线程上下文的Post/Send方法，将数据以异步/同步消息的形式发送到UI线程的消息队列；UI线程收到该消息后，根据消息是异步消息还是同步消息来决定通过异步/同步的方式调用SetTextSafePost方法直接更新自己的控件了。

在本质上，向UI线程发送的消息并是不简单数据，而是一条委托调用命令。

（2）通过UI控件的Invoke/BegainInvoke方法更新；

使用控件的Invoke/BegainInvoke方法，将委托转到UI线程上调用，实现线程安全的更新。原理与方法1类似，本质上还是把线程中要提交的消息，通过控件句柄调用委托交到UI线程中去处理。

（3）通过BackgroundWorker取代Thread执行异步操作；

C# Winform中执行异步任务时，BackgroundWorker是个不错的选择。它是EAP（Event based Asynchronous Pattern）思想的产物，DoWork用来执行异步任务，在任务执行过程中/执行完成后，我们可以通过ProgressChanged，ProgressCompleteded事件进行线程安全的UI更新。

（4）通过设置窗体属性，取消线程安全检查来避免"跨线程操作异常"（非线程安全，建议不使用）。

通过设置CheckForIllegalCrossThreadCalls属性，可以指示是否捕获线程间非安全操作异常。该属性值默认为ture，即线程间非安全操作是要捕获异常的（"线程间操作无效"异常）。通过设置该属性为false简单的屏蔽了该异常。

# 3 C#二维数组用法

（1）  如何获取二维数组中的元素个数？     

int[,] array = new int[,] {{1,2,3},{4,5,6},{7,8,9}};//定义一个3行3列的二维数组
int row = array.Rank;//获取维数，这里指行数
int col = array.GetLength(1);//获取指定维度中的元素个数，这里也就是列数了。（0是第一维，1表示的是第二维）
int num = array.Length;//获取整个二维数组的长度，即所有元的个数  

例如下面的四维数组：

int[,,,] arr = new int[9, 8, 7, 6];

arr.Rank;//返回4
arr.GetLength(0);//返回9
arr.GetLength(1);//返回8
arr.GetLength(2);//返回7
arr.GetLength(3);//返回6 
arr.GetUpperBound(0)+1;//返回9
arr.Length;//返回3024

# 4 自定义控件和用户控件

## 4.1 概述

 用户控件(UserControl): 扩展名为*.ascx,跟*.aspx在结构上相似，是指页面中加载的功能块,只是用户控件不能单独作为页面运行,必须嵌入到*.aspx页面或其它用户控件中使用. 

自定义控件，编译后可以添加引用到工具栏里面，直接用鼠标拖动使用. 

## 4.2  区别

（1）用户控件用.ascx文件表示，在"添加新项"中点击"vveb用户控件"。它不是编译代码，编译随网页动态进行自定义控件在dll文件中表示，它是编译代码。在“新建项目”的模块中点击“web控件库”,用户控件不会出现在工具箱中，而自定义控件会出现在工具箱中。

（2）用户控件支持缓存，而自定义控件不支持缓存。

（3）用户控件会对使用可视化设计的用户提供有限的支持，而自定义控件会提供全面的支持。

（4）用户控件可以在一个应用程序中重用，但不能跨应用程序重用。自定义用户就可以跨应用程序使用，它放在被称为全局程序集缓存的中央库中，以便那台服务器上的所有应用程序都可以使用它。

用户控件不能独立存在和使用，它要求用asp.net页面作为容器。

## 4.3 意义

通过继承和组合已有控件，最大限度的重用代码，并能够实现新的界面功能。



  

​     

 

 





























































#  



​        



  

​     

 

 

 

 

 





























































​         



  

​     

 

 

 

 

 





























































  

​     

 

 

 

 

 



























































​        



  

​     

 

 

 

 

 

























































 

​     

 

 

 

 

 







































  

​     

 

 

 

 

 




















































