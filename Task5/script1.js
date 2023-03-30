//Створити функцію, яка для 4 чисел знаходить добуток;

console.log(Mult(3,2,5,6));
function Mult(firstNumber, secondNumber, thirdNumber, forthNumber){
  let result = firstNumber*secondNumber*thirdNumber*forthNumber;
  return result;
}

var anonymusMult = function(firstNumber, secondNumber, thirdNumber, forthNumber){
  let result = firstNumber*secondNumber*thirdNumber*forthNumber;
  return result;
}
console.log(anonymusMult(3,2,5,6));

let lambdaMult = (firstNumber, secondNumber, thirdNumber, forthNumber) => {return firstNumber*secondNumber*thirdNumber*forthNumber; };
console.log(lambdaMult(3,2,5,6));
