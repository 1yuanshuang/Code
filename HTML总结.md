# 1 HTML

## 1.1 常用标签

换行标签 <br />
水平线标签 <hr />
段落标签：<p>文本内容</p>
标题标签：h1-h6 标签等级h1~h6，字体大小逐级递减
文本标签：<font>文本内容</font>
文本加粗标签：<strong></strong> <b></b> 推荐使用 strong
文本倾斜标签：<em></em> <i></i> 推荐使用 em
删除线标签：<del></del> <s></s> 推荐使用 del
下划线标签：<ins></ins> <u></u> 推荐使用 ins
定义锚点：<p id = "md">
音乐标签：<embed src="" type="" hidden="">

## 1.2 图片标签

```c#
<img src="" slt="" title="" width="" height="" />
```

src：图片来源，不可省略。
Alt：替换文本，图片不显示的时候显示的文字。
title：提示文本，把鼠标放到图片上显示的文字。
width：图片宽度 。height：图片高度。 （图片没有定义宽高的时候，图片按照百分之百比例显示，如果只更改图片的宽度或者高度，图片等比例缩放。）

## 1.3 超链接

```c#
<a href="" title="" target="">标签显示的文字</a>
```

href：将跳转的页面。
title：提示文本，鼠标放到链接上显示的文字。
target=”self”:默认值，在自身页面打开。 Target=”blank” 打开新页面 （自身页面不关闭，打开一个新的链接页面）

## 1.4 列表

无序列表：<ul></ul>

有序列表:</ol></ol>

## 1.5 表格

```c#
<table border="" width="" height="" cellspacing="" cellpadding=""  align="" bgcolor="">  
<caption>表头</caption>
<tr> 
<td> 列</td>
</tr>

<tr> 
<td> 列</td>
<td colspan="2"></td>
</tr>

<tr> 
<td rowspan="2"> 列</td>
<td></td>
</tr>
</table>
```

Border=” ” 边框。 Width=” ” 宽度。 Height=”” 高。 cellspacing=”” 单元格与单元格的距离。 cellpadding=”” 内容距边框的距离。
align=”left | right | center” 如果直接给表格用align=”center” 表格居中，如果给tr或者td使用 ，tr或者td内容居中。 bgcolor=”” 背景颜色。
表头 <caption></caption>。colspan=”2” 合并同一行上的单元格.。 rowspan=”2” 合并同一列上的单元格。

## 1.6 表单

```
<form action="x.php" method=""></form>
```

action:处理信息
Method=”get | post”：Get通过地址栏提供（传输）信息，安全性差。Post 通过1.php来处理信息，安全性高。

## 1.7 文本输入框

```
<input type="text" maxlength="" readonly="" disabled="" name="" value="" >
```

maxlength="6" 限制输入字符长度
disabled="disabled" 输入框未激活状态
readonly=”readonly” 将输入框设置为只读状态（不能编辑）
name="username" 输入框的名称
value="大前端" 将输入框的内容传给处理文件

## 1.8 单选框

```c#
<label for="gender">性别：</label>
<input type="radio" name="gender" value="男" checked="checked">男
<input type="radio" name="gender" value="女">女
```

只有将name的值设置相同的时候，才能实现单选效果。
checked=”checked” 设置默认选择项。

## 1.9 多选框

```c#
<label for="interest">爱好：</label>
<input type="checkbox" name="interest" value="运动">运动
<input type="checkbox" name="interest" value="艺术">艺术
<input type="checkbox" name="interest" value="科学">科学
```

## 1.10下拉列表

```c#
<select Multiple="multiple">
<option>下拉列表选项</option>
<option Selected="selected">下拉列表选项</option>
</select>
```

<optgroup></optgroup> 对下拉列表进行分组。
Multiple=”multiple” 将下拉列表设置为多选项。
Selected=”selected” 设置默认选中项目。

## 1.11多行文本

```c#
<textarea name="" id="" cols="30" rows="10"></textarea>
```

Cols 控制输入字符的长度。
Rows 控制输入的行数。

## 1.12 按钮

```c#
<input type="submit" value="确认提交">
```

# 2 上下文选择器

## 2.1 标签选择器

```c#
<style>
  h1 {font-size: 16px;}
  p {color:red;}
</style>
```

代码中的h1和p就是选择器，他们是选择器里面最常用的一种，叫做**标签选择器**。我们可以直接通过标签元素来指定需要添加样式的位置。

