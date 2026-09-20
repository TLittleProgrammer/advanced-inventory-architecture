using LocalPackages.Inventory;
using NUnit.Framework;

namespace Tests
{
    internal class InventoryTests
    {
        private Inventory<TestResource, TestResourceSlot> _inventory;
        private const int Capacity = 3;
        
        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory<TestResource, TestResourceSlot>(Capacity, () => new TestResourceSlot());
        }

        [TestCase(0, 1)]
        public void AddResourceWithoutIndex(int resourceId, int amount)
        {
            var resource = new TestResource(resourceId, amount);

            Assert.AreEqual(true, _inventory.Add(resource));
        }
        
        [TestCase(0, 1, 0)]
        [TestCase(0, 1, 1)]
        [TestCase(0, 1, 2)]
        public void AddResourceByIndex(int resourceId, int amount, int index)
        {
            var resource = new TestResource(resourceId, amount);

            Assert.AreEqual(true, _inventory.Add(index, resource));
        }
        
        [TestCase(0, 1, 2)]
        public void CheckSlotDataAfterAdding(int resourceId, int amount, int index)
        {
            var resource = new TestResource(resourceId, amount);
            _inventory.Add(index, resource);
            
            var slot = _inventory.GetSlot(index);
            
            Assert.AreEqual(slot.ResourceId, resourceId);
            Assert.AreEqual(slot.Amount, amount);
        }
        
        [TestCase(0, 1, 2)]
        public void CheckSlotDataAfterMerging(int resourceId, int amount, int index)
        {
            var resource = new TestResource(resourceId, amount);
            _inventory.Add(index, resource);
            _inventory.Add(index, resource);
            
            var slot = _inventory.GetSlot(index);
            
            Assert.AreEqual(slot.ResourceId, resourceId);
            Assert.AreEqual(slot.Amount, amount * 2);
        }

        [TestCase(-1)]
        [TestCase(4)]
        [TestCase(100)]
        public void RemoveOutOfRangeTest(int index)
        {
            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            {
                _inventory.Remove(index);
            });
        }
    }
}