function solve(firstNumber, secondNumber, thirdNumber) {
    'use strict';
    function sum(num1, num2) {
        return num1 + num2;
    }

    function substract(num1, num2) {
        return num1 - num2;
    }
    
    const result = substract(sum(firstNumber, secondNumber), thirdNumber);

    console.log(result);
}

solve(23, 6, 10);
solve(1, 17, 30);
solve(42, 58, 100);