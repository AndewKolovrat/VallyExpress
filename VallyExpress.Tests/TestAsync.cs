using System;
using NUnit.Framework;
using System.Threading.Tasks;

using VallyExpress.Models;

namespace VallyExpress.Tests
{
    public class TestAsync
    {

        Shop shop;
        Random rnd;
        int reserveds = 0;
        Product prod;

        [SetUp]
        public void Setup()
        {
            Shop.SetConnectionsString("Host = localhost; Port=5432;Database=store;Username=postgres;Password=test");
            shop = new Shop();
            shop.initSample();
            rnd = new Random();
            prod = shop.GetProduct(1);
        }

        Task testHandleAsync()
        {
            Task t = null;
            for (int i = 0; i <= 10; i++)
            {
                t = Task.Factory.StartNew(encloseHandleAsync);
                t.Wait();
            }
            return t;
        }
        async Task encloseHandleAsync()
        {
            for (int j = 0; j <= 1000; j++)
            {
                Reserv r = await shop.ReserveAsync(1, 1, rnd.Next(1, 4));
                reserveds += r.Count;
            }
        }

        [Test]
        public void AsyncTest()
        {
            for (int i = 0; i <= 10; i++)
            {
                Assert.DoesNotThrowAsync(testHandleAsync);
            }
            Assert.IsTrue(reserveds == prod.InReserved);
            Assert.IsTrue(prod.Count >= 0);
        }

    }

}