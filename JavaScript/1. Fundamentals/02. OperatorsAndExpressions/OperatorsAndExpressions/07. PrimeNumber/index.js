var num1 = 3,
    num2 = 4;

function isPrime(number) {
    'use strict';

    var start = 2;

    while (start <= Math.sqrt(number)) {
        if (number % start === 0) {
            return false;
        }

        start++;
    }

    return true;
}

console.log('Is %d prime? - %s', num1, isPrime(num1));
console.log('Is %d prime? - %s', num2, isPrime(num2));