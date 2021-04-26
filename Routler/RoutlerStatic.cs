using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Routler
{
    public static class RoutlerStatic
    {
        public static string GetRoute(this Type t, string name)
        {
            RoutlerClassAttribute[] atts = (RoutlerClassAttribute[])Attribute.GetCustomAttributes(t, typeof(RoutlerClassAttribute));
            return atts.Where(a => a.Name == name).FirstOrDefault()?.URI;
        }

        public static string GenerateURL(this Object o, string MethodName)
        {
            List<string> attributes = new List<string>();
            string uri = string.Empty; 

            Type t = o.GetType();

            StringBuilder urlBuilder = new StringBuilder();
            // Put the instance of the attribute on the class level in the att object.
            RoutlerClassAttribute[] atts = (RoutlerClassAttribute[])Attribute.GetCustomAttributes(t, typeof(RoutlerClassAttribute));

            RoutlerClassAttribute classAtt = atts.FirstOrDefault(att => att.Name == MethodName);
            uri = classAtt.URI;
            //List<KeyValue> modelthing = new List<KeyValue>();
            //KeyValuePair<string, string> defaultArg;
            string defaultArg = null;

            if (classAtt == null)
            {
                return null;
            }

            // Get the method-level attributes.

            // Get all methods in this class, and put them
            // in an array of System.Reflection.MemberInfo objects.
            FieldInfo[] MyMemberInfo = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            for (int i = 0; i < MyMemberInfo.Length; i++)
            {
                RoutlerFieldAttribute[] RoutlerFieldatt = (RoutlerFieldAttribute[])Attribute.GetCustomAttributes(MyMemberInfo[i], typeof(RoutlerFieldAttribute));
                var filteredAttributes = RoutlerFieldatt.Where(r => r.RoutlerClassName == classAtt.Name);
                if (filteredAttributes.Any())
                {
                    if (filteredAttributes.Count() > 1)
                    {
                        throw new Exception();
                    }

                    if (filteredAttributes.ElementAt(0).DefaultRoute)
                    {
                        if (defaultArg != null)
                        {
                            //Cannot have multiple default arguments.
                            throw new Exception();
                        }

                        defaultArg = MyMemberInfo[i].GetValue(o).ToString();
                    }
                    else
                    {
                        string name = filteredAttributes.ElementAt(0).ParameterName ?? MyMemberInfo[i].Name;
                        string value = MyMemberInfo[i].GetValue(o).ToString();
                        //modelthing.Add(new KeyValue(name, value));
                        urlBuilder.Append($"&{name}={value}");
                    }
                }
            }
            return  uri + "?" + defaultArg + urlBuilder.ToString();
        }
    }
}
