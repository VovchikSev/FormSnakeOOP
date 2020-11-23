using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace FormSnakeOOP
{
    class Snake:Figure
    {
        Direction direction;
        public Snake(PointLocal tail, int lenghth,Direction direction)
        {
            this.direction = direction;
            pList = new List<PointLocal>();
            for (int i = 0; i < lenghth; i++)
            {                
                PointLocal p = new PointLocal(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            // змея представляетя собой перевернутый список. первый элемент, это хвост, последний голова.
            // при движении стирается точка хвоста,
            
            PointLocal tail = pList.First();
            pList.Remove(tail);
            PointLocal head = GetNextPoint();
            // а к движенее создается тем, что добавляется точка головы, в направлении движения GetNextPoint();
            // так меняя только две точки, создается иллюзия движения.
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }

        private PointLocal GetNextPoint()
        {
            PointLocal head = pList.Last();
            PointLocal nextPoint = new PointLocal(head);
            nextPoint.Move(1, direction);
            return nextPoint;
            
        }
        public void HandleKey(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (direction != Direction.Down)
                        direction = Direction.UP;
                    break;
                case Keys.Down:
                    if (direction != Direction.UP)
                        direction = Direction.Down;
                    break;
                case Keys.Left:
                    if (direction != Direction.RIGHT)
                        direction = Direction.LEFT;
                    break;
                case Keys.Right:
                    if (direction != Direction.LEFT)
                        direction = Direction.RIGHT;
                    break;
                default:
                    break;
            }
        }
        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count-2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }
        internal bool Eat(PointLocal food)
        {
            PointLocal head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Color = pList.First().Color;
                food.Draw();
                pList.Add(food);
                return true;
            }
            else
                return false;

        }
    }
}
