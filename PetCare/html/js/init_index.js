define(function (require, exports, module) {
    var _ = require("underscore");
    var backbone = require("./backbone");
    var AppView = Backbone.View.extend({
        el: $("body"),
        initialize: function () {
            $("#test").click(function () {
                $.get("../Adopt/GetBasicMessage.do", null, function (json) {
                    $("#adoptext").append(json);
                });
            });
            $("#test").click(function () {
                $.get("../Bussiness/GetBasicMessage.do", null, function (json) {
                    $("#bussitext").append(json);
                });
            });
            $("#test").click(function () {
                $.get("../User/Index.do", null, function (json) {
                    $("#usertext").append(json);
                });
            });
        }
    });
    var App = new AppView();
});
