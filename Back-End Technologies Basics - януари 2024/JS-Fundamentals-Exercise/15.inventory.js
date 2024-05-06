function createHeroRegister(heroData) {
    'use strict';

    const heroRegister = [];

    // Process each hero data and store it in the heroRegister array
    heroData.forEach(hero => {
        const [heroName, heroLevel, items] = hero.split(' / ');

        const heroInfo = {
            name: heroName,
            level: Number(heroLevel),
            items: items ? items.split(', ') : []  // Split items into an array if they exist
        };

        heroRegister.push(heroInfo);
    });

    // Sort the heroRegister array by level in ascending order
    heroRegister.sort((a, b) => a.level - b.level);

    // Print the result in the specified format
    heroRegister.forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);
    });
}

createHeroRegister([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );

createHeroRegister([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
    ]
    )
