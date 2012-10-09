<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeDemo.aspx.cs" Inherits="PetCare.HomeDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>宠物网-帮你寻找最喜爱的宠物</title>
    <link href="Scripts/GlobalStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
    <!--Html5兼容性标签，未经测试-->
    <header>
        <div id="top">
            <div id="logo">宠物网</div>
            <div class="userNav">
                <a href="#">首页</a><span>|</span>
                <a href="#">通知</a><span>|</span>
                <a href="#">好男人就是我 ▼</a>
            </div>
        </div>
        <div class="clear"></div>
    </header>
    </div>
    <div id="wrapper">
    	<div id="content">
            <div id="tabView">
                <p id="mostRecent">最新动态</p>
                <div id="tabFilter">
                    <a href="#" class="linkActive">最新</a>
                    •
                    <a href="#">最热门</a>
                </div>
                <div class="clear"></div>
            </div>
            <div class="article">
            <!--Html5兼容性标签，未经测试-->
            <article>
                
            </article>
            </div>
        </div>
        <div id="aside">
        <!--Html5兼容性标签，未经测试-->
        <aside>

        </aside>
        </div>   
        <div class="clear"></div>
    </div>
    </form>
</body>
</html>
