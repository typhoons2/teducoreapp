var loginController = function () {
    this.initialize = function () {
        registerEvents();
    }
    
    var registerEvents = function () {
        $("#btnLogin").on("click", function (e) {
            e.preventDefault();
            var user = $("#txtUserName").val();
            var pass = $("#txtPassword").val();
            login(user, pass);
        });
    }

    var login = function (user, pass) {
        $.ajax({
            type: "POST",
            data: {
                UserName: user,  
                Password: pass
            },
            dataType: "json",
            url:"/admin/login/authen",
            success: function (response) {
                if (response.success) {
                    window.location.href = "/Admin/Home/Index";
                } else {
                    tedu.notify("Đăng nhập không đúng", "error");
                }
            },
        });
    }
}                           