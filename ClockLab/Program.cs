namespace ClockLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Первый объект
                DialClock clock1 = new DialClock();
                clock1.Show();

                // Второй объект 
                DialClock clock2 = new DialClock(3);
                clock2.Show();

                // Третий объект
                DialClock clock3 = new DialClock(15, 39);
                clock3.Show();

                // Инкрементирование первого объекта (инкрементируем минуты)
                clock1++;
                clock1.Show();

                // Декрементирование первого объекта (декрементируем минуты)
                clock1--;
                clock1.Show();

                // Создаём булевую переменную IsAngleMultiple с помощью explicit оператора
                bool isAngleMultiple = (bool)clock1;
                Console.WriteLine($"Угол между стрелками часов clock1 кратен 2.5? {isAngleMultiple}");

                // Создаём переменную countOfDivisions типа int с помощью implicit оператора
                int countOfDivisions = (int)clock3;
                Console.WriteLine($"Общее количество минут часов clock1 равно: {countOfDivisions}");

                // Создаём четвёртый объект с помощью бинарной операции сложения справа
                DialClock clock4 = clock1 + 25;
                clock4.Show();

                // Создаём пятный объект с помощью бинарной операции вычитания слева
                DialClock clock5 = -40 + clock3;
                clock5.Show();

                // Проверяем равны ли новые созданные объекты
                Console.WriteLine($"clock4 и clock5 равны? - {clock4.Equals(clock5)}");

                // Создаём первую коллекцию
                DialClockArray c1 = new DialClockArray(5);
                c1.Show();
                // Создаём вторую коллекцию c2 на основе c1
                DialClockArray c2 = new DialClockArray(c1);
                c2.Show();

                // Применяем глубокое копирование для первого элемента массива
                c1[0].Hours = 22;
                Console.WriteLine("Изменённый массив c1:");
                c1.Show();
                Console.WriteLine("Изменённый массив c2:");
                c2.Show();

                // Выводим количество созданных объектов
                Console.WriteLine($"Количество созданных объектов: {DialClock.GetObjectCount()}");
                // Выводим количество созданных коллекций
                Console.WriteLine($"Количество созданных коллекций: {DialClockArray.GetCollectionCount()}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла непредвиденная ошибка" + ex.Message);
            }
            finally
            {
                Console.WriteLine("Конец работы");
            }
        }
    }
}