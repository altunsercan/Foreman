using UnityEngine;
using System.Collections.Generic;
using System;

namespace Foreman
{
    public class Foreman
    {
        private static List<JobHandlerProvider> _behaviourProviderList = new List<JobHandlerProvider>();

        public static bool AddProvider( JobHandlerProvider provider )
        {
            if( _behaviourProviderList.Contains(provider))
            {
                return false;
            }

            _behaviourProviderList.Add(provider);
            return true;
        }

        public static JobHandler CreateHandler(Job jobData, GameObject gameObj)
        {
            foreach( JobHandlerProvider provider in _behaviourProviderList )
            {
                JobHandler behaviour = provider.CreateHandler(jobData, gameObj);
                if(behaviour!=null)
                {
                    if(behaviour is MonoBehaviour)
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
