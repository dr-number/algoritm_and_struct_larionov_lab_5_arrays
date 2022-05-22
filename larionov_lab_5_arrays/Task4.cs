namespace larionov_lab_5_arrays
{
    internal class Task4
    {
        private void printArray(int[,] array)
        {
            int countRow = array.GetLength(0);
            int countCol = array.GetLength(1);


            Console.WriteLine($"Строк:    {countRow}");
            Console.WriteLine($"Столбцов: {countCol}\n");

            string header = " \t";

            for (int i = 0; i < countCol; i++)
                header += $"[{i}]\t";

            Console.WriteLine(header);

            string str = "";

            for (int i = 0; i < countRow; i++)
            {
                str = string.Format("[{0}]\t ", i);

                for (int j = 0; j < countCol; j++)
                    str += string.Format("{0}\t", array[i, j]);

                Console.WriteLine(str);
                str = "";
            }
        }

        private int getIndexFirstPositiveElementCol(int[,] array)
        {
            int countRow = array.GetLength(0);
            int countCol = array.GetLength(1);

            bool isNegative = false;

            for (int j = 0; j < countCol; j++)
            {

                isNegative = false;

                for (int i = 0; i < countRow; i++)
                    if (array[i, j] < 0)
                    {
                        isNegative = true;
                        break;
                    }

                if (!isNegative)
                    return j;
            }

            return -1;
        }

        private int[] getRow(int[,] array, int i)
        {
            int countCol = array.GetLength(1);
            int[] result = new int[countCol];

            for (int j = 0; j < countCol; j++)
                result[j] = array[i, j];

            return result;
        }
        private int getCountQualRepeatElements(int[] array)
        {

            //int[] array = {3, 3, 3, 4, 4, 5, 5, 5, 5};

            int size = array.Length;

            MySort.ModeSort modeSort = new MySort.ModeSort();
            modeSort.direction = MySort.INCRASE;
            modeSort.algoritm = MySort.ALGORITM_SELECT;

            int count = 0;
            int qual = array[0];

            int sumCount = 0;


            MySort mySort = new MySort();
            array = mySort.sort(array, modeSort, false, false);

            for (int i = 1; i < size; i++)
            {
                if (qual == array[i])
                    ++count;
                else
                {
                    sumCount += count;

                    if (count != 0)
                        ++sumCount;

                    count = 0;
                }

                qual = array[i];

            }

            if (count != 0)
                sumCount += count + 1;

            return sumCount;
        }

        private struct StringsWithRepeat
        {
            public int[] strings;
            public bool isExistRepeat;
        }
        private StringsWithRepeat getStringsWithRepeat(int[,] array)
        {
            int countRow = array.GetLength(0);
            int countQualRepeatElements;

            bool isExistRepeat = false;
            int[] result = new int[countRow];
            int[] tmpArray;

            for (int i = 0; i < countRow; i++)
            {

                tmpArray = getRow(array, i);
                countQualRepeatElements = getCountQualRepeatElements(tmpArray);

                if (countQualRepeatElements != 0)
                {
                    result[i] = countQualRepeatElements;
                    isExistRepeat = true;
                }

            }

            StringsWithRepeat res = new StringsWithRepeat();
            res.strings = result;
            res.isExistRepeat = isExistRepeat;

            return res;
        }

        private struct TmpMaxCountQual
        {
            public int count;
            public int[] row;
        }

        private int comparsionEqal(TmpMaxCountQual a, TmpMaxCountQual b)
        {
            int countA = a.count;
            int countB = b.count;

            if (countA > countB) return 1;
            if (countA < countB) return -1;
            return 0;
        }

        public void init()
        {
            Console.WriteLine(TasksInfo.TASK_16_4);

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

            printArray(array);

            int indexFirstPositiveElementCol = getIndexFirstPositiveElementCol(array);

            if (indexFirstPositiveElementCol == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВсе столбцы содержат минимум один отрицательный элемент!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\nНомер первого из столбцов, не содержащих ни одного отрицательного элемента: {indexFirstPositiveElementCol + 1}");
                Console.ResetColor();
            }

            mySort.sort(array, modeSort, true, true);

            StringsWithRepeat stringsWithRepeat = getStringsWithRepeat(array);

            if (!stringsWithRepeat.isExistRepeat)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВ строках нет повторяющихся элементов!");
                Console.ResetColor();
            }
            else
            {
                int[] maxCountQual = stringsWithRepeat.strings;
                int countRow = array.GetLength(0);
                int countCol = array.GetLength(1);

                List<TmpMaxCountQual> tmpMaxCountQual = new List<TmpMaxCountQual>();
                TmpMaxCountQual itemTmpMaxCountQual;
                List<int> ignoreIndex = new List<int>();
                int[] tmpRow;

                string repeatsInStrings = "";
                int countQual = maxCountQual.Length;

                for (int i = 0; i < countQual; i++)
                {

                    if (maxCountQual[i] != 0)
                    {
                        repeatsInStrings += (i + 1) + ", ";

                        tmpRow = getRow(array, i);
                        itemTmpMaxCountQual.row = tmpRow;
                        itemTmpMaxCountQual.count = getCountQualRepeatElements(tmpRow);
                        tmpMaxCountQual.Add(itemTmpMaxCountQual);
                        ignoreIndex.Add(i);
                    }

                }

                repeatsInStrings = repeatsInStrings.Remove(repeatsInStrings.Length - 2);
                repeatsInStrings = "\nСтроки с номерами: " + repeatsInStrings + " - содержат повторяющиеся элементы\n";

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(repeatsInStrings);

                tmpMaxCountQual.Sort(comparsionEqal);
                int tmpMaxCountQualSize = tmpMaxCountQual.Count;

                int[,] sortArray = new int[countRow, countCol];

                for (int i = 0; i < tmpMaxCountQualSize; i++)
                    for (int j = 0; j < countCol; j++)
                        sortArray[i, j] = tmpMaxCountQual[i].row[j];

                int n = 0;

                for (int i = 0; i < countRow; i++)
                {
                    if (!ignoreIndex.Contains(i))
                    {
                        for (int j = 0; j < countCol; j++)
                            sortArray[tmpMaxCountQualSize + n, j] = array[i, j];

                        ++n;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Матрица с упорядоченными по возрастанию повторяющихся элементов строками");


                //============================================================
                Console.WriteLine($"Строк:    {countRow}");
                Console.WriteLine($"Столбцов: {countCol}\n");

                string header = " \t";

                for (int i = 0; i < countCol; i++)
                    header += $"[{i}]\t";

                Console.WriteLine(header);

                string str = "";
                n = 0;

                for (int i = 0; i < countRow; i++)
                {
                    str = string.Format("[{0}]\t ", i);

                    for (int j = 0; j < countCol; j++)
                        str += string.Format("{0}\t", sortArray[i, j]);

                    if (n < tmpMaxCountQualSize)
                    {
                        str += " - количество одинаковых элементов в строке: " + tmpMaxCountQual[n].count;
                        ++n;
                    }

                    Console.WriteLine(str);
                    str = "";
                }

                //printArray(sortArray);
                //============================================================

            }

            Console.ResetColor();
        }
    }
}
