using System.Drawing;
using System.Windows.Forms;

namespace FormSnakeOOP
{
    /* Класс игрового поля.
     * Служит для отображения на нем объектов
     * Как это буде реализовано:
     * получаем относительную координату (максимальное значение / на масштаб)
     * Исходя из этого получить абсолютную координату. 
     * 
     */
    class GameBoard
    {
        private Graphics graph;
        private PictureBox pictureBox;
        private int scale;
        /// <summary>
        /// кисть для очистки
        /// </summary>
        private SolidBrush clearBrush;
        
        /// <summary>
        /// Получить масштаб поля, величина относительно которой пересчитываются относительные координаты в абсолютные.
        /// </summary>
        public int Scale { get { return scale; } }

        public int RelativeX { get { return pictureBox.Width / scale; } }
        public int RelativeY { get { return pictureBox.Height / scale; } }
        public Graphics Graph { get { return graph; } }
        public PictureBox PictureBox { get{ return pictureBox; } }
        public SolidBrush ClearBrush { get {return clearBrush;}  }

        public GameBoard()
        {
            // пустой конструктор как заглушка
           
        }
        public GameBoard(PictureBox pictureBox, int scale, Color backGroundColor)
        {

            this.scale = ((scale > 0) ? scale : 1);
            this.pictureBox = pictureBox;

           
            clearBrush = new SolidBrush(backGroundColor);
            // graph построить относительно имеющиегося pictureBox
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            // Graphics созданный из Image на весь pictureBox, использует для рисования весь pictureBox
            graph = Graphics.FromImage(pictureBox.Image);
            // при создании залить весь graph белой кистью.
            graph.FillRectangle(ClearBrush, 0, 0, pictureBox.Width, pictureBox.Height);
            ShowGrid();

            pictureBox.Invalidate();

        }

        public void DrawPoint(PointLocal point)
        {
            // нарисовать точку цветом из точки 
            /* вычислить координаты начала квадрата для тчки
             * Перевести относительны координаты в абсолютные
             * 
             * Попробовать FillEllipse сделать через прямоугольник 
             */
            
            graph.FillEllipse(point.PointBrush, 
                              RelativeToAbsolute( point.X, point.Diametr) , 
                              RelativeToAbsolute(point.Y, point.Diametr), 
                              point.Diametr, point.Diametr);
            PictureBox.Invalidate();
        }
        public void ClearPoint(PointLocal point)
        {
            // накрисовать точку цветом clearBrush
            graph.FillEllipse(this.clearBrush,
                              RelativeToAbsolute(point.X, point.Diametr),
                              RelativeToAbsolute(point.Y, point.Diametr),
                              point.Diametr, point.Diametr);
            pictureBox.Invalidate();
        }

        #region private methods
        /// <summary>
        /// Возвращает абсолютную координату для прямоугольника точки.
        /// вычисленную из относительной координаты с учетом размера.
        /// </summary>
        /// <param name="relativeValue">Относительное значение</param>
        /// <param name="size">размер.</param>
        /// <returns></returns>
        private int RelativeToAbsolute(int relativeValue, int size )
        {
            return relativeValue * scale + (this.scale - size);
        }

        private void ShowGrid()
        {
            // нарисовать серую сетку с шагом в Scale
            // предварительно создав перо
            Pen pen = new Pen(Color.LightGray, 1);
            //graph.DrawLine(pen, 255, 255)
                // из точки с координатами х1 у1 в точку с координатами х2 у2
            
            for (int xMin = 0; xMin < pictureBox.Width; xMin += scale )
            {
                graph.DrawLine(pen, xMin, 0, xMin, pictureBox.Height);
            }
            
            for (int yMin = 0; yMin < pictureBox.Height; yMin += scale)
            {
                graph.DrawLine(pen, 0, yMin, pictureBox.Width, yMin);
            }
            
            //graph.DrawLine
        }
        #endregion
    }
}
