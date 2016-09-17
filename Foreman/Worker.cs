// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman
{
    public interface Worker
    {
        JobHandler CurrentHandler { get; }

        Job[] Queued { get; }

        WorkerState State { get; }

        bool QueueJob(Job job);

        bool RemoveJob(Job job);

        void ResetJobs();

        bool Work(Job job = null);
    }
}