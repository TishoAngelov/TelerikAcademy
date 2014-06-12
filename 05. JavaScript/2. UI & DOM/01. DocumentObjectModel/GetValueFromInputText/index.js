function getValueFromInputTypeText() {
    var inputElement = document.querySelector('input[type="text"]')
    return inputElement.value;
}

function printValueInConsole(someStr) {
    console.log(someStr);
}

function solve() {
    printValueInConsole(getValueFromInputTypeText());
}