var canvas = document.getElementById('the-canvas'),
    context = canvas.getContext('2d'),
    startX = 50,
    startY = 30,
    updateX = 2,
    updateY = 2;

canvas.style.border = '3px solid black';
context.strokeStyle = 'black';
context.lineWidth = 3;
  
setInterval(function () {
    'use strict';

    context.fillStyle = 'white';
    context.beginPath();

    context.rect(0, 0, canvas.width, canvas.height);
    context.fill();

    startX += updateX;
    startY += updateY;

    if (startX + 20 >= canvas.width || startX - 20 <= 0) {
        updateX *= -1;
    }

    if (startY + 20 >= canvas.height || startY - 20 <= 0) {
        updateY *= -1;
    }

    context.fillStyle = 'red';

    context.beginPath();

    context.arc(startX, startY, 20, 0, 2 * Math.PI);
    context.fill();
    context.stroke();
}, 5);
