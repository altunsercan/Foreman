using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Foreman;
using Moq;

namespace Foreman.Test
{
    public class WorkerPoolTests
    {

        [Test]
        public void WorkerPool_CheckSize()
        {
            Mock<WorkerPool> mock = new Mock<WorkerPool>(MockBehavior.Strict);

            WorkerPool pool = mock.Object;
            int count = RandomPopulateWorkerPool(pool);

            Worker[] workers = pool.All();

            Assert.AreNotEqual(count, 0);
            Assert.AreEqual(count, workers.Length);
            Assert.AreEqual(count, pool.Size);
        }

        [Test]
        public void WorkerPool_SelectWorker()
        {
            Mock<WorkerPool> mock = new Mock<WorkerPool>(MockBehavior.Strict);

            WorkerPool pool = mock.Object;
            int count = RandomPopulateWorkerPool(pool, 10, 30);

            Worker[] workers = pool.All();
            Worker randomWorker = workers[Random.Range(0, workers.Length)];

            Worker selectedWorker = pool.SelectFirst(delegate (Worker w) {
                if (w == randomWorker)
                {
                    return true;
                }
                return false;
            });

            Assert.AreEqual(randomWorker, selectedWorker);
        }
        public void WorkerPool_SelectWorkerAll()
        {
            Mock<WorkerPool> mock = new Mock<WorkerPool>(MockBehavior.Strict);

            WorkerPool pool = mock.Object;
            int count = RandomPopulateWorkerPool(pool, 10, 30);

            Worker[] workers = pool.All();
            Worker randomWorker = workers[Random.Range(0, workers.Length)];
            Worker randomWorker2 = workers[Random.Range(0, workers.Length)];

            Worker[] selectedWorkers = pool.SelectAll(delegate (Worker w) {
                if (w == randomWorker || w == randomWorker2)
                {
                    return true;
                }
                return false;
            });

            Assert.IsTrue(ArrayUtility.Contains<Worker>(selectedWorkers, randomWorker));
            Assert.IsTrue(ArrayUtility.Contains<Worker>(selectedWorkers, randomWorker2));
        }
        
        private int RandomPopulateWorkerPool(WorkerPool pool, int minSize = 2, int maxSize = 10)
        {
            Mock<Worker> mock;
            int randomWorkerCount = Random.Range(minSize, maxSize);

            for (int index = 0; index < randomWorkerCount; index++)
            {
                mock = new Mock<Worker>(MockBehavior.Strict);

                pool.AddWorker(mock.Object);
            }

            return randomWorkerCount;
        }
    }
}

