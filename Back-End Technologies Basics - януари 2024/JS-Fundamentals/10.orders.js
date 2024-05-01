function solve(product, quantity) {
    'use strict';
    let price = 0;

    if (product === 'coffee') {
        price = 1.50 * quantity;
    } else if (product === 'coke') {
        price = 1.40 * quantity;
    } else if (product === 'water') {
        price = 1.00 * quantity;
    } else if (product === 'snacks') {
        price = 2.00 * quantity;
    } 
    console.log(price.toFixed(2));

}
solve("water", 5);
solve("coffee", 2);