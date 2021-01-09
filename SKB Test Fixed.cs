using System;
using System.Text;

namespace SKB_Test
{
    class Program
    {
        static void Main(string [] arg)
        {
            Console.WriteLine("Тестовая работа Виталия Одинокова для СКБ Контур.");          // Заголовки 
        Start:                                                                              //Перенаправление кода к метке
                Random rnd = new Random();                                                  //Генерация числа
                int firstPlayer = rnd.Next(1000, 9999);                                     //Условия генерации числа
                int d = firstPlayer % 10;
                int c = firstPlayer % 100 / 10;
                int b = firstPlayer % 1000 / 100;
                int a = firstPlayer % 10000 / 1000;                                         //Разбивка 4х-значных чисел на отдельные числа, чтобы сравнить каждое число
            if (d == c || d == b || d == a || c == b || c == a || b == a)                  //Проверка на совпадения по числам и отправление на повторную генерацию, если есть совпадения
            {
                goto Start;
            }
        Repeat:                                                                             //Перенаправление на повтор в случае ошибки
            Console.WriteLine("Введите любое четырехзначное число:");
            string secondPlayerStr = Console.ReadLine();                                   //Вводится сначала строка для проверки допустимости символов
            int checkNum;
            while (true)
            {
                
                try
                {
                    checkNum = int.Parse(secondPlayerStr);                              //Если всё верно, то идёт перенаправление на следующий участок кода
                    goto Next;
                }

                catch 
                {
                    Console.WriteLine("Недопустимые символы!");                         //Здесь идет перенаправление в начало в случае ошибки (любые символы, не цифры)
                    goto Repeat;
                }
            }
        Next:
            int secondPlayer = Convert.ToInt32(secondPlayerStr);                    //Число, которое вводит пользователь     
            if (secondPlayer < 1000 || secondPlayer > 9999)                        //Проверка на правильность входных числовых данных
                {
                    Console.WriteLine("Цифры должны быть не меньше 1000 и не больше 9999!");
                    goto Repeat;
                }
                int d1 = secondPlayer % 10;
                int c1 = secondPlayer % 100 / 10;
                int b1 = secondPlayer % 1000 / 100;
                int a1 = secondPlayer % 10000 / 1000;
                                                                                            //Разбивка 4х-значных чисел на отдельные числа, чтобы сравнить каждое число
                
                int bulls = 0;                                                            //Сумматор быков
                int cows = 0;                                                            //Сумматор коров
                if (a == a1 && b == b1 && c == c1 && d == d1)                           //Условие, если число угадано
                {
                    Console.WriteLine("Число угадано!");
                Mistake:                                                          //Метка на случай нажатия клавиш, которые не являются Y или N
                    Console.WriteLine("Начать сначала? (y/n)");
                    string key = Console.ReadKey().Key.ToString();                  //Захват нажатия клавиши
                    if (key.ToUpper() == "Y")                                       //Если нажали Y
                    {
                        goto Start;
                    }
                    if (key.ToUpper() == "N")                                     //Если нажали N
                    {
                        goto Finish;
                    }
                    else                                                         //Если нажали любую другую клавишу
                        goto Mistake;
                }

                if (a == a1)                                                    //4 условия для поиска и подсчета "быков"
                {
                    bulls += 1;
                }
                if (b == b1)
                {
                    bulls += 1;
                }
                if (c == c1)
                {
                    bulls += 1;
                }
                if (d == d1)
                {
                    bulls += 1;
                }

                int[] a_cows = { b1, c1, d1 };      //Массивы для поиска "коров"
                int[] b_cows = { a1, c1, d1 };
                int[] c_cows = { a1, b1, d1 };
                int[] d_cows = { a1, b1, c1 };

                for (int i = 0; i < a_cows.Length; i++) //Условия подсчета "коров"
                {
                    if (a == a_cows[i])
                    {
                        cows ++;
                        break;                          //break нужен для остановки выполнения (чтобы не получилось прибавления два раза)
                    }
                }
                for (int i = 0; i < b_cows.Length; i++)
                {
                    if (b == b_cows[i])
                    {
                        cows ++;
                        break;
                    }
                }
                for (int i = 0; i < c_cows.Length; i++)
                {
                    if (c == c_cows[i])
                    {
                        cows ++;
                        break;
                    }
                }
                for (int i = 0; i < a_cows.Length; i++)
                {
                    if (d == d_cows[i])
                    {
                        cows ++;
                        break;
                    }
                }

                Console.WriteLine("Быков:");
                Console.WriteLine(bulls);
                Console.WriteLine("Коров:");
                Console.WriteLine(cows);
                Console.WriteLine("Ваше число:");
                Console.WriteLine(secondPlayer);
                if (firstPlayer != secondPlayer)           //Если ответ введен неверно, игра перезапускается до тех пор, пока пользователь не отгадает
                {
                    goto Repeat;
                }

            Finish:
                Console.WriteLine("Спасибо за игру!");






            

        }
    }
}

