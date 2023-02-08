class A 
{
    //Members: Methods, Fields
    public int x;
    public void Do()
    {

    }
}

class B : A // single inheritance
{
    public int y;
}

class C : B   // multi-level inheritance
{
    public int z;
}

interface ID
{
    public void T();//declaration 
}

class E: A, ID     //multiple inheritance 
{
   public void T()//implementation
   {

   }
}