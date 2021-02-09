using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eberon___Design_Patternd
{
    public interface IStrategy
    {
        void RenderWorld(object data, object cw);
    }
}
