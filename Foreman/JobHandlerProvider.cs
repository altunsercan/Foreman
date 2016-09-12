using Foreman;
using UnityEngine;

namespace Foreman
{
    public interface JobHandlerProvider
    {
        JobHandler CreateHandler(Job job, GameObject gobj);
    }
}