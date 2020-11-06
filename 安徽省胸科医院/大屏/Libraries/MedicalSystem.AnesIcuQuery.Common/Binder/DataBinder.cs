// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// 
namespace Castle.Components.Binder
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Reflection;
    using System.Web;
    using System.Linq;

	/// <summary>
	/// </summary>
	[Serializable]
	public class DataBinder : MarshalByRefObject, IDataBinder
	{
		protected internal static readonly BindingFlags PropertiesBindingFlags =
			BindingFlags.Instance | BindingFlags.Public;

		private IConverter converter = new DefaultConverter();

        public static IDataBinder GetBinder()
        {
            DataBinder binder = new DataBinder();
            return binder;
        }

        public IConverter Converter
        {
            get
            {
                return converter;
            }
        }

        internal static bool IsGenericList(Type instanceType)
        {
            if (!instanceType.IsGenericType)
            {
                return false;
            }
            if (typeof(IList).IsAssignableFrom(instanceType))
            {
                return true;
            }

            Type[] genericArgs = instanceType.GetGenericArguments();

            if (genericArgs.Length == 0)
            {
                return false;
            }
            Type listType = typeof(IList<>).MakeGenericType(genericArgs[0]);
            return listType.IsAssignableFrom(instanceType);
        }

    }
}