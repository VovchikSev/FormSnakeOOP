using System.Drawing;
using System.Collections.Generic;
namespace FormSnakeOOP
{
    class Figure
    {
        protected List<PointLocal> pList;
        
        public void Draw()
        {
            foreach (PointLocal p in pList)
            {
                p.Draw();
            }
        }
        internal bool IsHit(Figure figure)
        {
            foreach(var p in pList)
            {
                if (figure.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsHit(PointLocal point)
        {
            foreach(var p in pList)
            {
                if(p.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
