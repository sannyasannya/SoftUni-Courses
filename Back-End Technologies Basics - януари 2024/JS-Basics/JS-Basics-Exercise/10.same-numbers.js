function solve(number) {
    'use strict';

    let totalSum = 0;
    let allDigitAreTheSame = true;
    let firstDigit = number % 10;

    while (number > 0) {
        let currentNum = number % 10;

        if(firstDigit != currentNum) {
            allDigitAreTheSame = false;
        }

        totalSum += currentNum;
        number = Math.floor(number / 10);
    }

    console.log(allDigitAreTheSame);
    console.log(totalSum);
}

solve(2222222);
solve(1234);