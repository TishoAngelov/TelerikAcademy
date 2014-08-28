var number = 5,
    givenArray = [1, 2, 3, 5, 5, 5, 5, 10, 16];

function countNumberOccurencesInArray(intNumber, intArray) {
    'use strict';

    var counter = 0,
        i;

    for (i = 0; i < intArray.length; i += 1) {
        if (intNumber === intArray[i]) {
            counter += 1;
        }
    }

    return counter;
}

console.log('Given array: %s', givenArray.join(', '));
console.log('The given number "%d" appears %d times in the array.',
    number, countNumberOccurencesInArray(number, givenArray));