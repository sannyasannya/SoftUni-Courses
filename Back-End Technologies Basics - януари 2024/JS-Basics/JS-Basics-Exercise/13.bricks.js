function solve(numberOfBricks, workers, capacity) {
    'use strict';

    numberOfBricks = Number(numberOfBricks);
    workers = Number(workers);
    capacity = Number(capacity);

    let totalBricksPerCourse = workers * capacity;
    let numberOfTrips = Math.ceil(numberOfBricks / totalBricksPerCourse);
    console.log(numberOfTrips);
}

solve(120, 2, 30);
solve(355, 3, 10);
solve(5, 12, 30);