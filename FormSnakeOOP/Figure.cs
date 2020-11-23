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
    }
}
