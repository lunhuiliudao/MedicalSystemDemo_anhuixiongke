// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.



namespace System.ComponentModel.DataAnnotations.Schema
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Specifies the database table that a class is mapped to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    [SuppressMessage("Microsoft.Performance", "CA1813:AvoidUnsealedAttributes")]
    public class TableAttribute : Attribute
    {
        private readonly string _name;
        private string _schema;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableAttribute" /> class.
        /// </summary>
        /// <param name="name"> The name of the table the class is mapped to. </param>
        public TableAttribute(string name)
        {
            _name = name;
        }

        /// <summary>
        /// The name of the table the class is mapped to.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// The schema of the table the class is mapped to.
        /// </summary>
        public string Schema
        {
            get { return _schema; }
            set
            {
                _schema = value;
            }
        }
    }
}

