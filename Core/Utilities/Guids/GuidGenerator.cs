using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Guids
{
    public class GuidGenerator
    {
        public string Generator()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
    }
}
