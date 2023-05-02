let Form = document.getElementById("ExampleForm");
let inputCollection = Form.getElementsByTagName("input");

function clicCalc(){
    let a = parseFloat(inputCollection[0].value);
    let b = parseFloat(inputCollection[1].value);
    let sum = a + b;
    inputCollection[2].value = sum.toString();
}

let firstInput = inputCollection[0];
let secondInput = inputCollection[1];

firstInput.onchange = () => {
    let a = parseFloat(firstInput.value);
    if (a<0){
        alert("Додавання не відбувається(значення мають бути більше за 0)");
        firstInput.value = 0;
    }
}

secondInput.onchange = () => {
    let a = parseFloat(secondInput.value);
    if (a<0){
        alert("Додавання не відбувається(значення мають бути більше за 0)");
        secondInput.value = 0;
    }
}