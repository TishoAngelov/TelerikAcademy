/// <reference path="../_reference.js" />


function convertCoordinates(x, y) {
    var fieldX = Math.floor((x - BORDER_SIZE) / FIELD_SIZE);
    var fieldY = Math.floor((y - BORDER_SIZE) / FIELD_SIZE);
    return { top: fieldY, left:  fieldX};
}

function boardClickEventHandler(event) {
    var clickedFieldCoordinates = convertCoordinates(event.clientX, event.clientY);

    var currentFigureColour; // when is whites turn this is WHITE and vice versa

    if (clickedFieldCoordinates.top < 0 || clickedFieldCoordinates.top > ROW_COUNT ||
        clickedFieldCoordinates.left < 0 || clickedFieldCoordinates.left > COLL_COUNT) {
        //Do whatever we do when we click outside the board
    } else {
        var clickedField = BOARD[clickedFieldCoordinates.left][clickedFieldCoordinates.top];

        //if (isWhiteTurn && (clickedField.figure.colour != COLOUR_TYPES.BLACK)) {

        if (currentField != null) {
            //we must try to move
            if (checkMove(BOARD, currentField, clickedField)) {
                moveFigure(currentField, clickedField);
                clickedField.figure.moveImage(clickedFieldCoordinates.left,
                    clickedFieldCoordinates.top);
                //Turn alternation occurs (might be a good idea to insert it into moveFigure
                //Some end of game evaluation goes here
            } else {

            }
            //prepare for next clicks
            clearHighlightFlags();
            //It could be a good idea the merge the function above and the one bellow
            clearHighlightLayer();
            currentField = null;
        } else {
            //this is new logic
            if (isWhiteTurn) {
                currentFigureColour = COLOUR_TYPES.WHITE;
            } else {
                currentFigureColour = COLOUR_TYPES.BLACK;
            }

            if (clickedField.figure != null && clickedField.figure.colour==currentFigureColour)/*TODO: and it's the same colour !!!*/ {                
                currentField = clickedField;
                highlightFields();
                drawHighlights();
                
            }
        }

        mainStage.batchDraw();
        //} else if (!isWhiteTurn && (clickedField.figure.colour != COLOUR_TYPES.WHITE)) {

        //} else if (clickedField.figure == null) 
    }
}