using BagImplementation;
using static BagImplementation.Bag;


namespace BagImplementationTest {
    [TestClass]
    public class BagTest {
        [TestMethod]
        public void TestPrintBag() {
            Bag Bag = new Bag();
            Assert.ThrowsException<EmptyBagException>(() => { Bag.printBag(); });
            Bag.insertElement(1);
            Assert.IsNotNull(Bag.printBag());
        }

        [TestMethod]
        public void TestLargestElement() {
            Bag Bag = new Bag();
            Assert.ThrowsException<EmptyBagException>(() => { Bag.largestElement(); });
            Bag.insertElement(1);
            Assert.IsNotNull(Bag.printBag());
            Bag.insertElement(2);
            Bag.insertElement(5);
            Bag.insertElement(5);
            Assert.AreEqual(Bag.largestElement(), 5);
        }

        [TestMethod]
        public void TestFrequency() {
            Bag Bag = new Bag();
            Assert.ThrowsException<EmptyBagException>(() => { Bag.frequency(1); });
            Bag.insertElement(1);
            Assert.AreEqual(Bag.frequency(1), 1);
            Assert.AreEqual(Bag.frequency(2), 0);
        }

        [TestMethod]
        public void TestRemoveElement() {
            Bag Bag = new Bag();
            Assert.ThrowsException<EmptyBagException>(() => { Bag.removeElement(1); });

            Bag.insertElement(1);
            Bag.insertElement(1);
            Bag.insertElement(2);
            Bag.removeElement(2);
            Assert.AreEqual(Bag.frequency(2), 0);
            Bag.removeElement(1);
            Assert.AreEqual(Bag.frequency(1), 1);

            Assert.ThrowsException<ItemNotFoundException>(() => { Bag.removeElement(3); });
        }

        [TestMethod]
        public void TestInsertElement() {
            Bag Bag = new Bag();
            Bag.insertElement(1);
            Bag.insertElement(2);
            Assert.AreEqual(Bag.printBag().Count, 2);

            Bag.insertElement(1);
            Assert.AreEqual(Bag.printBag().Count, 2);

            Bag.insertElement(1);

            Assert.AreEqual(Bag.frequency(1), 3);
        }
    }
}