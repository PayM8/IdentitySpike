site.page = function () {

    var successCallback = function (jsonData) {
        site.console.log("Successfully sent choice:");
        site.console.log(jsonData.responseText);

        $("#output").html(jsonData.responseText);
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

        return {
            submitOption: submitOption
        };
    }();

    var submit = function () {
        dataAcces.submitOption(successCallback);
    };

    return {
        links: {},
        submit: submit,
        dataAcces: dataAcces
    };
}();