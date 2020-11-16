using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormSnakeOOP
{
    public partial class SnakeForm : Form
    {
        
        /// <summary>
        /// Размер поля по высоте (Y)
        /// </summary>
        int fieldHeight;
        /// <summary>
        /// Размер поля по ширине (X)
        /// </summary>
        int fieldWidth;
        /// <summary>
        /// масштаб изображения. 1 - один пиксель (без масштаба)
        /// </summary>
        int scale;
        // вынести в класс GameBoard

        GameBoard gameBoard;

        PointLocal testPont;
        
        //int _counter
        Snake snake;
        FoodCreator foodCreator;
        PointLocal food;

        public SnakeForm()
        {
            InitializeComponent();
            // начальная инициализация компонентов
            scale = 10; //масштаб
            //_counter = 0;
            // GameFieldPictueBox.Image = new Bitmap(GameFieldPictueBox.Width, GameFieldPictueBox.Height);
            fieldHeight = GameFieldPictueBox.Height / scale;
            fieldWidth = GameFieldPictueBox.Width / scale;
            
            // создать доску с белым фоном
            gameBoard = new GameBoard(GameFieldPictueBox, scale, Color.White);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            //gameBoard.Graph.FillRectangle(whiteBrush, 0, 0, GameFieldPictueBox.Width, GameFieldPictueBox.Height);

            // нарисовать рамку через объекты горизонтальная и вертикальная линия
            
            HorisontalLine upLine = new HorisontalLine(0, fieldWidth, 0 , 10,Color.DarkRed , gameBoard);
            upLine.Draw();
            HorisontalLine downLine = new HorisontalLine(1, fieldWidth,  fieldHeight-1, 10, Color.DarkRed, gameBoard);
            downLine.Draw();

            VerticalLine leftLine = new VerticalLine(0, 0, fieldHeight , 10, Color.DarkRed, gameBoard);
            leftLine.Draw();
            VerticalLine rightLine = new VerticalLine(fieldWidth -1, 0, fieldHeight, 10, Color.DarkRed, gameBoard);
            rightLine.Draw();
            //-------------------
            // создание и вывод первой точки
            testPont = new PointLocal(fieldWidth / 2, fieldHeight / 2, Color.Red, gameBoard);
            snake = new Snake(testPont, 4, Direction.RIGHT);
            snake.Draw();
            snake.Move();

            foodCreator = new FoodCreator( Color.Green, gameBoard);
            food = foodCreator.CreateFood();
            food.Draw();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (snake.Eat(food))
            {
                food = foodCreator.CreateFood();
                food.Draw();
            }
            else
            { 
                snake.Move(); 
            }
        }

        private void SnakeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                GameTimer.Enabled = !GameTimer.Enabled;
            else
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                  snake.HandleKey(e);

        }
        /*
private void DrawPoint(PointLocal point, Graphics graph)
{
graph.FillEllipse(point.pointBrush, point.x*point.diametr, point.y * point.diametr, point.diametr, point.diametr);
GameFieldPictueBox.Invalidate();
}*/
    }
}
