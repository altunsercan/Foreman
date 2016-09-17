// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Impl
{
    using System.Collections.Generic;

    public abstract class CompoundJobBase : JobBase, CompoundJob
    {
        protected CompoundJobBase(string name, string identifier)
            : base(name, identifier)
        {
            this.SubJobsList = new List<Job>();
        }

        public Job[] SubJobs
        {
            get
            {
                return this.SubJobsList.ToArray();
            }
        }

        protected List<Job> SubJobsList { get; set; }
    }
}