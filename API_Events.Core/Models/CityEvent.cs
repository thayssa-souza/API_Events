using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace API_Events.Core.Models
{
    public class CityEvent
    {
        public long IdEvent { get; set; }
        
        [Required(ErrorMessage = "É obrigatório cadastrar o nome do evento.")]
        [MaxLength(100, ErrorMessage = "Por razões comerciais, o nome do evento não pode conter mais que 100 caracteres.")]
        public string? Title { get; set; }

        [MaxLength(250, ErrorMessage = "A descrição do evento não pode ultrapassar 250 caracteres.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "A data e o horário de ínicio do evento são obrigatórios no cadastro.")]
        public DateTime DateHourEvent { get; set; }

        [Required(ErrorMessage = "É obrigatório cadastrar o local onde acontecerá o evento.")]
        [MaxLength(100, ErrorMessage = "Por razões comerciais, o local do evento deve ser cadastrado com, no máximo, 100 caracteres.")]
        public string? Local { get; set; }

        [MaxLength(200, ErrorMessage = "Por razões comerciais, o local do evento deve ser cadastrado com, no máximo, 200 caracteres.")]
        public string? Address { get; set; }
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Este campo não pode ser nulo.")]
        public bool Status { get; set; }
    }
}
