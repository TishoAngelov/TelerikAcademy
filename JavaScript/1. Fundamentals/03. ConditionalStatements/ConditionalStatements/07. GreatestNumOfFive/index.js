var num1 = 3,
    num2 = 1,
    num3 = 10,
    num4 = 5,
    num5 = 9,
    greatestNum = num1;

if (num2 > greatestNum) {
    greatestNum = num2;
}

if (num3 > greatestNum) {
    greatestNum = num3;
}

if (num4 > greatestNum) {
    greatestNum = num4;
}

if (num5 > greatestNum) {
    greatestNum = num5;
}

console.log('Numbers: %d, %d, %d, %d, %d', num1, num2, num3, num4, num5);
console.log('Greatest number: %d', greatestNum);