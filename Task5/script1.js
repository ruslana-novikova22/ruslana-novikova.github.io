//Створити функцію, яка для 4 чисел знаходить добуток;

console.log(Mult(3,2,5,6));
function Mult(firstNumber, secondNumber, thirdNumber, forthNumber){
  let result = firstNumber*secondNumber*thirdNumber*forthNumber;
  return result;
}

var anonymusMult = function Mult(firstNumber, secondNumber, thirdNumber, forthNumber){
  let result = firstNumber*secondNumber*thirdNumber*forthNumber;
  return result;
}
console.log(anonymusMult(3,2,5,6));

function MakeOperation(firstNumber, secondNumber, thirdNumber, forthNumber, operation){
  return operation(firstNumber, secondNumber, thirdNumber, forthNumber)
}
console.log(MakeOperation(3,2,5,6, (x,y,z,t) => x*y*z*t));