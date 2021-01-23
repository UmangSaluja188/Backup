function age(){
    var age=20;
    if(age<18)
    {
        alert("u r not adult");
    }
    else{
        alert("u are adult");
    }
    }
    var global="umang";
    document.write("global value",global);
    function add(){
        var a=10;
        var b=20;
        add=a+b;
        var local="local";
        document.write("add is",add);
        document.write("local value is",local);
    }
    function globalvar(){
        window.value=100;
    }
function evenodd(){
    var value=10;
    if(value%2==0)
    {
        document.write("the no is even",value);
    }
    else
    {
        document.write("the value is odd",value);
    }
}
function grade(){
    var marks=20;
    if(marks<33){
        document.write("student fails");
    
    }
    else if(marks>=33 && marks<50){
        document.write("grade is c");

    }
    else if(marks>=51 && marks<70){
        document.write("grade is b ");

    }
    else if(marks>=70 && marks<80){
        document.write("grade is a");
    }
    else(marks>=80 && marks<101)
    {
        document.write("grade is A+");
    }
}
function switchgrade () {
    var grade='';
switch (grade) {
    case 'a':
        document.write("result is",grade)
        break;
    case 'b':
        document.write("result is",grade)
    case 'c':
        document.write("result is",grade)
    default:
        document.write("d");
        break;

}
}
function whileloop(){
    var no=1;
    while(no<=10){
        document.write("no is ",no +"<br/>");
    no++;
}
}
function doloop(){
    var table=1;
    do{
        document.write(table*3+"<br/>");
        table++;
    }
    while(table<=10)
}
function forloop()
{
    for(i=1;i<=10;i++){
        document.write("no is",i+"<br/>")
    }
}
function cube(no=3){
    alert(no*no*no);
}
function getinfo(){
    return "hii i m umang";
    alert("DFG")
}
