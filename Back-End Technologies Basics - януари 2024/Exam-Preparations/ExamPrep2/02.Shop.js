function shop(input) {
    'use strict';

    let n = Number(input[0]);
    let productsName = input.slice(1, n + 1);
    let commands = input.slice(n + 1);

    for (let index = 0; index < commands.length; index++) {
        let rawParams = commands[index].split(' ');
        let commandName = rawParams[0]; // Corrected variable name

        if (commandName === 'Sell') {
            let soldProducts = productsName.shift();
            console.log(`${soldProducts} product sold!`);
            
        } else if (commandName === 'Add') {
            let productToAdd = rawParams[1]; // Corrected variable name

            if (!productToAdd) {
                continue;
            }
            productsName.push(productToAdd);

        } else if (commandName === 'Swap') {
            let firstIndex = parseInt(rawParams[1], 10);
            let secondIndex = parseInt(rawParams[2], 10);

            if (firstIndex < 0 || firstIndex >= productsName.length || secondIndex < 0 || secondIndex >= productsName.length || isNaN(firstIndex) || isNaN(secondIndex)) {
                continue;
            }

            let productOnFirstIndex = productsName[firstIndex];
            productsName[firstIndex] = productsName[secondIndex];
            productsName[secondIndex] = productOnFirstIndex; // Corrected variable name

            console.log('Swapped!');

        } else if (commandName === 'End') {
            break; // Added break to exit the loop when 'End' is encountered
        }
    }

    if (productsName.length) {
        console.log(`Products left: ${productsName.join(', ')}`);
    } else {
        console.log('The shop is empty');
    }
}
shop(['3', 'Apple', 'Banana', 'Orange', 'Sell', 'End', 'Swap 0 1'])
shop(['5', 'Milk', 'Eggs', 'Bread', 'Cheese', 'Butter', 'Add Yogurt', 'Swap 1 4', 'End']) 
shop(['3', 'Shampoo', 'Soap', 'Toothpaste', 'Sell', 'Sell', 'Sell', 'End'])