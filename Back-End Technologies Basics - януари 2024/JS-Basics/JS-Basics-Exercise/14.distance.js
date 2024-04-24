function solve(initialSpeed, firstTime, secondTime, thirdTime) {
    'use strict';

    initialSpeed = Number(initialSpeed);
    firstTime = Number(firstTime) / 60;
    secondTime = Number(secondTime) / 60;
    thirdTime = Number(thirdTime) / 60;

    let firstDistance = initialSpeed * firstTime;
    let newSpeed = initialSpeed * 1.1;

    let secondDistance = newSpeed * secondTime;
    let thirdDistance = (newSpeed * 0.95) * thirdTime;

    let totalDistance = firstDistance + secondDistance + thirdDistance;
    console.log(`${totalDistance.toFixed(2)}`);
}

solve(90, 60, 70, 80);
solve(140, 112, 75, 190);