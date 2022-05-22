namespace larionov_lab_5_arrays
{
    internal class Task2
    {
        private int getCountNegativeElements(int[] array)
        {
            int count = 0;
            int size = array.Length;

            for (int i = 0; i < size; ++i)
                if (array[i] < 0)
                    ++count;

            return count;
        }

        private int getIndexMinAbs(int[] array)
        {
            int size = array.Length;
            int min = Math.Abs(array[0]);
            int index = 0;

            for (int i = 1; i < size; i++)
                if (Math.Abs(array[i]) < min)
                {
                    min = Math.Abs(array[i]);
                    index = i;
                }

            return index;
        }

        private int getSumAbsAfterIndex(int[] array, int index)
        {
            if (index < 0)
                return 0;

            int size = array.Length;
            int sum = 0;

            for (int i = index + 1; i < size; i++)
                sum += Math.Abs(array[i]);

            return sum;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_16_2);

            MyArray myArray = new MyArray();
            int[] array = myArray.createArray();

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(false);

            Console.WriteLine("\nИсходный массив чисел:\n");

            int indexMinModule = getIndexMinAbs(array);

            int size = array.Length;

            string sign = "";

            for (int i = 0; i < size; ++i)
            {

                if (array[i] < 0)
                    sign = "отрицательное число";
                else
                    sign = "";

                if (i == indexMinModule)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[{0, 1}] {1, 3} " + sign + " - минимальный по модулю элемент массива", i, array[i]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                    Console.WriteLine("[{0, 1}] {1, 3} " + sign, i, array[i]);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nКоличество отрицательных элементов массива: {getCountNegativeElements(array)}\n");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Сумма модулей элементов массива, расположенных после минимального по модулю элемента: {getSumAbsAfterIndex(array, indexMinModule)}\n");

            Console.ResetColor();

            for (int i = 0; i < size; ++i)
                if (array[i] < 0)
                    array[i] = (int)Math.Pow(array[i], 2);

            mySort.sort(array, modeSort, true, true);
            Console.ResetColor();
        }
    }
}
