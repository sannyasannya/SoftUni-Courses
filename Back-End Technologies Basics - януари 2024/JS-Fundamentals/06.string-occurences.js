function solve(text, searchedWord) {
    'use strict';
  let words = text.split(' ');
  let counter = 0;
  for (const word of words) {
    if (word === searchedWord) {
        counter++;
    } else {
        continue;
    }
    }
    console.log(counter);
}

solve('This is a word and it also is a sentence','is');
solve('softuni is great place for learning new programming languages','softuni')
