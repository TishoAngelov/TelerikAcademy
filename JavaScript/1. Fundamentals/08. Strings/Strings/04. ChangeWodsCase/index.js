var givenText = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.";

function generateMixCase(word) {
    'use strict';

    var outWord = "",
        i;

    for (i = 0; i < word.length; i++) {
        if (Math.random() * 10 > 5) {
            outWord += word[i].toUpperCase();
        } else {
            outWord += word[i].toLowerCase();
        }
    }

    return outWord;
}

function tagReplace(text) {
    'use strict';

    var result = '',
        i;
    result = text.replace(/<upcase>(.*?)<\/upcase>/gi, function (match) { return match.toUpperCase(); });
    result = result.replace(/<lowcase>(.*?)<\/lowcase>/gi, function (match) { return match.toLowerCase(); });
    result = result.replace(/<mixcase>(.*?)<\/mixcase>/gi, generateMixCase);

    result = result.split('');

    for (i = 0; i < result.length; i++) {
        if (result[i] === '<') {

            while (true) {
                if (result[i] === '>') {
                    result[i] = '';
                    break;
                }

                result[i] = '';
                i++;
            }
        }
    }

    return result.join('');
}

console.log(tagReplace(givenText));