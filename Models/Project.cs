using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MVCApplicationNew.Models
{
    public enum StatusOptions
    {
        Pending,
        Progress,
        Completed
    }
    public class Project
    {
        [Key, RegularExpression("^[0-9]*$", ErrorMessage = "ProjectId must be digit only")]
        public int ProjectId { get; set; }

        [Required, RegularExpression("^[a-zA-Z_ ]*$", ErrorMessage = "ProjectName must be character only")]
        public string ProjectName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required, RegularExpression("^[a-zA-Z_ ]*$", ErrorMessage = "ProjectManager must be character only")]
        public string ProjectManager { get; set; }

        [Required, RegularExpression("^[0-9]*$", ErrorMessage = "Budget must be digit only")]
        public double Budget { get; set; }

        [Required]
        public StatusOptions Status { get; set; }

        [Required, RegularExpression("^[a-zA-Z_ ]*$", ErrorMessage = "Description must be character only")]
        public string Description { get; set; }

        public double Duration => (EndDate - StartDate).TotalDays;
    }
}
