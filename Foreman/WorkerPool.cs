using System;

namespace Foreman
{
    public interface WorkerPool
    {
        int Size { get; }

        bool AddWorker(Worker worker);
        bool RemoveWorker(Worker worker); 

        Worker SelectFirst(Func<Worker, bool> selectMethod);
        Worker[] SelectAll(Func<Worker, bool> selectMethod);

        Worker[] All();

        bool Empty();
    }
}
