namespace larionov_lab_5_arrays
{
    internal class Task3
    {
        private void printSumInString(int[,] array, int m)
        {
            int sum = 0;
            bool isExistNegative = false;

            string str = string.Format("[{0}]\t ", m);

            int countCol = array.GetLength(1);

            for (int j = 0; j < countCol; j++)
            {

                sum += array[m, j];
                str += string.Format("{0}\t", array[m, j]);

                if (array[m, j] < 0)
                    isExistNegative = true;

            }

            if (isExistNegative)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                str += " - Сумма чисел в строке:" + string.Format("{0,5} ", sum);
            }
            else
                Console.ResetColor();

            Console.WriteLine(str);
        }

        private bool isMaxInCol(int[,] array, int i, int j)
        {
            int size = array.GetLength(0);

            for (int n = 0; n < size; ++n)
                if (array[n, j] > array[i, j])
                    return false;

            return true;
        }

        private bool isMinInRow(int[,] array, int i, int j)
        {
            int size = array.GetLength(1);

            for (int n = 0; n < size; ++n)
                if (array[i, n] < array[i, j])
                    return false;

            return true;
        }

        private void printSledPoints(int[,] array)
        {
            int countString = array.GetLength(0);
            int countCol = array.GetLength(1);

            bool isExist = false;

            for (int i = 0; i < countString; i++)
                for (int j = 0; j < countCol; j++)
                    if (isMinInRow(array, i, j) && isMaxInCol(array, i, j))
                    {

                        Console.WriteLine("Элемент [{0}][{1}] {2} - следовый (строка: {3} столбец: {4})", i, j, array[i, j], i + 1, j + 1);
                        isExist = true;
                    }

            if (!isExist)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nСледовых элементов не обнаружено!");
                Console.ResetColor();
            }

        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_6_3);

            MyArray myArray = new MyArray();
            int[,] array = myArray.createTwoDimensionalArray();

            /*
              int[,] array = {
                  {0, 2, 3, 4, 5},
                  {1, 1, 1, 1, 1},
                  {1, 1, 1, 1, 5},
                  {1, 1, 1, 4, 5},
                  {1, 1, 3, 4, 5},
                  {1, 2, 3, 4, 5},
              };
            */

            /*
              int[,] array = {
                {-1, 0, 2, 1, 4, 3, 6, 5, 7},
                {0, 0, 0, 3, 2, 1, 7, 6, 5},
                {4, 4, 3, 3, 3, 5, 5, 5, 5},
                {6, 6, 0, 6, 6, 6, 6, 6, 6},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {9, 8, 7, 9, 9, 7, 7, 9, 9}
            };
            */

            MySort mySort = new MySort();
            MySort.ModeSort modeSort = mySort.qwestionsSort(true);

            Console.WriteLine("\nИсходный массив чисел:\n");

            int countString = array.GetLength(0);
            int countRow = array.GetLength(1);


            Console.WriteLine($"Строк:    {countString}");
            Console.WriteLine($"Столбцов: {countRow}\n");

            string header = " \t";


            for (int i = 0; i < countRow; i++)
                header += $"[{i}]\t";

            Console.WriteLine(header);

            for (int i = 0; i < countString; i++)
                printSumInString(array, i);


            Console.WriteLine("");
            printSledPoints(array);

            Console.ResetColor();
            mySort.sort(array, modeSort, true, true);
            Console.ResetColor();
        }
    }

}
