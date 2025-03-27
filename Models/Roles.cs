namespace WebApiTikects.Models
{
    public class Roles
    {
        public int ro_identificador { get; set; }                  // Identificador único del rol
        public string ro_descripcion { get; set; }                 // Descripción del rol
        public DateTime ro_fecha_adicion { get; set; }             // Fecha de creación del rol
        public string ro_adicionado_por { get; set; }              // Usuario que agregó este rol
        public DateTime? ro_fecha_modificacion { get; set; }        // Fecha de última modificación
        public string? ro_modificado_por { get; set; }
    }
}
