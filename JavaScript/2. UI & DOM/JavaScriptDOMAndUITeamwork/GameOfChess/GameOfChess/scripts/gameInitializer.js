/// <reference path="../_reference.js" />

var FIELD_SIZE = 70;
var BORDER_SIZE = 50;
var ROW_COUNT = 8;
var COLL_COUNT = 8;
var BOARD = [];
var IMAGES = [];
var FIGURES = [];
var GREEN_HIGHLIGHT = "greenHighlight";
var YELLOW_HIGHLIGHT = "yellowHighlight";
var CONTAINER_NAME = "kinetic-container";
var CLOCK_CONTAINER = "clock-container"
var TIME = 901000
var CLOCK;
//Images loaded in advance
//Might be a good idea to move to a different file
var currentField;
var futureField;
var figureLayer;
var movingFigureLayer;
var highlightLayer;
var mainStage;
var isWhiteTurn = true;

window.onload = function () {
    mainStage = new Kinetic.Stage({
        container: CONTAINER_NAME,
        width: FIELD_SIZE * COLL_COUNT + BORDER_SIZE * 2,
        height: FIELD_SIZE * ROW_COUNT + BORDER_SIZE * 2,
    });
    figureLayer = new Kinetic.Layer();
    movingFigureLayer = new Kinetic.Layer();
    highlightLayer = new Kinetic.Layer();
    //Load resources
    initializeBoard();
    initializeImages();
    //drawBoard();
    initializeFigures();
    drawBoard(FIELD_SIZE, BORDER_SIZE, BORDER_SIZE); // TODO: Remove hardcoded starting coordinates.
    mainStage.add(highlightLayer);
    mainStage.add(figureLayer);
    mainStage.add(movingFigureLayer);
    CLOCK = new Clock(CLOCK_CONTAINER, TIME, function () {
        showAllert("Black WON!", "white", "black");
    }, function () {
        showAllert("White WON!", "black", "white");
    });
    //adding events
    document.getElementById(CONTAINER_NAME).onclick = boardClickEventHandler;
    mainStage.batchDraw();
};

//Initialize all figure images and save em in IMAGES
function initializeImages() {

    for (var color in COLOUR_TYPES) {
        for (var type in FIGURE_TYPES) {
            var figureName = COLOUR_TYPES[color] + FIGURE_TYPES[type];
            var figureImage = new Image();
            figureImage.src = "/images/" + figureName + ".png";
            IMAGES[figureName] = figureImage;
        }
    }
    IMAGES[GREEN_HIGHLIGHT] = new Image();
    IMAGES[GREEN_HIGHLIGHT].src = "/images/greenHighlight.png";
    IMAGES[YELLOW_HIGHLIGHT] = new Image();
    IMAGES[YELLOW_HIGHLIGHT].src = "/images/yellowHighlight.png";

}

function initializeBoard() {
    currentField = null;
    for (var i = 0; i < COLL_COUNT; i++) {
        BOARD[i] = [];
        for (var j = 0; j < ROW_COUNT; j++) {
            BOARD[i][j] = new Field(i, j);
        }
    }
}

//A function helping for the initial initialize 
function putFigure(colour, type, fieldPoxitionX, fieldPositionY) {
    var figure = new Figure(colour, type, fieldPoxitionX, fieldPositionY);
    FIGURES.push(figure);
    BOARD[fieldPoxitionX][fieldPositionY].figure = figure;
    figureLayer.add(figure.image);
}

//Initializes the figures for the end of the game and draws them
//It's a little hard coded but I don't see how it can be avoided
function initializeFigures() {
    //Black
    //major black peaces 
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.ROOK, 0, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.ROOK, 7, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.KNIGHT, 1, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.KNIGHT, 6, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.BISHOP, 2, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.BISHOP, 5, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.QUEEN, 3, 0);
    putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.KING, 4, 0);
    //Initialize black pawns
    for (var i = 0; i < 8; i++) {
        putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.PAWN, i, 1);
    }
    //White
    //major white peaces 
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.ROOK, 0, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.ROOK, 7, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.KNIGHT, 1, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.KNIGHT, 6, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.BISHOP, 2, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.BISHOP, 5, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.QUEEN, 3, 7);
    putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.KING, 4, 7);
    //Initialize white pawns
    for (var i = 0; i < 8; i++) {
        putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.PAWN, i, 6);
    }
}

function highlightFields() {
    for (var i = 0; i < ROW_COUNT; i++) {
        for (var j = 0; j < COLL_COUNT; j++) {
            var currentCheckField = BOARD[j][i];
            if (checkMove(BOARD, currentField, currentCheckField)) {
                BOARD[j][i].isHighlighted = true;
            }
        }
    }
}

function hasChess(currentField) {
    var hasChess = false;

    if (currentField) {
        for (var i = 0; i < ROW_COUNT; i++) {
            for (var j = 0; j < COLL_COUNT; j++) {
                var currentCheckField = BOARD[j][i];

                if (checkMove(BOARD, currentField, currentCheckField)) {
                    if (BOARD[j][i].figure) {
                        if (BOARD[j][i].figure.type === FIGURE_TYPES.KING) {
                            hasChess = true;
                        }
                    }
                }
            }
        }
    }   

    return hasChess;
}

