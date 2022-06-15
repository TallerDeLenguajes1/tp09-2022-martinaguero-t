using System.Text.Json;
namespace TP92;

class Program{

    static int Main(string[] args){
        
        Console.WriteLine("==== PRODUCTOS: ");
        Console.WriteLine("-> Ingrese la cantidad de productos a generar: ");
        
        int cantidadProductos;
        int.TryParse(Console.ReadLine(),out cantidadProductos);

        List<Producto> listaProductos = GenerarProductos(cantidadProductos);

        Console.WriteLine("Se cargaron los siguientes productos: ");
        MostrarProductos(listaProductos);

        Serializar(listaProductos);
        
        List<Producto> listaDeserializada = Deserializar();

        Console.WriteLine("El contenido de la lista deserializada es: ");
        MostrarProductos(listaDeserializada);
        
        Console.Read();

        return 0;
    }

    public static void MostrarProductos(List<Producto> listaProductos){

        int i = 1;

        foreach (var producto in listaProductos)
        {
            Console.WriteLine($"==> PRODUCTO {i}: ");
            Console.WriteLine($"- Nombre: {producto.Nombre}");
            Console.WriteLine($"- Fecha de vencimiento: {producto.FechaVencimiento.ToString("dd-MM-yyyy")}");
            Console.WriteLine($"- Precio: ${producto.Precio} ");
            Console.WriteLine($"- Tamaño: {producto.Tamanio} \n");
        }
    }

    public static List<Producto> GenerarProductos(int cantidadProductos){

        List<Producto> listaProductos = new List<Producto>();

        for (int i = 0; i < cantidadProductos; i++)
        {
            listaProductos.Add(GenerarProductoAleatorio());
        }

        return listaProductos;

    }

    
    public static Producto GenerarProductoAleatorio(){

        string[] posiblesNombres = {"Galletitas","Agua","Manzana","Banana","Sandía","Caramelos"};
        string[] posiblesTamanios = {"Pequeño","Mediano","Grande"};

        Random rand = new Random();

        Producto nuevoProducto = new Producto(posiblesNombres[rand.Next(posiblesNombres.Length)],new DateTime(rand.Next(2021,2023),rand.Next(1,13),rand.Next(1,29)),(float) rand.Next(1,1000),posiblesTamanios[rand.Next(posiblesTamanios.Length)]);

        return nuevoProducto;

    }

    public static void Serializar(List<Producto> listaProductos){

        string rutaArchivoJson = @"D:\Facultad\2do\Taller_de_Lenguajes_I\Repositorios\TPS\tp09-2022-martinaguero-t\productos.json";

        using(StreamWriter sw = new StreamWriter(rutaArchivoJson,true)){

            string serializarListaProductos = JsonSerializer.Serialize(listaProductos);
            sw.WriteLine(serializarListaProductos);

        }

    }

    public static List<Producto> Deserializar(){

        string rutaArchivoJson = @"D:\Facultad\2do\Taller_de_Lenguajes_I\Repositorios\TPS\tp09-2022-martinaguero-t\productos.json";

        List<Producto> deserializarProductos = new List<Producto>();

        using(StreamReader sr = new StreamReader(rutaArchivoJson)){

            string textoJson = sr.ReadLine();

            if(!string.IsNullOrEmpty(textoJson)){
                deserializarProductos = JsonSerializer.Deserialize<List<Producto>>(textoJson);
            }

        }

        return deserializarProductos;

    }
    
}

