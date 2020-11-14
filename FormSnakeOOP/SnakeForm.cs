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
        Random R;
        int _counter;

        public SnakeForm()
        {
            InitializeComponent();
            // начальная инициализация компонентов
            scale = 10; //масштаб
            _counter = 0;
            // GameFieldPictueBox.Image = new Bitmap(GameFieldPictueBox.Width, GameFieldPictueBox.Height);
            fieldHeight = GameFieldPictueBox.Height / scale;
            fieldWidth = GameFieldPictueBox.Width / scale;
            R = new Random();
            // создать доску с белым фоном
            gameBoard = new GameBoard(GameFieldPictueBox, scale, Color.White);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            gameBoard.Graph.FillRectangle(whiteBrush, 0, 0, GameFieldPictueBox.Width, GameFieldPictueBox.Height);

            testPont = new PointLocal(fieldWidth / 2, fieldHeight / 2, scale, Color.Gray, gameBoard);
            testPont.Draw();



            // HorisontalLine topLine = new HorisontalLine(0, fieldWidth, Color.Red);


            //GameBoard = Graphics.FromImage(GameFieldPictueBox.Image);
            // альтернатива заливке всего поля очистка. позднее проверить как работает очистка на смене изображения, 
            // если что вернуться к перезаливке белого квадрата.
            
            
            //GameBoard.Clear(Color.White);
            // попытка отрисовать бордюры из класса  с помощью списка точек
            /*
            int diametrBorderPoint = 20;
            HorisontalLine UpLine = new HorisontalLine(0, GameFieldPictueBox.Width / diametrBorderPoint, 0, diametrBorderPoint, Color.Brown);
            UpLine.Draw(GameBoard, GameFieldPictueBox);
            HorisontalLine DownLine = new HorisontalLine(0, GameFieldPictueBox.Width / diametrBorderPoint,  
                                      GameFieldPictueBox.Height / diametrBorderPoint, diametrBorderPoint, Color.Black);
            DownLine.Draw(GameBoard, GameFieldPictueBox);
            */

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            // срабатывание тика
            // gameBoard.Graph.DrawString внести строку на канву
            //стереть точку нарисовать в новом месте
            // testPont.Clear();
            testPont.X = R.Next(fieldWidth);
            testPont.Y = R.Next(fieldHeight);
            testPont.Draw();

        }
        /*
private void DrawPoint(PointLocal point, Graphics graph)
{
   graph.FillEllipse(point.pointBrush, point.x*point.diametr, point.y * point.diametr, point.diametr, point.diametr);
   GameFieldPictueBox.Invalidate();
}*/
    }
}
