using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BAUERGROUP.Shared.Core.Configuration
{
    public sealed class ConfigurationConverter : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            var cleanAssemblyName = assemblyName;
            var cleanTypeName = typeName;

            //Sample Assembly Name: BAUERGROUP.bgShippingManager.Application, Version=1.25.6183.13447, Culture=neutral, PublicKeyToken=8aa9b91ff6f9b054
            //Remove Version Information & PublicKeyToken from Assemby Name
            if (assemblyName.StartsWith("BAUERGROUP."))
            {
                var startRemove = assemblyName.IndexOf(", Version");
                var endRemove = assemblyName.IndexOf(", Culture");

                //Remove Version
                if ((startRemove > 0) || (endRemove > 0))
                {
                    var removeableString = assemblyName.Substring(startRemove, endRemove - startRemove);
                    cleanAssemblyName = assemblyName.Replace(removeableString, "");
                }

                //Remove PublicKeyToken
                var tokenStart = cleanAssemblyName.IndexOf(", PublicKeyToken");
                cleanAssemblyName = cleanAssemblyName.Remove(tokenStart);
            }

            //Sample Type Name: System.Collections.Generic.Dictionary`2[[BAUERGROUP.Shared.Shipping.ShippingRuleControllerConfigurationItemKey, BAUERGROUP.Shared.Shipping, Version=1.0.6183.13442, Culture=neutral, PublicKeyToken=0d37b4f7da07fa4d],[BAUERGROUP.Shared.Shipping.ShippingRuleControllerConfigurationItemValue, BAUERGROUP.Shared.Shipping, Version=1.0.6183.13442, Culture=neutral, PublicKeyToken=0d37b4f7da07fa4d]]
            //Rewrite Namespace
            if (typeName.Contains("BAUERGROUP."))
            {
                var startRemoveType = typeName.IndexOf(", Version");
                var endRemoveType = typeName.IndexOf(", Culture");

                if ((startRemoveType > 0) || (endRemoveType > 0))
                {
                    var removeableString = typeName.Substring(startRemoveType, endRemoveType - startRemoveType);
                    cleanTypeName = typeName.Replace(removeableString, "");
                }
            }

            return Type.GetType(String.Format("{0}, {1}", cleanTypeName, cleanAssemblyName))!;
        }
    }
}
