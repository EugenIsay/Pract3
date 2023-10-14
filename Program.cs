using gamecharacter;
class program
{
    static void Main()
    {
        string read;
        int c;
        int temp;
        int enemy_c = 0;
        int countenemy;
        int countally;
        ConsoleKeyInfo key;
        Console.WriteLine("Введите сколько персонажей есть");
        game_character[] characters = new game_character[Convert.ToInt32(Console.ReadLine())];
        string[] char_name = new string[characters.Length];
        Random random = new Random();
        for (int i = 0; i < characters.Length; i++)
        {
            characters[i] = new game_character();
            characters[i].info($"Isay{i + 1}", random.Next(0, 11), random.Next(0, 11), Convert.ToBoolean(random.Next(0, 2)) , random.Next(20, 51) , random.Next(4, 20));
            char_name[i] = $"Isay{i + 1}";
        }
        start:
        Console.WriteLine("Введите имя персонажа");
        read = Console.ReadLine();
        c = Array.IndexOf(char_name, read);
        while (true)
        {
            temp = 0;
            countenemy = 0;
            countally = 0;
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[c].coord() == characters[i].coord() && c != i)
                {
                    if(characters[c].camp_belong() != characters[i].camp_belong())
                        countenemy++;
                    else countally++;
                }
            }
            Console.WriteLine($"На вашем поле {countenemy} врагов и {countally} союзников");
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("S - Показать информацию, M - передвинутся, R - востановится, ");
            Console.WriteLine("H - восстановить какое-то количество здоровья, A - атаковать, ");
            Console.WriteLine("D - удалить персонажа, C - поменять лагерь, Q - сменить персонажа");
            Console.WriteLine(" ");
            key = Console.ReadKey(true);
            switch (key.Key.ToString())
            {
                case "S":
                    characters[c].print();
                    if (countally > 0)
                    {
                        Console.WriteLine("Ваши союзники на данный момент:");
                        for (int i = 0; i < characters.Length; i++)
                        {
                            if (characters[c].coord() == characters[i].coord() && c != i)
                            {
                                if (characters[c].camp_belong() == characters[i].camp_belong())
                                {
                                    Console.WriteLine(characters[i].GetName());
                                }
                            }
                        }

                    }
                    break;
                case "M":
                    Console.WriteLine("На WASD выберите в какую сторону хотите передвинутся");
                    key = Console.ReadKey(true);
                    Console.WriteLine("Насколько вы хотите передвинутся");
                    temp = Convert.ToInt32(Console.ReadLine());
                    switch (key.Key.ToString())
                    {
                        case "W":
                            characters[c].movey(temp);
                            break;
                        case "S":
                            characters[c].movey(-temp);
                            break;
                        case "A":
                            characters[c].movex(-temp);
                            break;
                        case "D":
                            characters[c].movex(temp);
                            break;
                    }
                    break;
                case "R":
                    characters[c].recovery();
                    break;
                case "H":
                    Console.WriteLine("Сколько очков здоровья хотите восстановить");
                    temp = Convert.ToInt32(Console.ReadLine());
                    characters[c].heal(temp);
                    break;
                case "A":
                    if (countenemy > 0)
                    {
                        Console.WriteLine("Доступные враги");
                        for (int i = 0; i < characters.Length; i++)
                        {
                            if (characters[c].coord() == characters[i].coord() && c != i)
                            {
                                if (characters[c].camp_belong() != characters[i].camp_belong())
                                {
                                    Console.WriteLine(characters[i].GetName());
                                    read = characters[i].GetName();
                                    enemy_c = Array.IndexOf(char_name, read);
                                }
                            }  
                        }
                        if (countenemy > 1)
                        {
                            Console.WriteLine("Кому вы хотите нанести урон?");
                            read = Console.ReadLine();
                            enemy_c = Array.IndexOf(char_name, read);
                        }
                        Console.WriteLine("Сколько очков урона хотите нанести");
                        temp = Convert.ToInt32(Console.ReadLine());
                        if (characters[c].GetAttack() < temp)
                        {
                            Console.WriteLine("Вы не можете нанести столько урона");
                        }
                        else
                        {
                            characters[enemy_c].damage(temp);
                        }
                        temp = 0;
                        for (int i = 0; i < characters.Length; i++)
                        {
                            if (characters[c].coord() == characters[i].coord() && c != i)
                            {
                                if (characters[c].camp_belong() == characters[i].camp_belong())
                                {
                                    temp += characters[i].GetAttack();
                                }
                            }
                        }
                        for (int i = 0; i < characters.Length; i++)
                        {
                            if (characters[c].coord() == characters[i].coord())
                            {
                                if (characters[c].camp_belong() != characters[i].camp_belong())
                                {
                                    characters[i].damage(temp / countenemy);
                                }
                            }
                        }
                    }
                    else Console.WriteLine("Нет доступных врагов");
                    break;
                case "D":
                    characters[c].delete();
                    break;
                case "C":
                    if (characters[c].camp_belong() == true)
                    characters[c].camp_change(false);
                    else characters[c].camp_change(true);
                    break;
                case "Q":
                    goto start;
            }
            Console.WriteLine(" ");
            if (key.Key.ToString() != "S")
            {
                temp = 0;
                countally += 1;
                if (countenemy != 0)
                {
                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (characters[c].coord() == characters[i].coord() && c != i)
                        {
                            if (characters[c].camp_belong() != characters[i].camp_belong())
                            {
                                temp += characters[i].GetAttack();
                            }
                        }
                    }
                    for (int i = 0; i < characters.Length; i++)
                    {
                        if (characters[c].coord() == characters[i].coord())
                        {
                            if (characters[c].camp_belong() == characters[i].camp_belong())
                            {
                                characters[i].damage(temp / countally);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < characters.Length; i++)
            {
                if (characters[i].GetName() == null)
                {
                    char_name[i] = null;
                }
            }
            if (characters[c].GetName() == null)
            {
                goto start;
            }
        }
    }
}