如果需要为多个标签添加同一种样式时，我们可以把它们组合在一起，每个标签选择器用“,”隔开，如下：

```c#
<style>
  h1,h2,h3 {
    font-weight: bold;
    color: blue;
  }
</style>
```

这样的组合我们叫它**分组选择器**。

## 2.2 后代组合选择器

当为article和aside的段落文本分别设置不同的字号时，就可以用到**后代选择器**了，它们是在祖先元素和后代元素之间加了一个空格，如代码所示：

```c#
<style>
  article p {
    font-size: 12px;
  }
  aside p {
    font-size: 14px;
  }
</style>
```

后代选择器有一个问题就是，祖先元素选择的后代元素都会带有样式，但是我们有时候并不需要所有的标签都带有样式，这个时候我们就要用到其他的选择器了。

## 2.3 子选择器

我们可以用DOM中的父子元素关系来选择，也就是**子选择器**，两个元素中间用“>”来连接，如代码所示：

```c#
<style>
  article>p {
    font-size: 12px;
  }
</style>
```

## 2.4 同胞选择器

我们也可以通过同胞关系来选择，叫做**同胞选择器**或者是**兄弟选择器**，这就意味着选择器的标签元素需要具有同一个父元素，它们之间用“+”来连接，例子：

```c#
<style>
  h2+p {
    font-size: 12px;
  }
</style>
```

并且需要注意的是：`p`标签必须是紧跟在`h2`标签的后面。

## 2.5 一般同胞选择器

一般同胞选择器中间用“~”连接。

```c#
<style>
  h2~p {
    font-size: 12px;
  }
</style>
```

一般同胞选择器和同胞选择器的区别就是，`p`标签不一定是紧跟在`h2`标签的后面。

## 2.6 通用选择器

通用选择器是使用通配符“ * ”，它可以匹配任何元素。比如：

```c#
*｛
  color: green;
｝
```

它会导致所有文本和边框都变成绿色。这里有个小知识：

color属性设定的是前景色。前景色既影响文本也影响边框，但通常我们只用它设定文本颜色。

我们也可以这样使用通用选择器：

```c#
p* {
  color: green;
}
```

这样只会把`p`包含的所有元素的文本变成红色。

# 3 id和类选择器

id和类选择器是我们在CSS中常用的选择器，它们可以更精确的定位到我们要添加样式的标签位置。只要在HTML标记中为元素添加id和class属性，就可以通过id和类选择器直接选择。

可以给id和class属性设定任何值，但不能以数字或特殊符号开头。

## 3.1 类选择器

`body`标签包含的任何HTML元素都可以添加class属性，如：

```c#
<h1 class="specialtext">这是一个H1标签</h1>
<p>这是一个段落。</p>
<p class="specialtext featured">这是另一个段落</p>
```

然后我们就可以用类选择器添加样式了，类选择器前面要加一个“ . ” ，后面跟着类名，如下：

```c#
<style>
  p {
    font-family: helvetica,sans-serif;
  }
  .specialtext {
    font-style: italic;
  }
</style>
```

### 3.1.1 标签带类选择器

当然，需要更精确的也可以这样写：

```c#
<style>
  p {
    font-family: helvetica,sans-serif;
  }
  .specialtext {
    font-style: italic;
  }
  p.specialtext {
    color: red;
  }
  p.specialtext span{
    font-weight: bold;
  }
</style>
```

第三个样式只选择带`.specialtext`类的`p`，第四就更精确到`p`中的`span`元素了。

### 3.1.2 多类选择器

同个标签可以存在多个类属性，每个类都用空格分隔，要选择两个类名可以这样写：

```c#
<style>
  .specialtext .featured {
    font-size: 120%;
  }
</style>
```

CSS类选择器的两个类名之间没有空格，如果加了空格就变成了“祖先/后代”关系的上下文选择器了。

## 3.2 ID选择器

ID与类的写法相似，只不过id选择器前面用“ # ”后面跟着id名，

```c#
<style>
  #specialtext {
    font-style: italic;
  }
</style>
<p id="specialtext">这是一个特殊段落</p>
```

id还可以用于页内导航

```c#
<a href="#bio">Biography</a>
```

这样的链接就可以直接在页面内跳转到具有id名为“bio”的标签的位置。如果没想好“href”中放什么链接，也可以用“#”来充当占位符。

## 3.3 两者区别

