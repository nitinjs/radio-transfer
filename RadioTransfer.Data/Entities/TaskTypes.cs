using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thornton.Data
{
    //[Table("TaskType")]
    public class TaskType
    {
        public long TaskTypeId { get; set; }
        public string Name { get; set; }
    }
    /*
    1 HTTP 
    2 FTP 
    3 Network Folder 
    4 Dropbox 
    5 Google Drive 
    6 RSS 
     */
    public class TaskTypes
    {
        public const int HTTP = 1;
        public const int FTP = 2;
        public const int NetworkFolder = 3;
        public const int Dropbox = 4;
        public const int GoogleDrive = 5;
        public const int RSS = 6;
    }
}
