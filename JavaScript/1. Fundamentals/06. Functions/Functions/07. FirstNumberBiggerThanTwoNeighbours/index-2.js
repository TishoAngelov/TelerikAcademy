var givenArray = [1, 1, 3, 1, 1, 5, 1];

function indexOfFirstNumberBiggerThanTwoNeighbours(intArray) {
    'use strict';

    var i;

    for (i = 0; i < intArray.length; i++) {
        if (numberBiggerThanTwoNeighbours(i, intArray)) {
            return i;
        }
    }

    return -1;
}

console.log('Given array: %s', givenArray.join(', '));
console.log('Index of the first element in array that is bigger than its neighbors: %s',
    indexOfFirstNumberBiggerThanTwoNeighbours(givenArray));