using System.Text.Json;
namespace TP9;

class Program{

    static int Main(string[] args){
        
        Console.WriteLine("====> Indexador de carpeta: ");
        Console.WriteLine("Advertencia: no probar con carpetas que contengan archivos sin un nombre y una extensión");
        Console.WriteLine("Ingrese el path de una carpeta: ");

        string? path = Console.ReadLine();

        var listaArchivos = new List<InfoArchivo>();
        // Lista para guardar los archivos encontrados

        EnlistarYMostrarArchivos(path,listaArchivos);
        SerializarListaArchivos(listaArchivos);

        Console.WriteLine("\nDeserialización del archivo JSON: ");

        var listaArchivosDeserializada = DeserializarListaArchivos();
        // Lista para deserializar JSON

        foreach (var archivo in listaArchivosDeserializada)
        {
            Console.WriteLine($"Archivo: {archivo.Nombre}.{archivo.Extension}");
        }

        Console.Read();

        return 0;
    }

    static void EnlistarYMostrarArchivos(string path, List<InfoArchivo> listaArchivos){

        if(Directory.Exists(path)){

            List<string> archivos = Directory.GetFiles(path).ToList();
            List<string> subcarpetas = Directory.GetDirectories(path).ToList();
            // Se crean listas con los nombres de los archivos y las subcarpetas del directorio pedido.
            
            if(archivos.Any() || subcarpetas.Any())
            {

                var separarRuta = path.Split("\\");

                Console.WriteLine("Mostrando los archivos de la carpeta " + separarRuta[separarRuta.Length - 1]);
                // Se indica al usuario en qué directorio están los archivos.

                MostrarYEnlistar(listaArchivos, archivos);
                // Método para mostrar los archivos y enlistarlos.

                foreach (string rutaSubcarpeta in subcarpetas)
                {
                    EnlistarYMostrarArchivos(rutaSubcarpeta, listaArchivos);
                }
                // Se recorren las subcarpetas!

            }
        }
    }

    private static void MostrarYEnlistar(List<InfoArchivo> listaArchivos, List<string> archivos)
    {
        short i = 1;
        // Indice para indicar el número de archivo o carpeta en una carpeta determinada. Se "reinicia" en cada llamada recursiva.

        string[] separarRuta;

        foreach (string rutaArchivo in archivos)
        {
            separarRuta = rutaArchivo.Split("\\");

            Console.WriteLine("File -> " + separarRuta[separarRuta.Length - 1]);
            // Se muestra al usuario cada archivo de cada subcarpeta

            var nombreYExtension = separarRuta[separarRuta.Length - 1].Split(".");

            listaArchivos.Add(new InfoArchivo(i, nombreYExtension[0], nombreYExtension[1]));
            // Se enlista el archivo a la lista de archivos.

            i++;
        }
    }

    public static void SerializarListaArchivos(List<InfoArchivo> listaArchivos){

        string rutaArchivoJson = @"D:\Facultad\2do\Taller_de_Lenguajes_I\Repositorios\TPS\tp09-2022-martinaguero-t\index.json";

        using(StreamWriter sw = new StreamWriter(rutaArchivoJson)){

            string serializarArchivos = JsonSerializer.Serialize(listaArchivos);
            sw.WriteLine(serializarArchivos);

        }

    }

    public static List<InfoArchivo> DeserializarListaArchivos(){

        string rutaArchivoJson = @"D:\Facultad\2do\Taller_de_Lenguajes_I\Repositorios\TPS\tp09-2022-martinaguero-t\index.json";

        List<InfoArchivo> deserializarArchivos = new List<InfoArchivo>();

        using(StreamReader sr = new StreamReader(rutaArchivoJson)){

            string textoJson = sr.ReadLine();

            if(!string.IsNullOrEmpty(textoJson)){
                deserializarArchivos = JsonSerializer.Deserialize<List<InfoArchivo>>(textoJson);
            }

        }

        return deserializarArchivos;

    }
}
