function solve(arr, number) {
    'use strict';

    for (let i = 0; i < number; i++) {
        let firstElement = arr.shift();
        arr.push(firstElement);        
    }
    console.log(arr.join(' '));
}

solve([51, 47, 32, 61, 21], 2);
solve([32, 21, 61, 1], 4);
solve([2, 4, 15, 31], 5);