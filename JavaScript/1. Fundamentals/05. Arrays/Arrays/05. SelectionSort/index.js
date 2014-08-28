var givenArr = [34, 17, 23, 35, 1, 45, 9],
    currMinNumberIndex,
    numberToSwap;

console.log('Given array: %s', givenArr.join(', '));
console.log('Sorting...');

for (var i = 0; i < givenArr.length - 1; i++) {
    currMinNumberIndex = i;

    for (var j = i + 1; j < givenArr.length; j++) {
        if (givenArr[j] < givenArr[currMinNumberIndex]) {
            currMinNumberIndex = j;
        }
    }

    if (givenArr[i] > givenArr[currMinNumberIndex]) {
        numberToSwap = givenArr[currMinNumberIndex];
        givenArr[currMinNumberIndex] = givenArr[i];
        givenArr[i] = numberToSwap;
    }

    console.log('%d. %s', i + 1, givenArr.join(', '));
}