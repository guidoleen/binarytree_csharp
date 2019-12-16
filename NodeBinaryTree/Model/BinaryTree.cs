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

			// 1) If Found has no children
			if (found.left == null && found.right == null) {

				Console.Write (parent.NodeObject.ToString ());
				if(parent.left == found)
					parent.left = null;
				else
					parent.right = null;

				return; // where done
			}

			// 2) If Found has one child
			if (found.left == null && found.right != null){
				if (parent.left == found)
					parent.left = found.right;
				else
					parent.right = found.right;
				return; // where done
			}
			if(found.left != null && found.right == null) {
				if (parent.left == found)
					parent.left = found.left;
				else
					parent.right = found.left;
				return; // where done
			}

			// TODO
			// 3) If Found has two children
			if(found.left != null && found.right != null){

				// Intit vars
				Node<T> left = found;
				Node<T> parentLeft;

				// 1) Go right once 
				parentLeft = left;
				left = found.right; // Set to right

				// 2) Go all the way left till null >> last node
				while (left != null) {
					parentLeft = left;
					left = left.left;
				}

				// 3) Swapping 
				// First check if found is root so there's no parent
				if (found != _binaryTree) {
					// Replace parent.left with left
					if(left.right != null)
						parentLeft.left = left.right;
					else
						parentLeft.left = null;
				}

				// Swap it
				left.right = found.right;
				left.left = found.left;
			}
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
			parent = current;

			while (current != null) {
				iComparer = this.NodeCompareOnValue (current, obj);

				// Go Left
				if (iComparer == 1) {
					// First set parent
					parent = current;
					current = current.left;
				}

				// Go Right
				if (iComparer == -1) {
					// First set parent
					parent = current;
					current = current.right;
				}

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
			this._binaryTreeResult = null;

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

