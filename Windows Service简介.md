###1 Windows Service简介:

一个Windows服务程序是在Windows操作系统下能完成特定功能的可执行的应用程序。Windows服务程序虽然是可执行的，但是它不像一般的可执行文件通过双击就能开始运行了，**它必须有特定的启动方式。这些启动方式包括了自动启动和手动启动两种**。对于自动启动的Windows服务程序，它们在Windows启动或是重启之后用户登录之前就开始执行了。只要你将相应的Windows服务程序注册到服务控制管理器（Service Control Manager）中，并将其启动类别设为自动启动就行了。而对于手动启动的Windows服务程序，你可以通过命令行工具的**NET START** 命令来启动它，或是通过控制面板中管理工具下的服务一项来启动相应的Windows服务程序。

同样，一个Windows服务程序也不能像一般的应用程序那样被终止。因为Windows服务程序一般是没有用户界面的，所以你也要通过命令行工具或是下面图中的工具来停止它，或是在系统关闭时使得Windows服务程序自动停止。因为Windows服务程序没有用户界面，所以基于用户界面的API函数对其是没有多大的意义。为了能使一个Windows服务程序能够正常并有效的在系统环境下工作，程序员必须实现一系列的方法来完成其服务功能。Windows服务程序的应用范围很广，典型的Windows服务程序包含了硬件控制、应用程序监视、系统级应用、诊断、报告、Web和文件系统服务等功能。

和Windows服务程序相关的命名空间涉及到以下两个：**System.ServiceProcess **和**System.Diagnostics**。

4.回到设计窗口点右键选择-**添加安装程序** -生成serviceInstaller1和 serviceProcessInstaller1两个组件 
把serviceInstaller1的属性ServiceName改写为你的服务程序名，并把启动模 式设置为AUTOMATIC  
把serviceProcessInstaller1的属性account改写为 LocalSystem  

5.编译链接生成服务程序

通过从生成菜单中选择生成来生成项目。

 

6.安装服务

用.net framework工具INSTALLUTIL安装服务程序即可。

用项目的输出作为参数，从命令行运行 InstallUtil.exe。在命令行中输入下列代码： 
**installutil yourproject.exe**

*Hint: a windows service must first be installed using installutil.exe and then started with the serviceExplorer, windows Services Administrative tool or the NET START command.*

 

7.卸载服务

用项目的输出作为参数，从命令行运行 InstallUtil.exe。

**installutil /u yourproject.exe**

5、运行 installutil.exe 

6、安装服务命令： installutil  yourservices.exe

7、卸载服务命令： installutil  /u  yourservices.exe

**注意的是**:安装跟卸载需要保证程序是一样的，没有变更过的，要不会提示卸载不干净。也就是在已安装过服务的时候，不要在vs中修改你的程序。

**报错：**

在初始化安装时发生异常:
System.BadImageFormatException: 未能加载文件或程序集“file:///C:\maintain\VICTTEC_Maintain.exe”或它的某一个依赖项。生成此程序集的运行时比当前加载的运行时新，无法加载此程

问题在哪里呢？根据报错信息来看完全没有头绪，经过一段时间的思考，想到会不会是InstallUtil.exe这个程序的版本问题呢？于是换个思路，离开v2.0.50727这个文件夹，进入

v4.0.30319这个版本的目录，再次运行命令，OK，成功。

环形队列是在实际编程极为有用的数据结构,它有如下特点。

   它是一个首尾相连的FIFO的数据结构，采用数组的线性空间,数据组织简单。能很快知道队列是否满为空。能以很快速度的来存取数据。

   因为有简单高效的原因，甚至在硬件都实现了环形队列.

 

   环形队列广泛用于网络数据收发，和不同程序间数据交换（比如内核与应用程序大量交换数据,从硬件接收大量数据）均使用了环形队列.

 

一.环形队列实现原理

\------------------------------------------------------------

 

  内存上没有环形的结构，因此环形队列实上是数组的线性空间来实现。那当数据到了尾部如何处理呢？它将转回到0位置来处理。这个的转回是通过取模操作来执行的。

   因此环列队列的是逻辑上将数组元素q[0]与q[MAXN-1]连接，形成一个存放队列的环形空间。

   为了方便读写，还要用数组下标来指明队列的读写位置。head/tail.其中head指向可以读的位置，tail指向可以写的位置。

