using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLab
{
    public class DialClockArray
    {
        static Random rnd = new Random();
        DialClock[] clocks;
        public int Length => clocks.Length;
        public static int collectionCount = 0;

        public DialClockArray()
        {
            clocks = new DialClock[0];
            collectionCount++;
        }

        public DialClockArray(int length)
        {
            clocks = new DialClock[length];
            for (int i = 0; i < length; i++)
            {
                clocks[i] = new DialClock(rnd.Next(0, 100), rnd.Next(0, 100));
            }
            collectionCount++;
        }

        // Конструктор глубокого копирования 
        public DialClockArray(DialClockArray other)
        {
            clocks = new DialClock[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                clocks[i] = new DialClock(other[i].Hours, other[i].Minutes);
            }
            collectionCount++;
        }

        // Метод, показывающий информацию о каждом элементе созданного массива
        public void Show()
        {
            Console.WriteLine("Начало массива");
            for (int i = 0; i < clocks.Length; i++)
            {
                clocks[i].Show();
            }
            Console.WriteLine("Массив закончен");
            Console.WriteLine();
        }

        // Метод для поиска объекта с максимальным углом между стрелками
        public DialClock FindMaxAngleInArray()
        {
            if (clocks.Length == 0) throw new InvalidOperationException("Массив пуст"); ;

            DialClock maxClock = clocks[0];
            double maxAngle = maxClock.CalculateTheAngle();

            for (int i = 1; i < clocks.Length; i++)
            {
                double currentAngle = clocks[i].CalculateTheAngle();
                if (currentAngle > maxAngle)
                {
                    maxAngle = currentAngle;
                    maxClock = clocks[i];
                }
            }
            return maxClock;
        }

        // Индексатор
        public DialClock this[int index]
        {
            get
            {
                if (index < 0 || index >= clocks.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива");
                return clocks[index];
            }
            set
            {
                if (index < 0 || index >= clocks.Length)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы массива");
                clocks[index] = value;
            }
        }

        // Метод, возвращающий количество созданных коллекций
        public static int GetCollectionCount() => collectionCount;
    }
}