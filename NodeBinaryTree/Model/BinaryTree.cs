using System;

namespace NodeBinaryTree
{
	public class BinaryTree<T>
	{
		private Node<T> _binaryTree; // root Node
		public int Length { get; set; }
		private string _binaryTreeResult;
		private int iComparer = 0;

		public void Add(T obj)
		{
			if (_binaryTree == null) 
			{
				this._binaryTree = new Node<T> ();
				this._binaryTree.NodeObject = obj;

				Length = 1;
				return;
			}

			Node<T> current = this._binaryTree;
			Node<T> newNode =  new Node<T> ();

			while (current != null) 
			{
				iComparer = this.NodeCompareOnValue (current, obj);
				if (iComparer == 1 || iComparer == 0 ) // Go left
				{ 
					if (current.left == null) {
						current.left = newNode;
						newNode.NodeObject = obj;
						Length++;
						return;
					}
					current = current.left;
				}

				if (iComparer == -1) // Go Right
				{ 
					if (current.right == null) {
						current.right = newNode;
						newNode.NodeObject = obj;
						Length++;
						return;
					}
					current = current.right;
				}
			}
		}

		public void Remove(T obj)
		{
			// First find Node in tree
			Node<T> parent;
			Node<T> found = this.FindNodeinTree(obj, out parent);
			if (found == null)
				return;

			// TODO
			Console.Write(found.NodeObject.ToString());

		}

		// Node Comparer CompareTo Method
		private int NodeCompareOnValue(Node<T> current, T obj)
		{
			return current.NodeObject.ToString ().CompareTo (obj.ToString ());
		}

		// Node finder for Removal or finding
		private Node<T> FindNodeinTree(T obj, out Node<T> parent)
		{
			Node<T> current = this._binaryTree;

			while (current != null) {
				iComparer = this.NodeCompareOnValue (current, obj);

				// First set parent
				parent = current;

				// Go Left
				if (iComparer == 1)
					current = current.left;

				// Go Right
				if (iComparer == -1)
					current = current.right;

				// Found
				if (iComparer == 0) {
					return current;
				}
			}
			// Not found
			parent = null;
			return null;
		}

		public override string ToString ()
		{
			GetDataFromBinaryTree (this._binaryTree);
			return string.Format ( this._binaryTreeResult );
		}

		// SortFunction with recurrence
		private void GetDataFromBinaryTree(Node<T> node)
		{
			if (node == null) {
				return;
			}

			GetDataFromBinaryTree(node.right);
				_binaryTreeResult += node.NodeObject.ToString ();
			GetDataFromBinaryTree(node.left);
		}
	}
}

