/// <reference path="../_reference.js" />

var PeacesImgURL = {
    WhiteKing: "http://localhost:50501/images/WhiteKing.png",
    WhiteQueen: "http://localhost:50501/images/WhiteQueen.png",
    WhiteKing: "http://localhost:50501/images/WhiteKing.png",
    WhiteKing: "http://localhost:50501/images/WhiteKing.png",
}

function drawHighlights() {
    if (currentField !== null) {
        var selectedHighlight = new Kinetic.Image({
            x: BORDER_SIZE + FIELD_SIZE * currentField.left,
            y: BORDER_SIZE + FIELD_SIZE * currentField.top,
            image: IMAGES[YELLOW_HIGHLIGHT],
            width: FIELD_SIZE,
            height: FIELD_SIZE
        });
        highlightLayer.add(selectedHighlight);
    }

    for (var i = 0; i < COLL_COUNT; i++) {
        for (var j = 0; j < ROW_COUNT; j++) {
            if (BOARD[i][j].isHighlighted) {
                var possibleHighlight = new Kinetic.Image({
                    x: BORDER_SIZE + FIELD_SIZE * BOARD[i][j].left,
                    y: BORDER_SIZE + FIELD_SIZE * BOARD[i][j].top,
                    image: IMAGES[GREEN_HIGHLIGHT],
                    width: FIELD_SIZE,
                    height: FIELD_SIZE
                });
                highlightLayer.add(possibleHighlight);
            } 
        }
    }
}

function clearHighlightLayer() {
    highlightLayer.removeChildren();
}

//function drawBoard() {
//    //I will use an image the draw the background
//    //I think this will be a bit faster, but I could be wrong
//    var boardImage = new Image();
//    boardImage.onload = function () {
//        var checkersBoard = new Kinetic.Image({
//            x: BORDER_SIZE,
//            y: BORDER_SIZE,
//            image: boardImage,
//            width: FIELD_SIZE * 8,
//            height: FIELD_SIZE * 8
//        });
//        //The board layer is lost here.
//        //If we need to manipulate it should be saved here
//        var boardLayer = new Kinetic.Layer();
//        boardLayer.add(checkersBoard);
//        mainStage.add(boardLayer);
//        checkersBoard.moveToBottom();
//    };
//    boardImage.src = "/images/CheckersBoard.gif";
//}