var obj = [1, 1, 1, 1],
    propToCheck = 'length',
    hasProp;

function hasProperty(obj, prop) {
    'use strict';

    if (obj[prop] === undefined) {
        return false;
    }

    return true;
}

hasProp = hasProperty(obj, propToCheck);

console.log('The %s has property "%s" - %s', obj, propToCheck, hasProp);