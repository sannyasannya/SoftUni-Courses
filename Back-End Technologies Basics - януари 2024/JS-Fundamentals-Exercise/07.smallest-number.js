function findSmallest(firstNumber, secondNumber, thirdNumber) {
    'use strict';

    const smallestNum = Math.min(firstNumber, secondNumber, thirdNumber);
    console.log(smallestNum);
}

findSmallest(2, 5, 3);
findSmallest(600, 342, 123);
findSmallest(25, 21, 4);
findSmallest(2, 2, 2);