// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman
{
    using System;

    public interface JobHandler
    {
        event Action<JobStatus> StatusChanged;

        JobStatus Status { get; }

        void AssignJobData(Job jobData);
        
        bool StartJob();

        bool SuspendJob();

        bool CancelJob();
    }
}