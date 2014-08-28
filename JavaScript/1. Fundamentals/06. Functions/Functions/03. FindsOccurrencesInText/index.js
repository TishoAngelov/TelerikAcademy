var word = 'text',
    text = 'Text text text. Text.',
    occurrences;

function countAllOccurrencesOfWordInText(wordToSearch, textToSearch, isCaseSensitiveSearch) {
    'use strict';

    var count;

    if (isCaseSensitiveSearch === undefined) {
        isCaseSensitiveSearch = false;
    }

    if (!isCaseSensitiveSearch) {
        wordToSearch = wordToSearch.toLowerCase();
        textToSearch = textToSearch.toLowerCase();
    }

    count = (textToSearch.match(new RegExp(wordToSearch, 'g')) || []).length;

    return count;
}

console.log('Text to search: %s', text);
console.log('Word to search: %s', word);

occurrences = countAllOccurrencesOfWordInText(word, text, true);
console.log('Occurrences: %d - calling the function with case sensitive "true"',
    occurrences);

occurrences = countAllOccurrencesOfWordInText(word, text);
console.log('Occurrences: %d - calling the function without case ' +
    'sensitive parameter (default is "false)"', occurrences);