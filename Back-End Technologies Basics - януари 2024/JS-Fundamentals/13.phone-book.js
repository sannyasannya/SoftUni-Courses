function getPhoneBook(phoneBook) {
    'use strict';
    const phoneBookMap = {};

    for (const record of phoneBook) {
        let recordParts = record.split(' ');
        let name = recordParts[0];
        let phoneNumber = recordParts[1];

        phoneBookMap[name] = phoneNumber;        
    }

    for (const name in phoneBookMap) {
        console.log(`${name} -> ${phoneBookMap[name]}`);
    }
}

getPhoneBook(['Tim 0834212554',

'Peter 0877547887',

'Bill 0896543112',

'Tim 0876566344']);

getPhoneBook(['George 0552554',

'Peter 087587',

'George 0453112',

'Bill 0845344']);