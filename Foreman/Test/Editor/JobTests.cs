using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using Moq;
using Foreman;

public class JobTests {

	[Test]
	public void JobStateChanges()
	{
        Mock<Job> mock = new Mock<Job>();

        Job job = mock.Object;

    }
}
