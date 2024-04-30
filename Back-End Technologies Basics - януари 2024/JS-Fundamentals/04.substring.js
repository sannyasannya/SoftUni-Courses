function solve(text, startIndex, count) {
    'use strict'; 
    // let endIndex = startIndex + count;
    // let substring = text.substring(startIndex, endIndex);
    // console.log(substring);
     
    text = text.substr(startIndex, count);
    console.log(text);
}

solve('ASentence', 1, 8);
solve('SkipWord', 4, 7);
