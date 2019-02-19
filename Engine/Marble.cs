using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
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
        public PointF Location { get; set; }

        public Marble(MarbleState state, MarbleType element)
        {
            State = state;
            Element = element;
            Matchers = new List<MarbleType>();
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

        public bool Placed()
        {
            if (Location.X == 0 && Location.Y == 0)
                return false;
            else
                return true;
        }

        public PointF GetTopXY()
        {
            return new PointF(this.Location.X, this.Location.Y - 1);
        }

        public PointF GetBottomXY()
        {
            return new PointF(this.Location.X, this.Location.Y + 1);
        }

        public PointF GetTopRightXY()
        {
            if (Location.X % 2 == 0)
                return new PointF(this.Location.X+1, this.Location.Y - 1);
            else
                return new PointF(this.Location.X+1, this.Location.Y);
        }

        public PointF GetTopLeftXY()
        {
            if (Location.X % 2 == 0)
                return new PointF(this.Location.X-1, this.Location.Y - 1);
            else
                return new PointF(this.Location.X-1, this.Location.Y );
        }

        public PointF GetBottomRightXY()
        {
            if (Location.X % 2 == 0)
                return new PointF(this.Location.X+1, this.Location.Y );
            else
                return new PointF(this.Location.X+1, this.Location.Y + 1);
        }

        public PointF GetBottomLeftXY()
        {
            if (Location.X % 2 == 0)
                return new PointF(this.Location.X - 1, this.Location.Y);
            else
                return new PointF(this.Location.X -1, this.Location.Y + 1);
        }

        public bool IsMetal()
        {
            //Lead, Tin, Iron, Copper, Silver, Gold
            if (Element == MarbleType.Lead || Element == MarbleType.Tin || Element == MarbleType.Iron || Element == MarbleType.Copper || Element == MarbleType.Silver || Element == MarbleType.Gold)
                return true;
            else
                return false;
        }

        public bool IsMatch(Marble m)
        {
            if (Matchers.Contains(m.Element))
                return true;
            else return false;
        }

        // not needed for this game
        public void Calcify()
        {
            Element = MarbleType.Salt;
        }

        

        // not needed for this game
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


