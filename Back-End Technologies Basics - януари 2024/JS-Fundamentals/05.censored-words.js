function solve(text, word) {
    'use strict';

    let censoredWord = '*'.repeat(word.length);
    while (text.includes(word)) {
        text = text.replace(word, censoredWord);
    }
    console.log(text);

}
solve('A small sentence with some words','small');
solve('Find the hidden word', 'hidden');