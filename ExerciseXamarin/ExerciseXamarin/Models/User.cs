using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseXamarin.Models
{
    public class UserList
    {
        public User[] Results { get; set; }
        public Info info { get; set; }
    }

    public class Info
    {
        public string seed { get; set; }
        public int results { get; set; }
        public int page { get; set; }
        public string version { get; set; }
    }

    public class User
    {
        public string Gender { get; set; }
        public Name Name { get; set; }
        public Location Location { get; set; }
        public string Cell { get; set; }
        public Picture Picture { get; set; }
    }

    public class Name
    {
        public string title { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string FullName { get; set; }

    }

    public class Location
    {
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public Coordinates coordinates { get; set; }
        public Timezone timezone { get; set; }
    }

    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Timezone
    {
        public string offset { get; set; }
        public string description { get; set; }
    }

    public class Picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }



}
