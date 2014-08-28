var firstCharArr = ['a', 'b', 'c'],
    secondCharArr = ['a', 'b', 'c'],
    areArraysEqual = true;

console.log('First char array: %s', firstCharArr.join(', '));
console.log('Second char array: %s', secondCharArr.join(', '));

if (firstCharArr.length !== secondCharArr.length) {
    areArraysEqual = false;
} else {
    for (var i = 0; i < firstCharArr.length; i++) {
        if (firstCharArr[i] !== secondCharArr[i]) {
            areArraysEqual = false;

            break;
        }
    }
}

console.log('The two char arrays are equal - %s', areArraysEqual);