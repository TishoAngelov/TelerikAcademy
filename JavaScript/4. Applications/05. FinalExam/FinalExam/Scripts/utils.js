define(['http-requester', 'jquery'], function (HttpRequester, $) {
    return {
        displayError: function (error) {
            console.log(error);
        },

        renderHtmlTemplateAndLoadItIn: function (selector, url, data) {
            HttpRequester.getJson(url)
                .then(function (res) {
                    var output = Mustache.render(res, view);

                    $("#main-content").html(output);
                }, function (err) {
                    console.log(err)
                });
        }
    };
});