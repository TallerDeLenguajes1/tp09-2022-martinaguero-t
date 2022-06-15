namespace TP92;

public class Producto{
    public string Nombre {get; set;}
    public DateTime FechaVencimiento {get; set;}
    public float Precio {get; set;}
    public string Tamanio {get; set;}

    public Producto(){
        Nombre = "";
        FechaVencimiento = default(DateTime);
        Precio = 0;
        Tamanio = "";
    }
    // Constructor predeterminado para objetos de la clase

    public Producto(string nombre, DateTime fechaVencimiento, float precio, string tamanio){
        Nombre = nombre;
        FechaVencimiento = fechaVencimiento;
        Precio = precio;
        Tamanio = tamanio;
    }

}