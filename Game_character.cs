namespace gamecharacter
{
    class game_character
    {
        private string name;
        private int x;
        private int y;
        private bool camp;
        private int life_amount;
        private int total_life;
        public void info(string name, int x, int y, bool camp, int life_amount)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.camp = camp;
            this.life_amount = life_amount;
            maxhp();
        }
        public (int x, int y) coord()
        {
            return (x, y);
        }
        public bool camp_belong()
        {
            return camp;
        }
        public string GetName()
        {
            return name;
        }
        private void maxhp()
        { total_life = life_amount; }
        public void print()
        {
            Console.WriteLine($"Имя: {name}");
            Console.Write($"Координаты: {x} ");
            Console.WriteLine($"{y}");
            Console.WriteLine($"Лагерь {camp}");
            Console.WriteLine($"Количество очков здоровья:{life_amount} из {total_life}");
        }
        public void movex(int dx)
        {
            if (x + dx > 11 || x + dx < 0)
            {
                Console.WriteLine("Вы не можете выйти за поле");
            }
            else x += dx;
        }
        public void movey(int dy)
        {
            if (y + dy > 11 || y + dy < 0)
            {
                Console.WriteLine("Вы не можете выйти за поле");
            }
            else y += dy; ;
        }
        public void delete()
        {
            name = null;
            x = -1;
            y = -1;
            life_amount = 0;
        }
        public void damage(int dc)
        {
            if (dc > life_amount)
            {
                delete();
            }
            else life_amount -= dc;

        }
        public void heal(int lr)
        {
            if (lr + life_amount > total_life)
            {
                Console.WriteLine("Вы не можете восполнить столько очков здоровья");
            }
            else
            {
                life_amount += total_life;
            }
        }
        public void recovery()
        {
            life_amount = total_life;
        }
        public void camp_change(bool c)
        {
            this.camp = c;
        }
    }
}