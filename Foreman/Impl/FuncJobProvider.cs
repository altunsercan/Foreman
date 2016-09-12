using System;
using UnityEngine;

namespace Foreman.Impl
{
    public class FuncJobProvider : JobHandlerProvider
    {
        private Func<Job, GameObject, JobHandler> _function;
        public FuncJobProvider( Func<Job, GameObject, JobHandler> function )
        {
            _function = function;
        }

        public JobHandler CreateHandler(Job job, GameObject gobj)
        {
            return _function(job, gobj);
        }
    }
}
