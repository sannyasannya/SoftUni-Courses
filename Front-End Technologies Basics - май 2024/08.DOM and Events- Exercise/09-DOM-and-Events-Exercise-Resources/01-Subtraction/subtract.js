function subtract() {
    let firstInput = document.getElementById("firstNumber");
    let secondInput = document.getElementById("secondNumber");
    let resultDiv = document.getElementById("result");

    let firstValue = Number(firstInput.value);
    let secondValue = Number(secondInput.value);

    let finalResult = firstValue - secondValue;

    resultDiv.textContent = finalResult;
} 