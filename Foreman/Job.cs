using System;
namespace Foreman
{
    public interface Job
    {
        string Name { get; }
        string Identifier { get; }

        JobStatus Status { get; }
        event Action<JobStatus> StatusChanged;

        bool Suspend();
        bool Pause();
        bool Continue();
        bool Start();
        bool Cancel();
    }
}