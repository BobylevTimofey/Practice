namespace Practice.Services.AdditionalInfoServices.Sortings.TreeSort
{
    public class TreeNode<T>
        where T : IComparable
    {
        public TreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public TreeNode<T>? Left { get; set; }

        public TreeNode<T>? Right { get; set; }

        public void Insert(TreeNode<T> node)
        {
            if (node.Data.CompareTo(Data) < 0)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        public T[] Printout(List<T>? elements = null)
        {
            if (elements == null)
            {
                elements = new List<T>();
            }

            if (Left != null)
            {
                Left.Printout(elements);
            }

            elements.Add(Data);

            if (Right != null)
            {
                Right.Printout(elements);
            }

            return elements.ToArray();
        }
    }
}
