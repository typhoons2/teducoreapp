var tedu = {
    config: {
        pageSize: 10,
        pageIndex: 1,
    },
    notify: function (message, type) {
        $.notify(message, {
            // whether to hide the notification on click
            clickToHide: true,
            // whether to auto-hide the notification
            autoHide: true,
            // if autoHide, hide after milliseconds
            autoHideDelay: 5000,
            // show the arrow pointing at the element
            arrowShow: true,
            // arrow size in pixels
            arrowSize: 5,
            // position defines the notification position though uses the defaults below
            position: 'top right',
            // default positions
            elementPosition: 'top right',
            globalPosition: 'top right',
            // default style
            style: 'bootstrap',
            // default class (string or [string])
            className: type,
            // show animation
            showAnimation: 'slideDown',
            // show animation duration
            showDuration: 400,
            // hide animation
            hideAnimation: 'slideUp',
            // hide animation duration
            hideDuration: 200,
            // padding between element and notification
            gap: 2
        });
    },
    confirm: function (message, okCallback) {
        bootbox.confirm({
            message: message,
            buttons: {
                confirm: {
                    label: 'Đồng ý',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'Hủy',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    okCallback();
                }
            }
        });
    },
    dateFormatJson : function (datetime){
        if (datetime == null) return "";
        var date = new Date(datetime);
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var year = date.getFullYear();
        if (month < 10) month = "0" + month;
        if (day < 10) day = "0" + day;
        return day + "/" + month + "/" + year;

    },
    dateTimeFormatJson: function(datetime) {
        if (datetime == null) return "";
        var date = new Date(datetime);
        var month = date.getMonth() + 1;
        var day = date.getDate();
        var year = date.getFullYear();
        var hour = date.getHours();
        var minute = date.getMinutes();
        var second = date.getSeconds();
        if (month < 10) month = "0" + month;
        if (day < 10) day = "0" + day;
        if (hour < 10) hour = "0" + hour;
        if (minute < 10) minute = "0" + minute;
        if (second < 10) second = "0" + second;
        return day + "/" + month + "/" + year + " " + hour + ":" + minute + ":" + second;
    },
    startLoading: function() {
        if ($(".dv-loading").length > 0) {
            $('.dv-loading').removeClass('hide');
        }
    },
    stopLoading: function() {
        if ($(".dv-loading").length > 0) {
            $('.dv-loading').addClass('hide');
        }
    },
    getStatus: function(status) {
        if (status == 1) return '<span class="badge bg-green">Kích hoạt</span>';
        else  return '<span class="badge bg-red">Không kích hoạt</span>';
    },
    formatNumber: function(number,precision){
        if (!isNumber(number)) return number.toString();

        var a = number.toFixed(precision).split('.');
        a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, "$&,");
        return a.join(".");
    },
    unflatten: function(arr) {
        var map = {};
        var roots = [];
        for (var i = 0; i < arr.length; i++) {
            var node = arr[i];
            node.children = [];
            map[node.id] = i; // use map to look-up the parents
        }
        for (var i = 0; i < arr.length; i++) {
            var node = arr[i];
            if (node.ParentId != null && map[node.ParentId] !== undefined) {
                arr[map[node.ParentId]].children.push(node);
            } else {
                roots.push(node);
            }
        }
        return roots;
    },
    addToken: function (xhr, options) {
        if (options.type && (options.type.toUpperCase() == "POST" || options.type.toUpperCase() == "PUT")) {
            var token = $('#formLogin').find('input[name="__RequestVerificationToken"]').val();
            console.log('Token:', token); // Thêm dòng này
            if(token) xhr.setRequestHeader("RequestVerificationToken", token);
        }
    }
}

// Đăng ký sự kiện ajaxSend để tự động thêm AntiForgeryToken cho mọi AJAX request
$(document).ajaxSend(function (e, xhr, options) {
    tedu.addToken(xhr, options);
});
