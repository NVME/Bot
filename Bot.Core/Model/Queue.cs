using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bot.COMM
{
    public class Queue
    {
        public int QueueId { get; set; }
        public string EnglishName { get; set; }
        public string CustomerId { get; set; }
        public HoursOfOperation HoursOfOperation { get; set; }
        public List<string> SupportedLanguages { get; set; } // list of language code
    }
    public class Avaya : Queue
    {
        public string SIP { get; set; }
        public string BackupSIP { get; set; }
    }

    public class ServiceNow : Queue { }

    [DataContract]
    public class LocalQueueName
    {
        [DataMember]
        public string  LanguageCode { get; set; }
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
        All24Hours =1,
        [EnumMember]
        Custom =2,
        [EnumMember]
        Closed =3
    }
}
