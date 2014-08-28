var expression1 = '((a+b)/5-d)',
    expression2 = ')(a+b))';

function areBracketsCorrect(expression) {
    'use strict';
    var bracketsCount = 0,
        i;

    for (i = 0; i < expression.length; i += 1) {
        if (expression[i] === '(') {
            bracketsCount += 1;
        } else if (expression[i] === ')') {
            bracketsCount -= 1;
        }

        if (bracketsCount < 0) {
            return false;
        }
    }

    return true;
}

console.log('%s has correct brackets - %s.',
    expression1, areBracketsCorrect(expression1));
console.log('%s has correct brackets - %s.',
    expression2, areBracketsCorrect(expression2));