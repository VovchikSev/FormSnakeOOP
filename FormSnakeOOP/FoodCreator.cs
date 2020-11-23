using System;
using System.Drawing;
namespace FormSnakeOOP
{
    class FoodCreator
    {
        // можно получать относительные величины из gameBoard
        int mapsWidth;
        int mapsHeight;
        //int diametr;
        Color color;
        GameBoard gameBoard;
        Random random = new Random();

        public FoodCreator(Color color, GameBoard gameBoard)
        {
            this.gameBoard = gameBoard;
            mapsWidth = gameBoard.PictureBox.Image.Width / gameBoard.Scale;
            mapsHeight = gameBoard.PictureBox.Image.Height / gameBoard.Scale;
            //this.diametr = gameBoard.Scale; // пока не понятно для чего использовать, может если понадобится размер точки не равный масштабу.
            // и тогда можно исподльзовать другой механизм получения относительных координат
            this.color = color;
        }
        public PointLocal CreateFood()
        {
            int x = random.Next(2, mapsWidth - 2);
            int y = random.Next(2, mapsHeight - 2);
            return new PointLocal(x, y, color, gameBoard);
        }
    }
}
