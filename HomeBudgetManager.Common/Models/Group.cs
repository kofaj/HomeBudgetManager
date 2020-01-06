using System.Collections.Generic;

namespace HomeBudgetManager.Common.Models
{
    public struct Group
    {
        public int GroupId;
        public string Name;
        public IList<Atribute> Atributes;

        public Group(int groupId, string name, IList<Atribute> atributes)
        {
            GroupId = groupId;
            Name = name;
            Atributes = atributes;
        }

        public override bool Equals(object obj)
        {
            bool result = false;

            if(obj is Group g)
            {
                result = g.Name == Name;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() * 11;
        }
    }
}
