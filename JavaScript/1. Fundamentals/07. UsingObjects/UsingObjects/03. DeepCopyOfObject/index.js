var obj = {
        name: 'Ivan'
    },
    clonedObj;

function deepCopy(obj) {
    'use strict';

    var result = {},
        prop;

    for (prop in obj) {
        if (typeof obj[prop] === "object" &&
                obj[prop] !== null) {
            result[prop] = result[prop] || {};
            arguments.callee(result[prop], obj[prop]);
        } else {
            result[prop] = obj[prop];
        }
    }

    return result;
}

console.log('Given object name - %s', obj.name);

console.log('Cloning the given object...');
clonedObj = deepCopy(obj);

obj.name = 'Pesho';
console.log('Setting the name of the given object to: %s', obj.name);

console.log('The name of the cloned object: %s', clonedObj.name);