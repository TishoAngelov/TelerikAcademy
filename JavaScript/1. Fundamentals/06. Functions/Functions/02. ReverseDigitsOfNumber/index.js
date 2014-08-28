var number = 4513;

function reverseDigits(number) {
    'use strict';

    var numberAsString = number.toString(),
        reversedNumber = '',
        i;

    for (i = numberAsString.length - 1; i >= 0; i -= 1) {
        reversedNumber += numberAsString[i];
    }

    return parseInt(reversedNumber, 10);
}

console.log('Number: %d', number);
console.log('Reversed number: %d', reverseDigits(number));