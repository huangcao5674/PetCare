define(function (require, exports, module) {
    var under = require("underscore");
    var backbone = require("backbone");

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

    var AppView = Backbone.View.extend({
        el: $("body"),
        initialize: function () {
            contentList.bind("add", this.addList, this);
            //            $("#publish").click(function () {
            $.getJSON("../Adopt/GetBasicMessage", [], function (json) {
                contentList.trigger("add", json);
            });
            //            });
        },
        addList: function (json) {
            _.each(json, function (item) {
                var view = new _View({
                    model: new _model(item)
                });
                view.template = _.template($("#templateModel").html());
                $("#content").append(view.render().el);
            });
        }
    });
    var App = new AppView();
});
