namespace Labb_2
{
    abstract class LevelElement
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool isSeen = false;
        protected char Icon { get; set; }
        protected ConsoleColor FColor { get; set; }
        public LevelElement(int x, int y, char icon, ConsoleColor fColor)
        {
            X = x;
            Y = y;
            Icon = icon;
            FColor = fColor;

        }
        public bool Collision(int x, int y, List<LevelElement> _elements)
        {
            foreach (var element in _elements)
            {
                if (element.X == x && element.Y == y && element is Wall)
                {
                    return true;
                }
                if (element.X == x && element.Y == y && element is Rat)
                {
                    return true;
                }
                if (element.X == x && element.Y == y && element is Snake)
                {
                    return true;
                }

            }
            return false;
        }
        public void Draw(LevelElement p)
        {
/*            var range = Math.Sqrt(((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y)));
            if(range <= 5 || isSeen == true)
            {
                if(this.GetType() == typeof(Wall))
                {
                    this.isSeen = true;
                }

            }*/

            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = FColor;
            Console.WriteLine(Icon);
            Console.ResetColor();
        }

        public virtual void Update(List<LevelElement> leveldata)
        {

        }
        public void runGame()
        {

        }

        public virtual void Move(int moveX, int moveY)
        {
            X += moveX;
            Y += moveY;
        }

    }
}


