class vehicle{
    constructor(brand,speed){
        this.brand=brand;
        this.speed=speed;
    }
    vehicleDetails(){
    console.log("vehicle Info")
    console.log("Brand : "+this.brand)
    console.log("Speed :"+this.speed)
    console.log()
    }
}class car extends vehicle{
    constructor(brand,speed,fuel){
        super(brand,speed);
        this.fuel=fuel;
    }
    showCarDetails(){
        console.log("Car Info")
        console.log("Brand : "+this.brand)
        console.log("Speed :"+this.speed)
        console.log("Fuel :"+this.fuel)
        console.log()
    }
}
let c1 = new car("ferrari","400kmp","petrol")
c1.showCarDetails();
c1.vehicleDetails();