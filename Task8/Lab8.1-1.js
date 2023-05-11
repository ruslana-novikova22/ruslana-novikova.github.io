/*6. Об’єкт “Абонент” (номер телефону, домашня адреса, власник; сумарна
тривалість розмов, рахунок).*/
function Abonent(number, adress, owner, callsAmount, bill){
    this.number = number;
    this.adress = adress;
    this.owner = owner;
    this.callsAmount = callsAmount;
    this.bill = bill;

    this.InfoAbonent = function(){
        console.log(`Абонент: ${this.owner}\nНомер телефону: ${this.number}\nАдреса: ${this.address}\nСумарна тривалість розмов: ${this.callDuration}\nРахунок: ${this.bill}`);
    }
}

const abonent1 = new Abonent("+38(050)6723431", "вул. Лавицького, 89" , "Іванов Костянтин", "3 години", "275 грн")
const abonent2 = new Abonent("+38(095)7239106", "просп. Тараса Шевченка, 98" , "Голубка Валентина", "2,5 години", "238 грн")
const abonent3 = new Abonent("+38(098)3781590", "пров. Авіаційний, 21" , "Ганіч Ганна", "1 година", "108 грн")
const abonent4 = new Abonent("+38(096)2845912", "вул. Станційна, 64" , "Алексєєнко Богдан", "2 години", "174 грн")

abonent1.InfoAbonent();
abonent2.InfoAbonent();
abonent3.InfoAbonent();
abonent4.InfoAbonent();
