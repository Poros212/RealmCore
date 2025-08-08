using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.Logic
{
    public class Utils
    {
        // clone a obj with a parameterless constructor
        public static T Clone<T>(T obj) where T : new()
        {
            
            T newObj = new T();
            return newObj;
        }
    }
}
