var point1,
    point2,
    line1,
    line2,
    line3;

function Point(X, Y) {
    'use strict';

    this.X = X;
    this.Y = Y;
    this.toString = function pointToString() {
        return 'P(' + this.X + ', ' + this.Y + ')';
    };
}

function Line(firstPoint, secondPoint) {
    'use strict';

    this.firstPoint = firstPoint;
    this.secondPoint = secondPoint;
    this.toString = function lineToString() {
        return 'L(' + firstPoint.toString() + ', ' + secondPoint.toString() + ')';
    };
}

function distanceBetweenTwoPoints(point1, point2) {
    'use strict';

    var xd = point1.X - point2.X,
        yd = point1.Y - point2.Y;

    return Math.sqrt(xd * xd + yd * yd);
}

function linesCanFormTriangle(line1, line2, line3) {
    'use strict';

    var result = false,
        a = distanceBetweenTwoPoints(line1.firstPoint, line1.secondPoint),
        b = distanceBetweenTwoPoints(line2.firstPoint, line2.secondPoint),
        c = distanceBetweenTwoPoints(line3.firstPoint, line3.secondPoint);

    if ((a + b > c) && (a + c > b) && (b + c > a)) {
        result = true;
    } else {
        result = false;
    }

    return result;
}

point1 = new Point(3, 3);
point2 = new Point(1, 5);

console.log('The distance between the points: %s and %s is %s',
    point1.toString(),
    point2.toString(),
    distanceBetweenTwoPoints(point1, point2).toFixed(2));

line1 = new Line(new Point(0, 0), new Point(5, 0));
line2 = new Line(new Point(0, 0), new Point(0, 5));
line3 = new Line(new Point(0, 5), new Point(5, 0));

console.log('The three lines: %s, %s, %s can form triangle - %s',
    line1.toString(), line2.toString(), line3.toString(),
    linesCanFormTriangle(line1, line2, line3));