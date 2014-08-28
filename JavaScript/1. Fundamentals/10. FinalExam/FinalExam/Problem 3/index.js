var test1 = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
'@section menu {',
'<ul id="menu">',
'    <li>Home</li>',
'    <li>About us</li>',
'</ul>',
'    }',
'@section footer {',
'    <footer>',
'    Copyright Telerik Academy 2014',
'    </footer>',
'}',
'<!DOCTYPE html>',
'<html>',
'<head>',
'    <title>Telerik Academy</title>',
'</head>',
'<body>',
'    @renderSection("menu")',
'',
'    <h1>@title</h1>',
'    @if (showSubtitle) {',
'        <h2>@subTitle</h2>',
'        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
'    }',
'',
'<ul>',
'    @foreach (var student in students) {',
'        <li>',
'            @student ',
'        </li>',
'        <li>Multiline @title</li>',
'    }',
'</ul>',
'    @if (showMarks) {',
'        <div>',
'            @marks ',
'        </div>',
'}',
'',
'    @renderSection("footer")',
'</body>',
'</html>'
],
    test2 = [],
    test3 = [];

function solve(params) {    
    var result = '';

    var variablesCount = parseInt(params[0]);

    var variables = [];
    for (var i = 1; i <= variablesCount; i++) {
        var currInputLine = params[i];
        var currVar = '';
        var currVarValue = '';
        var gotTheVar = false;

        for (var j = 0; j < currInputLine.length; j++) {
            if (currInputLine[j] === ':') {
                j++;
                gotTheVar = true;
            }

            if (gotTheVar) {
                currVarValue += currInputLine[j];
            } else {
                currVar += currInputLine[j];
            }
        }

        variables[currVar] = currVarValue;
    }

    //for (var key in variables) {
    //    console.log(key + ': ' + variables[key]);
    //}

    var linesInView = params[variablesCount + 1];
    


    for (var i = variablesCount + 2; i < linesInView; i++) {
        var currInputLine = params[i].split('');
        var currVarToReplace = '';

        for (var j = 0; j < currInputLine.length; j++) {
            var flag = false;


            if (currInputLine[j] === '@') {
                flag = true;
                var variableSawAt = j + 1;
                j++;
                while (currInputLine[j] !== ' ') {
                    currVarToReplace += currInputLine[j];
                    j++;
                }

                j = variableSawAt;
            } else {
                result += currInputLine[j];
            }
            
            if (flag) {
                var valToReplace = '';
                for (var key in variables) {
                    if (key === currVarToReplace) {
                        valToReplace = variables[key];
                    }
                }

                for (var z = j; z < valToReplace.length; z++) {
                    result += valToReplace[z];
                }

                flag = false;
            }
        }
    }



    console.log(result);
}

solve(test1);
