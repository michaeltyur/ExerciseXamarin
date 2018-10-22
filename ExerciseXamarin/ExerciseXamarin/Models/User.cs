using System;
using System.Collections.Generic;
using System.Text;

namespace ExerciseXamarin.Models
{

        public class User
        {
            public Result[] Results { get; set; }
            public Info Info { get; set; }
        }

        public class Info
        {
            public string seed { get; set; }
            public int results { get; set; }
            public int page { get; set; }
            public string version { get; set; }
        }

        public class Result
        {
            public string gender { get; set; }
            public Name Name { get; set; }
            public Location location { get; set; }
            public string Email { get; set; }
            public Login login { get; set; }
            public Dob dob { get; set; }
            public Registered registered { get; set; }
            public string Phone { get; set; }
            public string Cell { get; set; }
            public Id Id { get; set; }
            public Picture Picture { get; set; }
            public string nat { get; set; }
        }

        public class Name
        {
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class Location
        {
            public string street { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public int postcode { get; set; }
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

        public class Login
        {
            public string uuid { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string salt { get; set; }
            public string md5 { get; set; }
            public string sha1 { get; set; }
            public string sha256 { get; set; }
        }

        public class Dob
        {
            public DateTime date { get; set; }
            public int Age { get; set; }
        }

        public class Registered
        {
            public DateTime Date { get; set; }
            public int Age { get; set; }
        }

        public class Id
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }

        public class Picture
        {
            public string Large { get; set; }
            public string Medium { get; set; }
            public string Thumbnail { get; set; }
        }

}
