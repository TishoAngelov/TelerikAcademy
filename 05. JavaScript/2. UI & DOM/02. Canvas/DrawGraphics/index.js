function drawHouse() {
    'use strict';

    var canvas = document.getElementById('draw-pane'),
        context = canvas.getContext('2d'),
        windowWidth = 50,
        windowHeight = 30;

    context.fillStyle = 'white';
    context.rect(0, 0, canvas.width, canvas.height);
    context.fill();

    context.beginPath();

    context.fillStyle = 'rgb(151, 91, 91)';
    context.strokeStyle = 'black';
    context.lineWidth = 3;

    context.rect(10, 170, 290, 220);

    context.fill();
    context.stroke();

    context.lineTo(155, 10);
    context.lineTo(300, 170);
    context.closePath();
    context.fill();
    context.stroke();

    // Windows
    context.beginPath();

    context.fillStyle = 'black';

    context.rect(32, 197, windowWidth, windowHeight);
    context.rect(32, 197 + windowHeight + 3, windowWidth, windowHeight);
    context.rect(32 + windowWidth + 3, 197, windowWidth, windowHeight);
    context.rect(32 + windowWidth + 3, 197 + windowHeight + 3, windowWidth, windowHeight);

    context.rect(173, 197, windowWidth, windowHeight);
    context.rect(173, 197 + windowHeight + 3, windowWidth, windowHeight);
    context.rect(173 + windowWidth + 3, 197, windowWidth, windowHeight);
    context.rect(173 + windowWidth + 3, 197 + windowHeight + 3, windowWidth, windowHeight);

    context.rect(173, 287, windowWidth, windowHeight);
    context.rect(173, 287 + windowHeight + 3, windowWidth, windowHeight);
    context.rect(173 + windowWidth + 3, 287, windowWidth, windowHeight);
    context.rect(173 + windowWidth + 3, 287 + windowHeight + 3, windowWidth, windowHeight);

    context.fill();

    // Door
    context.beginPath();
    context.moveTo(43, 390);
    context.lineTo(43, 315);
    context.stroke();

    context.beginPath();
    context.moveTo(84, 390);
    context.lineTo(84, 301);
    context.stroke();

    context.beginPath();
    context.moveTo(123, 390);
    context.lineTo(123, 315);
    context.stroke();

    context.beginPath();
    context.arc(72, 358, 4, 0, 2 * Math.PI);
    context.stroke();

    context.beginPath();
    context.arc(95, 358, 4, 0, 2 * Math.PI);
    context.stroke();

    context.beginPath();
    context.bezierCurveTo(
        43, 315,
        84, 280,
        123, 315);
    context.stroke();

    // Chimney
    context.fillStyle = 'rgb(151, 91, 91)';

    context.beginPath();
    context.moveTo(212, 131);
    context.lineTo(212, 52);
    context.lineTo(244, 52);
    context.lineTo(244, 131);
    context.fill();
    context.stroke();

    context.beginPath();
    context.save();
    context.scale(1, 0.3);
    context.arc(228, 170, 16, 0, 2 * Math.PI);
    context.fill();
    context.stroke();
    context.restore();
}

function drawBicycle() {
    'use strict';

    var canvas = document.getElementById('draw-pane'),
        context = canvas.getContext('2d');

    context.fillStyle = 'white';
    context.rect(0, 0, canvas.width, canvas.height);
    context.fill();

    context.strokeStyle = 'rgb(51, 126, 144)';
    context.lineWidth = 3;

    context.beginPath();
    context.moveTo(150, 138);
    context.lineTo(193, 188);
    context.stroke();

    context.beginPath();
    context.fillStyle = 'white';
    context.arc(173, 164, 16, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.fillStyle = 'rgb(144, 202, 215)';

    context.beginPath();
    context.arc(68, 167, 56, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.beginPath();
    context.arc(295, 167, 56, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.beginPath();
    context.moveTo(295, 167);
    context.lineTo(276, 48);
    context.lineTo(310, 10);
    context.stroke();

    context.beginPath();
    context.moveTo(276, 48);
    context.lineTo(230, 65);
    context.stroke();

    context.beginPath();
    context.moveTo(68, 167);
    context.lineTo(173, 164);
    context.lineTo(280, 90);
    context.lineTo(140, 90);
    context.closePath();
    context.stroke();

    context.beginPath();
    context.moveTo(98, 65);
    context.lineTo(147, 65);
    context.stroke();

    context.beginPath();
    context.moveTo(173, 164);
    context.lineTo(123, 65);
    context.stroke();
}

function drawFace() {
    'use strict';

    var canvas = document.getElementById('draw-pane'),
        context = canvas.getContext('2d');

    context.fillStyle = 'white';
    context.rect(0, 0, canvas.width, canvas.height);
    context.fill();

    context.strokeStyle = 'rgb(51, 126, 144)';
    context.lineWidth = 3;
    context.fillStyle = 'rgb(144, 202, 215)';

    // Face
    context.beginPath();
    context.arc(95, 175, 72, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    // Nose
    context.beginPath();
    context.moveTo(80, 150);
    context.lineTo(65, 180);
    context.lineTo(80, 180);
    context.stroke();

    // Eyes
    context.beginPath();
    context.save();

    context.scale(1, 0.7);
    context.arc(52, 215, 10, 0, 2 * Math.PI);
    context.stroke();

    context.beginPath();
    context.arc(110, 215, 10, 0, 2 * Math.PI);
    context.stroke();

    context.restore();

    context.fillStyle = 'rgb(51, 126, 144)';
    context.save();

    context.beginPath();
    context.scale(0.7, 1);
    context.arc(70, 151, 4, 0, 2 * Math.PI);
    context.stroke();
    context.fill();
    
    context.beginPath();
    context.arc(152, 151, 4, 0, 2 * Math.PI);
    context.stroke();
    context.fill();

    context.restore();

    // Mouth
    context.beginPath();
    context.save();

    context.rotate(10 * Math.PI / 180);
    context.scale(1, 0.3);

    context.arc(110, 650, 30, 0, 2 * Math.PI);
    context.stroke();

    context.restore();

    // Hat
    context.fillStyle = 'rgb(57, 102, 147)';
    context.strokeStyle = 'black';
    context.lineWidth = 5;

    context.beginPath();

    context.save();
    context.scale(1, 0.3);

    context.arc(90, 345, 80, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.restore();
    context.save();
    context.lineWidth = 4;

    context.beginPath();

    context.scale(1, 0.4);
    context.arc(95, 210, 50, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.restore();
    context.lineWidth = 3;
    context.beginPath();

    context.moveTo(45, 85);
    context.lineTo(45, 25);
    context.lineTo(145, 25);
    context.lineTo(145, 85);
    context.fill();
    context.stroke();

    context.lineWidth = 4;
    context.save();
    context.beginPath();

    context.scale(1, 0.4);
    context.arc(95, 55, 50, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.restore();
}
