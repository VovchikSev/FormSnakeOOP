using System.Drawing;
using System.Collections.Generic;

namespace FormSnakeOOP
{
    class VerticalLine:Figure
    {
       // List<PointLocal> pList;
        public VerticalLine(int x, int yUp, int yDown,  int diametr, Color color, GameBoard _board)
        {
            pList = new List<PointLocal>();
            for (int y = yUp; y < yDown; y++)
            {
                PointLocal p = new PointLocal(x, y,  color, _board);
                pList.Add(p);
            }
        }
        /* переехало в фигуру
        public void Draw()
        {
            foreach (PointLocal p in pList)
            {
                p.Draw();
            }
        }
        */

    }
}
