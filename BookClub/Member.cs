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
        Gender nem;
        DateTime birth_date;
        bool banned;

        public Member(int id, string name, string nem, DateTime birth_date, bool banned)
        {
            this.id = id;
            this.name = name;
            this.nem = GetGender(nem);
            this.birth_date = birth_date;
            this.banned = banned;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Birth_date { get => birth_date; set => birth_date = value; }
        public bool Banned { get => banned; set => banned = value; }
        public string Nem { get => getGenderText(this.nem); }
        Gender GetGender(string input)
        {
            switch (input)
            {
                case "M":
                    return Gender.male;
                case "F":
                    return Gender.female;
                default:
                    return Gender.other; // Ha más karaktereket kapsz vagy nem megfelelő karaktereket, akkor a nemet "other"-re állítja
            }
        }
        string getGenderText(Gender gender)
        {
            string description = "";
            switch (gender)
            {
                case Gender.male:
                    description = "Férfi";
                    break;
                case Gender.female:
                    description = "Nő";
                    break;
                case Gender.other:
                    description = "Ismeretlen";
                    break;
                default:
                    description = "Ismeretlen"; // Ez a biztonság kedvéért.
                    break;
            }
            return description;
        }
    }
}
