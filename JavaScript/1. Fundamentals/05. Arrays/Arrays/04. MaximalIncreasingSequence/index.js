var givenSequence = [3, 2, 3, 4, 2, 2, 4],
    currIncreasingSequence = [],
    maximalIncreasingSequence = [];

console.log('Given sequence: %s', givenSequence.join(', '));

for (var i = 0; i < givenSequence.length - 1; i++) {
    if (givenSequence[i] + 1 === givenSequence[i + 1]) {
        currIncreasingSequence.push(givenSequence[i + 1]);
    } else {
        currIncreasingSequence = [givenSequence[i + 1]];
    }

    if (currIncreasingSequence.length > maximalIncreasingSequence.length) {
        maximalIncreasingSequence = currIncreasingSequence;
    }
}

console.log('Maximal increasing sequence: %s', maximalIncreasingSequence.join(', '));