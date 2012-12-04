
var CommFunc = {
    fSubString: function () {
        var _length = 0;
        _length = Math.floor((dom.width() - 15) / 15);
        return (str.length > _length) ? (str.substring(0, _length - 1) + "...") : str
    },
    //计算字符串的宽度  一个汉字宽度为2，英文为1
    stringWidth: function (str) {
        if (str.length <= 0)
            return 0;
        var sum = 0;
        var lst = /[u00-uFF]/;
        for (var i = 0; i < str.length; i++) {
            if (!lst.test(str.charAt(i)))
                sum += 2;
            else
                sum++;
        }
        return sum;
    },
    //str:原始字符串
    //length:超过多少字符长度 显示...
    fSubstring: function (str, length) {//截取字符串
        return (str.length > length) ? (str.substring(0, length) + "...") : str
    }
}