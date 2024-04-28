function solve(input) {
    'use strict';

    const typeOfParams = typeof input;

    if(typeOfParams === 'number') {
        const area = input ** 2 * Math.PI;
        console.log(area.toFixed(2));

    } else {
        console.log(`We can not calculate the circle area, because we received a ${typeOfParams}.`)
    }
}

solve(5);
solve('name');