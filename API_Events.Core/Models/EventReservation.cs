using System.ComponentModel.DataAnnotations;

namespace API_Events.Core.Models
{
    public class EventReservation
    {
        public long IdReservation { get; set; }
        public long IdEvent { get; set; }

        [Required(ErrorMessage = "O nome da pessoa que está fazendo a reserva é obrigatório.")]
        [MaxLength(100, ErrorMessage = "Por razões comerciais, o nome pode conter apenas 100 caracteres, " +
            "adicione apenas o primeiro nome e o último sobrenome")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "Por questões de segurança, é obrigatório informar a quantidade de pessoas" +
            " para realizar a reserva")]
        public long Quantity { get; set; }
    }
}
