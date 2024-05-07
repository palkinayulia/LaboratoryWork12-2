using ClassLibrary10Lab;
using Лабораторная_работа_12_2;

namespace Tests12_2Lab
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCreating()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>();
            Watch watch = new Watch();
            //Act
            table.AddItem(watch);
            //Assert
            Assert.AreEqual(1, table.Count);
        }

        [TestMethod]
        public void TestContains()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>();
            Watch watch = new Watch();
            //Act
            table.AddItem(watch);
            bool check = table.Contains(watch);
            //Assert
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void TestRemove()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>();
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            //Act
            table.AddItem(watch);
            table.AddItem(watch2);
            table.RemoveData(watch2);
            //Assert
            Assert.AreEqual(1, table.Count);
        }
        [TestMethod]
        public void TestFindItem()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>();
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            //Act
            table.AddItem(watch);
            //table.AddItem(watch2);
            int n = table.FindItem(watch2);
            //Assert
            Assert.AreEqual(-1, n);
        }

        [TestMethod]
        public void TestAddItem()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>(1);
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            //Act
            table.AddItem(watch);
            table.AddItem(watch2);
            //Assert
            Assert.AreEqual(2, table.Count);
        }
        [TestMethod]
        public void TestAddData()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>(1);
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            //Act
            table.AddData(watch);
            //Assert
            Assert.ThrowsException<Exception>(() => table.AddData(watch2));
        }
        [TestMethod]
        public void TestFindItem2()
        {
            //Arrange
            MyHashTable1<Watch> table = new MyHashTable1<Watch>(3);
            Watch watch = new Watch();
            Watch watch2 = new Watch();
            Watch watch3 = new Watch();
            //Act
            watch.RandomInit();
            watch2.RandomInit();
            watch3.RandomInit();
            table.AddItem(watch);
            table.AddItem(watch2);
            //Assert
            Assert.AreEqual(-1, table.FindItem(watch3));
        }
    }
}