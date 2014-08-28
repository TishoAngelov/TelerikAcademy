var numberPosition = 2,
    givenArray = [1, 2, 3, 2, 1, 5, 1];

function numberBiggerThanTwoNeighbours(numberPosition, intArray) {
    'use strict';

    var isBigger = false;

    if (numberPosition === 0 || numberPosition === intArray.length - 1) {
        return false;
    }

    if (givenArray[numberPosition] > givenArray[numberPosition - 1] &&
            givenArray[numberPosition] > givenArray[numberPosition + 1]) {
        return true;
    }

    return isBigger;
}

function printResultOnConsole() {
    'use strict';

    console.log('Given array: %s', givenArray.join(', '));
    console.log('Position of number to check: %d', numberPosition);
    console.log('Number is bigger than its two neighbours: %s',
        numberBiggerThanTwoNeighbours(numberPosition, givenArray));
}
