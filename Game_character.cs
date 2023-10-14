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
        private int attack;
        public void info(string name, int x, int y, bool camp, int life_amount, int attack)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.camp = camp;
            this.life_amount = life_amount;
            this.attack = attack;
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
        public int GetAttack()
        {
            return attack;
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
            Console.WriteLine($"Возможная атака: {attack}");
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
            Console.WriteLine($"Персонаж {name} умер");
            name = null;
            x = -1;
            y = -1;
            life_amount = -1;
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