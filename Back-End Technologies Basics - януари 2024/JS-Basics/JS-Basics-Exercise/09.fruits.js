function solve(typeOfFruit, weight, pricePerKg) {
    'use strict';

    const pricePerGram = pricePerKg / 1000;
    const totalPrice = weight * pricePerGram;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${typeOfFruit}.`)
}

solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);