using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.CodeLevel1Managements
{
    public class CodeLevel1ManagementUpdateRequest
    {
        [MaxLength(3, ErrorMessage = "Mã code level 1 không được vượt quá 3 ký tự")]
        public string CodeLevel1 { get; set; } //Mã code lv1
        [MaxLength(50, ErrorMessage = "Mô tả code level 2 không được vượt quá 50 ký tự")]
        public string CodeLevel1Description { get; set; }//Mô tả code lv1
        public int CodeLevel1Lenght { get; set; }//Độ dài mã code lv
    }
}
