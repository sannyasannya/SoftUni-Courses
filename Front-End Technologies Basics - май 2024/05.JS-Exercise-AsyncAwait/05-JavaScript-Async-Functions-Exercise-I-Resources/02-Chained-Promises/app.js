function chainedPromises() {
    console.log("Start");
    setTimeout(function(){
       console.log("1"); 
       setTimeout(function(){
        console.log("2");
        setTimeout(function(){
            console.log("3");
        }, 1000)
       }, 1000)
    }, 1000)
}

