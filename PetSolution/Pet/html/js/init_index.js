define(function (require, exports, module) {
    var _ = require("underscore");
    var Backbone = require("Backbone");
    var AppView = Backbone.View.extend({
        el: $("body"),
        initialize: function () {
            $("#adoption").click(function () {
                $.get("../Adopt/GetBasicMessage.do", null, function (json) {
                    $("#adoptext").append(json);
                });
            });
            $("#bussiness").click(function () {
                $.get("../Bussiness/GetBasicMessage.do", null, function (json) {
                    $("#bussitext").append(json);
                });
            });
            $("#user").click(function () {
                $.get("../User/Index.do", null, function (json) {
                    $("#usertext").append(json);
                });
            });
        }
    });
    var App = new AppView();
});
