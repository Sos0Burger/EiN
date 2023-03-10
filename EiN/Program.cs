internal class Program
{
    private static void Main(string[] args)
    {
        bool exit = true;
        while (exit)
        {
            Console.WriteLine("1 - изменить файл\n2 - сравнить с файлом\n3 - выход");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("1 - ввести ручками\n2 - ввести размер");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            Console.WriteLine("Введите массив через пробел");
                            string[] stringMas = Console.ReadLine().Split();
                            Che[] cheMas = new Che[stringMas.Length];

                            for (int i = 0; i < stringMas.Length; i++)
                            {
                                cheMas[i] = new Che(Convert.ToInt32(stringMas[i]));
                            }
                            bool[] boolMas = new bool[cheMas.Length];
                            writeToFile(boolMas);
                            break;
                        case 2:
                            Console.Write("Введите размеры массива через запятую: ");
                            string input = Console.ReadLine();
                            string[] sizes = input.Split(',');
                            int dimensions = sizes.Length;

                            int totalSize = 1;
                            int[] dimensionsSizes = new int[dimensions];

                            for (int i = 0; i < dimensions; i++)
                            {
                                dimensionsSizes[i] = int.Parse(sizes[i]);
                                totalSize *= dimensionsSizes[i];
                            }

                            Console.WriteLine($"Количество элементов в массиве: {totalSize}");

                            Che[] indices = new Che[totalSize];
                            for (int i = 0; i < indices.Length; i++)
                            {
                                indices[i] = new Che(0);
                            }
                            bool[] bools1 = new bool[indices.Length];
                            for (int i = 0; i < indices.Length; i++)
                            {
                                bools1[i] = indices[i].getBool();
                            }
                            writeToFile(bools1);
                            break;
                        default: Console.WriteLine("Нет такой цифры"); break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите массив через пробел");
                    string[] strings = Console.ReadLine().Split();
                    Che[] ches = new Che[strings.Length];

                    for (int i = 0; i < strings.Length; i++)
                    {
                        ches[i] = new Che(Convert.ToInt32(strings[i]));
                    }
                    bool[] bools = new bool[ches.Length];
                    for (int i = 0; i < ches.Length; i++)
                    {
                        bools[i] = ches[i].getBool();
                    }
                    isFileEquals(bools);
                    break;
                case 3:
                    exit = false;
                    break;
                default: Console.WriteLine("Неверная цифра"); break;
            }
        }
    }
    static void result(bool[] result)
    {
        foreach (bool i in result)
        {
            if (i)
            {
                Console.WriteLine(true);
                return;
            }
        }
        Console.WriteLine(false);
    }
    static void isFileEquals(bool[] bools)
    {
        bool[] oldmass;
        string[] mass;
        string str = "";
        StreamReader sr = new StreamReader("mass.txt");
        try
        {
            str = sr.ReadLine();
            sr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        mass = str.Split(" ");
        oldmass = new bool[mass.Length];
        for (int i = 0; i < mass.Length; i++)
        {
            oldmass[i] = Convert.ToBoolean(Convert.ToInt32(mass[i]));
        }

        if (oldmass.SequenceEqual(bools))
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
    static void writeToFile(bool[] bools)
    {
        StreamWriter sw = new StreamWriter("mass.txt");
        try
        {
            sw.Flush();
            for (int i = 0; i < bools.Length; i++)
            {
                sw.Write(Convert.ToInt32(bools[i]));
                if (i < bools.Length - 1)
                {
                    sw.Write(" ");
                }
            }
            sw.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
class Che
{
    int statement;

    public Che(int statement)
    {
        this.statement = statement;
    }

    public bool getBool()
    {
        if (statement == 1)
        {
            return true;
        }
        else { return false; };
    }
}