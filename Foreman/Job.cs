// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman
{
    public interface Job
    {
        string Identifier { get; }

        string Name { get; }
    }

    public interface CompoundJob : Job
    {
        Job[] SubJobs { get; }
    }
}