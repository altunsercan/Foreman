// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman
{
    using System.Collections.Generic;

    using UnityEngine;

    public static class Foreman
    {
        private static readonly List<JobHandlerProvider> BehaviourProviderList = new List<JobHandlerProvider>();

        public static bool AddProvider(JobHandlerProvider provider)
        {
            if (BehaviourProviderList.Contains(provider))
            {
                return false;
            }

            BehaviourProviderList.Add(provider);
            return true;
        }

        public static void ClearProviders()
        {
            BehaviourProviderList.Clear();
        }

        public static JobHandler CreateHandler(Job jobData, GameObject gameObj)
        {
            foreach (JobHandlerProvider provider in BehaviourProviderList)
            {
                JobHandler behaviour = provider.CreateHandler(jobData, gameObj);
                if (behaviour != null)
                {
                    if (behaviour is MonoBehaviour)
                    {
                        (behaviour as MonoBehaviour).enabled = false;
                    }

                    behaviour.AssignJobData(jobData);
                    return behaviour;
                }
            }

            return null;
        }
    }
}