# Foreman: AI Planning & Job Execution Manager

This library is in early stages of development, hence incomplete. It is developed as a component of a bigger project. It is not designed as a general purpose library.

Current project scope includes:
- Worker behaviours to queue and manage Jobs
- Unit Job descriptors to assign to Workers
- JobControllers to handle execution of the Jobs
- Domain descriptors for planning algorithms
- Foreman to run domain-configurable planners

## Concepts
### Worker
**Worker** inteface is responsible for orchestration jobs execution. Standard implementation provided is **MonoWorker**; where all jobs added run sequentially by the GameObject MonoWorker is attached to. However interface may be implemented in different means to support other execution schemes.
```C#
Worker worker = dwarfGameObject.GetComponent<MonoWorker>();
worker.QueueJob(new PickUp("pickupGold", item));
worker.QueueJob(new DropOff("dropOffGold", item, target));
worker.Work();
```

### Job & JobHandler
In Foreman we define job units with two interfaces. We create an unit operation by extending **Job** interface. This interface provides information necessary for running the Job *independent from Worker*. These jobs are then queued for execution in a concrete Worker. You can extend *JobBase* class or implement Job interface directly to define a new Job.

```C#
public class DropOff : JobBase
    {
        public readonly GameObject Carriable;
        public readonly Transform Target;
        public DropOff(string identifier,GameObject carriable, Transform target):base("DropOff", identifier)
        {
            Carriable = carriable;
            Target = target;
        }
    }
}
```
When it is their turn to run, Worker will ask Foreman for the appropriate **JobHandler** to execute the job. If This JobHandler is a MonoBehaviour it is added as a component to the Worker GameObject. Otherwise Worker simply executes inteface method to trigger execution of the job. JobHandlers which extend MonoBehavour, will be enabled/disabled based on the job status and destroyed when job is completed. ***So storing persistant data inside these are classes are not recommended***.

### JobHandlerProvider
When a Worker attempts to run a job it asks for related JobHandler via **JobHandlerProvider** classes. These providers are registered to the Foreman singleton and run in chain-of-responsibility pattern. Foreman will try each provider by passing Job and Worker instances to the provider's interface. If provider returns null Foreman moves on to the next provider. This process continiues until a provider returns a value or all providers are checked without a solution. Below is the example of FuncJobHandlerProvider, a generic class that uses a delegate method to provide JobHandlers.

```C#
Foreman.AddProvider(new FuncJobProvider((job, gobj) => {
                if (!(job is DropOff))
                {
                    return null;
                }

                DropOffBehaviour behaviour = gobj.AddComponent<DropOffBehaviour>();

                return behaviour;
            }));
```

#### Developed By
[Sercan Altun](https://sercanaltun.com) - Game Designer & Programmer

Foreman is licensed under MIT License.