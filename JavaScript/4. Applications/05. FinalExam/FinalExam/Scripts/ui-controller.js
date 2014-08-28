define(['http-requester', 'jquery', 'mustache', 'data-persister'], function (HttpRequester, $, Mustache, Data) {
    var UI;

    UI = (function () {

        var rootUrl = 'http://localhost:3000';
        var mainPersister = Data.get(rootUrl);

        var loadPage = function (selector, templateUrl, data) {
            HttpRequester.getJson(templateUrl)
                .then(function (res) {
                    var output = Mustache.render(res, data);
                    $(selector).html(output);
                    attachUIEventHandlers(selector);
                }, function (err) {
                    console.log(err)
                });
        };

        var attachUIEventHandlers = function (selector) {
            var wrapper = $(selector);

            wrapper.on('click', '#btn-register', function () {
                var user = {
                    username: $(selector).find("#tb-register-username").val(),
                    password: $(selector + " #tb-register-password").val()
                }

                mainPersister.user.register(user)
                    .then(function (response) {
                        alert('Registration was succesful!');
                        window.location = 'http://localhost:2393/index.html#/home';
                    });

                return false;
            });

            wrapper.on('click', '#btn-login', function () {
                var user = {
                    username: $(selector).find("#tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                mainPersister.auth.login(user)
                    .then(function (response) {
                        window.location.hash = '#/app-page';
                    }, function (err) {
                        console.log(err)
                    });

                return false;
            });
        }

        return {
            loadHomePage: function (selector) {
                if (mainPersister.isUserLoggedIn()) {
                    window.location.hash = '#/app-page';
                } else {
                    loadPage(selector, '../View/home-partial.html');
                }
            },
            loadRegisterPage: function (selector) {
                if (mainPersister.isUserLoggedIn()) {
                    window.location.hash = '#/app-page';
                } else {
                    loadPage(selector, '../View/register-partial.html');
                }
            },
            loadLoginPage: function (selector) {
                if (mainPersister.isUserLoggedIn()) {
                    window.location.hash = '#/app-page';

                } else {
                    loadPage(selector, '../View/login-partial.html');
                }
            },
            loadAllPostsPage: function (selector) {

                mainPersister.post.getAll().then(function (response) {
                    loadPage(selector, '../View/all-posts-partial.html', response);
                });

            },
            loadAppPage: function (selector) {
                if (mainPersister.isUserLoggedIn()) {
                    loadPage(selector, '../View/app-partial.html');
                } else {
                    window.location.hash = '#/home';
                }
            },
            loadLogoutPage: function () {
                mainPersister.user.logout()
                    .then(function () {
                        window.location.hash = '#/home';
                    }, function (err) {
                        console.log(err);
                    });
            },
        };
    }());

    return UI;
});