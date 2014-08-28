var test1 = [
  '3 5',
  'dr dl dr ur ul',
  'dr dr ul ur ur',
  'dl dr ur dl ur'
]

test2 = [
  '3 5',
  'dr dl dl ur ul',
  'dr dr ul ul ur',
  'dl dr ur dl ur'
];

function solve(args) {
    var answer = '';

    var rowsColsAsString = args[0].split(' ');
    var rows = parseInt(rowsColsAsString[0]);
    var cols = parseInt(rowsColsAsString[1]);

   // console.log(rows + ' ' + cols);

    // Read directions and fill the another matrix
    var directions = [];
    var numMatrix = [];

    for (var row = 0; row < rows; row++) {
        var firstNumInRow = Math.floor(Math.pow(2, row));
        directions[row] = [];
        numMatrix[row] = [];
        var currInputLineArr = args[row + 1].split(' ');

        for (var col = 0; col < cols; col++) {
            numMatrix[row][col] = firstNumInRow++;
            directions[row][col] = currInputLineArr[col];
        }
    }

    //for (var i = 0; i < rows; i++) {
    //    console.log(numMatrix[i].join(', '));
    //}
    /////////////////////////




    // Jump
    var sumofNumbers = 0;

    var currPos = [];
    currPos.Row = 0;
    currPos.Col = 0;

    var nextPos = [];

    while (true) {
        // Escape
        if (currPos.Row < 0 || currPos.Row >= rows ||
            currPos.Col < 0 || currPos.Col >= cols) {
            answer += 'successed with ' + sumofNumbers;

            break;
        }

        // failed
        if (directions[currPos.Row][currPos.Col] === '*') {
            answer += 'failed at (' + currPos.Row + ', ' + currPos.Col + ')';

            break;
        }



        

        sumofNumbers += numMatrix[currPos.Row][currPos.Col];

      //  console.log('Curr sum : %d', sumofNumbers);

    //    console.log('Curr pos: %d %d', currPos.Row, currPos.Col);

        //•	"dr" stands for "down-right" direction
        //•	"ur" stands for "up-right" direction
        //•	"ul" stands for "up-left" direction
        //•	"dl" stands for "down-left" direction


        switch (directions[currPos.Row][currPos.Col]) {
            case 'dr':
                nextPos.Row =  1;
                nextPos.Col =  1;
                break;
            case 'ur':
                nextPos.Row =  - 1;
                nextPos.Col = 1;
                break;
            case 'ul':
                nextPos.Row =  - 1;
                nextPos.Col =  - 1;
                break;
            case 'dl':
                nextPos.Row =  1;
                nextPos.Col =  - 1;
                break;
        }



        directions[currPos.Row][currPos.Col] = '*';



        currPos.Row += nextPos.Row;
        currPos.Col += nextPos.Col;

        //if (j === J - 1) {
        //    j = -1;
        //}
    }





    console.log(answer);
}

solve(test2);