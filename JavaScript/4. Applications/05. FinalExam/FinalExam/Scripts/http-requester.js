/// <reference path="libs/jquery-2.1.1.js" />
/// <reference path="libs/q-1.0.1.js" />
define(['jquery', 'Q'], function ($, Q) {
    'use strict';

    var HttpRequester;

    HttpRequester = (function () {
        var promiseAjaxRequest,
            promiseAjaxRequestGet,
            promiseAjaxRequestPost,
            promiseAjaxRequestPut;

        promiseAjaxRequest = function (url, type, data) {
            var defered = Q.defer();

            if (data) {
                data = JSON.stringify(data);
            }

            $.ajax({
                url: url,
                type: type,
                data: data,
                timeout: 5000,
                contentType: 'application/json',
                success: function (responseData) {
                    defered.resolve(responseData);
                },
                error: function (errorData) {
                    defered.reject(errorData);
                }
            });

            return defered.promise;
        };

        promiseAjaxRequestGet = function (url) {
            return promiseAjaxRequest(url, 'GET');
        };

        promiseAjaxRequestPost = function (url, data) {
            return promiseAjaxRequest(url, 'POST', data);
        };

        promiseAjaxRequestPut = function (url) {
            var defered = Q.defer();

            $.ajax({
                url: url,
                type: 'PUT',
                data: true,
                beforeSend: function (xhr) { xhr.setRequestHeader('X-SessionKey', localStorage.getItem("sessionKey")); },
                timeout: 5000,
                contentType: 'application/json',
                success: function (responseData) {
                    defered.resolve(responseData);
                },
                error: function (errorData) {
                    defered.reject(errorData);
                }
            });

            return defered.promise;
        };

        return {
            getJson: promiseAjaxRequestGet,

            postJson: promiseAjaxRequestPost,

            put: promiseAjaxRequestPut
        };
    }());

    return HttpRequester;
});
