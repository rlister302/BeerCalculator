using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Abstract
{
    public abstract class ModelBase
    {
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class ControllerAttribute : Attribute
        {
            public readonly string Name;

            public ControllerAttribute(string name)
            {
                Name = name;
            }
        }

        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        protected sealed class PrimaryKeyAttribute : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class GetAllActionAttribute : Attribute
        {
            public readonly string Name;

            public GetAllActionAttribute(string name)
            {
                Name = name;
            }
        }
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class GetDetailsActionAttribute : Attribute
        {
            public readonly string Name;

            public GetDetailsActionAttribute(string name)
            {
                Name = name;
            }
        }
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class CreateActionAttribute : Attribute
        {
            public readonly string Name;

            public CreateActionAttribute(string name)
            {
                Name = name;
            }
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class UpdateActionAttribute : Attribute
        {
            public readonly string Name;

            public UpdateActionAttribute(string name)
            {
                Name = name;
            }
        }

        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
        protected sealed class DeleteActionAttribute : Attribute
        {
            public readonly string Name;

            public DeleteActionAttribute(string name)
            {
                Name = name;
            }
        }

        public string GetControllerName()
        {
            if (Attribute.IsDefined(GetType(), typeof(ControllerAttribute)))
            {
                var controllerName = (ControllerAttribute)Attribute.GetCustomAttribute(GetType(), typeof(ControllerAttribute));
                return controllerName.Name;
            }

            return "";
        }

        public string GetAllActionName()
        {
            if (Attribute.IsDefined(GetType(), typeof(GetAllActionAttribute)))
            {
                var action = (GetAllActionAttribute)Attribute.GetCustomAttribute(GetType(), typeof(GetAllActionAttribute));
                return action.Name;
            }

            return "";
        }

        public string GetDetailsAction()
        {
            if (Attribute.IsDefined(GetType(), typeof(GetDetailsActionAttribute)))
            {
                var action = (GetDetailsActionAttribute)Attribute.GetCustomAttribute(GetType(), typeof(GetDetailsActionAttribute));
                return action.Name;
            }

            return "";
        }

        public string GetCreateAction()
        {
            if (Attribute.IsDefined(GetType(), typeof(CreateActionAttribute)))
            {
                var action = (CreateActionAttribute)Attribute.GetCustomAttribute(GetType(), typeof(CreateActionAttribute));
                return action.Name;
            }

            return "";
        }

        public string GetUpdateAction()
        {
            if (Attribute.IsDefined(GetType(), typeof(UpdateActionAttribute)))
            {
                var action = (UpdateActionAttribute)Attribute.GetCustomAttribute(GetType(), typeof(UpdateActionAttribute));
                return action.Name;
            }

            return "";
        }

        public string GetDeleteAction()
        {
            if (Attribute.IsDefined(GetType(), typeof(DeleteActionAttribute)))
            {
                var action = (DeleteActionAttribute)Attribute.GetCustomAttribute(GetType(), typeof(DeleteActionAttribute));
                return action.Name;
            }

            return "";
        }

        public int GetPrimaryKeyValue()
        {
            foreach (var property in GetType().GetProperties())
            {
                if (IsPrimaryKey(property.Name))
                {
                    var value = GetType().GetProperty(property.Name).GetValue(this);
                    return (int)value;
                }
            }

            return -1;
        }

        public bool IsPrimaryKey(string propertyName)
        {
            return Attribute.IsDefined(GetPropertyInfo(propertyName), typeof(PrimaryKeyAttribute));
        }

        public PropertyInfo GetPropertyInfo(string propertyName)
        {
            var property = GetType().GetProperty(propertyName);
            return property;
        }
    }
}
