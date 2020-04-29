using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


[AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
public class OptionAttribute : Attribute
{
    public OptionAttribute()
    {

    }
    public OptionAttribute(string longName)
    {

    }
    public OptionAttribute(char shortName)
    {

    }
    public OptionAttribute(char shortName, string longName)
    {

    }

    public string LongName { get { return string.Empty; } }
    public string ShortName { get { return string.Empty; } }
    public string SetName { get; set; }
    public char Separator { get; set; }


    public bool Required { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }
    public object Default { get; set; }
    public string HelpText { get; set; }
    public string MetaValue { get; set; }
    public bool Hidden { get; set; }
}