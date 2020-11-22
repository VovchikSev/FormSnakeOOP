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
        SolidBrush pointBrush;
        /// <summary>
        /// Объект Graphics на котором будет отображаться точка.
        /// </summary>
        
        GameBoard gameBoard;
        // скрыть излишне открытые члены
        // инициализацию сделать в конструкторе
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Color Color { get => pointBrush.Color; set => pointBrush.Color = value; }

        public SolidBrush PointBrush { get => pointBrush; }

        public int Diametr { get => diametr; }
        /// <summary>
        /// Конструктор точки
        /// </summary>
        /// <param name="x">относительная координата по X</param>
        /// <param name="y">относительная координата по Y</param>
        /// <param name="_color">Цвет точки</param>
        /// <param name="_gameBoard">Игровое пле, на котором будет отображена точка</param>
        /// <param name="diametr">диаметр точки, абсолютный размер, если не задан или = 0 то за диаметр будет принят масштаб игрового поля</param>
        public PointLocal(int x, int y, Color _color, GameBoard _gameBoard, int diametr = 0 )        
        {
            this.x = x;
            this.y = y;            
            pointBrush = new SolidBrush(_color);
            gameBoard = _gameBoard;
            this.diametr = (diametr == 0) ? gameBoard.Scale : diametr;
        }

        public PointLocal(PointLocal p)
        {
            x = p.x;
            y = p.y;
            diametr = p.diametr;
            gameBoard = p.gameBoard;
            pointBrush = p.pointBrush;
            //graph = p.graph;
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
            // перенести в GameBoard. Тогда точке не 
            //graph.FillEllipse(pointBrush, x * diametr, y * diametr, diametr, diametr);
            // перенести в обработчик таймера и там перерисовывать. 
            gameBoard.DrawPoint(this);

            //gameBoard.PictureBox.Invalidate();
        }
        // сделать другой Draw, где не будет смещения по диаметру.
        // нужно понимание роцесса рисования. 
        // наверное нужно сделать отдельный класс с рисованием линии например

       
        public void Clear()
        {
            gameBoard.ClearPoint(this);
        }
        public bool IsHit(PointLocal p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
