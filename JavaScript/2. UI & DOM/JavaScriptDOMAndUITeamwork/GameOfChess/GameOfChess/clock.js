/// <reference path="C:\Users\LDL\Documents\GitHub\Kenshi\GameOfChess\GameOfChess\scripts/kinetic.js" />
function Clock(containerSelector,time,onWhiteTimeOut,onBlackTimeOut) {
    this.isWhiteTurn = true;
    this.stage = new Kinetic.Stage({
        container: containerSelector,
        width: (FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2)/2,
        height: FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2,
    });
    this.clockArrowsLayer = new Kinetic.Layer();
    var clockArrowsLayer = this.clockArrowsLayer
    this.stage.add(clockArrowsLayer);
    var blackLittleHand = new Kinetic.Line({
        points: [(FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4, (FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4, 0, 0],
        stroke: "black",
        strokeWidth: 3
    });
    var blackBigHand = new Kinetic.Line({
        points: [(FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4, (FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4, 0, 0],
        stroke: "black",
        strokeWidth: 5
    });
    var whiteLittleHand = new Kinetic.Line({
        points: [(FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4, (FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2)*3/4 , 0, 0],
        stroke: "white",
        strokeWidth: 3
    });
    var whiteBigHand = new Kinetic.Line({
        points: [(FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4, (FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2)*3/4, 0, 0],
        stroke: "white",
        strokeWidth: 5
    });
    drwaClock(blackLittleHand, blackBigHand, time, clockArrowsLayer);
    drwaClock(whiteLittleHand, whiteBigHand, time, clockArrowsLayer);

    clockArrowsLayer.add(blackBigHand);
    clockArrowsLayer.add(blackLittleHand);
    clockArrowsLayer.add(whiteBigHand);
    clockArrowsLayer.add(whiteLittleHand);
    var blackTime = time;
    var whiteTime = time;
    var clock=this;
    setInterval(function () {
        if (!clock.paused) {
            if (clock.isWhiteTurn) {
                whiteTime -= 1000;
                drwaClock(whiteLittleHand, whiteBigHand, whiteTime, clockArrowsLayer);
                if (whiteTime < 0) {
                    onWhiteTimeOut();
                }
            } else {
                blackTime -= 1000;
                drwaClock(blackLittleHand, blackBigHand, blackTime, clockArrowsLayer);
                if (blackTime<0) {
                    onBlackTimeOut();
                }
            }
        }
        
    }, 1000);
    this.paused = false;




    this.moveDone = function () {
        this.isWhiteTurn = !this.isWhiteTurn;
    }
    
    this.togglePause = function () {
        this.paused = !this.paused;
    }
    function milisecondsToMinutesInRad(time) {
        return milisecondsToSecondsInRad(Math.floor(time / 60));
    }
    function milisecondsToSecondsInRad(time) {
        return (Math.floor(time / 1000) % 60) * (Math.PI / 60);
    }

    function drwaClock(littleHand, bigHand, time, layer) {
        //handle little hand
        var littleHandPoints = littleHand.points();
        var littleHandAngle = milisecondsToSecondsInRad(time);
        var cx = littleHandPoints[0];
        var cy = littleHandPoints[1];
        var r = (FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2) / 4;
        var x = cx + r * Math.cos(littleHandAngle * 2 - Math.PI / 2);
        var y = cy + r * Math.sin(littleHandAngle * 2 - Math.PI / 2);
        littleHandPoints.pop();
        littleHandPoints.pop();
        littleHandPoints.push(x);
        littleHandPoints.push(y);
        littleHand.points(littleHandPoints);
        //handle big hand
        var bigHandPoints = bigHand.points();
        var bigHandAngle = milisecondsToMinutesInRad(time);
        cx = bigHandPoints[0];
        cy = bigHandPoints[1];
        r = r * 0.75;
        x = cx + r * Math.cos(bigHandAngle*2 - Math.PI/2);
        y = cy + r * Math.sin(bigHandAngle * 2 - Math.PI / 2);
        bigHandPoints.pop();
        bigHandPoints.pop();
        bigHandPoints.push(x);
        bigHandPoints.push(y);
        bigHand.points(bigHandPoints);
        layer.batchDraw();
    }
}
