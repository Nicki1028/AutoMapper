using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class KeyVauleModel<SourceType, DestType>
    {
        public Dictionary<string, string> namemapping = new Dictionary<string, string>();

        public KeyVauleModel()
        {

        }
        

        public KeyVauleModel<SourceType, DestType> Formember<SourceProperty>(Expression<Func<SourceType, SourceProperty>> sourceProperty, Expression<Func<DestType, object>> destProperty)
        {
            var sourcePropInfo = GetPropertyInfo(sourceProperty);
            var destPropInfo = GetPropertyInfo(destProperty);

            namemapping[sourcePropInfo.Name] = destPropInfo.Name;

            return this;
        }
      

        private PropertyInfo GetPropertyInfo<T, TProperty>(Expression<Func<T, TProperty>> propertyLambda)
        {
            
            if (propertyLambda.Body is MemberExpression member)
            {
                if (member.Member is PropertyInfo propInfo)
                {
                    return propInfo;
                }
            }
            throw new ArgumentException("Lambda expression must be a property");
        }       
    }
}