function hasSheh(currentField) {
    var hasSheh = false;

    if (currentField) {
        for (var i = 0; i < ROW_COUNT; i++) {
            for (var j = 0; j < COLL_COUNT; j++) {
                var currentCheckField = BOARD[j][i];

                if (checkMove(BOARD, currentField, currentCheckField)) {
                    if (BOARD[j][i].figure) {
                        if (BOARD[j][i].figure.type === FIGURE_TYPES.QUEEN) {
                            hasSheh = true;
                        }
                    }
                }
            }
        }
    }

    return hasSheh;
}

function moveFigure(currentField, futureField) {
    if (checkMove(BOARD, currentField, futureField)) {
        if (futureField.figure != null) {
            //What if the field is populated
            clearField(futureField);
        }
        isWhiteTurn = !isWhiteTurn;
        CLOCK.moveDone();
        currentField.figure.isMoved = true;
        //variables to check whether a pawn in the current field is reaching the opposite side of the board
        var isWhitePawnQueen = ((currentField.figure.type === FIGURE_TYPES.PAWN) &&
            futureField.top === 0) && (currentField.figure.colour === COLOUR_TYPES.WHITE);
        var isBlackPawnQueen = ((currentField.figure.type === FIGURE_TYPES.PAWN) &&
            futureField.top === ROW_COUNT - 1) && (currentField.figure.colour === COLOUR_TYPES.BLACK);

        if (isWhitePawnQueen) {
            //if white pawn has reached the opposite side of the board, it becomes a white queen
            clearField(currentField);
            putFigure(COLOUR_TYPES.WHITE, FIGURE_TYPES.QUEEN, futureField.left, futureField.top);
            futureField.isMoved = true;
        }
        else if (isBlackPawnQueen) {
            //if black pawn has reached the opposite side of the board, it becomes a black queen
            clearField(currentField);
            putFigure(COLOUR_TYPES.BLACK, FIGURE_TYPES.QUEEN, futureField.left, futureField.top);
            futureField.figure.isMoved = true;
        }
        else {
            //the regular case, no pawns becoming queens
            futureField.figure = currentField.figure;

            // Check if there is a chess given after a figure is moved.
            if (hasChess(futureField)) {
                showAllert("Check!","#aabbbb","rgba(255,0,0,0.7)");
            }

            // Check if there is a chess given after a figure is moved.
            if (hasSheh(futureField)) {
                // TODO: Alert the user for sheh.
                showAllert("Sheh!", "#aabbbb", "rgba(0,150,0,0.7)");
            }
        }

        //in any case, free the current field
        currentField.figure = null;
    }
}

function showAllert(message,fontColour,backgroundColour) {
    var allertWindow = document.createElement("div");
    allertWindow.style.position = "absolute";
    allertWindow.style.width = (FIELD_SIZE * 8 + 2 * BORDER_SIZE) + "px";
    allertWindow.style.height = (FIELD_SIZE * 8 + 2 * BORDER_SIZE )+ "px";
    allertWindow.style.left = 0;
    allertWindow.style.top = 0;
    allertWindow.style.textAlign = "center";
    allertWindow.style.lineHeight= (FIELD_SIZE * 8 + 2 * BORDER_SIZE )+ "px";
    allertWindow.style.verticalAlign = "middle";
    allertWindow.style.color = fontColour;
    allertWindow.style.fontSize = "5em";
    allertWindow.style.fontWeight = "bold";
    allertWindow.style.backgroundColor = backgroundColour;
    console.log('Chess!');  
    allertWindow.innerText = message;   
    document.body.appendChild(allertWindow);
    window.setTimeout(function () {
        document.body.removeChild(allertWindow)
    }, 2000)
}
function clearField(field) {
    field.figure.deleteImage();
    var length = FIGURES.length;
    for (var i = 0; i < length; i++) {
        var topFigure = FIGURES.shift();
        if (topFigure !== field.figure) {
            FIGURES.push(topFigure);
        }
    }
}

function clearHighlightFlags() {
    for (var i = 0; i < ROW_COUNT; i++) {
        for (var j = 0; j < COLL_COUNT; j++) {
            BOARD[i][j].isHighlighted = false;
        }
    }
}

function drawBoard(cellSize, startX, startY) {
    var svg = document.getElementById('chess-board'),
        counter = 0,
        nextX = startX,
        nextY = startY;

    for (var row = 0; row < ROW_COUNT; row++) {
        for (var col = 0; col < COLL_COUNT; col++) {
            counter++;

            var newCell = document.createElementNS("http://www.w3.org/2000/svg", 'rect');

            newCell.setAttribute("x", nextX);
            newCell.setAttribute("y", nextY);
            newCell.setAttribute("width", cellSize);
            newCell.setAttribute("height", cellSize);

            newCell.style.stroke = "none";

            // Set the color of the current cell.
            if (counter % 2 === 0) {
                newCell.style.fill = 'black';
            } else {
                newCell.style.fill = 'white';
            }

            svg.appendChild(newCell);

            nextX += cellSize;
        }

        nextY += cellSize;
        nextX = startX;
        counter++;
    }
}