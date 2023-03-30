/*Завдання 2. Створити функцію, яка приймає два числа, якщо числа парні – повертає їх добуток,
якщо не парні – суму, якщо одне парне а інше непарне – повертає найбільше з них.*/

console.log(twoNumbers(prompt("Введіть перше число"), prompt("Введіть друге число")));
function twoNumbers(firstNumber,secondNumber){
    if (firstNumber%2 === 0 && secondNumber%2 === 0){
        return mult = firstNumber*secondNumber;
    } else if(firstNumber%2 != 0 && secondNumber%2 != 0){
        return sum = firstNumber + secondNumber;
    } else{
        return Math.max(firstNumber,secondNumber)
    }
}

let anonymusTwoNumbers = function(firstNumber,secondNumber){
    if (firstNumber%2 == 0 && secondNumber%2 == 0){
        return mult = firstNumber*secondNumber;
    } else if(firstNumber%2 != 0 && secondNumber%2 != 0){
        return sum = firstNumber+secondNumber;
    } else{
        return Math.max(firstNumber,secondNumber)
    }
}
console.log(anonymusTwoNumbers(firstNumber(prompt("Введіть перше число")), secondNumber(prompt("Введіть друге число"))));

/*Завдання 3. Дано список слів. Підрахувати кількість слів, у яких перша літера і остання літера
однакові.*/

let Words = ["Університет", "Акула", "Мозаїка", "Програма", "Антарктида", "Пазл", "Крик"]
console.log(Words.filter(element => element[0] == element[Words.length-1]))
let count = 0;
for(let i = 0; i < Words.length; i++){
    if(i("firstLatter") === i("lastLatter")){
        count++;
    }
}
console.log(count);
