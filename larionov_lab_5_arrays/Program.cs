namespace larionov_lab_5_arrays
{
    class Class1
    {
        public static void MyPause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nДля продолжения нажмите любую клавишу...");
            Console.ReadLine();

            Console.ResetColor();
        }

        static void Main(string[] args)
        {

            bool isGo = true;

            while (isGo)
            {
                Console.WriteLine("\nЛарионов Никита Юрьевич. гр. 110з\n");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Лабораторная работа №5. Одномерный массив.\n");
                Console.ResetColor();

                Console.WriteLine($"1) {TasksInfo.TASK_6_1}");
                Console.WriteLine($"2) {TasksInfo.TASK_16_2}");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Лабораторная работа №6. Матрица.\n");
                Console.ResetColor();

                Console.WriteLine($"3) {TasksInfo.TASK_6_3}");
                Console.WriteLine($"4) {TasksInfo.TASK_16_4}");

                Console.WriteLine("\nВведите номер задачи: ");
                Console.WriteLine("Для выхода введите \"0\": ");

                string selectStr = Console.ReadLine();

                switch (selectStr)
                {
                    case "1":
                        Task1 task1 = new Task1();
                        task1.init();
                        break;

                    case "2":
                        Task2 task2 = new Task2();
                        task2.init();
                        break;

                    case "3":
                        Task3 task3 = new Task3();
                        task3.init();
                        break;

                    case "4":
                        Task4 task4 = new Task4();
                        task4.init();
                        break;

                    case "0":
                        isGo = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nНекорректные данные!");
                        Console.ResetColor();
                        break;

                }

                MyPause();
            }
        }

    }
}
