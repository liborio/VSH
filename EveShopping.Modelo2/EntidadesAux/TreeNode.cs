using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo.EntidadesAux
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        public IList<TreeNode<T>> Descendants { get; set; }
        public TreeNode<T> Parent { get; set; }

        public TreeNode()
        {
            Descendants = new List<TreeNode<T>>();
        }
    }
}
