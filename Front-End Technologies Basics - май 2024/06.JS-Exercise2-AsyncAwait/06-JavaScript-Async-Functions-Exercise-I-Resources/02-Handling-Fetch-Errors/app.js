async function fetchDataWithErrorHandling() {
    try {
        const response = await fetch('https://swapi.dev/api/people/1');
        if(!response.ok) throw new Error('Page Not Found');
        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.log("Error message:", error);
    }
    
}