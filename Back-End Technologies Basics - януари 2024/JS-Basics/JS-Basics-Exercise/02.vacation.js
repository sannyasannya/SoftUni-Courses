function solve(numberOfPeople, typeOfGroup, dayOfWeek) {
    'use strict';

    let totalAmount = 0;
   

    if(typeOfGroup === 'Students') {
        if(dayOfWeek == 'Friday') {
            totalAmount = numberOfPeople * 8.45;

        } else if(dayOfWeek === 'Saturday') {
            totalAmount = numberOfPeople * 9.80;

        } else if(dayOfWeek === 'Sunday') {
            totalAmount = numberOfPeople * 10.46;

        }
        
        if(numberOfPeople >= 30) {
            totalAmount = totalAmount * 0.85;
        }

    } else if(typeOfGroup === 'Business') {
        if(dayOfWeek == 'Friday') {
            totalAmount = numberOfPeople * 10.90;

        } else if(dayOfWeek === 'Saturday') {
            totalAmount = numberOfPeople * 15.60;

        } else if(dayOfWeek === 'Sunday') {
            totalAmount = numberOfPeople * 16;
            
        }

        if(numberOfPeople >= 100) {
            const pricePerNight = totalAmount / numberOfPeople;
            totalAmount = pricePerNight * (numberOfPeople -10);
        }

    } else if(typeOfGroup === 'Regular') {
        if(dayOfWeek == 'Friday') {
            totalAmount = numberOfPeople * 15;

        } else if(dayOfWeek === 'Saturday') {
            totalAmount = numberOfPeople * 20;

        } else if(dayOfWeek === 'Sunday') {
            totalAmount = numberOfPeople * 22.50;
            
        }

        if(numberOfPeople >= 10 && numberOfPeople <= 20) {
            totalAmount = totalAmount * 0.95;
        }

    }

    console.log(`Total price: ${totalAmount.toFixed(2)}`);

}

solve(30, 'Students', 'Sunday');
solve(40, 'Regular', 'Saturday');
