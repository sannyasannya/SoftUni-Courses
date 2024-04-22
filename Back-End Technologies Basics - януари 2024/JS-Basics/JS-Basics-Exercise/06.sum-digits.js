function solve (number) {
    'use strict';

    let sum = 0;
    let numAsString = number.toString();

    for (let index = 0; index < numAsString.length; index++) {
        const element = Number(numAsString[index]);
        sum += element;
    }

    console.log(sum);
}
solve(245678);
solve(97561);
solve(543);