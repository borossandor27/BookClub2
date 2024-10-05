using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub
{
    internal class Member
    {
        int id;
        string name;
        enum gender { male, female, other };
        DateTime birth_date;
        bool banned;

        public Member(int id, string name, string nem, DateTime birth_date, bool banned)
        {
            this.id = id;
            this.name = name;
            this.birth_date = birth_date;
            this.banned = banned;
            this.GetGender(nem);
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Birth_date { get => birth_date; set => birth_date = value; }
        public bool Banned { get => banned; set => banned = value; }
        gender GetGender(string input)
        {
            switch (input)
            {
                case "M":
                    return gender.male;
                case "F":
                    return gender.female;
               default:
                    return gender.other; // Ha más karaktereket kapsz vagy nem megfelelő karaktereket, akkor a nemet "other"-re állítja
            }
        }
    }
}
