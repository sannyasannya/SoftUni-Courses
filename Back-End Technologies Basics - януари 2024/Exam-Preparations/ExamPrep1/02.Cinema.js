function cinema(input) {
    'use strict';

    let n = Number(input[0]);
    let movies = input.slice(1, n + 1);
    let commands = input.slice(n + 1);

    for (let index = 0; index < commands.length; index++) {
        let rawParams = commands[index].split(' ');
        let commandName = rawParams[0]; // Corrected variable name

        if (commandName === 'Sell') {
            let soldMovie = movies.shift();
            console.log(`${soldMovie} ticket sold!`);
            
        } else if (commandName === 'Add') {
            let movieTitleToAdd = commands[index].slice(4);

            if (!movieTitleToAdd) {
                continue;
            }
            movies.push(movieTitleToAdd);

        } else if (commandName === 'Swap') {
            let firstIndex = parseInt(rawParams[1], 10);
            let secondIndex = parseInt(rawParams[2], 10);

            if (firstIndex < 0 || firstIndex >= movies.length || secondIndex < 0 || secondIndex >= movies.length || isNaN(firstIndex) || isNaN(secondIndex)) {
                continue;
            }

            let movieOnFirstIndex = movies[firstIndex];
            movies[firstIndex] = movies[secondIndex];
            movies[secondIndex] = movieOnFirstIndex; // Corrected variable name

            console.log('Swapped!');

        } else if (commandName === 'End') {
            break; // Added break to exit the loop when 'End' is encountered
        }
    }

    if (movies.length) {
        console.log(`Tickets left: ${movies.join(', ')}`);
    } else {
        console.log('The box office is empty');
    }
}

cinema(['3','Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1'])

cinema(['5', 'The Matrix', 'The Godfather', 'The Shawshank Redemption',
 'The Dark Knight', 'Inception', 'Add The Lord of the Rings', 'Swap 1 4', 'End'])

 cinema(['3', 'Star Wars', 'Harry Potter', 'The Hunger Games'], ['Sell', 'Sell', 'Sell', 'End'])