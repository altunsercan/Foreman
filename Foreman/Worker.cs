
namespace Foreman
{
    public interface Worker
    {
        WorkerState State { get; }

        bool RemoveJob(Job job);
        bool QueueJob(Job job);
        bool Work(Job job = null);

        Job[] Queued { get; }
    }
}
