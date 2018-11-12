using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Datas
{
    /// <summary>
    /// the class contains all the information for an event
    /// </summary>
    public class EventDetail
    {
        public string name { get; set; }
        public DateTime date { get; set; }
        public int available_seats { get; set; }
        public float price { get; set; }
        public string venue { get; set; }
        public List<string> labels { set; get; }
    }
}
