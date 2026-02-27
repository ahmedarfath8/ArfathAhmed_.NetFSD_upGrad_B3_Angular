class payment{
    pay(){
        console.log("general payment")
    }
} 
class creditCardPayment extends payment{
    pay(cash){
        console.log(`Paid ₹${cash} using Credit Card`)
    }
}
class upiPayment extends payment{
    pay(cash){
        console.log(`Paid ₹${cash} using UPI`)
    }
}
class cashPayment extends payment{
    pay(cash){
        console.log(`Paid ₹${cash} using Cash`)
    }
}

let p1 = new creditCardPayment();
let p2 = new upiPayment();
let p3 = new cashPayment();

p1.pay(2100);
p2.pay(480);
p3.pay(500);
