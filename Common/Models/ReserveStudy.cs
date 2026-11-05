using System.Runtime.CompilerServices;

namespace Common.Models
{
    public class ReserveStudy
    {
        public List<Component> components { get; set; } = new List<Component>();
        public int NumUnits { get; set; } = 0;
        public const int StudyHorizon = 30;
    }
}