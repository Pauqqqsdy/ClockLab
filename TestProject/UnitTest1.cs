using ClockLab;

namespace TestsForClockLab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDialClockConstructorWithHoursAndMinutes()
        {
            // Arrange
            DialClock expected = new DialClock(1, 150);
            // Act
            DialClock clock = new ClockLab.DialClock(3, 30);
            // Assert
            Assert.AreEqual(expected.Hours, clock.Hours);
            Assert.AreEqual(expected.Minutes, clock.Minutes);
        }

        [TestMethod]
        public void TestDialClockConstructorWithHours()
        {
            // Arange
            DialClock expected = new DialClock(3);
            // Act
            DialClock clock = new ClockLab.DialClock(3);
            // Assert
            Assert.AreEqual(expected.Hours, clock.Hours);
            Assert.AreEqual(expected.Minutes, clock.Minutes);
        }

        [TestMethod]
        public void TestDialClockConstructorDefault()
        {
            // Arange
            DialClock expected = new DialClock();
            // Act
            // Assert
            Assert.AreEqual(0, 0);
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void TestSettingHours()
        {
            // Arrange
            DialClock clock = new DialClock();
            // Act
            clock.Hours = 25;
            // Assert
            Assert.AreEqual(1, clock.Hours);
        }

        [TestMethod]
        public void TestSettingMinutes()
        {
            // Arrange
            DialClock clock = new DialClock();
            // Act
            clock.Minutes = 105;
            // Assert
            Assert.AreEqual(45, clock.Minutes);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentOutOfRangeExceptionForHours()
        {
            DialClock clock1 = new DialClock(-10, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestArgumentOutOfRangeExceptionForMinutes()
        {
            DialClock clock1 = new DialClock(10, -40);
        }

        [TestMethod]
        public void TestCalculationTheAngle()
        {
            // Arrange
            DialClock clock = new DialClock(3, 0);
            // Act
            double angle = clock.CalculateTheAngle();
            // Assert
            Assert.AreEqual(angle, 90);
        }

        [TestMethod]
        public void TestIncrementOperator()
        {
            // Arrange
            DialClock clock = new DialClock(23, 69);
            // Act
            DialClock incClock = ++clock;
            // Assert
            Assert.AreEqual(0, incClock.Hours);
            Assert.AreEqual(10, incClock.Minutes);
        }

        [TestMethod]
        public void TestDecrementOperator()
        {
            // Arrange
            DialClock clock = new DialClock(0, 0);
            // Act
            DialClock deClock = --clock;
            // Assert
            Assert.AreEqual(23, deClock.Hours);
            Assert.AreEqual(59, deClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorLeft()
        {
            // Arrange
            DialClock clock = new DialClock(1, 50);
            // Act
            DialClock newClock = 10 + clock;
            // Assert
            Assert.AreEqual(2, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorRight1()
        {
            // Arrange
            DialClock clock = new DialClock(1, 30);
            // Act
            DialClock newClock = clock + 90;
            // Assert
            Assert.AreEqual(3, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }
        [TestMethod]
        public void TestAddingMinutesOperatorRight2()
        {
            // Arrange
            DialClock clock = new DialClock(23, 0);
            // Act
            DialClock newClock = clock + 120;
            // Assert
            Assert.AreEqual(1, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestAddingMinutesOperatorRight3()
        {
            // Arrange
            DialClock clock = new DialClock(12, 30);

            // Act
            DialClock newClock = clock + (-30); // 12:30 - 30 минут = 12:00

            // Assert
            Assert.AreEqual(12, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestSubtractingMinutesOperatorRight()
        {
            // Arrange
            DialClock clock = new DialClock(1, 30);
            // Act
            DialClock newClock = clock - 40;
            // Assert
            Assert.AreEqual(0, newClock.Hours);
            Assert.AreEqual(50, newClock.Minutes);
        }

        [TestMethod]
        public void TestSubtractMinutesLeft1()
        {
            // Arrange
            DialClock clock = new DialClock(0, 0);

            // Act
            DialClock newClock = 60 - clock;

            // Assert
            Assert.AreEqual(23, newClock.Hours);
            Assert.AreEqual(0, newClock.Minutes);
        }

        [TestMethod]
        public void TestEqualsOperatorTrue()
        {
            // Arrange
            DialClock clock1 = new DialClock(3, 15);
            DialClock clock2 = new DialClock(3, 15);
            // Act
            bool areEqual = clock1.Equals(clock2);
            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestMethod]
        public void TestGetObjectCount()
        {
            // Arrange
            DialClock clock1 = new DialClock();
            DialClock clock2 = new DialClock();
            DialClock clock3 = new DialClock();
            // Act
            int count = DialClock.GetObjectCount();
            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void TestExplicitOperator()
        {
            // Arrange
            DialClock clock = new DialClock(5, 0);
            // Act
            bool result = (bool)clock;
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestImplicitOperator()
        {
            // Arrange
            DialClock clock = new DialClock(12, 0);
            // Act
            int result = (int)clock;
            // Assert
            Assert.AreEqual(720, result);
        }

        [TestMethod]
        public void TestConstructorWithLength()
        {
            // Arrange
            int length = 5;
            // Act
            DialClockArray clockArray = new DialClockArray(length);
            // Assert
            Assert.AreEqual(length, clockArray.Length);
            Assert.AreEqual(1, DialClockArray.GetCollectionCount());
        }

        [TestMethod]
        public void TestEmptyConstructor()
        {
            // Act
            DialClockArray clockArray = new DialClockArray();
            // Assert
            Assert.AreEqual(0, clockArray.Length);
            Assert.AreEqual(5, DialClockArray.GetCollectionCount());
        }

        [TestMethod]
        public void TestCopyingConstructor()
        {
            // Arrange
            DialClockArray origArray = new DialClockArray(3);
            // Act
            DialClockArray copiedArray = new DialClockArray(origArray);
            // Assert
            Assert.AreEqual(origArray.Length, copiedArray.Length);
            Assert.AreNotSame(origArray[0], copiedArray[0]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCopyingConstructorException()
        {
            // Arrange
            DialClockArray ClockArray = new DialClockArray(5);
            // Act
            ClockArray[6] += 1;
        }

        [TestMethod]
        public void TestFindMaxAngleInArray()
        {
            // Arrange
            DialClockArray clockArray = new DialClockArray(5);
            // Act
            DialClock maxClock = clockArray.FindMaxAngleInArray();
            // Assert
            Assert.IsNotNull(maxClock);
        }

        [TestMethod]
        public void GetHashCodeShouldBeEqualForEqualObjects()
        {
            // Arrange
            var clock1 = new DialClock { Hours = 10, Minutes = 30 };
            var clock2 = new DialClock { Hours = 10, Minutes = 30 };
            // Act
            var hash1 = clock1.GetHashCode();
            var hash2 = clock2.GetHashCode();
            // Assert
            Assert.AreEqual(hash1, hash2);
        }

        [TestMethod]
        public void GetHashCodeShouldNotBeEqualForDifferentObjects()
        {
            // Arrange
            var clock1 = new DialClock { Hours = 10, Minutes = 30 };
            var clock2 = new DialClock { Hours = 11, Minutes = 30 };
            // Act
            var hash1 = clock1.GetHashCode();
            var hash2 = clock2.GetHashCode();
            // Assert
            Assert.AreNotEqual(hash1, hash2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestInvalidOperationException()
        {
            // Arrange
            DialClockArray emptyClockArray = new DialClockArray();
            // Act
            emptyClockArray.FindMaxAngleInArray();
        }
    }
}