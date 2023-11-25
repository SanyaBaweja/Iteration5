using System;
using Iteration5;
using System.Xml.Linq;

namespace Iteration5

{
    public class Path : Game_Object
    {
        Location _l;
        bool _locked;

        public Path(string[] ids, string name, string desc, Location l) : base(ids, name, desc)
        {
            _l = l;
        }

        public Location Loc
        {
            get
            {
                return _l;
            }
        }
        public bool Locked
        {
            get
            {
                return _locked;
            }
            set
            {
                _locked = value;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "On moving " + Name + " there is " + Loc.Name;
            }
        }
    }
}


