using System;

namespace NodeBinaryTree
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Binary tree");

			// BinaryTreeOnString ();
			BinaryTreeOnInt ();
		}

		private static void BinaryTreeOnInt()
		{
			BinaryTree<int> btree = new BinaryTree<int> ();

			int[] arrInt = {
				5, 8, 6, 6, 3, 7, 8, 2
			};

			for (int i = 0; i < arrInt.Length; i++) {
				btree.Add (arrInt [i]);
			}

			Console.Write (btree.ToString ());
			Console.WriteLine ();
			btree.Remove (7);

			Console.WriteLine ();
			Console.WriteLine (btree.ToString ());
		}

		private static void BinaryTreeOnString()
		{
			BinaryTree<string> btree = new BinaryTree<string> ();
			btree.Add ("String 1");
			btree.Add ("String 2");
			btree.Add ("Dat is");

			Console.Write (btree.ToString ());

		}
	}
}
