var Home = function (options) {
    this.init(options);
};

Home.prototype = (function () {
    var showError = function (msg) {
        var me = this;
        me.error.html(msg).show();
    };

    return {
        init: function (options) {
            var me = this;
            me.txt = $("#email_txt");
            me.btn = $("#submit_btn");
            me.error = $("#error_msg");
            var regex = new RegExp(/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/); //regular expression to check 
            me.txt.off("focus").on("focus", function () {
                me.error.hide();
            });
            me.btn.off("click").on("click", function (evt) {
                var txt = me.txt.val();
                if (txt === "") {
                    showError.call(me,"Please enter an email.");
                    return false;
                } else if (!regex.test(txt)) {
                    showError.call(me, "Please enter valid email.");
                    return false;
                }
                $("#frmsignip").submit();
            });
        }
    };
}());