using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENB.PharmaciesAndPrescriptions.Entities
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OwnerAttribute: Attribute
    {

    }
}
