namespace ContactosModel.Model
{
    public class ContactoModel
    {
        public int idOrigen { get; set; } 
        public int idDestino { get; set; } 
        public string nombreCompleto { get; set; } //Nombre y apellido concatenados (del destino).
    }
}