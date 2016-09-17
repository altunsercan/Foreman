// /*
//  * Copyright (C) 2016 Sercan Altun
//  * All rights reserved.
//  *
//  * This software may be modified and distributed under the terms
//  * of open source MIT license.  See the LICENSE file for details.
//  */
namespace Foreman.Impl
{
    public abstract class JobBase : Job
    {
        private readonly string _identifier;

        private readonly string _name;

        protected JobBase(string name, string identifier)
        {
            this._identifier = identifier;
            this._name = name;
        }

        public string Identifier
        {
            get
            {
                return this._identifier;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
        }
    }
}