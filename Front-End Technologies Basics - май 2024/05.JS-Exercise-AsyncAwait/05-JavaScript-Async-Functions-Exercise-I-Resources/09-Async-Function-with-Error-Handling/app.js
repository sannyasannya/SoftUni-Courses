async function promiseRejectionAsync() {
   let promise = new Promise(function(resolve, reject){
      setTimeout(function(){
         reject(new Error("Error message!"))
      }, 1000);
   });

   try{
      await promise;
   }
   catch(errorMessage) {
      console.log(errorMessage);
   }
}