function solve(n, inputArray) {
    'use strict';
    let newArr = [];

    for (let i = 0; i < n; i++) {
        newArr.unshift(inputArray[i]);        
    }

    console.log(newArr.join(" "));
}

solve(3, [10, 20, 30, 40, 50]);
solve(4, [-1, 20, 99, 5]);
solve(2, [66, 43, 75, 89, 47]);
