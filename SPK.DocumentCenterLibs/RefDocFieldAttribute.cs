using System;

namespace SPK.DocumentCenterLibs
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RefDocFieldAttribute : Attribute
    {
        public string Title { get; set; }

        public RefDocFieldAttribute(string title)
        {
            Title = title;
        }
    }
}