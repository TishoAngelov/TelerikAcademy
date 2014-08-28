var numberToGuess,
    resultContainer,
    inputNumber,
    isNumberCorrect,
    inputNumber;

resultContainer = document.getElementById('guesses-data');

function generateRandomGuessingNumber(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
}

numberToGuess = generateRandomGuessingNumber(1000, 9999);

function guessTheNumber() {
    inputNumberString = document.getElementById('input-number').value;

    isNumberCorrect = inputNumberString.length === 4; // TODO: Check if it is a number
    inputNumber = Number(inputNumberString);

    if (isNumberCorrect) {

    } else {
        alert('Incorrect number! Allowed range 1000-9999.');
    }
}