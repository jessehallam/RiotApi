using System;

namespace RiotApi.Serialization.Json
{
    [AttributeUsage(AttributeTargets.Field)]
    public class MappingAttribute : Attribute
    {
        public string Name { get; set; }

        public MappingAttribute(string name)
        {
            Name = name;
        }
    }
}