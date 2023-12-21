using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Catalog.CodeLevel2Managements
{
    public class CodeLevel2ManagementCreateRequest
    {
        [MaxLength(3, ErrorMessage = "Mã code level 1 không được vượt quá 3 ký tự")]
        public string CodeLevel1 { get; set; } //Mã code lv1
        public string IDLevel1 { get; set; } //Mã lv1
        [MaxLength(20, ErrorMessage = "Mã code level 2 không được vượt quá 20 ký tự")]
        public string CodeLevel2 { get; set; } //Mã code lv2
        [MaxLength(50, ErrorMessage = "Mô tả code level 2 không được vượt quá 50 ký tự")]
        public string CodeLevel2Description { get; set; }//Mô tả code lv2
        public int CodeLevel2Lenght { get; set; }//Độ dài mã code lv2
    }
}
