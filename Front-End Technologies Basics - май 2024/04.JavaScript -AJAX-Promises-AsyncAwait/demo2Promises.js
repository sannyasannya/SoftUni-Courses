let promise = new Promise(function(resolve, reject) {
    setTimeout(() => {
        let success = false;
        if(success){
            resolve("Operation is successful!")
        }
        else{
            reject("Operation is not successful!")
        }

    }, 2000)
});

promise.then(function(result){
    console.log(result);
})
.catch(function(err){
    console.log(err);
})