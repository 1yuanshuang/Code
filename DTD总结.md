#### 什么是DTD

DTD全称Docement Type Defineition（文档类型定义）。DTD可以看做是一个或多个XML文件的模板，XML文件中的元素、属性、元素的排列顺序等必须符合DTD的定义。

#### DTD的作用

DTD是一种XML的约束方式。DTD的目的就是约束XML标签的写法； 首先DTD里面会规定比如你的xml文件里面的根元素叫什么，根元素里面必须要有什么或必须要有哪几个元素，这个元素是可以出现一次还是可以出现多次，这个元素里面必须要有什么属性，哪个属性必须出现等等。这样的话就有了一套规则，我们定义的xml文档就必须要符合这种规则，我们把符合这种规则的xml文档叫做有效的xml文档，有效是建立在格式正规(符合xml语法要求，语法上没有错误)的基础之上的。如果在开发中开发人员不遵循DTD的规范，则会出现错误提示；

XML约束的重要性：在编写XML时，对于XML进行约束是非常重要的，因为如果对于XML不约束，则会让开发人员很难掌握；

#### XML和HTML的区别

HTML的问题所在，首先看下面的HTML代码

```html
<html>
<head>
	<title>信息显示</title>
	<meta charset="UTF-8">
</head>
<body>
	<h1>张三</h1>
	<h1>男</h1>
	<h1>汉族</h1>
	<h1>陕西</h1>
</body>
</html>
```

在打开的网页中显示了四行内容，分别是张三、男、汉族、陕西。HTML页面里面的所有标签的内容其最终的目标是为了显示数据，如果只是依靠个人是可以区分出这些信息的。但是其他人可能会认为籍贯是汉族，民族是陕西，这个时候就有可能造成一些误解。HTML虽然能显示数据，但是不能够方便的描述出一个准确的数据的描述结构。

在HTML中提供了三十多个标签元素，并且每一个标签都负责信息的显示处理操作，所以HTML中的元素是固定的，HTML标记文件的最大问题在于其所有的标签是固定的。为了可以方便的进行动态的标签扩充，出现了XML（可扩展标记语言），也就是说标签不是固定的，可以自己定义发明标签。

XML实例

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<member>
  	<name>张三</name>
  	<sex>男</sex>
  	<nation>汉族</nation>
  	<jiguan>陕西</jiguan>
