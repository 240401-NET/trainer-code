public class foo{
    static public int i=0;
    public int j=0;
    static public float product = 1;

    public foo(){
        i += 1; 
        j += 1;
    }
    static public void MultiplyToProduct(float _value){
        product *= _value;
    }
}

