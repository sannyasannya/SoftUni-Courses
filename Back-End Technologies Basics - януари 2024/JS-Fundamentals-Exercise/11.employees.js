function solve(arrayOfEmployees) {
    'use strict';
    
    const employeeData = arrayOfEmployees.map((employeeRaw) => {
        return {
            name: employeeRaw,
            personalNumber: employeeRaw.length
        }
    })

    // const employeeData = []

    // for (const employeeRaw of arrayOfEmployees) {
    //     employeeData.push({
    //         name: employeeRaw,
    //         personalNumber: employeeRaw.length
    //     })
    // }

    employeeData.forEach((employee) => console.log(`Name: ${employee.name} -- Personal Number: ${employee.personalNumber}`))

    //const employeeList = {};

    //for (const employee of employees) {
      //  const nameLength = employee.length;
        //const personalNum = nameLength;
        
       // employeeList[employee] = personalNum;
    //}

    //for (const employee of employeeList) {
      //  console.log(`Name: ${employee} -- Personal Number: ${employeeList[employee]}`);
    //}
}

solve(['Silas Butler','Adnaan Buckley','Juan Peterson','Brendan Villarreal']);
solve(['Samuel Jackson','Will Smith','Bruce Willis','Tom Holland']);