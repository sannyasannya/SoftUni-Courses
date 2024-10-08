function validateInput(input){
    if(input !== 'expectedValue'){
        return Promise.reject('Invalid input');
    }
    return Promise.resolve('Valid input')
}
validateInput('expectedValue')
.then(result => {
    console.log(result);
})
.catch(err => {
    console.log(err);
})


//Example 2
// let promise = new Promise(function(resolve, reject){
//     if(input !== 'expectedValue'){
//         reject('Invalid input');
//     }
//     return resolve('Valid input')
// })