//Створити функцію, яка за номером місяця повертає пору року, до якої відноситься цей
//місяць.
console.log(getSeason()); 

function getSeason(month) {
    month = prompt("Введіть місяць")
    if (month >= 3 && month <= 5) {
      return "весна";
    } else if (month >= 6 && month <= 8) {
      return "літо";
    } else if (month >= 9 && month <= 11) {
      return "осінь";
    } else {
      return "зима";
    }
}

month = prompt("Введіть місяць")
var anonymusGetSeason = function (month){
    
    if (month >= 3 && month <= 5) {
      return "весна";
    } else if (month >= 6 && month <= 8) {
      return "літо";
    } else if (month >= 9 && month <= 11) {
      return "осінь";
    } else {
      return "зима";
    }
}
console.log(anonymusGetSeason(month));

month = prompt("Введіть місяць");
let lambdaSeason = (month) =>{
    if (month >= 3 && month <= 5) {
        return "весна";
      } else if (month >= 6 && month <= 8) {
        return "літо";
      } else if (month >= 9 && month <= 11) {
        return "осінь";
      } else {
        return "зима";
      }
}
console.log(lambdaSeason(month));
