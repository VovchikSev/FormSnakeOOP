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
        public Color Color { get => pointBrush.Color; set => pointBrush.Color = value; }
        public PointLocal(int _x, int _y, Color _color, GameBoard _gameBoard )        
        {
            x = _x;
            y = _y;            
            pointBrush = new System.Drawing.SolidBrush(_color);
            gameBoard = _gameBoard;
            diametr = gameBoard.Scale;
            graph = gameBoard.Graph;
        }

        public PointLocal(PointLocal p)
        {
            x = p.x;
            y = p.y;
            diametr = p.diametr;
            gameBoard = p.gameBoard;
            pointBrush = p.pointBrush;
            graph = p.graph;
        }

        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.RIGHT:
                    /*
                    if (direction != Direction.LEFT)
                        direction = Direction.RIGT; */

                    x = x + offset;
                    break;
                case Direction.LEFT:
                    /*
                    if (direction != Direction.RIGT)
                        direction = Direction.LEFT;
                        */
                    x = x - offset;
                    break;
                case Direction.UP:
                    /*
                    if (direction != Direction.Down)
                        direction = Direction.UP;*/

                    y = y - offset;
                    break;
                case Direction.Down:
                    /*
                    if (direction != Direction.UP)
                        direction = Direction.Down;*/
                    y = y + offset;
                    break;
                default: break;

            }
        }
        public override string ToString()
        {
            return x + ", " + y + diametr;
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
        public bool IsHit(PointLocal p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
