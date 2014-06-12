function selectUsingQuerySelectorAll() {
    var selectedDivs = document.querySelectorAll('div div');

    for (var i = 0, len = selectedDivs.length; i < len; i++) {
        selectedDivs[i].style.backgroundColor = 'Green';
    }
    console.dir(selectedDivs);    
}

function selectUsingTagName() {
    var divs = document.getElementsByTagName('div'),
    currDiv,
    len,
    i;

    for (i = 0, len = divs.length; i < len; i++) {
        currDiv = divs[i];

        if (currDiv.parentElement instanceof HTMLDivElement) {
            console.dir(currDiv);
            currDiv.style.backgroundColor = 'Red';
        }
    }
}