![环形队列理论](http://hi.csdn.net/attachment/201107/9/0_1310174978ngyt.gif)

 

 

 环形队列的关键是判断队列为空，还是为满。当tail追上head时，队列为满时，当head追上tail时，队列为空。但如何知道谁追上谁。还需要一些辅助的手段来判断.

 

   如何判断环形队列为空，为满有两种判断方法。

  **一.是附加一个标志位tag**

​      当head赶上tail，队列空，则令tag=0,
​      当tail赶上head，队列满，则令tag=1,

 

  **二.限制tail赶上head，即队尾结点与队首结点之间至少留有一个元素的空间。**

**      **队列空：   head==tail
​      队列满：   (tail+1)% MAXN ==head

 

 

 

二.附加标志实现算法

\-------------------------------------------------------------

 

  采用第一个环形队列有如下结构

**[cpp]** [view plain](http://blog.csdn.net/sking002007/article/details/6584590#)[copy](http://blog.csdn.net/sking002007/article/details/6584590#)[print](http://blog.csdn.net/sking002007/article/details/6584590#)[?](http://blog.csdn.net/sking002007/article/details/6584590#)

1. typedef struct ringq{  
2. int head;   
3. int tail;    
4. int tag ;  
5. int size ;   
6. int space[RINGQ_MAX];   
7. ​    
8. }RINGQ;  

初始化状态: **q->head = q->tail = q->tag = 0;**

队列为空:(**q->head == q->tail) && (q->tag == 0)**

队列为满**: ((q->head == q->tail) && (q->tag == 1))**

入队操作:如队列不满，则写入

**     q->tail =  (q->tail + 1) % q->size ;**
出队操作：如果队列不空，则从head处读出。

​    下一个可读的位置在 **q->head =  (q->head + 1) % q->size**



1.   //队列索引尚未回绕  
2.   ​                if (_front == 0)  
3.   ​                {  
4.   ​                    //将旧队列数组数据转移到新队列数组中  
5.   ​                    Array.Copy(_queue, newQueue, _capacity);  
6.   ​                }  
7.   ​                else  
8.   ​                {  
9.   ​                    //如果队列回绕，刚需拷贝再次，  
10.   ​                    //第一次将队首至旧队列数组最大长度的数据拷贝到新队列数组中  
11.   ​                    Array.Copy(_queue, _front, newQueue, _front, _capacity - _rear - 1);  
12.   ​                    //第二次将旧队列数组起始位置至队尾的数据拷贝到新队列数组中  
13.   ​                    Array.Copy(_queue, 0, newQueue, _capacity, _rear + 1);  
14.   ​                    //将队尾索引改为新队列数组的索引  

# 循环队列 [**免费编辑](https://baike.so.com/create/edit/?eid=8776703&sid=9100674) [**添加义项名](javascript:;)

B 添加义项

 

?

所属类别 :

其他

为充分利用向量空间，克服"[假溢出](https://baike.so.com/doc/2191867-2319198.html)"现象的方法是:将向量空间想象为一个首尾相接的圆环，并称这种向量为循环向量。存储在其中的队列称为循环队列(Circular Queue)。这种循环队列可以以单链表的方式来在实际编程应用中来实现。

## 基本信息

- 中文名称

  循环队列

- 外文名称

  Circular Queue



- 类    别

  数据结构

- 实现方式

  单链表

| **目录 | *1*[基本操作](https://baike.so.com/doc/8776703-9100674.html#8776703-9100674-1) | *2*[条件处理](https://baike.so.com/doc/8776703-9100674.html#8776703-9100674-2) |
| ---- | ---------------------------------------- | ---------------------------------------- |
|      |                                          |                                          |

为充分利用向量空间，克服"[假溢出](https://baike.so.com/doc/2191867-2319198.html)"现象的方法是:将向量空间想象为一个首尾相接的圆环，并称这种向量为循环向量。存储在其中的队列称为循环队列(Circular Queue)。这种循环队列可以以单链表的方式来在实际编程应用中来实现。

## [折叠](https://baike.so.com/doc/8776703-9100674.html#)[**编辑本段](https://baike.so.com/create/edit/?eid=8776703&sid=9100674&secid=1)**基本操作**

插入新元素，使用PASCAL语言:

过程DEL2(Q,Y,F)从循环队列q中取出队首元素

## [折叠](https://baike.so.com/doc/8776703-9100674.html#)[**编辑本段](https://baike.so.com/create/edit/?eid=8776703&sid=9100674&secid=2)**条件处理**

循环队列中，由于入队时尾指针向前追赶头指针;出队时头指针向前追赶尾指针，造成队空和队满时头尾指针均相等。因此，无法通过条件front==rear来判别队列是"空"还是"满"。

解决这个问题的方法至少有两种:

① 另设一[布尔变量](https://baike.so.com/doc/9012309-9341727.html)以区别队列的空和满;

②另一种方式就是数据结构常用的: 队满时:(rear+1)%n==front，n为队列长度(所用[数组](https://baike.so.com/doc/5545345-5760453.html)大小)，由于rear，front均为所用空间的指针，循环只是逻辑上的循环，所以需要求余运算。如图情况，队已满，但是rear(5)+1=6!=front(0)，对空间长度求余，作用就在此6%6=0=front(0)。

[![img](https://p1.ssl.qhmsg.com/dr/220__/t01d5420d8f3c345f19.jpg)](https://p1.ssl.qhmsg.com/t01d5420d8f3c345f19.jpg)

类型定义采用环状模型来实现队列,各数据成员的意义如下:

front指定队首位置，删除一个元素就将front顺时针移动一位;

rear指向元素要插入的位置，插入一个元素就将rear顺时针移动一位;

count存放队列中元素的个数，当count等于MaxQSize时，不可再向队列中插入元素。

队空:count=0

队满:count=MaxQSize

\#define QueueSize 100//应根据具体情况定义该值

typedef char DataType;//DataType的类型依赖于具体的应用

typedef struct{

int front;//头指针，队非空时指向队头元素

int rear;//尾指针，队非空时指向队尾元素的下一位置

int count;//计数器，记录队中元素总数DataTypedata[QueueSize];

}CirQueue;

基本运算

用第三种方法，循环队列的六种基本运算:

① 置队空

voidInitQueue(CirQueue*Q){ Q->front=Q->rear=0;Q->count=0; }//计数器置0

② 判队空

intQueueEmpty(CirQueue*Q){ returnQ->count==0; }//队列无元素为空

③ 判队满

intQueueFull(CirQueue*Q){ returnQ->count==QueueSize;}//队中元素个数等于QueueSize时队满

④ 入队

voidEnQueue(CirQueue*Q,DataTypex){

if(QueueFull(Q))Error("Queueoverflow"); //队满上溢

Q->count++; //队列元素个数加1

Q->data[Q->rear]=x; //新元素插入队尾

Q->rear=(Q->rear+1)%QueueSize; //循环意义下将尾指针加1

}

⑤ 出队

DataTypeDeQueue(CirQueue*Q){

DataType temp;

if(QueueEmpty(Q))Error("Queueunderflow"); //队空下溢

temp=Q->data[Q->front];

Q->count--; //队列元素个数减1

Q->front=(Q->front+1)%QueueSize; //循环意义下的头指针加1returntemp;}

⑥取队头元素

DataTypeQueueFront(CirQueue*Q){

if(QueueEmpty(Q))Error("Queueisempty.");

returnQ->data[Q->front];

}

\````````````````````````````````````````````````````````````````````````````````````

队列的操作特点是"先进先出"。前者主要是头指针、尾指针的使用，后者主要是理解循环队列提出的原因及其特点。两者都要掌握队列空与满的判定条件以及出队列、入队列操作的实现。



**什么是队列？**

队列(Queue)也是一种运算受限的线性表。它只允许在表的一端进行插入，而在另一端进行删除。允许删除的一端称为队头(front)，允许插入的一端称为队尾(rear)。

**FIFO原则**

队列具有先进先出原则，与栈的先进后出形成对比。

**为什么设计循环队列？**

队列的顺序存储结构称为顺序队列，顺序队列实际上是运算受限的顺序表，和顺序表一样，顺序队列也是必须用一个向量空间来存放当前队列中的元素。

**入队，出队操作原理**

由于队列的队头和队尾的位置是变化的，因而要设两个指针和分别指示队头和队尾元素在队列中的位置，它们的初始值地队列初始化时均应置为０。入队时将新元素插入所指的位置，然后将加１。出队时，删去所指的元素，然后将加１并返回被删元素。

**杜绝“假上溢”**

和栈类似，队列中亦有上溢和下溢现象。此外，顺序队列中还存在“假上溢”现象。因为在入队和出队的操作中，头尾指针只增加不减小，致使被删除元素的空间永远无法重新利用。因此，尽管队列中实际的元素个数远远小于向量空间的规模，但也可能由于尾指针巳超出向量空间的上界而不能做入队操作。

为充分利用向量空间。克服上述假上溢现象的方法是将向量空间想象为一个首尾相接的圆环，并称这种向量为循环向量，存储在其中的队列称为循环队列（Circular Queue)。在循环队列中进行出队、入队操作时，头尾指针仍要加1，朝前移动。只不过当头尾指针指向向量上界（QueueSize-1）时，其加1操作的结果是指向向量的下界0。

实现代码：

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. if(I+1 == QueueSize)  
2. {  
3. ​    I = 0;  
4. }  
5. else  
6. {  
7. ​    i++;  
8. }  

利用模运算可简化为：

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. i = (i + 1)%QueueSize；  

**何时队列为空？何时为满？**

由于入队时尾指针向前追赶头指针，出队时头指针向前追赶尾指针，故队空和队满时头尾指针均相等。因此，我们无法通过front=rear来判断队列“空”还是“满”。

注：先进入的为‘头’，后进入的为‘尾’。

解决此问题的方法至少有三种：

其一是另设一个布尔变量以匹别队列的空和满；

其二是少用一个元素的空间，约定入队前，测试尾指针在循环意义下加1后是否等于头指针，若相等则认为队满（注意：rear所指的单元始终为空）；

其三是使用一个计数器记录队列中元素的总数（实际上是队列长度）。

队列的基本操作：

数据元素定义

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. \#include <stdio.h>  
2. \#include <assert.h>  
3. \#define QueueSize 100  
4. typedef char datatype;  
5. //队列的数据元素  
6. typedef struct  
7. {  
8. ​     int front;  
9. ​     int rear;  
10. ​     int count;  //计数器，用来记录元素个数  
11. ​     datatype data[QueueSize]; //数据内容  
12. }cirqueue;  

队列置空

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. //置空队  
2. void InitQueue(cirqueue *q)  
3. {  
4. ​     q->front = q->rear = 0;  
5. ​     q->count = 0;  
6. }  

判断队满

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. //判断队满  
2. int QueueFull(cirqueue *q)  
3. {  
4. ​     return (q->count == QueueSize);  
5. }  

判断队空

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. //判断队空  
2. int QueueEmpty(cirqueue *q)  
3. {  
4. ​     return (q->count == 0);  
5. }  

入队

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. //入队  
2. void EnQueue(cirqueue *q, datatype x)  
3. {  
4. ​     assert(QueueFull(q) == 0); //q满，终止程序  
5. ​
6. ​     q->count++;  
7. ​     q->data[q->rear] = x;  
8. ​     q->rear = (q->rear + 1)%QueueSize; //循环队列设计，防止内存浪费  
9. }  

出队

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. //出队  
2. datatype DeQueue(cirqueue *q)  
3. {  
4. ​     datatype temp;  
5. ​
6. ​     assert(QueueEmpty(q) == 0);//q空，则终止程序，打印错误信息  
7. ​
8. ​     temp = q->data[q->front];  
9. ​     q->count--;  
10. ​     q->front = (q->front + 1)%QueueSize;  
11. ​     return temp;  
12. }  

取头指针

**[cpp]** [view plain](http://blog.csdn.net/to_dreams/article/details/7708051#) [copy](http://blog.csdn.net/to_dreams/article/details/7708051#)

1. //取头指针  
2. datatype QueueFront(cirqueue *q)  
3. {  
4. ​     assert(QueueEmpty(q) == 0);  
5. ​     return (q->data[q->front]);  
6. }  



*用数组实现循环队列
(1)、设一标志位以区别队列是“空”还是“满”
(2)、少用一空间，约定“队列头指针在队尾指针的下一位置”上作为队列呈“满”状态的标志

随笔- 22  文章- 0  评论- 21 

# [数据结构--循环队列](http://www.cnblogs.com/yjsoft/archive/2008/10/06/1304759.html)

实现队列的方法很多，比如动态数组、链表，今天主要介绍循环队列

首先说用静态数组实现简单队列。

![img](http://images.cnblogs.com/cnblogs_com/yjsoft/simplequeue.JPG)

很显然，当队列满后，即便全部元素都出队，队列还是满的状态。这种情况就叫做“假溢出”，即数组中明明有可用空间，但却无法使用。

这是由定长数组的特性决定的。但我们可用改变一下思路，当队尾指针指向数组最后一个位置时，如果再有数据入队，并且队头指针没有指向数组的第一个元素，那么就让队为指针绕回到数组头部。这样就形成了一个逻辑上的环。

![img](http://images.cnblogs.com/cnblogs_com/yjsoft/Cycqueue.JPG)

这样，只要队列中实际的元素数量小于数组长度减一，就可以继续入队了。

其实这是一个非常简单的数据结构，难点就是判断队空、对满，以及计算队列长度。

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 1

const

 

int

 MAX_QUEUE_SIZE 

=

 

5

;

 2

![img](http://www.cnblogs.com/Images/OutliningIndicators/None.gif)template

<

typename T

\>

 3

![img](http://www.cnblogs.com/Images/OutliningIndicators/None.gif)

class

 cyc_queue

 4

![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockStart.gif)

{
 5![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)public:
 6![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    cyc_queue()
 7![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        :m_nHead(0),
 8![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        m_nTail(0)
 9![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)    {}
10![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
11![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
12![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    //如对操作， 将数据追加到队列头部，并改变队首指针，如队成功，则返回true
13![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    bool in_queue(const T & data)
14![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)    {
15![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        if(full())
16![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        //队列满
17![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)        {
18![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)            return false;
19![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)        }
20![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
21![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        m_array[m_nTail] = data;
22![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        m_nTail = (m_nTail + 1) % MAX_QUEUE_SIZE;
23![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)    }
24![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
25![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    //出队操作，将队首数据复制并返回，改变队首指针
26![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    T out_queue()
27![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)    {
28![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        if(empty())
29![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)        {
30![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)            throw("队列已空");
31![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)        }
32![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        
33![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        T temp = m_array[m_nHead];
34![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        m_nHead = (m_nHead + 1) % MAX_QUEUE_SIZE;
35![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        return temp;
36![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)    }
37![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
38![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    bool empty()
39![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)    {
40![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
41![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        return m_nTail == m_nHead;
42![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)    }
43![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
44![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    bool full()
45![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)    {
46![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        return (m_nTail + 1) % MAX_QUEUE_SIZE == m_nHead;
47![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)    }
48![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)
49![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    size_t size()
50![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockStart.gif)    {
51![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)        return (m_nTail - m_nHead + MAX_QUEUE_SIZE) % MAX_QUEUE_SIZE;
52![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedSubBlockEnd.gif)    }
53![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)private:
54![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    T m_array[MAX_QUEUE_SIZE];
55![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    int m_nHead;
56![img](http://www.cnblogs.com/Images/OutliningIndicators/InBlock.gif)    int m_nTail;
57![img](http://www.cnblogs.com/Images/OutliningIndicators/ExpandedBlockEnd.gif)}

;

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)



队列的抽象数据类型定义为：

类型名称：队列。

数据对象集：一个有0个或多个元素的有穷线性表。

操作集：对于一个长度为正整数MaxSize的队列Q∈Queue， 记队列中的任一元素item∈ElementType，有：

　　　　（1）Queue CreateQueue(int MaxSize)：创建一个长度为MaxSize的空队列；

　　　　（2）bool isEmpty(Queue Q)：判断队列是否为空，若不空返回true（1），否则返回false（0）；

　　　　（3）void AddQ(Queue Q, ElementType item)：若队列满，返回已满的信息；否则，把这个元素入队；

　　　　（4）bool isFull(Queue Q)：判断队列是否满，若满返回true（1），否则返回false（0）；

　　　　（5）ElementType DeleteQ(Queue Q)：若队列为空，返回队列为空的信息；否则，把队头元素先用临时变量存储起来并从队列中删去，最后返回队头元素。

 

为了解决队尾溢出（假溢出）而实际上数组仍然有多余空间的问题，我们运用循环队列解决问题。

此时需要定义一个front和rear分别指向队列的头元素的前一个位置和尾元素，并且开始时都初始化成0；

当插入和删除操作的作用单元达到数组的末端后，用公式“rear(或front)%数组长度”取余运算就可以实现折返到起始单元。

队满的条件是：“(rear+1)%数组长度”等于front；队空的条件为：rear等于front。

 

循环队列的顺序存储结构的定义可以如下：

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
// 实现循环队列 
#define MaxSize 21
typedef int ElementType;

typedef struct  {
    ElementType data[MaxSize];    
    int rear;      // 队尾指针 
    int front;     // 队头指针 
}Queue;
```

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 

循环队列的插入操作如下：

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
// 元素入队
void AddQ(Queue *PtrQ, ElementType item)
{
    if( (PtrQ->rear+1)%MaxSize == PtrQ->front )
    {
        printf("队列满.\n");
        return;
    }
    PtrQ->rear = (PtrQ->rear+1) % MaxSize;
    PtrQ->data[PtrQ->rear] = item; 
}
```

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 

循环队列的删除操作如下：

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
// 删除队头元素并把队头元素返回
ElementType DeleteQ( Queue *PtrQ )
{    
    if( PtrQ->front == PtrQ->rear )
    {
        printf("队列空.\n");
        return -1;
    } 
    else {
        PtrQ->front = (PtrQ->front+1) % MaxSize;
        return PtrQ->data[PtrQ->front];
    }
} 
```

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

 

循环队列的遍历，这个是我自己摸索了几遍才出来的，所以想记录一下，具体操作如下：

[![复制代码](http://common.cnblogs.com/images/copycode.gif)](javascript:void(0);)

```
// 队列元素的遍历
void print(Queue *PtrQ)
{
    int i = PtrQ->front;
    if( PtrQ->front == PtrQ->rear )
    {
        printf("队列空.");
        return;
    }
    printf("队列存在的元素如下:");
    while( i != PtrQ->rear)
    {
        printf("%d ", PtrQ->data[i+1]);
        i++;
        i = i % MaxSize;
    }
    return;
}
```



typedef和#define的用法与区别

一、typedef的用法

在C/C++[语言](http://action.vogate.com/click/click.php?r=http%3A//www.google.cn/search%3Fcomplete%3D1%26hl%3Dzh-CN%26inlang%3Dzh-CN%26newwindow%3D1%26q%3Dtypedef%26btnG%3DGoogle+%25E6%2590%259C%25E7%25B4%25A2%26meta%3D%26aq%3Dnull&ads_id=4151&site_id=6235007045036118&click=1&url=http%3A//www.programfan.com&v=0&k=%u8BED%u8A00&s=http%3A//www.sf.org.cn/Article/base/200608/18988.html&rn=35383)中，typedef常用来定义一个标识符及关键字的别名，它是语言编译过程的一部分，但它并不实际分配内存空间，实例像：

typedef    int       INT;
typedef    int       ARRAY[10];
typedef   (int*)   pINT;

typedef可以[增强](http://action.vogate.com/click/click.php?r=http%3A//www.google.cn/search%3Fcomplete%3D1%26hl%3Dzh-CN%26inlang%3Dzh-CN%26newwindow%3D1%26q%3Dtypedef%26btnG%3DGoogle+%25E6%2590%259C%25E7%25B4%25A2%26meta%3D%26aq%3Dnull&ads_id=3818&site_id=6235007045036118&click=1&url=http%3A//www.5ya.cn%20&v=0&k=%u589E%u5F3A&s=http%3A//www.sf.org.cn/Article/base/200608/18988.html&rn=302774)程序的可读性，以及标识符的灵活性，但它也有“非直观性”等缺点。

二、#define的用法

\#define为一宏定义语句，通常用它来定义常量(包括无参量与带参量)，以及用来实现那些“表面似和善、背后一长串”的宏，它本身并不在编

译过程中进行，而是在这之前(预处理过程)就已经完成了，但也因此难以[发现](http://action.vogate.com/click/click.php?r=http%3A//www.google.cn/search%3Fcomplete%3D1%26hl%3Dzh-CN%26inlang%3Dzh-CN%26newwindow%3D1%26q%3Dtypedef%26btnG%3DGoogle+%25E6%2590%259C%25E7%25B4%25A2%26meta%3D%26aq%3Dnull&ads_id=3593&site_id=6235007045036118&click=1&url=http%3A//yahoo.37you.com&v=0&k=%u53D1%u73B0&s=http%3A//www.sf.org.cn/Article/base/200608/18988.html&rn=842957)潜在的错误及其它代码维护问题，它的实例像：

\#define   INT             int
\#define   TRUE         1
\#define   Add(a,b)     ((a)+(b));
\#define   Loop_10    for (int i=0; i<10; i++)

在Scott Meyer的Effective C++一书的条款1中有关于#define语句弊端的分析，以及好的替代方法，大家可参看。

三、typedef与#define的区别

从以上的概念便也能基本清楚，typedef只是为了增加可读性而为标识符另起的新名称(仅仅只是个别名)，而#define原本在C中是为了定义常量

，到了C++，const、enum、inline的出现使它也渐渐成为了起别名的工具。有时很容易搞不清楚与typedef两者到底该用哪个好，如#define

INT int这样的语句，用typedef一样可以完成，用哪个好呢？我主张用typedef，因为在早期的许多C编译器中这条语句是非法的，只是现今的

编译器又做了扩充。为了尽可能地兼容，一般都遵循#define定义“可读”的常量以及一些宏语句的任务，而typedef则常用来定义关键字、冗

长的类型的别名。

宏定义只是简单的字符串代换(原地扩展)，而typedef则不是原地扩展，它的新名字具有一定的封装性，以致于新命名的标识符具有更易定义变

量的功能。请看上面第一大点代码的第三行：

typedef    (int*)      pINT;
以及下面这行:
\#define    pINT2    int*

[效果](http://action.vogate.com/click/click.php?r=http%3A//www.google.cn/search%3Fcomplete%3D1%26hl%3Dzh-CN%26inlang%3Dzh-CN%26newwindow%3D1%26q%3Dtypedef%26btnG%3DGoogle+%25E6%2590%259C%25E7%25B4%25A2%26meta%3D%26aq%3Dnull&ads_id=3480&site_id=6235007045036118&click=1&url=http%3A//www.samsungplay.com.cn/index.jsp&v=0&k=%u6548%u679C&s=http%3A//www.sf.org.cn/Article/base/200608/18988.html&rn=307562)相同？实则不同！实践中见差别：pINT a,b;的效果同int *a; int *b;表示定义了两个整型指针变量。而pINT2 a,b;的效果同int *a, b;

表示定义了一个整型指针变量a和整型变量b。

 

 

 

typedef的四个用途和两个陷阱

用途一： 
定义一种类型的别名，而不只是简单的宏替换。可以用作同时声明指针型的多个对象。比如： 
char*   pa,   pb;     //   这多数不符合我们的意图，它只声明了一个指向字符变量的指针，   
//   和一个字符变量； 
以下则可行： 
typedef   char*   PCHAR;     //   一般用大写 
PCHAR   pa,   pb;                 //   可行，同时声明了两个指向字符变量的指针 
虽然： 
char   *pa,   *pb; 
也可行，但相对来说没有用typedef的形式直观，尤其在需要大量指针的地方，typedef的方式更省事。 
用途二： 
用在旧的C代码中（具体多旧没有查），帮助struct。以前的代码中，声明struct新对象时，必须要带上struct，即形式为：   struct   结构名   对象名，如： 
struct   tagPOINT1 
{ 
​        int   x; 
​        int   y; 
}; 
struct   tagPOINT1   p1;   
而在C++中，则可以直接写：结构名   对象名，即： 
tagPOINT1   p1; 
估计某人觉得经常多写一个struct太麻烦了，于是就发明了： 
typedef   struct   tagPOINT 
{ 
​        int   x; 
​        int   y; 
}POINT; 
POINT   p1;   //   这样就比原来的方式少写了一个struct，比较省事，尤其在大量使用的时候 
或许，在C++中，typedef的这种用途二不是很大，但是理解了它，对掌握以前的旧代码还是有帮助的，毕竟我们在项目中有可能会遇到较早些年代遗留下来的代码。 
用途三： 
用typedef来定义与平台无关的类型。 
比如定义一个叫   REAL   的浮点类型，在目标平台一上，让它表示最高精度的类型为： 
typedef   long   double   REAL;   
在不支持   long   double   的平台二上，改为： 
typedef   double   REAL;   
在连   double   都不支持的平台三上，改为： 
typedef   float   REAL;   
也就是说，当跨平台时，只要改下   typedef   本身就行，不用对其他源码做任何修改。 
标准库就广泛使用了这个技巧，比如size_t。 
另外，因为typedef是定义了一种类型的新别名，不是简单的字符串替换，所以它比宏来得稳健（虽然用宏有时也可以完成以上的用途）。 
用途四： 
为复杂的声明定义一个新的简单的别名。方法是：在原来的声明里逐步用别名替换一部分复杂声明，如此循环，把带变量名的部分留到最后替换，得到的就是原声明的最简化版。举例： 
\1.   原声明：int   *(*a[5])(int,   char*); 
变量名为a，直接用一个新别名pFun替换a就可以了： 
typedef   int   *(*pFun)(int,   char*);   
原声明的最简化版： 
pFun   a[5];   
\2.   原声明：void   (*b[10])   (void   (*)()); 
变量名为b，先替换右边部分括号里的，pFunParam为别名一： 
typedef   void   (*pFunParam)(); 
再替换左边的变量b，pFunx为别名二： 
typedef   void   (*pFunx)(pFunParam); 
原声明的最简化版： 
pFunx   b[10]; 
\3.   原声明：doube(*)()   (*e)[9];   
变量名为e，先替换左边部分，pFuny为别名一： 
typedef   double(*pFuny)(); 
再替换右边的变量e，pFunParamy为别名二 
typedef   pFuny   (*pFunParamy)[9]; 
原声明的最简化版： 
pFunParamy   e;   
理解复杂声明可用的“右左法则”：从变量名看起，先往右，再往左，碰到一个圆括号就调转阅读的方向；括号内分析完就跳出括号，还是按先右后左的顺序，如此循环，直到整个声明分析完。举例： 
int   (*func)(int   *p); 
首先找到变量名func，外面有一对圆括号，而且左边是一个*号，这说明func是一个指针；然后跳出这个圆括号，先看右边，又遇到圆括号，这说明(*func)是一个函数，所以func是一个指向这类函数的指针，即函数指针，这类函数具有int*类型的形参，返回值类型是int。 
int   (*func[5])(int   *); 
func右边是一个[]运算符，说明func是具有5个元素的数组；func的左边有一个*，说明func的元素是指针（注意这里的*不是修饰func，而是修饰func[5]的，原因是[]运算符优先级比*高，func先跟[]结合）。跳出这个括号，看右边，又遇到圆括号，说明func数组的元素是函数类型的指针，它指向的函数具有int*类型的形参，返回值类型为int。 
也可以记住2个模式： 
type   (*)(....)函数指针   
type   (*)[]数组指针   
－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－ 
陷阱一： 
记住，typedef是定义了一种类型的新别名，不同于宏，它不是简单的字符串替换。比如： 
先定义： 
typedef   char*   PSTR; 
然后： 
int   mystrcmp(const   PSTR,   const   PSTR); 
const   PSTR实际上相当于const   char*吗？不是的，它实际上相当于char*   const。 
原因在于const给予了整个指针本身以常量性，也就是形成了常量指针char*   const。 
简单来说，记住当const和typedef一起出现时，typedef不会是简单的字符串替换就行。 
陷阱二： 
typedef在语法上是一个存储类的关键字（如auto、extern、mutable、static、register等一样），虽然它并不真正影响对象的存储特性，如： 
typedef   static   int   INT2;   //不可行 
编译将失败，会提示“指定了一个以上的存储类”。