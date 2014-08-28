var num = 1732,
    checkDigit = 7,
    thirdDigit;

thirdDigit = Math.floor(num / 100) % 10;

console.log('%d - %s', num, thirdDigit === checkDigit);