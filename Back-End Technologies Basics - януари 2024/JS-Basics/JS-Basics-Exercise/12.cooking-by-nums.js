function solve(number, op1, op2, op3, op4, op5) {
    'use strict';    

    let result = Number(number);
    let operation = '';

    for (let i = 0; i < 5; i++) {
        if (i === 0) {
            operation = op1;
        } else if (i === 1) {
            operation = op2;
        } else if (i === 2) {
            operation = op3;
        } else if (i === 3) {
            operation = op4;
        } else if (i === 4) {
            operation =op5;
        }

        if (operation === 'chop') {
            result = result / 2;
        } else if (operation === 'dice') {
            result = Math.sqrt(result);
        } else if (operation === 'spice') {
            result += 1;
        } else if (operation === 'bake') {
            result = result * 3;
        } else if (operation === 'fillet') {
            result = result * 0.8;
        }   
        
        console.log(result);
    } 
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
