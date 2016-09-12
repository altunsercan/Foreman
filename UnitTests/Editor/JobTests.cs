using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Moq;
using Foreman;

namespace Foreman.Test
{
    public class JobTests
    {

        [Test]
        public void JobStateChanges()
        {
            Mock<Job> mock = new Mock<Job>();

            Job job = mock.Object;
            Assert.AreEqual(job.Status, JobStatus.WAITING);

            job.Start();
            Assert.AreEqual(job.Status, JobStatus.INPROGRESS);

            job.Pause();
            Assert.AreEqual(job.Status, JobStatus.SUSPENDED);

        }
    }
}
