using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trees
{
    public interface INode<T>
    {
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        T Item { get; set; }
    }
}
