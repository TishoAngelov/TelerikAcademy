var someStr = 'asdf';

function reverseString(str) {
    'use strict';

    var reversedString = '',
        i;

    for (i = str.length - 1; i >= 0; i -= 1) {
        reversedString += str[i];
    }

    return reversedString;
}

console.log('Given string: %s', someStr);
console.log('Reversed string: %s', reverseString(someStr));