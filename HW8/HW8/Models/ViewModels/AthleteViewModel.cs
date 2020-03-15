using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW8.Models;
using HW8.Models.ViewModels;

namespace HW8.Models.ViewModels {
    public class AthleteViewModel {

        private TracknFieldContext db = new TracknFieldContext();

        public AthleteViewModel(Athlete athlete) {

            MeetDate = athlete.Events.Select(x => x.Location).Select(d => d.Date).OrderBy(a => a.Date).ToList();
            AthleteID = athlete.ID;
            Distance = athlete.Events.Select(m => m.Distance).ToList();                     
            RaceTime = athlete.Events.Select(k => k.RaceTimes).ToList();
            Location = athlete.Events.Select(a => a.Location).Select(b=>b.Name).ToList();
            Name = athlete.Name.ToString();

            //Hanna has helped me with the sorting
            //https://stackoverflow.com/questions/21931941/cannot-implicitly-convert-type-when-groupby
            //Used above link to fix the GroupBy

            List<Tuple<DateTime, string>> temp = new List<Tuple<DateTime, string>>();

            for (int i = 0; i < MeetDate.Count; i++) {
                temp.Add(new Tuple<DateTime, string>(MeetDate[i], Distance[i]));
            }


            temp = temp.OrderBy(i => i.Item1).GroupBy(k => k.Item2).SelectMany(gr => gr).ToList();

            for (int i = 0; i < MeetDate.Count; i++) {
                MeetDate[i] = temp[i].Item1;
                Distance[i] = temp[i].Item2;
            }

        }

        [Key]

        //converted to iterable list so that I can format it in the view
        //I fear I may need to use javascript to iterate over this nonsense
        public int? AthleteID { get; private set; }
       
        public string Name { get; private set; }
        public List<float?> RaceTime { get; private set; }
        //public float?[] RaceTime { get; private set; }
        public List<DateTime> MeetDate { get; private set; }
        //public DateTime[] MeetDate { get; private set; }
        public List<string> Distance { get; private set; }
        //public string[] Distance { get; private set; }
        public List<string> Location { get; private set; }
        //public string[] Location { get; private set; }

    }
}