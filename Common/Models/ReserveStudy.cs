using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Common.Models
{
    /// <summary>
    /// Model class representing a reserve study
    /// </summary>
    public class ReserveStudy
    {
        /// <summary>
        /// List of Reserve Study Components representing the components of the reserve study.
        /// </summary>
        public List<RSComponent> Components { get; set; } = new List<RSComponent>();
        /// <summary>
        /// Represents the number of units that an HOA oversees. Must be a positive value above zero.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int NumUnits { get; set; } = 1;
        /// <summary>
        /// Constant static value representing the length of the study in years.
        /// </summary>
        public const int StudyHorizon = 30; // I couldn't decide whether I should tie this value to each reserve study and allow the user to change it. The way I am reading the instructions, "fixed" means this value will be fixed for this program.
    }
}