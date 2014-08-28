var num1 = 1,
    num2 = 3,
    num3 = 2,
    biggestNum;

console.log('Numbers: %d, %d, %d', num1, num2, num3);

if (num1 > num2) {
    if (num1 > num3) {
        biggestNum = num1;
    } else {
        biggestNum = num3;
    }
} else {
    if (num2 > num3) {
        biggestNum = num2;
    } else {
        biggestNum = num3;
    }
}

console.log('The biggest number is: %d', biggestNum);