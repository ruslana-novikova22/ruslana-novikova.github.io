/*1. Об’єкт “Бухгалтерія” (Код, ПІБ; посада; заробітна плата; кількість дітей;
стаж).*/
function Accounting(code, surname, work, salary, children, experience){
    this.code = code;
    this.surname = surname;
    this.work = work;
    this.salary = salary;
    this.children = children;
    this.experience = experience;

    this.WorkerInformation = function(){
        console.log(`Код: ${this.code}\n ПІБ: ${this.surname}\n Посада: ${this.work}\n Зарплата: ${this.salary}\n Кількість дітей: ${this.children}\n Стаж: ${this.experience}`);
    }
}

const worker1 = new Accounting("803", "Горохова А.Г", "Головний бухгалтер", "12000", "3", "20 років");
const worker2 = new Accounting("319", "Марич П.В", "Бухгалтер", "9000", "2", "13 років");
const worker3 = new Accounting("572", "Варга Ю.М", "Молодший бухгалтер", "7500", "3", "6 років");

worker1.WorkerInformation();
worker2.WorkerInformation();
worker3.WorkerInformation();