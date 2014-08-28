var num1 = 2,
    num2 = -2,
    num3 = 12,
    minusCounter = 0;

console.log('Numbers: %d, %d, %d', num1, num2, num3);

if (num1 < 0) {
    minusCounter++;
}

if (num2 < 0) {
    minusCounter++;
}

if (num3 < 0) {
    minusCounter++;
}

if (minusCounter % 2 === 0) {
    console.log('The sign of the product is plus.');
} else {
    console.log('The sign of the product is minus.');
}