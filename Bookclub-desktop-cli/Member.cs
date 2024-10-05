using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookclub_desktop_cli
{
    internal class Member
    {
        int id;
        string name;
        string gender;
        DateTime birth_date;
        bool banned;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public DateTime Birth_date { get => birth_date; set => birth_date = value; }
        public bool Banned { get => banned; set => banned = value; }

        public Member(int id, string name, string gender, DateTime birth_date, bool banned)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Birth_date = birth_date;
            Banned = banned;
        }
    }
}
