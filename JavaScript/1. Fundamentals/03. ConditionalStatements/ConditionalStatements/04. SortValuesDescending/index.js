var firstNum = 5,
    secondNum = 3,
    thirdNum = 6,
    min,
    mid,
    max;

if (firstNum > secondNum) {
    if (firstNum < thirdNum) {
        max = thirdNum;
        mid = firstNum;
        min = secondNum;
    } else {
        if (secondNum > thirdNum) {
            max = firstNum;
            mid = secondNum;
            min = thirdNum;
        } else {
            max = firstNum;
            mid = thirdNum;
            min = secondNum;
        }
    }
} else {
    if (secondNum < thirdNum) {
        max = thirdNum;
        mid = secondNum;
        min = firstNum;
    } else {
        if (firstNum > thirdNum) {
            max = secondNum;
            mid = firstNum;
            min = thirdNum;
        } else {
            max = secondNum;
            mid = thirdNum;
            min = firstNum;
        }
    }
}

console.log("%f >= %f >= %f", max, mid, min);
