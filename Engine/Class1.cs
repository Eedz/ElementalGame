using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace Engine
{
    public enum MarbleState { Frozen, Free }
    public enum MarbleType { Salt, Earth, Fire, Water, Air, Vitae, Mors, Quicksilver, Lead, Tin, Iron, Copper, Silver, Gold }

    public class Marble
    {
        public MarbleState State { get; set; }
        public MarbleType Element { get; set; }
        public List<MarbleType> Matchers { get; set; }

        public Marble(MarbleState state, MarbleType element)
        {
            State = state;
            Element = element;
            GetMatchers();
        }

        public void GetMatchers()
        {
            switch (Element)
            {
                case MarbleType.Air:
                    Matchers.Add(MarbleType.Air);
                    Matchers.Add(MarbleType.Salt);
                    break;
                case MarbleType.Water:
                    Matchers.Add(MarbleType.Water);
                    Matchers.Add(MarbleType.Salt);
                    break;
                case MarbleType.Earth:
                    Matchers.Add(MarbleType.Earth);
                    Matchers.Add(MarbleType.Salt);
                    break;
                case MarbleType.Fire:
                    Matchers.Add(MarbleType.Fire);
                    Matchers.Add(MarbleType.Salt);
                    break;
                case MarbleType.Salt:
                    Matchers.Add(MarbleType.Air);
                    Matchers.Add(MarbleType.Water);
                    Matchers.Add(MarbleType.Earth);
                    Matchers.Add(MarbleType.Fire);
                    Matchers.Add(MarbleType.Salt);
                    break;
                case MarbleType.Vitae:
                    Matchers.Add(MarbleType.Mors);
                    break;
                case MarbleType.Mors:
                    Matchers.Add(MarbleType.Vitae);
                    break;
                case MarbleType.Quicksilver:
                    Matchers.Add(MarbleType.Lead);
                    Matchers.Add(MarbleType.Tin);
                    Matchers.Add(MarbleType.Iron);
                    Matchers.Add(MarbleType.Copper);
                    Matchers.Add(MarbleType.Silver);
                    Matchers.Add(MarbleType.Gold);
                    break;
                case MarbleType.Lead:
                    Matchers.Add(MarbleType.Quicksilver);
                    break;
                case MarbleType.Tin:
                    Matchers.Add(MarbleType.Quicksilver);
                    break;
                case MarbleType.Iron:
                    Matchers.Add(MarbleType.Quicksilver);
                    break;
                case MarbleType.Copper:
                    Matchers.Add(MarbleType.Quicksilver);
                    break;
                case MarbleType.Silver:
                    Matchers.Add(MarbleType.Quicksilver);
                    break;
                case MarbleType.Gold:
                    break;
            }
        }

        public void Calcify()
        {
            Element = MarbleType.Salt;
        }

        public bool IsMatch(Marble m)
        {
            if (Matchers.Contains(m.Element))
                return true;
            else return false;
        }

        public void Ascend()
        {
            switch (Element)
            {
                case MarbleType.Lead:
                    Element = MarbleType.Tin;
                    break;
                case MarbleType.Tin:
                    Element = MarbleType.Iron;
                    break;
                case MarbleType.Iron:
                    Element = MarbleType.Copper;
                    break;
                case MarbleType.Copper:
                    Element = MarbleType.Silver;
                    break;
                case MarbleType.Silver:
                    Element = MarbleType.Gold;
                    break;
                default:
                    break;
            }
        }
    }
}


