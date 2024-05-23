using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyTe.Models.Entities
{
    public class WBSDTO
    {
        public int Id { get; set; }
        public string? CodigoWBS { get; set; }
        public string? Descricao { get; set; }
    }
}
