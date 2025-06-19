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
                    required: "Please enter username",
                    minlength: "Username must be between 3-50 characters",
                    maxlength: "Username must be between 3-50 characters",
                    regex: "Username can only contain letters, numbers and underscore"
                },
                password: {
                    required: "Please enter password",
                    minlength: "Password must be between 6-100 characters",
                    maxlength: "Password must be between 6-100 characters"
                }
            }
        });

        // Add custom validator for regex
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
                    tedu.notify("Invalid login credentials", "error");
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
                tedu.notify("An error occurred", "error");
            }
        });
    }
}                           