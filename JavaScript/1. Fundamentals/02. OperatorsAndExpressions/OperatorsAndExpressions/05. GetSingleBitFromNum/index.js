var num = 123123,
    position = 3,
    numToBinary;

numToBinary = num.toString(2);      // Converts the number to string in binary notation.
console.log('%d = %s', num, numToBinary);
console.log('third bit is 1? - %s', numToBinary[position] === '1');