var objects = [document, window, navigator],
    objProperties = [];

function findSmallestAndLargestProperty(obj) {
    'use strict';

    var smallest = 'zzzzz',
        largest = 'aaaaaa',
        result = [],
        property;

    for (property in obj) {
        if (property < smallest) {
            smallest = property;
        }

        if (property > largest) {
            largest = property;
        }
    }

    result['smallest'] = smallest;
    result['largest'] = largest;

    return result;
}

for (var i in objects) {
    objProperties = findSmallestAndLargestProperty(objects[i]);
    console.log('The ' + objects[i] + '\'s smallest lexicographically property  is ' +
        objProperties['smallest']);
    console.log('The ' + objects[i] + '\'s biggest lexicographically property  is ' +
        objProperties['largest']);
    console.log();
}