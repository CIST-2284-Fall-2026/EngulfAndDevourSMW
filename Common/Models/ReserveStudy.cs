using System.Runtime.CompilerServices;

namespace Common.Models
{
    public class ReserveStudy
    {
        public List<RSComponent> components { get; set; } = new List<RSComponent>();
        public int NumUnits { get; set; } = 0;
        public const int StudyHorizon = 30;
    }
}