</member>
```

这些元素都属于XML自己定义的，可以发现每个元素能够准确描述出对应数据的含义，此时的数据结构非常清晰，这样可以方便实现数据交换

两者的区别：

HTML适合于数据的显示处理，XML适合于数据的结构描述，可以用于通讯上

在HTML中有时不严格，如果上下文清楚的显示出段落或列表键在何处结尾，那么你可以省略</p>或者</li>之类的结束标记。在XML中，是严格的树状结构，绝对不能省略掉结束标记。

XML 不是 HTML 的替代，对于HTML以及XML而言都属于SGML语法的扩充，在实际的开发过程中，两者是一种互补的关系，XML可以方便的描述出数据结构，就可以用XML作为数据传输，而最终在进行数据显示的时候，可以使用HTML完成处理，如果HTML需要显示出XML数据的内容，就需要JavaScript的支持处理，这也就是DHTML技术。

#### CDATA和#PCDATA的区别

\#PCDATA是要给XML解析的数据，如 > 要写成 &gt；才不会出错。 

CDATA区域表示里面是什么数据XML不会解析。

例如在DTD中声明： 

​    <!ELEMENT name (#PCDATA)> 它表示在<name>和</name>标签之间可以插入字符或者子标签。

在DTD中，指定标签中某个属性的类型为字符型时，使用CDATA。因为XML解析器会去分析这段字符内容，因而里面如果需要使用>, <, &, ', "这5个特殊字符，应当用对应的替代字符来表示(必须以&开始，以;结束)。具体如下： 

<    &lt；(less than) 

\>    &gt； (greater than) 

&    &amp； (ampersand) 

'      &apos； (apostrophe) 

"     &quot；  (straight double quotation mark) 

在XML中，指定某段内容不必被XML解析器解析时，使用<![CDATA[...]]>。也就是说中括号中的内容解析器不会去分析。所以其中**可以**包含>, <, &, ', "这5个特殊字符。经常把一段程序代码嵌入到<![DATA[...]]>中。 因为代码中可能包含大量的 >, <, &, "这样的特殊字符。 

例如在XML中声明：

```xml-dtd
<![CDATA[ 
    if(a>b)
    { 
        System.out.println(a);
    } 
]]> 
```

注意上面的一个＂＞＂符号．PCDATA的数据是要给XML解析器去解析的，那上面的＞去解析肯定会出错了，所以要用实体定义．上面的数据如果用PCDATA表示如下：

```xml-dtd
if(a&gt;b)
{
　　System.out.println(a);
} 
```

注意：声明元素的内容必须为字符串时  ——#PCDATA

声明属性值必须为字符串时——CDATA

#### 在XML文档中引入DTD

DTD分为内部DTD与外部DTD两类；

内部DTD：将DTD定义在XML文档的内部

```xml-dtd
<!DOCTYPE  根元素名  [元素描述]>
```

外部DTD(引用DTD的单独文件**.dtd**   类似于**INCLUDE**)

```xml-dtd
<!DOCTYPE 根元素名  SYSTEM  “DTD文件名">
```

外部DTD的优势：

定义一份DTD文档，就可以方便地被多个XML文档共享

当语义约束需要改变时，无需为每份XML文档改变DTD定义，只需改变它们共享的外部DTD即可

#### 元素类型声明

语法：〈ELEMENT 元素名称 元素内容说明〉

元素内容形式如下：

(1)子元素（说明元素包含的是子元素，当一个元素只包含子元素，而没有字符数据时，则称此元素类型具有元素型内容

①可以用竖线（|）或者（,）来分隔元素

````xml-dtd
〈?xml version="1.0" encoding="gb2312"?〉
〈!DOCTYPE hr[
〈!ELEMENT hr(employee)〉
〈!ELEMENT employee(name,age,sex,salary)〉
〈!ELEMENT name(#PCDATA)〉
〈!ELEMENT age(#PCDATA)〉
〈!ELEMENT sex(#PCDATA)〉
〈!ELEMENT salary(cash | credit_card)〉
....
````

这种元素内容模型称为选择，选cash或credit_card其中一个子元素

注意：在一个组中，只允许使用一种连接符（例如“，”或“|”），因此像下面这样定义的DTD是不合法的：

```xml-dtd
<!ELEMENT 联系人（姓名，电话|EMAIL）>
```

要想使用多种连接符，只有通过创建子组的方式，使用

```xml-dtd
<!ELEMENT  联系人（姓名，（电话|EMAIL））>
```

例如下面的例子：

```xml-dtd
<!DOCTYPE 书架 [
<!ELEMENT 书架 (书+)>
<!ELEMENT 书 (书名|(作者,价格)|出版日期)>
<!ELEMENT 书名 (#PCDATA)>
<!ELEMENT 作者 (#PCDATA)>
<!ELEMENT 价格 (#PCDATA)>
<!ELEMENT 出版日期 (#PCDATA)>
<!ATTLIST 作者 编号 CDATA #REQUIRED>
]>
```

对应的XML如下：把（作者，价格）看成一个整体，然后和书名、出版日期用|连接起来，只能选择三者中的一个，其他的会提示元素XXX的子元素XXX无效，或者元素的内容不完整

```xml
<书架>
  <书>
    <书名>C#高级编程</书名>
  </书>
  
  <书>
    <作者 编号="1">王五</作者>
    <价格>50</价格>
  </书>

  <书>
    <出版日期>12.23</出版日期>
  </书>
</书架>
```

再看一个例子：

```xml-dtd
<?xml version="1.0" encoding="utf-8" standalone="yes"?>
<!DOCTYPE 书架 [
<!ELEMENT 书架 (书+)>
<!ELEMENT 书 (书名,(作者|价格),出版日期)>   //改变了这里
<!ELEMENT 书名 (#PCDATA)>
<!ELEMENT 作者 (#PCDATA)>
<!ELEMENT 价格 (#PCDATA)>
<!ELEMENT 出版日期 (#PCDATA)>
<!ATTLIST 作者 编号 CDATA #REQUIRED>
]>
```

对应的XML如下:

```xml
<书架>
  <书>
    <书名>C#高级编程</书名>
    <作者 编号= "1">张三</作者>
    <出版日期>12.23</出版日期>
  </书>
  <书>
    <书名>WPF高级编程</书名>
    <价格>50</价格>
    <出版日期>10.23</出版日期>
  </书>
</书架>
```

如果改成

```xml-dtd
<!ELEMENT 书 (书名,(作者|价格|出版日期))>
```

则结果是（书名，作者）、（书名、价格）、（书名、出版日期）

再看一个例子:

```xml-dtd
<!DOCTYPE 书架 [
<!ELEMENT 书架 (书+)>
<!ELEMENT 书 ((书名,作者),(价格|出版日期))>  //继续改变这里
<!ELEMENT 书名 (#PCDATA)>
<!ELEMENT 作者 (#PCDATA)>
<!ELEMENT 价格 (#PCDATA)>
<!ELEMENT 出版日期 (#PCDATA)>
<!ATTLIST 作者 编号 CDATA #REQUIRED>
]>
```

下面是XML：

```xml
<书架>
  <书>
    <书名>C#编程</书名>
    <作者 编号= "1">张三</作者>
    <价格>50</价格>
  </书>
  
  <书>
    <书名>C编程</书名>
    <作者 编号= "2">张三</作者>
    <出版日期>10.23</出版日期>
  </书>
</书架>
```

②内容模型是决定子元素类型和子元素出现顺序的一种简单语法

通过例子看内容模型的语法：

```xml-dtd
〈?xml version="1.0" encoding="gb2312"?〉
〈DOCTYPE hr[
〈!ELEMENT hr (employee)〉
〈!ELEMENT employee(#PCDATA)〉
]〉
〈hr〉
   〈employee〉雇员信息〈/employee〉
〈/hr〉
```

③进一步说明元素employee 有三个子元素name、age、sex，并按顺序出现：

```xml-dtd
〈?xml version="1.0" encoding="gb2312"?〉
〈!DOCTYPE hr [
〈!ELEMENT employee(name,age,sex)〉
〈!ELEMENT name(#PCDATA)〉
〈!ELEMENT age(#PCDATA)〉
〈!ELEMENT sex(#PCDATA)〉
]〉
〈hr〉
    〈employee〉
         〈name〉张三〈/name〉
         〈age〉25〈/age〉
         〈sex〉男〈/sex〉
    〈/employee〉
〈/hr〉
```

④有时需体现员工的兴趣爱好，这时可以用星号（*）来实现，星号表示零或多个

```xml-dtd
〈?xml version="1.0" encoding="gb2312"?〉
〈!DOCTYPE hr [
〈!ELEMENT hr(employee)〉
〈!ELEMENT employee(name,age,sex,interest*)〉 //可有可无的interest子元素
〈!ELEMENT name(#PCDATA)〉
〈!ELEMENT age(#PCDATA)〉
〈!ELEMENT sex(#PCDATA)〉
〈!ELEMENT name(#PCDATA)〉
]〉
〈hr〉
 〈employee〉
        〈name〉张三〈/name〉
        〈age〉25〈/age〉
        〈sex〉男〈/sex〉
        〈interest〉篮球〈/interest〉
        〈interest〉游泳〈/interest〉
 〈/employee〉
〈/hr〉
```

⑤如果至少有一种爱好可以用加号(+)来说明一个或多个子元素

```xml-dtd
〈!ELEMENT employee(name,age,sex,interest+)〉
```

⑥用？号表示员工配偶信息

```xml-dtd
〈!ELEMENT employee ((name,age,sex),interest+,spouse?)〉
```

⑦综合实例：

```xml-dtd
〈!ELEMENT 简历(名字，性别，(电话|手机)，家庭住址?,兴趣爱好,教育经历+,工作经验*)〉
```

(2)#PCDATA （说明元素包含字符数据）

例：

```xml-dtd
〈?xml version="1.0" encoding="gb2312"?〉
〈!DOCTYPE hr [〈!ELEMENT hr(#PCDATA)〉]〉
〈hr〉人力资源标准〈/hr〉
```

指明这个XML文档有一个根元素hr，它的内容只能是字符数据，hr元素内容是“人力资源标准”

(3)混合内容

有时，在一个元素中既希望包含基本元素（纯文本），也希望包含子元素，XML中允许使用这种方法，并把这种元素称为混合内容的元素。

混合内容的元素定义语法：

```xml-dtd
<!ELEMENT 元素 （#PCDATA | 子元素 |......）>
```

说明：

无论何时使用#PCDATA关键字，它位于内容模型的第一项

在内容模型中不能使用逗号和基数操作符

各个子元素出现的次序和次数（甚至不出现）都是任意的

```xml-dtd
〈?xml version="1.0" encoding="gb2312"?〉
〈!DOCTYPE employee [
〈!ELEMENT employee (#PCDATA | name)*〉  //表示employee元素的内容可以包含0个或多个字符数据，包含0个或多个name子元素
〈!ELEMENT name(#PCDATA)〉
]〉
〈employee〉
    员工信息
    〈name〉张三〈/name〉
〈/employee〉
//注：用竖线分隔的#PCDATA和元素的列表是合法的，其它用法都是不合法的。
```

(4)EMPTY

````xml-dtd
声明的空元素:〈!ELEMENT br EMPTY〉  //表明br是一个没有内容的空元素.
````

(5)ANY

表明该元素可以包含任何的字符数据和子元素，只要它们不违反XML格式

```xml-dtd
〈!ELEMENT employee ANY〉 //我们要尽量不用ANY ，定义一个明确的DTD
```

#### 属性定义 

<!ATTLIST 所属的元素名  属性名称  属性类型  属性默认值>

属性设置说明：

1>#REQUIRED，表示必须设置该属性，中文意思必须的；

2>#IMPLIED，表示可设置也可不设，中文意思是暗示、意味、模糊的；

3>#FIXED，表示该属性值为一个固定值，在xml文档中不能为该属性设置其他值，可以不设置，但如果设置必须为该属性提供这个值。

4>直接使用默认值：在xml中可以设置该值，也可以不设置该值，若没有设置则使用默认值。

5>常用属性值类型：CDATA，表示属性值为普通文本字符串；ENUMERATED，枚举；ID，唯一值标识；ENTITY，实体。

6>ENUMERATED，枚举类型，表示一组取值的列表，在xml文件中设置的属性值可以是这个列表中的某个值。例如：<!ATTLIST 肉 品种 (鸡肉 | 牛肉 | 猪肉) "鱼肉">；一个肉元素，属性名是品种，其属性值类型是枚举，有三个值可选，设置说明是默认，为“鱼肉”。

7>属性值类型ID，表示属性值设置为一个唯一值，ID属性值只能由字母，下划线开始，不能出现空白字符。

举例：

```xml-dtd
<!DOCTYPE personlist [  
<!ELEMENT personlist (person+)>  
<!ELEMENT person (name,age,salary)>  
<!ELEMENT name ANY>  
<!ELEMENT age (#PCDATA)>  
<!ELEMENT salary (#PCDATA)>  
<!ATTLIST person  
aaa CDATA #REQUIRED        <!--必须设置该属性-->  
bbb CDATA #IMPLIED         <!-- 可选属性-->  
ccc CDATA #FIXED "xiazdong" <!--固定值，不需要设置 -->  
ddd CDATA "XZDONG"         <!--默认值为"XZDONG", 可以自己设置 -->  
eee ID #REQUIRED             <!--ID -->  
fff (1|2|3) "1"              <!--枚举值，默认为1 -->  
>  
]>  
```

#### XML实体定义

DTD中允许用户自定义实体，所谓实体定义类似于C语言的宏变量，即为一段字符串数据提供一个别名,实体被声明后,就可在其它地方被引用 

DTD中定义的实体，可以在XML文档中引用，也可以在DTD中引用

实体的作用：提高代码复用，方便维护

XML中使用一些特殊符号时，会使XML解析器混淆，因此需要为这些符号定义为实体，例如大于或小于符号等，系统已定义好这些实体

对于长度较长并且需要反复使用到的字符串，为了减少字符输入量，可以将其定义为实体

(1)定义内部实体：只能在XML中引用

<!ENTITY  实体名称   “实体值”>

XML中使用实体   &实体名;

(2)定义外部实体：不在DTD中定义，在外部文件中指定

<!ENTITY  实体名称  SYSTEM   “实体所在文件的URI/URL">

引用方式：  &实体名;

(3)定义参数实体：只能在DTD中引用

<!ENTITY  %  实体名称   “实体值”>

引用参数实体方式为：   %实体名; 

注意：引用实体必须在XML中引用；

举例：

```xml-dtd
<!DOCTYPE personlist [  
<!ENTITY constant "aaaa">  
<!ELEMENT personlist (person+)>  
<!ELEMENT person (name,age,salary)>  
<!ELEMENT name ANY>  
<!ELEMENT age (#PCDATA)>  
<!ELEMENT salary (#PCDATA)>  
]>  
<personlist>  
    <person >  
        <name>&constant;</name>        <!-- 引用constant实体-->  
        <age>aaa</age>  
        <salary>aaa</salary>  
    </person>  
</personlist>  
```

#### Schema 

XML Schema 文件自身就是一个XML文件，但它的扩展名通常为.xsd。一个XML Schema文档通常称之为模式文档(约束文档)，遵循这个文档书写的xml文件称之为实例文档。和XML文件一样，一个XML Schema文档也必须有一个根结点，但这个根结点的名称为Schema。编写了一个XML Schema约束文档后，通常需要把这个文件中声明的元素绑定到一个URI地址上，在XML Schema技术中有一个专业术语来描述这个过程，即把XML Schema文档声明的元素绑定到一个名称空间上，以后XML文件就可以通过这个URI（即名称空间）来告诉解析引擎，xml文档中编写的元素来自哪里，被谁约束。

Schema是对XML文档结构的定义和描述，其主要的作用是用来约束XML文件，并验证XML文件有效性。DTD的作用是定义XML的合法构建模块，它使用一系列的合法元素来定义文档结构。‘

#### Schema与 DTD的区别

它们之间的区别有下面几点：

 1、Schema本身也是XML文档，DTD定义跟XML没什么关系，Schema在理解和实际应用有很多的好处。 

 2、DTD文档的结构是“平铺型”的，如果定义复杂的XML文档，很难把握各元素之间的嵌套关系；Schema文档结构性强，各元素之间的嵌套关系非常直观。

  3、DTD只能指定元素含有文本，不能定义元素文本的具体类型，如字符型、整型、日期型、自定义类型等。Schema在这方面比DTD强大。

   4、Schema支持元素节点顺序的描述，DTD没有提供无序情况的描述，要定义无序必需穷举排列的所有情况。Schema可以利用xs:all来表示无序的情况。

   5、对命名空间的支持。DTD无法利用XML的命名空间，Schema很好满足命名空间。并且，Schema还提供了include和import两种引用命名空间的方法。

#### 元数据

1、什么是元数据？

​        元数据（Meta Date），关于数据的数据或者叫做用来描述数据的数据或者叫做信息的信息。这些定义都很抽象，我们可以把元数据简单的理解成最小的数据单位。元数据可以为数据说明其元素或属性（名称、大小、数据类型、等），或其结构（长度、字段、数据列），或其相关数据（位于何处、如何联系、拥有者）。

​       生活中我们填写的《个人信息登记表》，包括姓名、性别、民族、政治面貌、一寸照片、学历、职称等等这些就是锁定这个人的元数据。

2、元数据之于信息架构的意义

​      元数据之于信息架构就像是房子的砖瓦，它可以根据需要摆放成不同的信息检索系统。元数据是所有组织系统的基础，从搜索到电子商务网站上的导航系统都强烈的依赖于元数据。

​    元数据（Meta Data）是关于数据仓库的数据，指在数据仓库建设过程中所产生的有关数据源定义，目标定义，转换规则等相关的关键数据。同时元数据还包含关于数据含义的商业信息，所有这些信息都应当妥善保存，并很好地管理。为数据仓库的发展和使用提供方便。

   元数据是一种二进制信息，用以对存储在公共语言运行库可移植可执行文件 (PE) 文件或存储在内存中的程序进行描述。将您的代码编译为 PE 文件时，便会将元数据插入到该文件的一部分中，而将代码转换为 Microsoft 中间语言 (MSIL) 并将其插入到该文件的另一部分中。在模块或程序集中定义和引用的每个类型和成员都将在元数据中进行说明。当执行代码时，运行库将元数据加载到内存中，并引用它来发现有关代码的类、成员、继承等信息。

3、元数据的优点

​      对于一种更简单的编程模型来说，元数据是关键，该模型不再需要接口定义语言 (IDL) 文件、头文件或任何外部组件引用方法。元数据允许 .NET 语言自动以非特定语言的方式对其自身进行描述，而这是开发人员和用户都无法看见的。另外，通过使用属性，可以对元数据进行扩展。元数据具有以下主要优点：

​      自描述文件。 

​      公共语言运行库模块和程序集是自描述的。模块的元数据包含与另一个模块进行交互所需的全部信息。元数据自动提供 COM 中 IDL 的功能，允许将一个文件同时用于定义和实现。运行库模块和程序集甚至不需要向操作系统注册。结果，运行库使用的说明始终反映编译文件中的实际代码，从而提高应用程序的可靠性。

​      语言互用性和更简单的基于组件的设计。 

​      元数据提供所有必需的有关已编译代码的信息，以供您从用不同语言编写的 PE 文件中继承类。您可以创建用任何托管语言（任何面向公共语言运行库的语言）编写的任何类的实例，而不用担心显式封送处理或使用自定义的互用代码。

4、元数据的意义

​      说到元数据的意义，可以从其应用目的来谈的。虽然做数据仓库言必称元数据，必称技术、业务元数据，但其到底用于何处？离开了目标去谈元数据，就发现元数据包含太多的东西，因为他是描述数据的数据嘛。

​      还是那客户关系系统来比喻，这个系统维护客户信息当然是有目的的，是要用这些信息进行一些自动的流程处理、去挖掘一些客户潜在的价值、做好客户服务。当然没有必要去维护客户的生命特征信息，诸如指纹、犯罪史等，这些信息跟客户关系管理的目标关系不大。元数据也是如此，你可以将所以数据的结构、大小、什么时间创建、什么时间消亡、被那些人使用等等，这些信息可以延伸得太广，如果不管目标，而试图去建一个非常完美的元数据管理体系，这是一种绝对的"自上而下"做法，必败无疑。

元数据列举

​      基于应用，可以将元数据分成以下的若干中。

​      数据结构：数据集的名称、关系、字段、约束等； 

​      数据部署：数据集的物理位置； 

​      数据流：数据集之间的流程依赖关系（非参照依赖），包括数据集到另一个数据集的规则； 

​      质量度量：数据集上可以计算的度量； 

​      度量逻辑关系：数据集度量之间的逻辑运算关系； 

​      ETL过程：过程运行的顺序，并行、串行； 

​      数据集快照：一个时间点上，数据在所有数据集上的分布情况； 

​      星型模式元数据：事实表、维度、属性、层次等； 

​      报表语义层：报表指标的规则、过滤条件物理名称和业务名称的对应； 

​      数据访问日志：哪些数据何时被何人访问； 

​      质量稽核日志：何时、何度量被稽核，其结果； 

​      数据装载日志：哪些数据何时被何人装载；

5、元数据开发应用的标准化框架 

(1)数字图书馆资源组织框架

Meta Data

​ (2)元数据开发应用框架

元数据的基本意义 Metadata（元数据）是“关于数据的数据”；

元数据为各种形态的数字化信息单元和资源集合提供规范、普遍的描述方法和检索工具；

元数据为分布的、由多种数字化资源有机构成的信息体系（如数字图书馆）提供整合的工具与纽带。

离开元数据的数字图书馆将是一盘散沙，将无法提供有效的检索和处理。

(3)元数据应用目的

​      1>确认和检索（Discovery andentification），主要致力于如何帮助人们检索和确认所需要的资源，数据元素往往限于作者、标题、主题、位置等简单信息，Dublin Core是其典型代表。

​      2>著录描述（Cataloging），用于对数据单元进行详细、全面的著录描述，数据元素囊括内容、载体、位置与获取方式、制作与利用方法、甚至相关数据单元方面等，数据元素数量往往较多，MARC、GILS和FGDC/CSDGM是这类Metadata的典型代表。

​      3>资源管理（Resource Administration），支持资源的存储和使用管理，数据元素除比较全面的著录描述信息外，还往往包括权利管理（Rights/Privacy Management）、电子签名（Digital Signature）、资源评鉴（Seal of Approval/Rating）、使用管理（Access Management）、支付审计（Payment and Accounting）等方面的信息。

​      4>资源保护与长期保存（Preservation and Archiving），支持对资源进行长期保存，数据元素除对资源进行描述和确认外，往往包括详细的格式信息、制作信息、保护条件、转换方式（Migration Methods）、保存责任等内容。

互联网发展的越来越快，元数据的格式越来越多，人们对它的互操作要求也越来越高，就出现了XML！在利用XML描述一个文档的时候，我们可以自己定义标签，如”<title>”。这些小标签都是元数据。在网络时代，XML作为元数据的一种表现形式是非常有潜力的。最后我们在来看一下XML的好朋友HTML。HTML的head里有一个meta标签。那么它是什么呢？它是“关于文档的信息”。meta的属性有两种，name和http-equiv.name属性用来描述网页的内容，以便搜索引擎查找。比如这个网页的keywords呀。http-equiv属性指示服务器在发送实际的文档之前先在要传送给浏览器的 MIME 文档头部包含名称/值对。比如<meta http-equiv="Content-Language" contect="zh-CN">用以说明主页制作所使用的文字以及语言

 #### DITA

DITA 是“Darwin Information TypingArchitecture”（达尔文信息类型化体系结构）的缩写，它是IBM公司为OASIS所支持的团体贡献的发明。OASIS 的全称为“Organization for the Advancement of Structured Information Standards”（结构信息标准化促进组织）。

基本内容

DITA 是基于XML的体系结构，用于编写、制作、交付面向主题的信息类型的内容。DITA的单源内容可以通过不同的方法进行重用，生成不同的交付内容。由于DITA过去用于大型技术手册的编写、管理和交付，它能够满足所有可能呈现给读者的信息发布类型的要求。DITA可用于技术手册、交互培训，教材、标准、报告、商业文档、贸易书籍、旅游和自然指南等书籍的编写。

定义主题

DITA 定义主题DTD，它支持主题化的信息创建方法。主题是信息的组成部分，而不是完整的文档。主题根据信息类型的不同，可以分为concept（概念）、task（任务）、reference（三种基本类型），这些主题通过Map文件组织起来形成文档。Map可被认为是文档目录结构，根据文档不同类型，有不同的章节划分方式。具体可以参见Darwin Information TypingArchitecture(DITA) v1.3中对topic、Map、以及topic中的元素和属性的详细描述。

定制工具

DITA Open Toolkit

DITA Open Toolkit

不同的主题都由DTD来定义的。只需掌握简单的DTD语法规则，就可以快速简单地定义适合本组织文档需求的主题。

DITA 规范提供了一个开源工具DITA Open Toolkit，该工具可方便地发布DITA格式内容，生成各种格式的输出。同时，可以很容易的定制该工具的发布过程，根据需要对输出样式进行定制化。

重用过滤

DITA提供了各种机制，包括conref和keyref等内容引用，对内容进行重用。同时通过DITAVAL文件，对不同的读者对象、平台、产品、版本等进行内容过滤。

协作共享

将内容主题化，将格式统一到样式表，通过Map组织内容章节目录。这些方法使得文档的开发

由于DITA文件是基于XML的文本文件，又可以很方便地进行存储和传输，实现文档的异地共享，协同作业。

任务可以很方便地分解到各个文档编写人员手中，生成格式统一，内容规范的文档。





   

　



　









　



　

  