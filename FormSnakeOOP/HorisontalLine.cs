using System.Drawing;
using System.Collections.Generic;


namespace FormSnakeOOP
{
    class HorisontalLine:Figure
    {
        //List<PointLocal> pList;
        public HorisontalLine(int xLeft, int xRight, int y, int diametr, Color color, GameBoard _board)
        {
            pList = new List<PointLocal>();
            for (int x = xLeft; x < xRight; x++)
            {
                PointLocal p = new PointLocal(x, y,  color, _board);
                pList.Add(p);
            }
        }
        /* переехало в фигуру
        public void Draw()
        {
            foreach(PointLocal p in pList)
            {
                p.Draw();
            }
        }
        */
    }
        
}
