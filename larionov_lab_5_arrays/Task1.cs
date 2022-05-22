namespace larionov_lab_5_arrays
{
    internal class Task1
    {

        private struct Val
        {
            public int index;
            public int value;
        };

        private Val getMin(int[] array)
        {

            int size = array.Length;
            Val min = new Val();

            min.index = 0;
            min.value = array[0];

            for (int i = 1; i < size; i++)
                if (array[i] < min.value)
                {
                    min.value = array[i];
                    min.index = i;
                }

            return min;
        }

        private int getFirstPozitivElemIndex(int[] array)
        {
            int index = -1;
            int size = array.Length;

            for (int i = 0; i < size; ++i)
                if (array[i] > 0)
                    return i;

            return index;
        }

        private int getEndPozitivElemIndex(int[] array)
        {
            int index = -1;
            int size = array.Length;

            for (int i = size - 1; i > 0; --i)
                if (array[i] > 0)
                    return i;

            return index;
        }

        private bool isExistZero(int[] array)
        {
            int size = array.Length;

            for (int i = 0; i < size; ++i)
                if (array[i] == 0)
                    return true;

            return false;
        }

        private int[] sortFirstZero(int[] array)
        {
            Array.Sort(array, (a, b) =>
            {
                if (a == 0 && b != 0) return -1;
                else if (a != 0 && b == 0) return 1;
                return 0;
            });

            return array;
        }


        public void init()
        {

            Console.WriteLine(TasksInfo.TASK_6_1);

            MyArray myArray = new MyArray();
            int[] array = myArray.createArray();

            Console.ForegroundColor = ConsoleColor.Yellow;

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(false);

            Console.WriteLine("\nИсходный массив чисел:\n");

            Val min = getMin(array);
            int indexMin = min.index;

            int startPozitivElemIndex = getFirstPozitivElemIndex(array);
            int endPozitivElemIndex = getEndPozitivElemIndex(array);

            bool isExistPozitivElements = startPozitivElemIndex != -1 && endPozitivElemIndex != -1;

            string stringSum = "";
            int sum = 0;

            int itemQual = array[0];
            bool isAllElemQual = true;

            int countValues = array.Length;

            for (int i = 0; i < countValues; i++)
            {

                if (isAllElemQual && array[i] != itemQual)
                    isAllElemQual = false;

                if (isExistPozitivElements && startPozitivElemIndex < i && i < endPozitivElemIndex)
                {
                    sum += array[i];
                    stringSum = "*";
                }
                else
                    stringSum = "";


                if (!isAllElemQual && i == indexMin)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[{0, 1}] {1, 3} " + stringSum + " - первый минимальный элемент массива", i, array[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    Console.WriteLine("[{0, 1}] {1, 3} " + stringSum, i, array[i]);
            }

            if (isAllElemQual)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nВсе элементы массива равны");
                Console.ResetColor();
            }


            if (isExistPozitivElements)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nПервый минимальный элемент массива: {min.value} (под индексом {indexMin})\n");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Первый положительный элемент массива: {array[startPozitivElemIndex]} (под индексом {startPozitivElemIndex})");
                Console.WriteLine($"Последний положительный элемент массива: {array[endPozitivElemIndex]} (под индексом {endPozitivElemIndex})\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Сумма чисел между первым и последним положительным элементом массива: {sum}\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ массиве нет положительных элементов!\n");
            }

            if (isExistZero(array))
            {
                Console.WriteLine("\nВ массив в котором сначала располагаются нули, а затем все остальные элементы:\n");

                int[] arraySort = sortFirstZero(array);

                for (int i = 0; i < countValues; i++)
                    Console.WriteLine("[{0, 1}] {1, 3}", i, arraySort[i]);

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ массиве нет нулей!\n");
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nОтсортированный массив:");

            mySort.sort(array, modeSort, true, true);
            Console.ResetColor();

        }

    }
}
