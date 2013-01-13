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
        limit: 2,
        sort: "date",
        order: "desc"
    });

    var AppView = Backbone.View.extend({
        el: $("body"),
        initialize: function () {
            contentList.bind("add", this.addList, this);
            var self = this;
            $("#sideNav>ul>li").bind("click", function (e) {
                _Paging.options.url = "../Adopt/Index";
                _Paging.getPagingDate();
            });
            _Paging.options.callback = function (json) {
                self.callback(json);
            }
            _Paging.options.url = "../Knowledge/Index";
            _Paging.getPagingDate();
            //            $.getJSON("../Knowledge/Index", [], function (json) {
            //                if (json.total && json.records.length > 0) {
            //                    contentList.trigger("add", json.records);
            //                }
            //            });
            //            });
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
        }
    });
    var App = new AppView();
});
