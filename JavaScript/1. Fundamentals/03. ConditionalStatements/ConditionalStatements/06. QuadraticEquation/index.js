var a = 1,
    b = -3,
    c = -4,
    discriminant = b * b + (-4) * a * c,
    rootX1 = (-b - Math.sqrt(discriminant)) / (2 * a),
    rootX2 = (-b + Math.sqrt(discriminant)) / (2 * a);

console.log('%fx^2 + %fx + %f = 0', a, b, c);
console.log('D = %f', discriminant);

if (discriminant > 0) {
    console.log('The roots are: x1 = %f, x2 = %f.', rootX1, rootX2);
} else if (discriminant === 0) {
    console.log('The roots are: x1 = x2 = %f.', rootX1);
} else {
    console.log('There are no real roots!');
}