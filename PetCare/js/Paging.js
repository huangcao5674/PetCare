
define(function () {
    return function ($) {
        $.fn.paging = function (options) {
            options = options || {};
            return this.each(function () {

            });
        };
        Paging.prototype = {
            _fire: function (event) {
                this.options[event].call(this);
            },
            uiEffect: function () {
                var _page = this.getWRAPPER("#" + this.options.DomId + "_page");
                _page.find("#" + this.options.DomId + "_pageindex").val(this.options.pageIndex); //设置当前的页面
                _page.find("#" + this.options.DomId + "_total").html("（共" + this.options.totalPage + "页）"); //设置当前的页面
                //var _PagePostionType = Paging.getPagePostionType();
                $("#" + this.options.DomId + "_firstpage").removeClass();
                $("#" + this.options.DomId + "_nextpage").removeClass();
                $("#" + this.options.DomId + "_prepage").removeClass();
                $("#" + this.options.DomId + "_lastpage").removeClass();
                switch (this.options.pagePostionType) {
                    case -1: //前后都没有记录
                        $("#" + this.options.DomId + "_firstpage").addClass("no_use");
                        $("#" + this.options.DomId + "_nextpage").addClass("no_use");
                        $("#" + this.options.DomId + "_prepage").addClass("no_use");
                        $("#" + this.options.DomId + "_lastpage").addClass("no_use");
                        break;
                    case 0: //前面没有记录
                        $("#" + this.options.DomId + "_firstpage").addClass("no_use");
                        $("#" + this.options.DomId + "_nextpage").removeClass();
                        $("#" + this.options.DomId + "_prepage").addClass("no_use");
                        $("#" + this.options.DomId + "_lastpage").removeClass();
                        break;
                    case 1: //前后都有记录
                        $("#" + this.options.DomId + "_firstpage").removeClass();
                        $("#" + this.options.DomId + "_nextpage").removeClass();
                        $("#" + this.options.DomId + "_prepage").removeClass();
                        $("#" + this.options.DomId + "_lastpage").removeClass();
                        break;
                    case 2: //后面没有记录
                        $("#" + this.options.DomId + "_firstpage").removeClass();
                        $("#" + this.options.DomId + "_nextpage").addClass("no_use");
                        $("#" + this.options.DomId + "_prepage").removeClass();
                        $("#" + this.options.DomId + "_lastpage").addClass("no_use");
                        break;
                }


                _page.find("input[type='button']").mouseover(function () {
                    if ($(this).attr("class") != 'no_use') {
                        $(this).removeClass();
                        $(this).addClass("hover");
                    }
                });
                _page.find("input[type='button']").mouseout(function () {
                    if ($(this).attr("class") != 'no_use') {
                        $(this).removeClass();
                    }
                });
            },
            getWRAPPER: function (ele) {
                return $(ele);
            },
            orderChanged: function (order, sort, callBack) {
                if (typeof (order) !== 'undefined' && order !== "") {
                    this.options.order = order;
                }
                if (typeof (sort) !== 'undefined' && sort !== "") {
                    this.options.sort = sort;
                }
                this.getPagingDate(callBack);
            },
            PageChanged: function (type, pageindex, callBack) {
                if (typeof (callBack) === 'undefined') {
                    callBack = this.options.callback;
                }
                switch (type) {
                    case "1":
                        this.options.pageIndex = 1;
                        this.getPagingDate(callBack);
                        break;
                    case "2":
                        this.options.pageIndex = this.options.pageIndex - 1;
                        this.getPagingDate(callBack);
                        break;
                    case "3":
                        this.options.pageIndex = this.options.pageIndex + 1;
                        this.getPagingDate(callBack);
                        break;
                    case "4":
                        this.options.pageIndex = this.options.totalPage;
                        this.getPagingDate(callBack);
                        break;
                    case "5":
                        try {
                            var _value = parseInt(pageindex, 10);
                            if (!isNaN(_value) && _value >= 1 && _value <= this.options.totalPage) {
                                this.options.pageIndex = _value;
                                this.getPagingDate(callBack);
                            }
                            else {
                                $("#" + this.options.DomId + "_pageindex").val(this.options.pageIndex);
                            }
                        }
                        catch (err) {

                        }
                        break;
                    default:
                        this.options.pageIndex = 1;
                        this.getPagingDate(callBack);
                }
            },
            getPagingDate: function (callBack) { //获取数据
                var _self = this;
                //var _data = "pageIndex=" + this.options.pageIndex + "&limit=" + this.options.limit + "&sort=" + encodeURI(this.options.sort) + "&order=" + this.options.order;
                var _data = null;
                $.getJSON(_self.options.url, _data, function (json) {
                    _self.options.totalCount = json.total; //json.total;
                    _self.getTotalPage();
                    _self.getOrderClass();
                    _self.getPagePostionType();
                    _self.uiEffect(); //分页控件的ui
                    if (typeof (callBack) === "function") {
                        callBack(json.records);
                    }
                    else {
                        if (typeof (_self.options.callback) === 'function')
                            _self.options.callback(json.records);
                    }

                });

            },
            getTotalPage: function () //获取总页数
            {
                this.options.totalPage = Math.ceil(this.options.totalCount / this.options.limit);
                //return Math.ceil(this.options.totalCount / this.options.limit);
            },
            getOrderClass: function () {
                switch (this.options.order) {
                    case "asc": this.options.orderClass = "ascIcon"; break;
                    case "desc": this.options.orderClass = "descIcon"; break;
                    default: this.options.orderClass = "unscIcon";
                }
            },
            getPagePostionType: function () //获取当前页在总页中的位置
            {
                var _pagePostionType = 0; //无任何记录
                var _pagenum = this.options.totalPage;
                var _index = this.options.pageIndex;
                if (_pagenum === 0) {
                    //前后都没有记录
                    _pagePostionType = -1;
                }
                else {
                    if (_index === _pagenum) {
                        if (_pagenum === 1) {
                            //前后都没有记录
                            _pagePostionType = -1;
                        }
                        if (_pagenum >= 2) {
                            //后面没有记录
                            _pagePostionType = 2;
                        }
                    }
                    if (_index < _pagenum) {
                        if (_index > 1) {
                            //前后都有记录
                            _pagePostionType = 1;
                        }
                        else {
                            //前面没有记录
                            _pagePostionType = 0;
                        }
                    }
                }

                this.options.pagePostionType = _pagePostionType;
            }
        };
        function Paging(options) {
            this.options = $.extend({}, Paging.DEFAULTS, options || {});
            this._page = $(Paging.WRAPPER(this.options.DomId));
            $("#" + this.options.DomId).append(this._page);
            //this.getPagingDate(this.options.callback);
            var _self = this;
            $("#" + this.options.DomId + "_firstpage").bind("click", function (e) {
                if (!($(e.currentTarget).hasClass("no_use"))) {
                    _self.PageChanged("1", "");
                }
            });
            $("#" + this.options.DomId + "_prepage").bind("click", function (e) {
                if (!($(e.currentTarget).hasClass("no_use"))) {
                    _self.PageChanged("2", "");
                }
            });
            $("#" + this.options.DomId + "_nextpage").bind("click", function (e) {
                if (!($(e.currentTarget).hasClass("no_use"))) {
                    _self.PageChanged("3", "");
                }
            });
            $("#" + this.options.DomId + "_lastpage").bind("click", function (e) {
                if (!($(e.currentTarget).hasClass("no_use"))) {
                    _self.PageChanged("4", "");
                }
            });
            $("#" + this.options.DomId + "_gotopage").bind("click", function (e) {
                if (!($(e.currentTarget).hasClass("no_use"))) {
                    _self.PageChanged("5", $("#" + _self.options.DomId + "_pageindex").val());
                }
            });
        };



        Paging.EF = function () { };
        $.extend(Paging, {
            WRAPPER: function (domid) {
                return "<ul class='right_ul clearFix' id='" + domid + "_page'>" +
                    "    <li><input id='" + domid + "_firstpage' type='button' value='首页'></li>" +
                    "    <li><input id='" + domid + "_prepage' type='button' value='上页' class='no_use'></li>" +
                    "    <li><input id='" + domid + "_nextpage' type='button' value='下页' class='hover'></li>" +
                    "    <li><input id='" + domid + "_lastpage' type='button' value='尾页'></li>" +
                    "    <li class='spa'>转到第<input type='text' class='text' id='" + domid + "_pageindex'>页<span id='" + domid + "_total'>（共24页）</span>" +
                    "       <input type='button' id='" + domid + "_gotopage' class='sure' value='确定'>" +
                    "    </li>" +
                    "</ul>";
            },
            DEFAULTS: {
                DomId: "",
                data: "",
                json: "",
                scope: this, //作用域
                url: "js/Notice/json_noticeList.txt",
                totalCount: 0,         	//总记录数
                totalPage: 1,
                pageIndex: 1, 			//当前的页码
                pagePostionType: -1,
                sort: "",        	 	//排序字段
                order: "desc",      	//升序 asc  降序desc
                orderClass: "descIcon", //升序降序样式
                limit: 20,  			//每页显示多少条数据
                jsonPrimaryKey: "id", 		//json中记录集的主键
                callback: Paging.EF
            }
        });
        return Paging;
    }
});