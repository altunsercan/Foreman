using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Moq;

namespace Foreman.Test
{
    public class WorkerTests
    {

        [Test]
        public void QueueJob()
        {
            Mock<Worker> workerMock = new Mock<Worker>();

            Worker worker = workerMock.Object;

            MockRepository jobMockFactory = new MockRepository( MockBehavior.Default );

            worker.QueueJob(jobMockFactory.Create<Job>().Object);
            worker.QueueJob(jobMockFactory.Create<Job>().Object);
            worker.QueueJob(jobMockFactory.Create<Job>().Object);

            Job[] queued = worker.Queued;

            Assert.AreEqual(queued.Length, 3);
        }
    }

}
