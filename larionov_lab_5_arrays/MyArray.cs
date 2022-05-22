namespace larionov_lab_5_arrays
{
    internal class MyArray
    {
        private const int MAX_COUNT = 10000, DEFAULT_VALUE = 10;
        private const int MIN_RANDOM = -100, MAX_RANDOM = 100;

        private bool isQwestionRandom()
        {
            Console.WriteLine("\nХотите сгенерировать данные случайным образом? [y/n]\0");
            return Console.ReadLine()?.ToLower() != "n";
        }

        public int[] createArray()
        {

            bool isRandom = isQwestionRandom();

            MyInput myInput = new MyInput();

            int countValues = myInput.inputCount($"\nСколько нужно чисел? (Для {DEFAULT_VALUE} нажмите ENTER): \0", MAX_COUNT, DEFAULT_VALUE);
            Console.WriteLine(" ");

            Random rnd = new Random();

            int[] array = new int[countValues];

            if (isRandom)
            {

                for (int i = 0; i < countValues; i++)
                    array[i] = rnd.Next(MIN_RANDOM, MAX_RANDOM);

            }
            else
            {
                for (int i = 0; i < countValues; i++)
                {
                    array[i] = myInput.inputData($"Введите число ({i + 1} из {countValues}):");
                    Console.WriteLine(" ");
                }
            }

            return array;
        }

        public int[,] createTwoDimensionalArray()
        {

            bool isRandom = isQwestionRandom();

            MyInput myInput = new MyInput();

            int m = myInput.inputCount($"\nСколько нужно строк? (Для {DEFAULT_VALUE} нажмите ENTER): \0", MAX_COUNT, DEFAULT_VALUE);
            Console.WriteLine(" ");

            int n = myInput.inputCount($"\nСколько нужно столбцов? (Для {DEFAULT_VALUE} нажмите ENTER): \0", MAX_COUNT, DEFAULT_VALUE);
            Console.WriteLine(" ");

            Random rnd = new Random();

            int[,] array = new int[m, n];

            if (isRandom)
            {

                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                        array[i, j] = rnd.Next(MIN_RANDOM, MAX_RANDOM);

            }
            else
            {
                int count = 1;

                for (int i = 0; i < m; ++i)
                    for (int j = 0; j < n; ++j)
                    {
                        array[i, j] = myInput.inputData($"Введите число № {count} (строка {i + 1} из {m}; столбец {j + 1} из {n}):");
                        Console.WriteLine(" ");
                        ++count;
                    }
            }

            return array;
        }

        private void printStringArray(int[,] array, int m)
        {

            string str = string.Format("[{0}]\t ", m);

            int countCol = array.GetLength(1);

            for (int j = 0; j < countCol; j++)
                str += string.Format("{0}\t", array[m, j]);


            Console.WriteLine(str);

        }
        public void printArray(int[,] array)
        {
            int countString = array.GetLength(0);
            int countRow = array.GetLength(1);

            Console.WriteLine($"Строк:    {countString}");
            Console.WriteLine($"Столбцов: {countRow}\n");

            string header = " \t";


            for (int i = 0; i < countRow; i++)
                header += $"[{i}]\t";

            Console.WriteLine(header);

            for (int i = 0; i < countString; i++)
                printStringArray(array, i);
        }
    }
}
