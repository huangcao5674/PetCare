define(function (require, exports, module) {
    var under = require("underscore");
    var backbone = require("backbone");
    var Paging = require("Paging")($);

    var _model = Backbone.Model.extend({
    });
    var _View = Backbone.View.extend({
        tagName: 'div',
        initialize: function () {
        },
        render: function () {
            $(this.el).html(this.template(this.model.toJSON()));
            return this;
        },
        remove: function () {
            $(this.el).remove();
        }
    });
    var Collection = Backbone.Collection.extend({
        model: _model
    });

    var contentList = new Collection();

    //定义分页
    var _Paging = new Paging({
        DomId: "paging",
        limit: 10,
        sort: "date",
        order: "desc"
    });

    var AppView = Backbone.View.extend({
        el: $("body"),
        initialize: function () {
            contentList.bind("add", this.addList, this);
            var self = this;
            $("#publish").bind("click", function () {
                window.open("../html/simple.html","发布");
            });
            var code = this.GetParamByDecodeURIComponent("Code",location.href);
            $("#sideNav>ul>li").bind("click", function (e) {
                _Paging.options.url = "../Adopt/Index";
                _Paging.getPagingDate();
            });
            _Paging.options.callback = function (json) {
                self.callback(json);
            }
            switch (code) {
                case "1":
                    _Paging.options.url = "../Adopt/Index";
                    break;
                case "3":
                    _Paging.options.url = "../Knowledge/Index";
                    break;
                default:
                    _Paging.options.url = "../Knowledge/Index";
                    break;
            }
            //_Paging.options.url = "../Knowledge/Index";
            _Paging.getPagingDate();
        },
        addList: function (json) {
            _.each(json, function (item) {
                var view = new _View({
                    model: new _model(item)
                });
                view.template = _.template($("#templateModel").html());
                $("#article").append(view.render().el);
            });
        },
        callback: function (json) {
            if (json.length > 0) {
                $("#article").html("");
                contentList.trigger("add", json);
            }
        },
        GetParamByDecodeURIComponent: function (paramName, url) { //采用js自带的decodeURIComponent解码获取querystring
            var _paramValue = "", _isFound = false, _arrSource, i = 0, _queryString;
            if (typeof (url) == 'undefined') {
                if (location.search.indexOf("?") == 0 && location.search.indexOf("=") > 1) {
                    _arrSource = location.search.substring(1, location.search.length).split("&");

                }
            }
            else {
                if (url.indexOf("?") > 0 && url.indexOf("=") > 1) {
                    _queryString = url.substring((url.indexOf("?") + 1));
                    _arrSource = _queryString.split("&");
                }
            }
            if (typeof (_arrSource) != 'undefined') {
                while (i < _arrSource.length && !_isFound) {
                    if (_arrSource[i].indexOf("=") > 0) {
                        if (_arrSource[i].split("=")[0].toLowerCase() == paramName.toLowerCase()) {
                            _paramValue = _arrSource[i].split("=")[1];
                            _isFound = true;
                        }
                    }
                    i++;
                }
            }

            return decodeURIComponent(_paramValue);
        }
    });
    var App = new AppView();
});
