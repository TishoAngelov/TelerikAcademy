/// <reference path="../_reference.js" />

function Figure(colour, type, fieldPositionX, fieldPositionY) {
    this.type = type;
    this.colour = colour;
    var figureName = colour + type;
    this.image=new Kinetic.Image({
        x: BORDER_SIZE+FIELD_SIZE*fieldPositionX,
        y: BORDER_SIZE + FIELD_SIZE * fieldPositionY,
        image: IMAGES[figureName],
        width: FIELD_SIZE,
        height: FIELD_SIZE
    });
    this.isMoved = false;
}
//This function changes the ONLY Image position of the figure 
Figure.prototype.moveImage = function (fieldPositionX, fieldPositionY) {
    var time = 500;
    var steps = 50;
    var stepX = ((fieldPositionX * FIELD_SIZE + BORDER_SIZE) - this.image.x()) / steps;
    var stepY = ((fieldPositionY * FIELD_SIZE + BORDER_SIZE) - this.image.y()) / steps;
    var timeInterval = time / steps;
    this.image.moveTo(movingFigureLayer);
    stepDrawer(stepX, stepY, steps, this, timeInterval);
    function stepDrawer(stepX, stepY, stepNumber, figure, interval) {
        figure.image.move({
            x: stepX,
            y: stepY
        })
        movingFigureLayer.draw();
        if (stepNumber>1) {
            setTimeout(function () {
                stepDrawer(stepX, stepY, stepNumber - 1, figure, interval)
            }, interval)
        } else {
            figure.image.moveTo(figureLayer);
            movingFigureLayer.draw();
            figureLayer.draw();
        }
    }
}
Figure.prototype.deleteImage = function () {
    this.image.destroy();
}