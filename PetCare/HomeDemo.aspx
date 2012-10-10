<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeDemo.aspx.cs" Inherits="PetCare.HomeDemo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>宠物网-帮你寻找最喜爱的宠物</title>
    <link href="Scripts/GlobalStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
    <!--Html5预留标签，未经测试-->
        <!--<header>-->
        <div id="top">
            <div id="logo">宠物网</div>
            <div class="userNav">
                <a href="#">首页</a><span>|</span>
                <a href="#">通知</a><span>|</span>
                <a href="#">好男人就是我 ▼</a>
            </div>
        </div>
        <div class="clear"></div>
        <!--</header>-->
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
            <!--Html5预留标签，未经测试-->
                <!--<article>-->
                <div class="userThumb">
                    <!--读取数据库用户头像，默认为Default-->
                    <img src="Images/DefaultUserThumb.PNG" alt="用户头像" />
                </div>
                <div class="userPush">
                    <!--读取数据库用户昵称-->
                    <p class="userNickName">养狗的二货
                        <span>: </span>
                        <span class="userPushTime">2012年10月10日</span>
                    </p>   
                    <!--读取数据库用户发布内容-->
                    <h2 class="contentTitle">阿富汗犬种于1886年首次登陆英国，成为英国皇室猎犬</h2>
                    <p class="contentBody">1926年英国将此犬种介绍给美国后，美国经过半世纪的改良使阿富汗猎犬有其高雅威武的外观，
                    以其美丽的姿容而形成独特的风格，在任何恶劣的环境中都能有较强的忍耐力，惊人的敏捷和强壮的体魄，
                    并且具有了极高的观赏性风靡全世界。
                    <a href="#">查看全文</a>
                    </p>
                    <!--没有图片则隐藏-->
                    <img class="contentImage" src="Images/imageTest.PNG" alt="发布图片" />           
                    <div class="articleFunction">
                        <div class="userTopic"> 
                            <!--读取数据库用户创建话题-->
                            <a href="#">#宠物知识</a>
                            <a href="#">#汪星人百科</a>
                        </div>
                        <div class="social">
                             <!--读取数据库用户创建话题-->
                            <a href="#">评论</a>
                            <span>|</span>
                            <a href="#">分享</a>
                            <span>|</span>
                            <a href="#">收藏</a>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="clear"></div>
                <!--</article>-->
            </div>
            <div class="article">
            <!--Html5预留标签，未经测试-->
                <!--<article>-->
                <div class="userThumb">
                    <!--读取数据库用户头像，默认为Default-->
                    <img src="Images/DefaultUserThumb.PNG" alt="用户头像" />
                </div>
                <div class="userPush">
                    <!--读取数据库用户昵称-->
                    <p class="userNickName">养狗的二货
                        <span>: </span>
                        <span class="userPushTime">2012年10月10日</span>
                    </p>   
                    <!--读取数据库用户发布内容-->
                    <h2 class="contentTitle">阿富汗犬种于1886年首次登陆英国，成为英国皇室猎犬</h2>
                    <p class="contentBody">1926年英国将此犬种介绍给美国后，美国经过半世纪的改良使阿富汗猎犬有其高雅威武的外观，
                    以其美丽的姿容而形成独特的风格，在任何恶劣的环境中都能有较强的忍耐力，惊人的敏捷和强壮的体魄，
                    并且具有了极高的观赏性风靡全世界。
                    <a href="#">查看全文</a>
                    </p>
                    <!--没有图片则隐藏-->
                    <img class="contentImage" src="Images/imageTest.PNG" alt="发布图片" />           
                    <div class="articleFunction">
                        <div class="userTopic"> 
                            <!--读取数据库用户创建话题-->
                            <a href="#">#宠物知识</a>
                            <a href="#">#汪星人百科</a>
                        </div>
                        <div class="social">
                             <!--读取数据库用户创建话题-->
                            <a href="#">评论</a>
                            <span>|</span>
                            <a href="#">分享</a>
                            <span>|</span>
                            <a href="#">收藏</a>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="clear"></div>
                <!--</article>-->
            </div>

            <div class="article">
            <!--Html5预留标签，未经测试-->
                <!--<article>-->
                <div class="userThumb">
                    <!--读取数据库用户头像，默认为Default-->
                    <img src="Images/DefaultUserThumb.PNG" alt="用户头像" />
                </div>
                <div class="userPush">
                    <!--读取数据库用户昵称-->
                    <p class="userNickName">养狗的二货
                        <span>: </span>
                        <span class="userPushTime">2012年10月10日</span>
                    </p>   
                    <!--读取数据库用户发布内容-->
                    <h2 class="contentTitle">阿富汗犬种于1886年首次登陆英国，成为英国皇室猎犬</h2>
                    <p class="contentBody">1926年英国将此犬种介绍给美国后，美国经过半世纪的改良使阿富汗猎犬有其高雅威武的外观，
                    以其美丽的姿容而形成独特的风格，在任何恶劣的环境中都能有较强的忍耐力，惊人的敏捷和强壮的体魄，
                    并且具有了极高的观赏性风靡全世界。
                    <a href="#">查看全文</a>
                    </p>
                    <!--没有图片则隐藏-->
                    <img class="contentImage" src="Images/imageTest.PNG" alt="发布图片" />           
                    <div class="articleFunction">
                        <div class="userTopic"> 
                            <!--读取数据库用户创建话题-->
                            <a href="#">#宠物知识</a>
                            <a href="#">#汪星人百科</a>
                        </div>
                        <div class="social">
                             <!--读取数据库用户创建话题-->
                            <a href="#">评论</a>
                            <span>|</span>
                            <a href="#">分享</a>
                            <span>|</span>
                            <a href="#">收藏</a>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="clear"></div>
                <!--</article>-->
            </div>

            <div class="article">
            <!--Html5预留标签，未经测试-->
                <!--<article>-->
                <div class="userThumb">
                    <!--读取数据库用户头像，默认为Default-->
                    <img src="Images/DefaultUserThumb.PNG" alt="用户头像" />
                </div>
                <div class="userPush">
                    <!--读取数据库用户昵称-->
                    <p class="userNickName">养狗的二货
                        <span>: </span>
                        <span class="userPushTime">2012年10月10日</span>
                    </p>   
                    <!--读取数据库用户发布内容-->
                    <h2 class="contentTitle">阿富汗犬种于1886年首次登陆英国，成为英国皇室猎犬</h2>
                    <p class="contentBody">1926年英国将此犬种介绍给美国后，美国经过半世纪的改良使阿富汗猎犬有其高雅威武的外观，
                    以其美丽的姿容而形成独特的风格，在任何恶劣的环境中都能有较强的忍耐力，惊人的敏捷和强壮的体魄，
                    并且具有了极高的观赏性风靡全世界。
                    <a href="#">查看全文</a>
                    </p>
                    <!--没有图片则隐藏-->
                    <img class="contentImage" src="Images/imageTest.PNG" alt="发布图片" />           
                    <div class="articleFunction">
                        <div class="userTopic"> 
                            <!--读取数据库用户创建话题-->
                            <a href="#">#宠物知识</a>
                            <a href="#">#汪星人百科</a>
                        </div>
                        <div class="social">
                             <!--读取数据库用户创建话题-->
                            <a href="#">评论</a>
                            <span>|</span>
                            <a href="#">分享</a>
                            <span>|</span>
                            <a href="#">收藏</a>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="clear"></div>
                <!--</article>-->
            </div>

            <div class="article">
            <!--Html5预留标签，未经测试-->
                <!--<article>-->
                <div class="userThumb">
                    <!--读取数据库用户头像，默认为Default-->
                    <img src="Images/DefaultUserThumb.PNG" alt="用户头像" />
                </div>
                <div class="userPush">
                    <!--读取数据库用户昵称-->
                    <p class="userNickName">养狗的二货
                        <span>: </span>
                        <span class="userPushTime">2012年10月10日</span>
                    </p>   
                    <!--读取数据库用户发布内容-->
                    <h2 class="contentTitle">阿富汗犬种于1886年首次登陆英国，成为英国皇室猎犬</h2>
                    <p class="contentBody">1926年英国将此犬种介绍给美国后，美国经过半世纪的改良使阿富汗猎犬有其高雅威武的外观，
                    以其美丽的姿容而形成独特的风格，在任何恶劣的环境中都能有较强的忍耐力，惊人的敏捷和强壮的体魄，
                    并且具有了极高的观赏性风靡全世界。
                    <a href="#">查看全文</a>
                    </p>
                    <!--没有图片则隐藏-->
                    <img class="contentImage" src="Images/imageTest.PNG" alt="发布图片" />           
                    <div class="articleFunction">
                        <div class="userTopic"> 
                            <!--读取数据库用户创建话题-->
                            <a href="#">#宠物知识</a>
                            <a href="#">#汪星人百科</a>
                        </div>
                        <div class="social">
                             <!--读取数据库用户创建话题-->
                            <a href="#">评论</a>
                            <span>|</span>
                            <a href="#">分享</a>
                            <span>|</span>
                            <a href="#">收藏</a>
                        </div>
                        <div class="clear"></div>
                    </div>
                </div>
                <div class="clear"></div>
                <!--</article>-->
            </div>
        </div>
        <div id="aside">
        <!--Html5，未经测试-->
        <!--<aside>-->

        <!--</aside>-->
        </div>   
        <div class="clear"></div>
    </div>
    </form>
</body>
</html>
