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

			// 3) If Found has two children
			if(found.left != null && found.right != null){

				// Intit vars
				Node<T> leftFound = found;
				Node<T> parentLeft;

				// 1) Go right once 
				leftFound = found.right; // Set to right one time

				// 2) Check if right has a left or not
				if (leftFound.left == null) {

					// Check if root or not
					if (found != _binaryTree) {
						if (found.left != null)
							leftFound.left = found.left;

						if (parent.left == found)
							parent.left = leftFound;
						else
							parent.right = leftFound;
					} else {
						// root node
						leftFound.left = found.left;
						_binaryTree = leftFound;

						found = null;
					}
					
					found = null;
					leftFound = null;

					return;
				} 
				else 
				{
					parentLeft = leftFound;

				// 3) Go all the way left till null >> last node
					while (true) 
					{
						if (leftFound.left == null)
							break;
						else {
							parentLeft = leftFound;
							leftFound = leftFound.left;
						}
					}

					// Replace parent.left with left
					if(leftFound.right != null)
						parentLeft.left = leftFound.right;
					else
						parentLeft.left = null;

				// 4) Swapping last part
					leftFound.left = found.left;
					leftFound.right = found.right;

					if (found != _binaryTree) {
						if (parent.left == found)
							parent.left = leftFound;
						else
							parent.right = leftFound;
					} else {
						_binaryTree = leftFound;
						return;
					}
				}
			}
		}

		// Node Comparer CompareTo Method >> Can be changed
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

		// TODO
		// Function for determine the middle value based on an array of objects
//		private T DetermineTheRootNode(T[] arrayObjects)
//		{
//			int GRANULARITY = (arrayObjects.Length < 5) ? 3 : 5;
//			// 5, 3, 8, 20, 1
//			int arrLength = Math.Round(arrayObjects.Length/GRANULARITY);
//
//			T obj = arrayObjects [0];
//
//			for (int i = 0; i < 5; i++) {
//				
//			}
//		}
	}
}

