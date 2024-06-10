function dvd_collection(dvds) {
    'use strict';

    let inputArr = dvds;
    let n = parseInt(inputArr[0]);
    let dvdName = inputArr.slice(1, n + 1);
    let commandArr = inputArr.slice(n + 1, inputArr.length);

    for (const command of commandArr) {
        let commandText = command;

        if (commandText.startsWith('Watch')) {
            if (dvdName.length > 0) {
                console.log(`${dvdName.shift()} DVD watched!`);
            } else {
                continue;
            }

        } else if (commandText.startsWith('Buy')) {
            let dvdToAdd = commandText.replace('Buy ', '');
            dvdName.push(dvdToAdd);

        } else if (commandText.startsWith('Swap')) {
            let commandParts = commandText.split(' ');
            let firstIndex = parseInt(commandParts[1]);
            let secondIndex = parseInt(commandParts[2]);
            
            if (firstIndex < 0 || secondIndex < 0 || firstIndex >= dvdName.length || secondIndex >= dvdName.length) {
                continue;
            }

            let firstDvd = dvdName[firstIndex];
            let secondDvd = dvdName[secondIndex];
            dvdName[firstIndex] = secondDvd;
            dvdName[secondIndex] = firstDvd;
            console.log('Swapped!');

        } else if (commandText.startsWith('Done')) {
            break;

        } else {
            continue;
        }
    }

    if (dvdName.length) {
        console.log(`DVDs left: ${dvdName.join(', ')}`);
    } else {
        console.log('The collection is empty');
    }
}
dvd_collection (['3', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'Watch', 'Done', 'Swap 0 1'])

dvd_collection (['5', 'The Lion King', 'Frozen', 'Moana', 'Toy Story', 'Shrek', 'Buy Coco', 'Swap 2 4', 'Done'])

dvd_collection (['5', 'The Avengers', 'Iron Man',
 'Thor', 'Captain America', 'Black Panther', 'Watch', 'Watch', 'Watch', 'Watch', 'Watch', 'Done']) 