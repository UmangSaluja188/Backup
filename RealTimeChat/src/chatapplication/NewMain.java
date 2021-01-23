/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package chatapplication;

/**
 *
 * @author K Kaul
 */
class A
{
    int a;
    int b;
    A()
    {
        a=1;
        b=2;
    }
    
}
class B extends A
{
    public void sum()
    {
        System.out.println("Sum Of Two No ="+(a+b));
    }
}
class C extends B
{
    public void average()
    {
        try
        {
            System.out.println(5/0);
        }
        finally
        {
            System.out.println;
        }
            
        
    }
}
public class NewMain {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here
        B b1=new B();
        C c1=new C();
        b1.sum();
        c1.average();
    }
}
