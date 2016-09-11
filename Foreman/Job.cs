namespace Foreman
{
    public interface Job
    {
        string Name { get; }
        string Identifier { get; }

        JobStatus Status { get; }
        JobBehaviours Behaviour { get; }

        bool Suspend();
        bool Pause();
        bool Continue();
        bool Start();
        bool Cancel();
    }
}