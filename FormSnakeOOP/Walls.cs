using System.Collections.Generic;
//using System.Drawing;
using System.Threading.Tasks;

namespace FormSnakeOOP
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight, int diametr, System.Drawing.Color color, GameBoard gameBoard )
        {
            wallList = new List<Figure>();
            // отрисовка рамки объектами соответствующих линий
            HorisontalLine upLine = new HorisontalLine(0, mapWidth - 1, 0, diametr, color, gameBoard);
            HorisontalLine downLine = new HorisontalLine(0, mapWidth, mapHeight - 1, diametr, color, gameBoard);
            VerticalLine leftLine = new VerticalLine(0, 0, mapHeight - 1, diametr, color, gameBoard);
            VerticalLine rightLine = new VerticalLine(mapWidth - 1, 0, mapHeight - 1, diametr, color, gameBoard);

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }
        internal bool IsHit(Figure figure)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