- ID具有唯一性，Class具有普遍性。
- ID是唯一的，所以尽量在结构外围使用，通常用于页面布局。
- Class是可重复的，所以尽量在结构内部使用，通常用于样式定义。
- ID的样式优先级高于Class。

# 4 属性选择器

## 4.1 属性名选择器

我们可能会遇到这样的HTML代码：

```c#
<img src="images/yellow_flower.jpg" title="yellow flower" alt="yellow flower" />
```

如果我们想要为带有title属性的图片添加样式，那么我们就可以用到**属性名选择器**了，如下：

```c#
img[title] {
  border: 2px solid blue;
}
```

这时图片就会显示2像素宽的蓝色边框。一般来说title属性和alt属性都是设定相同的值，增加可阅读性。

## 4.2 属性值选择器

属性值选择器就更精确地定位我们所需要添加样式的位置了。如下：

```c#
img[title="red flower"] {
  border: 4px solid green;
}
<img src="images/red_flower.jpg" title="red flower" alt="red flower" />
```

只有在title属性值为“red flower”时，才会为图片加上边框样式。

### 4.2.1 属性和值选择器-多个值

```c#
[title~="hello"]{
  color: red;
}
```

该例子为包含指定值的title属性的所有元素设置样式,适用于由空格分隔的属性值。

```c#
[lang|=en] {
  color: red;
}
```

该例子为带有包含指定值的lang属性的所有元素设置样式。适用于由连字符分隔的属性值。 

# 5 DIV+CSS布局

## 5.1 div和span

div和span在整个HTML标记中，没有任何意义，他们的存在就是为了应用CSS样式.
div和span的区别在于，span是内联元素，div是块级元素

## 5.2 盒模型

margin: 盒子外边距  padding: 盒子内边距   border: 盒子边框宽度  width: 盒子宽度   height: 盒子高度

## 5.3 布局相关的属性

### 5.3.1 position属性

css中定位的属性为position属性，属性值和功能如下

| 属性值      | 含义         | 特点                                       |
| -------- | ---------- | ---------------------------------------- |
| static   | 静态定位       | 默认定位方式，相当于无定位                            |
| relative | 相对定位       | 定位元素仍位于标准文档流中，相对于自身进行偏移                  |
| absolute | 绝对定位       | 定位元素脱离标准文档流，若有已定位祖先原始则相对于距离最近的祖先元素偏移，无已定位祖先元素则相对于根节点html偏移 |
| fixed    | 绝对定位中的固定定位 | 定位元素相对于窗口进行偏移                            |

### 5.3.2 定位 

left、right、top、bottom 离页面顶点的距离

z-index 层覆盖先后顺序(优先级)

### 5.3.3 display显示属性

display:none 该层不显示
display:block 块状显示，在元素后面换行，显示下一个块元素(block会尽可能的占据更多的width)
display:inline 内联显示，多个块可以显示在一行内(只占据它需要的width)

### 5.3.4 float浮动属性

left 左浮动
right 右浮动

### 5.3.5 clear清除浮动

clear:both

### 5.3.6 overflow溢出处理(主要是盒子小了，内容多了)

hidden 隐藏超出层大小的内容
scroll 无论内容是否超出大小都添加滚动条
auto 超出时自动添加滚动条

### 5.3.7 box-sizing设定盒模型的类型

通常，当我们定义一个div的时候，我们给出的width和height其实仅仅只是盒子的content的宽和长。
padding和border会另外加上。
比如：

```c#
div 
{
　 　width:300px;
　 　height:300px;
　 　padding:10px;
　 　border:10px;
}
```

此时的盒模型将会是320x320的大小，并不是我们希望的300x300
为了避免这样情况的发生，我们会使用

- {
  ​	box-sizing:border-box;
   }

  这时候，我们同样使用如下代码，

  ```c#
    div {
    　 　width:300px;
    　 　height:300px;
    　 　padding:10px;
    　 　border:10px;
    }
  ```

    此时的盒模型，大小依旧是300x300,content只有260x260

# 6 使用CSS样式的方式

## 6.1 内联样式表

```
<body style="background-color:green;margin:0;padding:0;"></body>
```

## 6.2 嵌入式样式表

```
<style type="text/css"> </style>
```

注意：需要将样式放在< head> < /head>中

## 6.3 引入式样式表

```c#
<link rel="stylesheet" type="text/css" href="style.css">
```