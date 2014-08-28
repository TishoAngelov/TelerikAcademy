define([], function () {
    'use strict';

    var ClassName;

    ClassName = (function () {
        function ClassName(val1) {
            this.prop1(val1);
        }

        ClassName.prototype = {
            prop1: function (propValue) {
                if (propValue) {
                    // VALDIATIONS !!!
                    this._prop1 = propValue;
                } else {
                    return this._prop1;
                }
            }
        };

        return ClassName;
    }());

    return ClassName;
});