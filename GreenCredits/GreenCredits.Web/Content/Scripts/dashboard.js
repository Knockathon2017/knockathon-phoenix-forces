var Dashboard = function (options) {
    this.init(options);
};

Dashboard.prototype = (function () {
    var template = {

    };

    var showError = function (msg) {
        var me = this;
        
    };

    return {
        init: function (options) {
            var me = this;
            //$("#displayAssets").template("displayAssets");

            me.fm = new FormManager({ form: "#form_add", loader: "#asdf" });
            var fmo = {
                url: "/xyz",
                data: "",
                callback: function (sysError, response) {
                    if (!response.status === 200) {
                        //error
                        return;
                    }
                }
            };
            $(document).off("click").on("click", function (event) {
                if (event.target !== $("#addContainer")[0] && event.target !== $("#addAssetsBtn")[0] && !$.contains($("#addContainer")[0], event.target)) {
                    $("#addContainer").hide();
                    me.fm.clear();
                }
            });
            $("#addAssetsBtn").off("click").on("click", function () {
                $("#addContainer").show();
            });
            $("#saveAssets").off("click").on("click", function () {
                me.fm.post(fmo);
            });
            $("#cancelAssets").off("click").on("click", function () {
                $("#addContainer").hide();
                me.fm.clear();
            });

            L.mapbox.accessToken = 'pk.eyJ1IjoiZXNodWdvZWwyNCIsImEiOiI1OTJmMWI4NmQ2YjhjYmUyZWUxNGE3N2ZhODkwZDczMSJ9.I75hZHvao74uIKTQZ88r-w';
            var geocoder = L.mapbox.geocoder('mapbox.places')
            var map = L.mapbox.map('map', 'eshugoel24.a5e4197d');
            var mapLeaflet = map.setView([21.000, 78.000], 4);
            var arr = ['Nagina, UP', 'New Delhi, DL', 'Jhansi, UP'];

            for (var i = 0; i < arr.length; i++) {
                geocoder.query(arr[i], showMap);
            }

            function showMap(err, data) {
                L.marker([data.latlng[0], data.latlng[1]]).bindPopup('<button class="trigger">Say hi</button>').addTo(mapLeaflet);
            }
        }
    };
}());

var FormManager = function (options) {
    this.init(options);
};

FormManager.prototype = (function () {
    var initForm = function (isPost) {
        var me = this;
        var loader = $(me.opts.loader);
        if (loader && loader.length > 0) {
            loader.show();
        }

        if (me.ajaxObj)
            me.ajaxObj.abort();

        me.ajaxObj = $.ajax({
            type: me.type || "POST",
            url: me.url,
            dataType: me.dataType,
            data: isPost ? me.form.serialize() : me.data,
            success: function (response) {
                if (response.responseCode === "105") {
                    window.location.href = "/error/UnAuthorise?errorUrl=" + me.url;
                    //window.location.href = "/login";
                    return false;
                }
                else if (response.responseCode === "401") {
                    window.location.href = "/login";
                    return false;
                }

                if (typeof me.callback === "function")
                    me.callback(200, response, {});
            },
            error: function (response) {

                me.callback(300, response, {});
            },
            complete: function () {

                if (loader) {
                    loader.hide();
                }
            }
        });
    },
      clear = function () {
          var me = this;
          var context = me.form;
          me.formItem = context.find("input,select,textarea");
          me.formItem.not("input[type=button],input[type=checkbox],input[type=radio],input[type=hidden],input[name=__RequestVerificationToken]").val("");

          me.formItem.filter(":checked").attr("checked", false);
      },
    fillForm = function (data) {
        var me = this;
        var context = me.form;
        me.formItem = context.find("input,select,textarea");
        me.formItem.each(function () {
            var obj = $(this);
            var name = obj.attr("name");
            var val = data[name];
            if (val)
                obj.val(val);
        });
    };

    var defaults = { loader: null, form: null };
    return {
        init: function (options) {
            var me = this;
            me.opts = $.extend({}, defaults, options);
            me.form = typeof me.opts.form === "string" && me.opts.form.length > 1 ? $(me.opts.form) : (me.opts.form.length > 0 ? me.opts.form : null);
            var startState = null;
            var endState = null;
            me.stateManager = {
                capture: function () {
                    startState = me.form.serialize();
                },
                isStateChanged: function () {
                    endState = me.form.serialize();
                    return startState !== endState;
                }
            };

        },
        error: function (a, b) { },
        success: function (a, b) { },
        post: function (postObj) {
            var me = this;
            if (typeof postObj === "object") {

                if (typeof postObj.data === "object" && me.form) {
                    for (var propName in postObj.data) {
                        var input = me.form.find("input[name=" + propName + "]");
                        if (input.length == 0) {
                            input = $("<input type=\"hidden\"/>").attr("name", propName);
                            input.appendTo(me.form);
                        }
                        input.val(postObj.data[propName]);
                    }
                }
            }

            me.type = "POST";
            me.url = postObj.url;
            me.callback = postObj.callback;
            initForm.call(me, true);
        },

        postWithoutForm: function (postObj) {
            var me = this;
            me.type = "POST";
            me.url = postObj.url;
            me.dataType = "json";
            me.data = postObj.data;
            me.callback = postObj.callback;
            initForm.call(me, false);
        },

        get: function (postObj) {
            var me = this;
            me.type = postObj.method || "GET";
            me.url = postObj.url;
            me.data = postObj.data;
            me.dataType = "json";
            me.callback = function (status, response) {
                fillForm.call(me, response);
                if (typeof postObj.callback === "function")
                    postObj.callback(status, response);
            };
            initForm.call(me, false);
        },

        abortRequest: function () {
            var me = this;
            if (me.ajaxObj)
                me.ajaxObj.abort();
        },
        load: function (postObj) {
            var me = this;
            me.type = "GET";
            me.url = postObj.url;
            me.dataType = "json";
            me.callback = function (status, response) {
                fillForm.call(me, response);
                if (typeof postObj.callback === "function")
                    postObj.callback(status, response);
            };
            initForm.call(me, false);
        },
        bind: function (data) {
            fillForm.call(this, data);
        },
        getHtml: function (postObj) {
            var me = this;
            me.type = "GET";
            me.url = postObj.url;
            me.dataType = "html";
            me.callback = postObj.callback;
            initForm.call(me, false);
        },
        clear: function () {
            clear.call(this);
        }
    };
})();