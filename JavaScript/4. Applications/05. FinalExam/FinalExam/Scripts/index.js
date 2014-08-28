/// <reference path="libs/require-2.1.14.js" />
/// <reference path="ui-controller.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="libs/sammy-0.7.5.js" />
(function () {
    'use strict';

    require.config({
        paths: {
            'jquery': 'libs/jquery-2.1.1',
            'mustache': 'libs/mustache',
            'Q': 'libs/q-1.0.1',
            'sammy': 'libs/sammy-0.7.5',
            'underscore': 'libs/underscore-1.6.0'
        },
        shim: {
            'underscore': {
                exports: '_'
            }
        }
    });

    require(['sammy', 'jquery', 'utils', 'ui-controller'],
        function (Sammy, $, Utils, UI) {
            var app = Sammy('#main-content', function () {
                this.get('#/home', function () {
                    UI.loadHomePage('#main-content');
                });
                
                this.get('#/user/register', function () {
                    UI.loadRegisterPage('#main-content');
                });

                this.get('#/auth/login', function () {
                    UI.loadLoginPage('#main-content');
                });

                this.get('#/post', function () {
                    UI.loadAllPostsPage('#main-content');
                });

                this.get('#/app-page', function () {
                    UI.loadAppPage('#main-content');
                });

                this.get('#/user/logout', function () {
                    UI.loadLogoutPage();
                });
            });

            $(function () {
                app.run('#/home');
            });
        });
}());