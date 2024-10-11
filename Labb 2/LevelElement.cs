namespace Labb_2
{
    abstract class LevelElement
    {
        //These are coordinates
        public int X { get; set; }
        public int Y { get; set; }
        public Dice AttackDice { get; set; }
        public Dice DefendDice { get; set; }

        public int Health { get; set; }

        public bool isSeen = false;
        protected char Icon { get; set; }
        protected ConsoleColor FColor { get; set; }

        private List<string> messages = new();
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
            var range = Math.Sqrt(((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y)));
            if (range <= 5 || isSeen == true)
            {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = FColor;
            Console.WriteLine(Icon);
            Console.ResetColor();
                if (this.GetType() == typeof(Wall))
                {
                    this.isSeen = true;
                }
            }

        }
        public List<string> GetMessages()
        {
            return messages;
        }

        public void ResetMessages()
        {
            messages.Clear();
        }
        public virtual void Update(List<LevelElement> leveldata)
        {

        }
        public virtual void Move(int moveX, int moveY, List<LevelElement> levelelements)
        {
            if (!Collision(this.X + moveX, this.Y + moveY, levelelements))
            {
                X += moveX;
                Y += moveY;
            }
            else
            {
                var xEnemy = levelelements.Where(e => e.X == this.X + moveX).ToList();
                var yEnemy = xEnemy.Where(e => e.Y == this.Y + moveY).FirstOrDefault();
                if (this.GetType() == typeof(Player))
                {
                    if(yEnemy.GetType() == typeof(Wall))
                    {
                        return;
                    }
                    int myAttack = Math.Clamp(this.AttackDice.ThrowDice() - yEnemy.DefendDice.ThrowDice(),0,1000);
                    int enemyAttack = Math.Clamp(yEnemy.AttackDice.ThrowDice() - this.DefendDice.ThrowDice(),0,1000);

                    yEnemy.Health = yEnemy.Health - myAttack;
                    this.Health =this.Health - enemyAttack;
                    
                    messages.Add($"You Attack {yEnemy.GetType().Name} for {myAttack} damage");
                    messages.Add($"{yEnemy.GetType().Name} attacks you for {enemyAttack} damage");
                    if (yEnemy.Health <= 0)
                    {
                        levelelements.Remove(yEnemy);
                        
                        messages.Add($"The {yEnemy.GetType().Name} dies");
                    }
                }
            }
        }
    }
}


