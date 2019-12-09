using System;

namespace NodeBinaryTree
{
	public class Node<T>
	{
		public Node<T> left { get; set; }
		public Node<T> right { get; set; }
		public T NodeObject { get; set; }
	}
}