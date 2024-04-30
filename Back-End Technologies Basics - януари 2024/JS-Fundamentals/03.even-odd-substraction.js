function solve(input) {
    'use strict';

    let evenSum = 0;
    let oddSum = 0;

    for (let i = 0; i < input.length; i++) {
        
        let currentNum = Number(input[i]);

        if(currentNum % 2 == 0) {
            evenSum += currentNum;
        } else {
            oddSum += currentNum;
        }        
    }
    let sum = evenSum - oddSum;

    console.log(sum);
}

solve([1,2,3,4,5,6]);
solve([3,5,7,9]);
solve([2,4,6,8,10]);