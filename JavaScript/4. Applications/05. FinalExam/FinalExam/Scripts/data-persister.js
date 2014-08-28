/// <reference path="libs/class.js" />
define(['http-requester'], function (HttpRequester) {
    var DataPersister;

    DataPersister = (function () {
        var username = localStorage.getItem("username"),
            sessionKey = localStorage.getItem("sessionKey");

        function saveUserData(userData) {
            localStorage.setItem("username", userData.username);
            localStorage.setItem("sessionKey", userData.sessionKey);
            username = userData.username;
            sessionKey = userData.sessionKey;
        }
        function clearUserData() {
            localStorage.removeItem("username");
            localStorage.removeItem("sessionKey");
            username = "";
            sessionKey = "";
        }

        var MainPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl;

                this.user = new UserPersister(this.rootUrl);
                this.auth = new AuthPersister(this.rootUrl);
                this.post = new PostPersister(this.rootUrl);
            },
            isUserLoggedIn: function () {
                var isLoggedIn = username != null && sessionKey != null;
                return isLoggedIn;
            },
            username: function () {
                return username;
            }
        });

        var UserPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "/user";
            },
            register: function (user) {
                var url = this.rootUrl;
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };
                return HttpRequester.postJson(url, userData);
            },
            logout: function () {
                var url = this.rootUrl;

                return HttpRequester.put(url)
                    .then(function (response) {
                        clearUserData();
                    });
            }
        });

        var AuthPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "/auth";
            },
            login: function (user) {
                var url = this.rootUrl;
                var userData = {
                    username: user.username,
                    authCode: CryptoJS.SHA1(user.username + user.password).toString()
                };
                return HttpRequester.postJson(url, userData)
                .then(function (data) {
                    saveUserData(data);
                });
            }
        });

        var PostPersister = Class.create({
            init: function (rootUrl) {
                this.rootUrl = rootUrl + "/post";
            },
            getAll: function () {
                var url = this.rootUrl;

                return HttpRequester.getJson(url);
            }
        });

        return {
            get: function (url) {
                return new MainPersister(url);
            }
        };
    }());

    return DataPersister;
});