site.page = function () {

    var submitOptionSuccess = function (jsonData) {
        site.console.log("Successfully sent choice:");
        site.console.log(jsonData.responseText);

        $("#output").html(jsonData.responseText);
    };

    var userLoginSuccess = function (jsonData) {
        site.console.log("Login response received:");
        site.console.log(jsonData.responseText);

        $("#loginContainer").html(jsonData.responseText);
    };

    var dataAcces = function() {
        var submitOption = function (successCallback) {
            var choice = $("input[name='multichoice']:checked").val();

            if (choice === undefined || choice === "") {
                return;
            }

            var data = {
                option: choice
            };

            site.common.ajax.submitAjaxGetHtml(site.page.links.submitOption, data, successCallback, successCallback);
        };

        var userLogin = function (successCallback) {
            var userName = $("input[name='Username']").val();
            var password = $("input[name='Password']").val();

            if (!userName || !password) {
                return;
            }

            var data = {
                userName: userName,
                password: password
            };

            site.common.ajax.submitAjaxGetHtml(site.page.links.userLogin, data, successCallback, successCallback);
        };

        return {
            submitOption: submitOption,
            userLogin: userLogin
        };
    }();

    var submit = function () {
        dataAcces.submitOption(submitOptionSuccess);
    };

    var userLogin = function () {
        dataAcces.userLogin(userLoginSuccess);
    };

    return {
        links: {},
        submit: submit,
        dataAcces: dataAcces,
        userLogin: userLogin
    };
}();