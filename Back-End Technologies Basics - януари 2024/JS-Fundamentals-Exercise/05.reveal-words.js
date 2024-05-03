function solve(revealWord, text) {
    'use strict';
    let revealWords = revealWord.split(',');

    let textAsWords = text.split(' ');

    let counter = 0;

    for (let i = 0; i < textAsWords.length; i++) {
        if (textAsWords[i].includes('*')) {
            textAsWords[i] = revealWords.find(x => x.length === textAsWords[i].length);//[counter].trim();           

            //if(revealWords.length - 1 > counter) {
            //    counter++;
            //}
        }       
    }
    let result = textAsWords.join(' ');
    console.log(result);
}
solve('great', 'softuni is ***** place for learning new programming languages');
solve('great,learning','softuni is ***** place for ******** new programming languages');