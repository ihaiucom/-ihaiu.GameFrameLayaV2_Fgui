using System;
using System.Collections.Generic;
using System.Text;



namespace EditorFguiAssets
{
    public enum ResourceComponentType
    {
        component,
        image,
        movieclip,
        swf,
        font,
        sound,
    }

    public static class ResourceComponentTypeHelper
    {
        public static ResourceComponentType GetResourceComponentTypeByName(this string name)
        {
            return (ResourceComponentType)Enum.Parse(typeof(ResourceComponentType), name);
        }
    }
}