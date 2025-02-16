using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockLab
{
    public class DialClock
    {
        // Переменная для хранения значений часов
        private int hours;
        // Переменная для хранения значений минут
        private int minutes;
        // Статистическая переменная подсчёта созданных объектов класса DialClock
        private static int objectCount = 0;

        // Свойство часов
        public int Hours
        {
            get { return this.hours; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Часы не могут быть отрицательными.");
                this.hours = value % 24;
            }
        }

        // Свойство минут
        public int Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Минуты не могут быть отрицательными.");

                this.hours += value / 60;
                this.minutes = value % 60;
                this.hours %= 24;
            }
        }
        // Пустой конструктор
        public DialClock()
        {
            objectCount++;
        }

        // Конструктор, устанавливающий значения Hours
        public DialClock(int hours)
        {
            this.Hours = hours;
            objectCount++;
        }

        // Конструктор, устанавливающий значения Hours и Minutes
        public DialClock(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            objectCount++;
        }

        // Метод, считающий угол между стрелками часов
        public double CalculateTheAngle()
        {
            double hoursAngle = hours % 12 * 30 + (minutes * 0.5);
            double minutesAngle = minutes * 6;
            double angle = Math.Abs(hoursAngle - minutesAngle);
            return angle > 180 ? 360 - angle : angle;
        }

        // Метод, который выводит текущее время и угол между стрелками на экран
        public void Show()
        {
            Console.WriteLine($"Текущее время: {Hours:D2}:{Minutes:D2}. Угол между стрелками часов: {CalculateTheAngle()}");
        }

        // Метод, возвращающий количество созданных объектов
        public static int GetObjectCount() => objectCount;

        // Унарный оператор для увеличения времени на минуту
        public static DialClock operator ++(DialClock clock)
        {
            clock.Minutes++;
            if (clock.Minutes >= 60)
            {
                clock.Minutes = 0;
                clock.Hours = (clock.Hours + 1) % 24;
            }
            return clock;
        }

        // Унарный оператор для уменьшения времени на минуту
        public static DialClock operator --(DialClock clock)
        {
            int newMinutes = clock.Minutes - 1;
            int newHours = clock.Hours;

            if (newMinutes < 0)
            {
                newMinutes = 59;
                newHours = (newHours - 1 + 24) % 24;
            }

            return new DialClock(newHours, newMinutes);
        }

        // Операция явная приведения типа, проверяющая кратность угла между стрелками числу 2.5
        public static explicit operator bool(DialClock clock)
        {
            return clock.CalculateTheAngle() % 2.5 == 0;
        }

        // Операция неявная приведения типа, возвращающая количество пройденных делений минутной стрелкой (отсчёт с 12)
        public static implicit operator int(DialClock clock)
        {
            return (clock.Hours * 60) + clock.Minutes;
        }

        // Бинарный оператор, добавляющий минуты к часу справа
        public static DialClock operator +(DialClock clock, int minutesToAdd)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes + minutesToAdd;
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }
        // Бинарный оператор, вычитающий из часов минуты справа
        public static DialClock operator -(DialClock clock, int minutesToSubtract)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes - minutesToSubtract;
            if (totalMinutes < 0)
            {
                totalMinutes += 24 * 60;
            }
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        // Бинарный оператор, добавляющий минуты к часу слева
        public static DialClock operator +(int minutesToAdd, DialClock clock)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes + minutesToAdd;
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        // Бинарный оператор, вычитающий из часов минуты слева
        public static DialClock operator -(int minutesToSubtract, DialClock clock)
        {
            int totalMinutes = clock.Hours * 60 + clock.Minutes;
            totalMinutes -= minutesToSubtract;
            if (totalMinutes < 0)
            {
                totalMinutes += 24 * 60;
            }
            int newHours = totalMinutes / 60 % 24;
            int newMinutes = totalMinutes % 60;
            return new DialClock(newHours, newMinutes);
        }

        // Метод для сравнения двух объектов
        public override bool Equals(object? obj)
        {
            if (obj is DialClock otherClock)
            {
                return this.Hours == otherClock.Hours && this.Minutes == otherClock.Minutes;
            }
            return false;
        }

        // Метод, возвращающий уникальный хэшкод, чтобы не было предупреждений в решении
        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes);
        }
    }
}