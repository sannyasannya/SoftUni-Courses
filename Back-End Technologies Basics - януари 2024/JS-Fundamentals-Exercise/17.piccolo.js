function manageParkingLot(commands) {
    'use strict';

    const parkingLot = new Set();

    for (const command of commands) {
        const [direction, carNumber] = command.split(', ');

        if (direction === 'IN') {
            parkingLot.add(carNumber);
        } else if (direction === 'OUT') {
            parkingLot.delete(carNumber);
        }
    }

    // Check if the parking lot is empty
    if (parkingLot.size === 0) {
        console.log('Parking Lot is Empty');
    } else {
        // Convert the Set to an array and sort it
        const sortedCarNumbers = Array.from(parkingLot).sort();

        // Print each car number on a new line
        sortedCarNumbers.forEach(carNumber => {
            console.log(carNumber);
        });
    }
}

manageParkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'IN, CA9999TT',
'IN, CA2866HI',
'OUT, CA1234TA',
'IN, CA2844AA',
'OUT, CA2866HI',
'IN, CA9876HH',
'IN, CA2822UU']
)

manageParkingLot(['IN, CA2844AA',
'IN, CA1234TA',
'OUT, CA2844AA',
'OUT, CA1234TA']
)