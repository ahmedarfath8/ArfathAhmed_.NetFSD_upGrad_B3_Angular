class student{
    constructor(name,roll,marks){
        this.name=name;
        this.roll=roll;
        this.marks=marks;
    }
    getDetails(){
        console.log("Student Info")
        console.log("name  : "+this.name) 
        console.log("roll :"+this.roll) 
        console.log("marks : "+this.marks) 
        console.log("Grade :"+this.getGrades())
        console.log("")
    }
    getGrades(){
        let marks = this.marks;
        if(marks >= 90){
            return "A";
        }else if(marks>=75){
            return "B";
        }else if(marks>=50){
            return "C";
        }else{
            return "FAIL";
        }
    }
}
let s1 = new student("arfath",20211,95);
let s2 = new student("ahmed",20221,67);
s1.getDetails();
s2.getDetails();