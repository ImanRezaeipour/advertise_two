using System;

namespace Advertise.Core.Types
{
    internal class DescripionAttribute : Attribute
    {
        private string v;

        public DescripionAttribute(string v)
        {
            this.v = v;
        }
    }
}