var loginController = function () {
    this.initialize = function () {
        registerEvents();
        validateForm();
    }
    
    var registerEvents = function () {
        $("#btnLogin").on("click", function (e) {
            e.preventDefault();
            if ($("#formLogin").valid()) {
                var user = $("#txtUserName").val();
                var pass = $("#txtPassword").val();
                login(user, pass);
            }
        });
    }

    var validateForm = function () {
        $("#formLogin").validate({
            errorClass: "text-danger",
            errorElement: "span",
            rules: {
                userName: {
                    required: true,
                    minlength: 3,
                    maxlength: 50,
                    regex: /^[a-zA-Z0-9_]+$/
                },
                password: {
                    required: true,
                    minlength: 6,
                    maxlength: 100
                }
            },
            messages: {
                userName: {
                    required: "Vui lòng nhập tên đăng nhập",
                    minlength: "Tên đăng nhập phải từ 3-50 ký tự",
                    maxlength: "Tên đăng nhập phải từ 3-50 ký tự",
                    regex: "Tên đăng nhập chỉ được chứa chữ cái, số và dấu gạch dưới"
                },
                password: {
                    required: "Vui lòng nhập mật khẩu",
                    minlength: "Mật khẩu phải từ 6-100 ký tự",
                    maxlength: "Mật khẩu phải từ 6-100 ký tự"
                }
            }
        });

        // Thêm custom validator cho regex
        $.validator.addMethod("regex", function(value, element, regexp) {
            var re = new RegExp(regexp);
            return this.optional(element) || re.test(value);
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
            error: function (xhr, status, error) {
                if (xhr.status === 400) {
                    var response = JSON.parse(xhr.responseText);
                    if (response.errors) {
                        var errors = response.errors;
                        if (errors.UserName) {
                            $("#userName-error").text(errors.UserName[0]);
                        }
                        if (errors.Password) {
                            $("#password-error").text(errors.Password[0]);
                        }
                    }
                }
                tedu.notify("Có lỗi xảy ra", "error");
            }
        });
    }
}                           