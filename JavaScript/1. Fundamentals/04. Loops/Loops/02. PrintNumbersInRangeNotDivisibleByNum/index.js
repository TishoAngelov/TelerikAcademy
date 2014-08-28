var numbersToPrint = 100,
    firstDivider = 3,
    secondDivider = 7,
    numDivisibleAtSameTimeBy = firstDivider * secondDivider;

for (var i = 1; i <= numbersToPrint; i++) {
    if (Math.floor(i % numDivisibleAtSameTimeBy) !== 0) {
        console.log(i);
    }
}