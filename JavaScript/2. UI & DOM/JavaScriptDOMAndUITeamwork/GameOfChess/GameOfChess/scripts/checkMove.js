/// <reference path="../_reference.js" />

function checkMove(board, currentField, futureField) {
    var result;
    if (!currentField.figure) {
        //if there is no figure in the current field
        return false;
    }

    if (currentField === futureField) {
        //same fields
        return false;
    }

    var currentFigureType = currentField.figure.type;
    var currentFigureColour = currentField.figure.colour;

    //if there is no future figure, assign null
    if (futureField.figure) {
        var futureFigureType = futureField.figure.type;
        var futureFigureColour = futureField.figure.colour;
    }

    switch (currentFigureType) {
        case FIGURE_TYPES.KING: result = checkKingMove();
            break;
        case FIGURE_TYPES.PAWN: result = checkPawnMove();
            break;
        case FIGURE_TYPES.BISHOP: result = checkBishopMove();
            break;
        case FIGURE_TYPES.KNIGHT: result = checkKnightMove();
            break;
        case FIGURE_TYPES.QUEEN: result = checkQueenMove();
            break;
        case FIGURE_TYPES.ROOK: result = checkRookMove();
            break;
        default: console.error("Invalid figure type in checkMove switch");
    }

    return result;

    function checkQueenMove() {
        var movesRookLike = checkRookMove();
        var movesBishopLike = checkBishopMove();
        if (movesRookLike || movesBishopLike) {
            return true;
        } else {
            return false;
        }
    }

    function checkRookMove() {
        var distance;
        var middleTop;
        var middleLeft;
        var middleField;

        if ((futureField.top !== currentField.top) && (futureField.left != currentField.left)) {
            // the row and the column are both different
            return false;
        }

        if (futureFigureColour == currentFigureColour) {
            //same player's figure is in the future field
            return false;
        }

        if (currentField.left === futureField.left) {
            //same column
            distance = futureField.top - currentField.top;
            if (distance < 0) {
                //up
                for (var i = distance + 1; i < 0; i++) {
                    middleTop = currentField.top + i;
                    middleField = board[currentField.left][middleTop];
                    if (middleField.figure) {
                        //if there is any figure, it is an obstacle for the rook
                        return false;
                    }
                }
            } else {
                //down
                for (var i = distance - 1; i > 0; i--) {
                    middleTop = currentField.top + i;
                    middleField = board[currentField.left][middleTop];
                    if (middleField.figure) {
                        return false;
                    }
                }
            }
        } else if (currentField.top === futureField.top) {
            //same row
            distance = futureField.left - currentField.left;
            if (distance < 0) {
                //left
                for (var i = distance + 1; i < 0; i++) {
                    middleLeft = currentField.left + i;
                    middleField = board[middleLeft][currentField.top];
                    if (middleField.figure) {
                        return false;
                    }
                }
            } else {
                //right
                for (var i = distance - 1; i > 0; i--) {
                    middleLeft = currentField.left + i;
                    middleField = board[middleLeft][currentField.top];
                    if (middleField.figure) {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    function checkKnightMove() {
        var isValidLeft;
        var isValidRight;
        var isValidPosition = false;
        var VALID_CHANGES = [
            [-2, -1],
            [-2, 1],
            [-1, 2],
            [-1, -2],
            [1, 2],
            [2, 1],
            [2, -1],
            [1, -2],
        ]

        for (var i = 0; i < VALID_CHANGES.length; i++) {
            isValidLeft = (currentField.left + VALID_CHANGES[i][0]) === futureField.left;
            isValidRight = (currentField.top + VALID_CHANGES[i][1]) === futureField.top;
            if (isValidLeft && isValidRight) {
                isValidPosition = true;
                break;
            }
        }

        if (!isValidPosition) {
            return false;
        }

        if (futureFigureColour === currentFigureColour) {
            return false;
        }

        return true;
    }

    function checkBishopMove() {
        var distance = Math.abs(currentField.top - futureField.top);
        var middleTop;
        var middleLeft;
        var middleField;
        if (Math.abs(currentField.top - futureField.top) !== Math.abs(currentField.left - futureField.left)) {
            //move is not along a diagonal
            return false;
        }
        if (futureFigureColour === currentFigureColour) {
            return false;
        }
        //left up diagonal
        if (futureField.left < currentField.left && futureField.top < currentField.top) {
            for (var i = distance - 1; i > 0; i--) {
                //for all fields along the diagonal to the future field
                middleTop = currentField.top - i;
                middleLeft = currentField.left - i;
                middleField = board[middleLeft][middleTop];
                if (middleField.figure) {
                    //if there is any figure, it is an obstacle for the bishop
                    return false;
                }
            }
        }
        //left down diagonal
        if (futureField.left < currentField.left && futureField.top > currentField.top) {
            for (var i = distance - 1; i > 0; i--) {
                middleTop = currentField.top + i;
                middleLeft = currentField.left - i;
                middleField = board[middleLeft][middleTop];
                if (middleField.figure) {
                    return false;
                }
            }
        }
        //right up diagonal
        if (futureField.top < currentField.top && futureField.left > currentField.left) {
            for (var i = distance - 1; i > 0; i--) {
                middleTop = currentField.top - i;
                middleLeft = currentField.left + i;
                middleField = board[middleLeft][middleTop];
                if (middleField.figure) {
                    return false;
                }
            }
        }
        //right down diagonal
        if (futureField.top > currentField.top && futureField.left > currentField.left) {
            for (var i = distance - 1; i > 0; i--) {
                middleTop = currentField.top + i;
                middleLeft = currentField.left + i;
                middleField = board[middleLeft][middleTop];
                if (middleField.figure) {
                    return false;
                }
            }
        }

        return true;
    }

    function checkPawnMove() {
        if (futureFigureColour === currentFigureColour) {
            //same player figures
            return false;
        }

        if (Math.abs(currentField.top - futureField.top) > 1) {
            //step greater than 1
            //move twice if possible
            var direction=(COLOUR_TYPES.WHITE==currentFigureColour?-2:2);
            if ((futureField.top - currentField.top) == direction && !currentField.figure.isMoved) {
                return futureField.figure == null &&
                    BOARD[currentField.left][currentField.top + direction/2].figure == null &&
                    currentField.left === futureField.left;
            }
            return false;
        } else if (Math.abs(currentField.left - futureField.left) > 1) {
            //step greater than 1
           
            return false;
        }

        if (currentFigureColour === COLOUR_TYPES.WHITE) {
            if (futureField.top > currentField.top) {
                //backward movement of white
                return false;
            }
        } else if (currentFigureColour === COLOUR_TYPES.BLACK) {
            if (futureField.top < currentField.top) {
                //backward movement of black
                return false;
            }
        }

        if (currentField.left === futureField.left) {
            if (futureField.figure) {
                //the field straight ahead is occupied
                return false;
            }

            return true;
        } else if (currentField.left != futureField.left) {
            if (currentField.top === futureField.top) {
                //move along the same horizontal line
                return false;
            }
            if (!futureField.figure) {
                return false;
            }

            //kill other player's figure diagonally
            return true;
        }
    }

    function checkKingMove() {
        if (Math.abs(futureField.top - currentField.top) > 1) {
            //if king's step > 1
            return false;
        }

        if (Math.abs(futureField.left - currentField.left) > 1) {
            //if king's step > 1
            return false;
        }

        if (!futureField.figure) {
            //if no future figure
            return true;
        }
        if (currentFigureColour === futureFigureColour) {
            return false;
        }

        return true;
    }
}
