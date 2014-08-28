var first = 5,
    second = 3,
    temp;

console.log('First num = %d, Second num = %d', first, second);

if (first > second) {
    temp = second;
    second = first;
    first = temp;

    console.log('Values are exchanged! First num = %d, Second num = %d', first, second);
} else {
    console.log('There is no need to exchange the values!');
}