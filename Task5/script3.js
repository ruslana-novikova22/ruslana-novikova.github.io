//Створити функцію, яка переводить сантиметри у дюйми

console.log(Inch(prompt("Довжина в сантиметрах")))
function Inch(Santimeters){
  let inch = Santimeters * 0.39;
  return inch;
}

var anonymusInch = function(Santimeters){
  let inch = Santimeters * 0.39;
  return inch;
}
console.log(anonymusInch(prompt("Довжина в сантиметрах")))

let Santimeters = prompt("Довжина в сантиметрах")
let n = 0.39;
let lambdaInch = (Santimeters, n ) => {return Santimeters*n; };
console.log(lambdaInch(Santimeters, n));
