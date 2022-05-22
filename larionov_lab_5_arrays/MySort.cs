using System.Diagnostics;

namespace larionov_lab_5_arrays
{
    internal class MySort
    {
        public const bool INCRASE = true;
        public const bool DESCENDING = false;

        public const string ALGORITM_SELECT = "S";
        public const string ALGORITM_INSERT = "I";
        const string ALGORITM_DEFAULT = ALGORITM_SELECT;

        public const string ORIENATION_STRING = "S";
        public const string ORIENTATION_COL = "C";
        const string ORIENTATION_DEFAULT = ORIENATION_STRING;

        public const string DIRECTION_UP = "U";
        public const string DIRECTION_DOWN = "D";
        const string DIRECTION_DEFAULT = DIRECTION_UP;

        private static void swap(int[] array, int i, int j)
        {
            if (i != j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        private string inputData(string text, string case1, string case2, string defaultCase = "")
        {

            string xStr = "";

            while (true)
            {
                Console.ResetColor();
                Console.WriteLine(text);

                xStr = Console.ReadLine().ToLower();

                if (xStr == "")
                    xStr = defaultCase.ToLower();

                if (xStr != case1.ToLower() && xStr != case2.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Некорректный ввод!");
                }
                else
                    break;
            }

            return xStr;
        }

        public struct ModeSort
        {
            public string algoritm;
            public bool direction;
            public string orientation;
        };

        public struct ArrayTime
        {
            public int[] array;
            public long time;
        }

        public ModeSort qwestionsSort(bool isTwoDimension)
        {
            MySort mySort = new MySort();
            ModeSort modeSort = new ModeSort();

            modeSort.algoritm = mySort.inputData(
                $"Какой алгоритм сортировки использовать? (Enter для [{ALGORITM_DEFAULT}])\n" +
                $"[{ALGORITM_SELECT}] - выбором" +
                $"\n[{ALGORITM_INSERT}] - вставкой\0", ALGORITM_SELECT, ALGORITM_INSERT, ALGORITM_DEFAULT);

            Console.WriteLine("");

            modeSort.direction = mySort.inputData(
                $"Отсортировать (Enter для [{DIRECTION_DEFAULT}]):\n" +
                $"[{DIRECTION_UP}] по возрастанию\n" +
                $"[{DIRECTION_DOWN}] по убыванию\0", DIRECTION_UP, DIRECTION_DOWN, DIRECTION_DEFAULT) == DIRECTION_UP.ToLower();

            Console.WriteLine("");

            if (isTwoDimension)
            {
                modeSort.orientation = mySort.inputData(
                   $"Выполнить сортировку (Enter для [{ORIENTATION_DEFAULT}])\n" +
                   $"[{ORIENATION_STRING}] по строкам\n" +
                   $"[{ORIENTATION_COL}] по столбцам\0", ORIENATION_STRING, ORIENTATION_COL, ORIENTATION_DEFAULT);

                Console.WriteLine("");
            }


            return modeSort;
        }
        public ArrayTime selectSort(int[] array, bool direction)
        {

            var startTime = Stopwatch.StartNew();
            //=================

            int size = array.Length;
            int tmp;

            for (int i = 0; i < size - 1; i++)
            {
                //поиск минимального числа или максимального
                int var = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (direction == DESCENDING && array[j] > array[var])
                        var = j;
                    else if (direction == INCRASE && array[j] < array[var])
                        var = j;
                }


                swap(array, var, i);
            }

            //
            startTime.Stop();

            ArrayTime result = new ArrayTime();
            result.array = array;


            result.time = startTime.ElapsedMilliseconds;
            return result;
        }

        public ArrayTime insertSort(int[] array, bool direction)
        {
            var startTime = Stopwatch.StartNew();
            //=================

            int x, j;
            int size = array.Length;

            for (int i = 1; i < size; i++)
            {

                x = array[i];
                j = i;

                if (direction)
                { //по возрастанию
                    while (j > 0 && array[j - 1] > x)
                    {
                        swap(array, j, j - 1);
                        --j;
                    }
                }
                else
                {
                    while (j > 0 && array[j - 1] < x)
                    {
                        swap(array, j, j - 1);
                        --j;
                    }
                }

                array[j] = x;
            }

            startTime.Stop();

            ArrayTime result = new ArrayTime();
            result.array = array;


            result.time = startTime.ElapsedMilliseconds;
            return result;
        }

        public int[] sort(int[] array, ModeSort modeSort, bool isCheckTime, bool isPrint)
        {

            bool direction = modeSort.direction;
            string algoritm = modeSort.algoritm.ToUpper();

            ArrayTime result;
            string strDirection = "по возрастанию";
            string strAlgoritm = "выбором";

            if (!direction)
                strDirection = "по убыванию";

            if (algoritm == ALGORITM_SELECT)
                result = selectSort(array, direction);
            else
            {
                result = insertSort(array, direction);
                strAlgoritm = "Вставкой";
            }

            int size = result.array.Length;

            if (isPrint)
            {
                for (int i = 0; i < size; i++)
                    Console.WriteLine("[{0, 1}] {1, 3}", i, result.array[i]);
            }

            if (isCheckTime)
            {
                Console.WriteLine($"\nСортировка {strAlgoritm} {strDirection} в массиве с {size} элементов");
                Console.WriteLine($"Выполнена за {result.time} мс.");
            }

            return result.array;
        }


        public int[,] sort(int[,] array, ModeSort modeSort, bool isCheckTime, bool isPrint)
        {
            ArrayTime result;

            string strDirection = "по возрастанию";
            string strOrientation = "от первой строки <- ->";
            string strAlgoritm = "выбором";

            bool direction = modeSort.direction;
            string algoritm = modeSort.algoritm.ToUpper();
            string orientation = modeSort.orientation.ToUpper();

            if (!direction)
                strDirection = "по убыванию";

            if (algoritm == ALGORITM_INSERT)
                strAlgoritm = "вставкой";

            int countString = array.GetLength(0);
            int countCol = array.GetLength(1);

            if (orientation == ORIENTATION_COL)
                strOrientation = "от первого столбца  /\\ \\/";

            long sumTime = 0;
            ArrayTime arrayTime;

            if (orientation == ORIENATION_STRING)
            {
                int[] tmpArray = new int[countCol];

                for (int i = 0; i < countString; i++)
                {
                    for (int j = 0; j < countCol; j++)
                        tmpArray[j] = array[i, j];

                    if (algoritm == ALGORITM_SELECT)
                        arrayTime = selectSort(tmpArray, direction);
                    else
                        arrayTime = insertSort(tmpArray, direction);

                    tmpArray = arrayTime.array;

                    for (int j = 0; j < countCol; j++)
                        array[i, j] = tmpArray[j];

                    sumTime += arrayTime.time;
                }

            }
            else
            {
                int[] tmpArray = new int[countString];

                for (int j = 0; j < countCol; j++)
                {
                    for (int i = 0; i < countString; i++)
                        tmpArray[i] = array[i, j];

                    if (algoritm == ALGORITM_SELECT)
                        arrayTime = selectSort(tmpArray, direction);
                    else
                        arrayTime = insertSort(tmpArray, direction);


                    tmpArray = arrayTime.array;

                    for (int i = 0; i < countString; i++)
                        array[i, j] = tmpArray[i];

                    sumTime += arrayTime.time;
                }
            }



            if (isPrint)
            {
                Console.WriteLine("");

                string str = "";

                string header = " \t";

                for (int i = 0; i < countCol; i++)
                    header += $"[{i}]\t";

                Console.WriteLine(header);

                for (int i = 0; i < countString; i++)
                {

                    str = string.Format("[{0}]\t", i);

                    for (int j = 0; j < countCol; j++)
                        str += string.Format("{0}\t", array[i, j]);

                    Console.WriteLine(str);
                }
            }

            if (isCheckTime)
            {
                Console.WriteLine($"\nСортировка {strAlgoritm} {strDirection} {strOrientation} в массиве с {countCol * countString} элементов");
                Console.WriteLine($"Выполнена за {sumTime} мс.");
            }

            return array;
        }
    }
}
