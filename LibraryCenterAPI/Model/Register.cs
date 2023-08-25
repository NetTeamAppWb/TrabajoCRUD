namespace LibraryCenterAPI.Model;

public class Register
{
    public int id { get; set; }
    public String Name { get; set; }
    public String Tipe { get; set; } //Solo se debe ingresar Emprendedor o Consumidor
}