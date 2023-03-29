//Створити функцію, яка переводить сантиметри у дюйми

console.log(Inch(prompt("Довжина в сантиметрах")))
function Inch(Santimeters){
  let inch = Santimeters * 0.39;
  return inch;
}

var anonymusInch = function Inch(Santimeters){
  let inch = Santimeters * 0.39;
  return inch;
}
console.log(anonymusInch(prompt("Довжина в сантиметрах")))

let Santimeters = prompt("Довжина в сантиметрах")
function MakeOperation(Santimeters, n, operation){
  return operation(Santimeters, n)
}
console.log(MakeOperation(Santimeters, n, (x,y) => x*y));