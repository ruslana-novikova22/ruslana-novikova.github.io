/*2. Дано масив, який зберігає кількість відвідувачів магазину протягом тижня. Вивести на екран:
• номери днів, протягом яких кількість відвідувачів була меншою за 20;
• номери днів, коли кількість відвідувачів була мінімальною;
• номери днів, коли кількість відвідувачів була максимальною;
• загальну кількість клієнтів у робочі дні;
• кількість клієнтів днів на вихідних.*/

let Visitors = [37, 22, 40, 7, 26, 43, 10];
for(let i = 0; i<Visitors.length;i++){
    if(Visitors[i]<20){
        console.log(i);
    }
}

let minimum = Math.min(...Visitors);
let minIndex = Visitors.indexOf(minimum);
console.log(minIndex);

let maximum = Math.max(...Visitors);
let maxIndex = Visitors.indexOf(maximum);
console.log(maxIndex);

let totalVisitors = 0; 
for (let i = 0; i <= 4; i++) {
    totalVisitors += Visitors[i];
}

let sumWeekends = Visitors[5]+Visitors[6];
console.log(sumWeekends);

