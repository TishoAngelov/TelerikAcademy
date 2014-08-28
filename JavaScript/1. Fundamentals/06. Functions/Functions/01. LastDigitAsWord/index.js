var number = 1231;

function lastDigitAsWord(number) {
    'use strict';

    var numberAsString = number.toString();

    switch (numberAsString[numberAsString.length - 1]) {
    case '0':
        return 'zero';
    case '1':
        return 'one';
    case '2':
        return 'two';
    case '3':
        return 'three';
    case '4':
        return 'four';
    case '5':
        return 'five';
    case '6':
        return 'six';
    case '7':
        return 'seven';
    case '8':
        return 'eigth';
    case '9':
        return 'nine';
    default:
        return 'error';
    }
}

console.log('Number: %d, Last digit: %s', number, lastDigitAsWord(number));