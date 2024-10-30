using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Responses.Messages
{
    public enum ResponseMessages
    {
        [Description("Error: Invalid operation.")]
        INVALID_OPERATION,
        [Description("Success: Valid operation.")]
        VALID_OPERATION,
        [Description("Error: Course not found.")]
        COURSE_NOT_FOUND,
        [Description("Error: The course cannot be deleted because it has registered modules.")]
        COURSE_CANNOT_BE_DELETED
    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field != null)
            {
                DescriptionAttribute attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));

                if (attribute != null)
                    return attribute.Description;
            }

            return value.ToString();
        }
    }
}
