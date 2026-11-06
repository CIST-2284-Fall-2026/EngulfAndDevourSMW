using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Common.Models
{
    public class ReserveStudy
    {
        public List<RSComponent> Components { get; set; } = new List<RSComponent>();
        [Required]
        [Range(0, int.MaxValue)]
        public int NumUnits { get; set; } = 1;
        public const int StudyHorizon = 30;
    }
}