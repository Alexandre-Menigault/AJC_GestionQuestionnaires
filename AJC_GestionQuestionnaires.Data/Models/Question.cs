using AJC_GestionQuestionnaires.Data.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJC_GestionQuestionnaires.Data.Models
{
    public class Question : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Answer1 { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string Answer2 { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string? Answer3 { get; set; }

        [Required]
        [MaxLength(200)]
        public string? Answer4 { get; set; }

        [Required]
        [MaxLength(200)]
        public string Answer { get; set; } = null!;
    }
}
