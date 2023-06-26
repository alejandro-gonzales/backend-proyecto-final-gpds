using static System.Runtime.InteropServices.JavaScript.JSType;

namespace backend_proyecto_final_gpds.Dominio
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdLibro { get; set; }
        public string FechaRetiro { get; set; }
        public string FechaDevolucion { get; set; }
        public Usuario? Usuario { get; set; }
        public Libro? Libro { get; set; }
    }
}
