var givenSequence = [2, 1, 1, 2, 3, 3, 2, 2, 2, 1],
    currEqualSequence = [],
    maximalEqualSequence = [];

console.log('Given sequence: %s', givenSequence.join(', '));

for (var i = 0; i < givenSequence.length - 1; i++) {
    if (givenSequence[i] === givenSequence[i + 1]) {
        currEqualSequence.push(givenSequence[i + 1]);
    } else {
        currEqualSequence = [givenSequence[i + 1]];
    }

    if (currEqualSequence.length > maximalEqualSequence.length) {
        maximalEqualSequence = currEqualSequence;
    }
}

console.log('Maximal equal sequence: %s', maximalEqualSequence.join(', '));