var givenArray = [1, 1, 1, 5, 1, 1, 1, 1],
    numberToRemove = 1;

Array.prototype.remove = function removeElementFromArray(element) {
    'use strict';

    for (var i = 0; i < this.length; i++) {
        if (this[i] === element) {
            this.splice(i, 1);
            i--;
        }
    }
};

console.log('Given array: %s (length %d)', givenArray.join(', '), givenArray.length);

givenArray.remove(numberToRemove);
console.log('The array after removing the number "%d": %s (length %d)',
    numberToRemove, givenArray.join(', '), givenArray.length);
