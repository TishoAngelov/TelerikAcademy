var sequenceOfNumbers = [ -5, 1, 10, 3351, 33, 78, -20, 333 ],
    min = Number.MAX_VALUE,
    max = Number.MIN_VALUE;

console.log('Sequence of numbers: %s', sequenceOfNumbers.join(', '));

// Find the min and max number in the given sequence
for (var i in sequenceOfNumbers) {
    if (sequenceOfNumbers[i] < min) {
        min = sequenceOfNumbers[i];
    }

    if (sequenceOfNumbers[i] > max) {
        max = sequenceOfNumbers[i];
    }
}

console.log('min = %d, max = %d', min, max);