var givenArr = [1, 2, 7, 9, 13, 18, 22, 29, 33, 55, 61, 62],
    number = 33,
    numberIndex;

function binarySearch(intArray, numberToSearch) {
    'use strict';

    var startSearch = 0,
        endSearch = intArray.length - 1,
        middle,
        counter = 0,
        i;

    for (i = 0; i < intArray.length; i++) {
        if (numberToSearch === intArray[i]) {
            counter++;
        }
    }

    if (counter === 0) {
        return -1;
    } else {
        while (startSearch <= endSearch) {
            middle = Math.floor((startSearch + endSearch) / 2);

            if (intArray[middle] === numberToSearch) {
                return middle;
            }

            if (intArray[middle] < numberToSearch) {
                startSearch = middle + 1;
            }

            if (intArray[middle] > numberToSearch) {
                endSearch = middle - 1;
            }
        }
    }
}

console.log('Given array: ' + givenArr.join(', '));

numberIndex = binarySearch(givenArr, number);

if (numberIndex < 0) {
    console.log('There is no such number (%d) in the given array!', number);
} else {
    console.log('The number (%d) is at index: %d', number, numberIndex);
}