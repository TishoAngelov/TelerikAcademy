define(['tech-store-models/item'], function (Item) {
    'use strict';

    var Store;

    Store = (function () {
        function sortByName(item1, item2) {
            if (item1.name < item2.name)
                return -1;
            if (item1.name > item2.name)
                return 1;
            return 0;
        }

        function sortByPrice(item1, item2) {
            return item1.price - item2.price;
        }

        function returnItemsByTypes(items, types) {
            var itemsToReturn = [],
                currentItem,
                currentType,
                i,
                j;

            for (i = 0; i < types.length; i += 1) {
                currentType = types[i];

                for (j = 0; j < items.length; j += 1) {
                    currentItem = items[j];

                    if (currentItem.type === currentType) {
                        itemsToReturn.push(currentItem);
                    }
                }
            }

            return itemsToReturn;
        }

        function Store(name) {
            if (name.length <= 6 || name.length >= 30) {
                throw {
                    message: 'Store name should have length between 6 and 30 characters.'
                };
            }

            this.name = name;
            this._items = [];
        }

        Store.prototype = {
            addItem: function (item) {
                if (!(item instanceof Item)) {
                    throw {
                        message: 'Invalid item for adding in store.'
                    };
                }

                this._items.push(item);

                return this;
            },
            getAll: function () {
                var itemsCopy;

                itemsCopy = this._items.slice(0);

                return itemsCopy.sort(sortByName);
            },
            getSmartPhones: function () {
                var types = [];

                types.push('smart-phone');

                return returnItemsByTypes(this._items.slice(0), types).sort(sortByName);
            },
            getMobiles: function () {
                var types = [];

                types.push('smart-phone');
                types.push('tablet');

                return returnItemsByTypes(this._items.slice(0), types).sort(sortByName);
            },
            getComputers: function () {
                var types = [];

                types.push('pc');
                types.push('notebook');

                return returnItemsByTypes(this._items.slice(0), types).sort(sortByName);
            },
            filterItemsByType: function (filterType) {
                var itemsToReturn = [],
                    currentItem,
                    i;

                for (i = 0; i < this._items.length; i += 1) {
                    currentItem = this._items[i];

                    if (currentItem.type === filterType) {
                        itemsToReturn.push(currentItem);
                    }
                }

                return itemsToReturn.sort(sortByName);
            },
            filterItemsByPrice: function (options) {
                var min,
                    max,
                    itemsToReturn = [];

                min = (options && options.min) || 0;
                max = (options && options.max) || Infinity;

                for (var i = 0; i < this._items.length; i += 1) {
                    if (this._items[i].price > min && this._items[i].price < max) {
                        itemsToReturn.push(this._items[i]);
                    }
                }

                return itemsToReturn.sort(sortByPrice);
            },
            filterItemsByName: function (partOfName) {
                var itemsToReturn = [],
                    currentItem,
                    i;

                for (i = 0; i < this._items.length; i++) {
                    currentItem = this._items[i];

                    if (currentItem.name.toLowerCase().indexOf(partOfName.toLowerCase()) !== -1) {
                        itemsToReturn.push(currentItem);
                    }
                }

                return itemsToReturn.sort(sortByName);
            },
            countItemsByType: function () {
                var result = [],
                    currentItem,
                    i;

                for (i = 0; i < this._items.length; i += 1) {
                    currentItem = this._items[i];

                    if (!result[currentItem.type.toString()]) {
                        result[currentItem.type.toString()] = 0;
                    }

                    result[currentItem.type.toString()] += 1;                  
                }

                return result;
            }
        };

        return Store;
    }());

    return Store;
});