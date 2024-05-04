function solve(arrayOfRowData) {
    'use strict';

    let townData = [];

    for (const rowData of arrayOfRowData) {
        let splitData = rowData.split(' | ');

        townData.push({
            town: splitData[0],
            latitude: parseFloat(splitData[1]).toFixed(2),
            longitude: parseFloat(splitData[2]).toFixed(2)
        })

    }
    townData.forEach((town) => console.log(town))
}
solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);

solve(['Plovdiv | 136.45 | 812.575']);