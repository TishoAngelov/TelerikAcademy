var arrOfInts = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3],
    mostFrequentNumberMatchCount = 0,
    mostFrequentNumber,
    currNumber,
    currMatchCount;

console.log('Given array of integers: %s', arrOfInts.join(', '));

for (var i = 0; i < arrOfInts.length; i++) {
    if (arrOfInts[i] === 'visited') {
        continue;
    } else {
        currNumber = arrOfInts[i];
        currMatchCount = 1;
    }

    for (var j = i + 1; j < arrOfInts.length; j++) {
        if (currNumber === arrOfInts[j]) {
            currMatchCount++;
            arrOfInts[j] = 'visited';
        }
    }
    
    if (mostFrequentNumberMatchCount < currMatchCount) {
        mostFrequentNumber = currNumber;
        mostFrequentNumberMatchCount = currMatchCount;
    }
}

console.log('Most frequent number: %d (%d times)',
    mostFrequentNumber, mostFrequentNumberMatchCount);