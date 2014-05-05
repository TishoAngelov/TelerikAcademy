var pointName = 'P',
    pointCoordinateX = 1.23,
    pointCoordinateY = 2.22,
    pointRadius = Math.sqrt((pointCoordinateX * pointCoordinateX) + (pointCoordinateY * pointCoordinateY)),
    circleName = 'C',
    circleCoordinateX = 0,
    circleCoordinateY = 5,
    circleRadius = Math.sqrt((circleCoordinateX * circleCoordinateX) + (circleCoordinateY * circleCoordinateY)),
    isWithinACircle = pointRadius <= circleRadius ? true : false;

console.log('Is your point %s(%f, %f) within the circle %s(%f, %f) ??? -> %s', pointName, pointCoordinateX,
                    pointCoordinateY, circleName, circleCoordinateX, circleCoordinateY, isWithinACircle);