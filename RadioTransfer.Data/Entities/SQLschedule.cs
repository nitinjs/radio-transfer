using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Thornton.Data;

namespace SQLjobScheduler
{
    [Serializable]
    //[Table("SQLschedules")]
    public class SQLschedule
    {
        public int SQLscheduleId { get; set; }
        //public string schedule_uid { get; set; }
        //public int originating_server_id { get; set; }
        public string name { get; set; }
        //public string owner_sid { get; set; }
        public bool enabled { get; set; }


        #region Form Element
        public int SelectedTabIndex { get; set; }
        public int Tab1_Minutes { get; set; }
        public int Tab2_SelectedRadioIndex { get; set; }
        public int Tab2_Hours { get; set; }
        public int Tab2_At_HH { get; set; }
        public int Tab2_At_MM { get; set; }
        public int Tab3_SelectedRadioIndex { get; set; }
        public int Tab3_Days { get; set; }
        public int Tab3_EveryWeekDay_HH { get; set; }
        public int Tab3_EveryWeekDay_MM { get; set; }
        public bool Tab4_Monday { get; set; }
        public bool Tab4_Tuesday { get; set; }
        public bool Tab4_Wednesday { get; set; }
        public bool Tab4_Thursday { get; set; }
        public bool Tab4_Friday { get; set; }
        public bool Tab4_Saturday { get; set; }
        public bool Tab4_Sunday { get; set; }
        public int Tab4_Day_HH { get; set; }
        public int Tab4_Day_MM { get; set; }
        public int Tab5_SelectedRadioIndex { get; set; }
        public int Tab5_DayX { get; set; }
        public int Tab5_XMonths { get; set; }
        public int Tab5_Xth { get; set; }
        public int Tab5_XthDay { get; set; }
        public int Tab5_EveryXMonths { get; set; }
        public int Tab5_Month_HH { get; set; }
        public int Tab5_Month_MM { get; set; }
        public int Tab6_SelectedRadioIndex { get; set; }
        public int Tab6_MonthName { get; set; }
        public int Tab6_MonthDate { get; set; }
        public int Tab6_Xth { get; set; }
        public int Tab6_XthDay { get; set; }
        public int Tab6_OfMonthName { get; set; }
        public int Tab6_Year_HH { get; set; }
        public int Tab6_Year_MM { get; set; }
        public string CronExpression { get; set; }
        #endregion

        public bool IsOnetime { get; set; }

        public DateTime active_start_date { get; set; }
        public DateTime? active_end_date { get; set; }
        public DateTime date_created { get; set; }
        public DateTime? date_modified { get; set; }
        //public int version_number { get; set; }

        public int TaskTypeId { get; set; }
        //public virtual TaskType TaskType { get; set; }
        public string Path { get; set; }//HTTP PATH
        public string OutputPath { get; set; }//LOCAL PATH
        public string OutputFileName { get; set; }
        public bool RenameOldFile { get; set; }
        public string FTP_Host { get; set; }
        public int FTP_Port { get; set; }
        public string FTP_Path { get; set; }
        public int FTP_Protocol { get; set; }
        public int FTP_LogonType { get; set; }
        public string FTP_UserName { get; set; }
        public string FTP_Password { get; set; }

        public bool FTP_IsPassive { get; set; }
        public bool FTP_SyncSubdirectories { get; set; }

        public bool IsProcessing { get; set; }
    }
}
