namespace ADRES_API.Models
{
    public class PresupuestoDTO
    {
        public int Id { get; set; }
        public decimal Presupuesto { get; set; }
        public string Unidad { get; set; }
        public string TipoDeBienOServicio { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime FechaDeAdquisicion { get; set; }
        public string Proveedor { get; set; }
        public string Documentacion { get; set; }
    }
}
