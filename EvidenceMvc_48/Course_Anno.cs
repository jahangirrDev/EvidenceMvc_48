using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EvidenceMvc_48
{
    public class Course_Anno
    {

        [Required]
        public int Id { get; set; }

        [StringLength(10)]
        public string Subject_Name { get; set; }

        [Range(1.0,500.0)]
        public Nullable<int> Course_Id { get; set; }
        public bool Is_Major { get; set; }

        [DataType(DataType.DateTime)]
        public System.DateTime Start_Date { get; set; }

        public string Book_Image { get; set; }
    }
}