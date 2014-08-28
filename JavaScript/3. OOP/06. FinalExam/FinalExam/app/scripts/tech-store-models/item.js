define([], function () {
    'use strict';

    var Item;

    Item = (function () {
        function Item(type, name, price) {
            if (!(type === 'accessory' ||
                    type === 'smart-phone' ||
                    type === 'notebook' ||
                    type === 'pc' ||
                    type === 'tablet')
                    ) {
                throw {
                    message: 'Invalid item type.'
                };
            }
            this.type = type;
            //if (name.length <= 6 || name.length >= 40) {
            //    throw {
            //        message: 'Item name should have length between 6 and 40 characters.'
            //    };
            //}

            this.name = name;
            this.price = price;
        }

        return Item;
    }());

    return Item;
});