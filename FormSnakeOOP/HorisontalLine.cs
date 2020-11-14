using System.Drawing;
using System.Collections.Generic;


namespace FormSnakeOOP
{
    class HorisontalLine
    {
        List<PointLocal> pList;
        public HorisontalLine(int xLeft, int xRight, int y, int diametr, Color color, GameBoard _board)
        {
            pList = new List<PointLocal>();
            for (int x = xLeft; x <= xRight; x++)
            {
                //PointLocal p = new PointLocal(x, y, diametr, color, _graph);
                //pList.Add(p);
            }
        }
        public void Draw(  System.Windows.Forms.PictureBox pictureBox)
        {
            foreach(PointLocal p in pList)
            {
                //p.Draw(graph, pictureBox);
            }
        }
    }
        
}
