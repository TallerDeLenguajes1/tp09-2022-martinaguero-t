namespace TP9;

public class InfoArchivo{

    public int NumRegistro {get; set;}
    public string Nombre {get; set;}
    public string Extension {get; set;}

    public InfoArchivo(int numRegistro, string nombreArchivo, string extensionArchivo){

        this.NumRegistro = numRegistro;
        if(!string.IsNullOrEmpty(nombreArchivo)) this.Nombre = nombreArchivo; else this.Nombre = "";
        if(!string.IsNullOrEmpty(extensionArchivo)) this.Extension = extensionArchivo; else this.Extension = "";

    }

    // Constructor predeterminado para deserializacion
    public InfoArchivo(){
        NumRegistro = 0;
        Nombre = "";
        Extension = "";
    }


} 