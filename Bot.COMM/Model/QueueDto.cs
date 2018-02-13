using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    [DataContract]
    public class QueueDto : Dto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CustomerId { get; set; }
        [DataMember]
        public HoursOfOperation HoursOfOperation { get; set; }
        [DataMember]
        public List<string> SupportedLanguages { get; set; }// list of language code
        [DataMember]
        public string SIP { get; set; }
        [DataMember]
        public string BackupSIP { get; set; }

    }

    [DataContract]
    public class LocalQueueName
    {
        [DataMember]
        public string LanguageCode { get; set; }
        [DataMember]
        public string QueueName { get; set; }
    }
    [DataContract]
    public class GlobalQueueName
    {
        [DataMember]
        public List<LocalQueueName> QueueNames { get; set; }
    }

    [DataContract]
    public class HoursOfOperation
    {
        [DataMember]
        public string TimeZone { get; set; }
        [DataMember]
        public List<WorkDay> WorkDays { get; set; } // seven days 

    }

    [DataContract]
    public class WorkShift
    {
        [DataMember]
        public int StartHour { get; set; }
        [DataMember]
        public int EndHour { get; set; }
        public WorkShift(int startHour, int endHour)
        {
            if (startHour > endHour)
            {
                throw new ArgumentException("startHour can't be greater then endHour!");
            }
            StartHour = startHour;
            EndHour = endHour;
        }

        public bool IsInWindow(DateTime dt, DayOfWeek dayofWeek)
        {
            return dt.DayOfWeek == dayofWeek && dt.Hour >= StartHour && dt.Hour < EndHour;
        }
        public override string ToString()
        {

            return 
                DateTime.ParseExact(StartHour.ToString("00"), "HH", CultureInfo.CurrentCulture).ToString("hh:mm tt")
             + " -- " +
                DateTime.ParseExact(EndHour.ToString("00"), "HH", CultureInfo.CurrentCulture).ToString("hh:mm tt"); ;
        }
    }
    [DataContract]
    public class WorkDay
    {
        [DataMember]
        public DayOfWeek Day { get; set; }
        [DataMember]
        public Choice Type { get; set; }
        [DataMember]
        public List<WorkShift> WorkShifts { get; set; }
    }

    [DataContract]
    public enum Choice
    {
        [EnumMember]
        All24Hours = 1,
        [EnumMember]
        Custom = 2,
        [EnumMember]
        Closed = 3
    }
}
