function solve(sentence) {
    'use strict';

    const words = sentence.toLowerCase().split(' ');
    let wordOccurrences = {};

    words.forEach(word => {
        wordOccurrences[word] = (wordOccurrences[word] || 0) + 1;
    });

    const oddOccurrences = Object.keys(wordOccurrences).filter(word => wordOccurrences[word] % 2 !== 0);

    console.log(oddOccurrences.join(' '));
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');
solve('Cake IS SWEET is Soft CAKE sweet Food');