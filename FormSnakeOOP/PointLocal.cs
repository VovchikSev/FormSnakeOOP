/*
 * класс локальной графической точки
 * 
 */
using System.Drawing;
namespace FormSnakeOOP
{
    class PointLocal
    {
        // точка состоит из координат: X Y кисти и диаметра. 
        /// <summary>
        /// Относительная координата по оси X
        /// </summary>
        int x;
        /// <summary>
        /// относительная координата по оси Y
        /// </summary>
        int y;
        /// <summary>
        /// Диаметр точки, совпадает с масштабом
        /// </summary>
        int diametr;
        /// <summary>
        /// масштаб
        /// </summary>
        int scale;
        /// <summary>
        /// Кисть которой рисуется точка.
        /// </summary>
        SolidBrush pointBrush ;
        /// <summary>
        /// Объект Graphics на котором будет отображаться точка.
        /// </summary>
        Graphics graph;
        GameBoard gameBoard;
        // скрыть излишне открытые члены
        // инициализацию сделать в конструкторе
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public PointLocal(int _x, int _y, int _diametr, Color _color, GameBoard _gameBoard )
        
        {


        x = _x;
            y = _y;
            diametr = _diametr;
            pointBrush = new System.Drawing.SolidBrush(_color);
            gameBoard = _gameBoard;
            graph = gameBoard.Graph;
        }


        public void Draw()
        {
            graph.FillEllipse(pointBrush, x * diametr, y * diametr, diametr, diametr);
            // перенести в обработчик таймера и там перерисовывать. 
            gameBoard.PictureBox.Invalidate();
        }
        // сделать другой Draw, где не будет смещения по диаметру.
        // нужно понимание роцесса рисования. 
        // наверное нужно сделать отдельный класс с рисованием линии например

       
        public void Clear()
        {
            // стирание точки, нарисовать точку цветом фона
            graph.FillEllipse(gameBoard.ClerBrush, x * diametr, y * diametr, diametr, diametr);
            gameBoard.PictureBox.Invalidate();           
        }

    }
}
