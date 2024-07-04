using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    internal class Mapper
    {
        

        public static Destination Map<Source,  Destination>(Source source, Func<KeyVauleModel<Source, Destination>, KeyVauleModel<Source, Destination>> func = null) where Destination : new()
        {
            Destination destination = new Destination();
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();
            foreach ( var property in sourceProperties )
            {
                var sourcepropertyname = property.Name.Replace("_","").ToLower();
                var desproperty = destinationProperties.FirstOrDefault(dp => dp.Name.Replace("_","").ToLower() == sourcepropertyname);
                if (desproperty != null)
                {
                    if (property.PropertyType != desproperty.PropertyType)
                    {
                        var convertValue = Convert.ChangeType(property.GetValue(source), desproperty.PropertyType);
                        desproperty.SetValue(destination, convertValue);                       
                    }
                    else
                    {
                        var Value = property.GetValue(source);
                        desproperty.SetValue(destination, Value);
                    }                   
                }                                                                     
            }

            
            if ( func != null )
            {
                KeyVauleModel<Source, Destination> result = func.Invoke(new KeyVauleModel<Source, Destination>());
                foreach (var map in result.namemapping)
                {
                    if (destination.GetType().GetProperty(map.Value).PropertyType != source.GetType().GetProperty(map.Key).PropertyType)
                    {
                        var covert = Convert.ChangeType(source.GetType().GetProperty(map.Key).GetValue(source), destination.GetType().GetProperty(map.Value).PropertyType);
                        destination.GetType().GetProperty(map.Value).SetValue(destination, covert);
                    }
                    else
                    {
                        destination.GetType().GetProperty(map.Value).SetValue(destination, source.GetType().GetProperty(map.Key).GetValue(source));
                    }
                    
                }

            }
            return destination;
        }

    }
}
