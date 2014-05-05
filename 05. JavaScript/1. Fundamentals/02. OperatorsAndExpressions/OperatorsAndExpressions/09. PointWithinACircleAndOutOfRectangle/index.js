// Point coordinates
var pointCoordinateX = 0.9,
    pointCoordinateY = 0.9,
    pointRadius = Math.sqrt((pointCoordinateX * pointCoordinateX) + (pointCoordinateY * pointCoordinateY));

// Circle coordinates
var circleCoordinateX = 1.1,
    circleCoordinateY = 3,
    circleRadius = Math.sqrt((circleCoordinateX * circleCoordinateX) + (circleCoordinateY * circleCoordinateY));

// Rectangle coordinates
var rectXLeft = -1,
    rectXRight = 5,
    rectWidth = rectXRight - rectXLeft,
    rectHeight = 2,
    rectYTop = 1,
    rectYBottom = rectYTop - rectHeight;

// Conditions
var isWithinACircle = pointRadius <= circleRadius ? true : false,
    isOutOfRectangle = (pointCoordinateX < rectXLeft) || (pointCoordinateX > rectXRight) ||
        (pointCoordinateY > rectYTop) || (pointCoordinateY < rectYBottom) ? true : false;
 
if (isWithinACircle && isOutOfRectangle)
{
    console.log("Is your point (%f, %f) withing the cricle K(%f, %f) AND out of the rectangle\n" +
        "R(top = %f; left = %f; width = %f; height = %f) -> True.", pointCoordinateX, pointCoordinateY, circleCoordinateX,
        circleCoordinateY, rectYTop, rectXLeft, rectWidth, rectHeight);
}
else
{
    console.log("Is your point (%f, %f) withing the cricle K(%f, %f) AND out of the rectangle\n" +
        "R(top = %f, left = %f, width = %f, height = %f) -> False.", pointCoordinateX, pointCoordinateY, circleCoordinateX,
        circleCoordinateY, rectYTop, rectXLeft, rectWidth, rectHeight);
}

console.log("Is withing a circle? -> %s.", isWithinACircle);
console.log("Is out of rectangle? -> %s.", isOutOfRectangle);