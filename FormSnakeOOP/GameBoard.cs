using System.Drawing;

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
        private System.Windows.Forms.PictureBox pictureBox;
        private int scale;
        /// <summary>
        /// кисть для очистки
        /// </summary>
        private SolidBrush clearBrush;
        /// <summary>
        /// кисть для рисования по умолчанию.
        /// </summary>
        private SolidBrush paintBrush; 

        public Graphics Graph { get { return graph; } }
        public System.Windows.Forms.PictureBox PictureBox { get{ return pictureBox; } }
        public SolidBrush ClerBrush { get {return clearBrush;}  }

        public GameBoard()
        {
            // пустой конструктор как заглушка
        }
        public GameBoard(System.Windows.Forms.PictureBox _pictureBox, int _scale, Color _backGroundColor)
        {

            scale = _scale;
            pictureBox = _pictureBox;
            
            paintBrush = new SolidBrush(Color.Black);
            clearBrush = new SolidBrush(Color.White);
            // graph построить относительно имеющиегося pictureBox
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            // Graphics созданный из Image на весь pictureBox, использует для рисования весь pictureBox
            graph = Graphics.FromImage(pictureBox.Image);
        }
    }
}
