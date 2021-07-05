using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using HPCSharpLibrary;

namespace SortingAlgorithm_Visualized
{
	class Program
	{
		static List<int> indexOfNumberToChangeItsColor = new List<int>();
		static void Main(string[] args)
		{
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			int[] arr = {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
			Random rand = new Random();
			arr = arr.OrderBy(x => rand.Next()).ToArray();
			/*for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i].ToString() + " ");
			}
			Console.WriteLine();
			List<int> l = new List<int>();
			l.Add(1);
			l.Add(2);
			DrawBarChart(arr, ConsoleColor.Red, l, ConsoleColor.Yellow);*/
			InsertionSort_Visualized(arr);
		}
		public static void PrintArray(int[] numberArray)
		{
			foreach (int number in numberArray)
			{
				Console.Write(" " + number.ToString() + " ");
			}
		}
		public static void PrintArray(int[] numberArray, List<int> indexOfNumberToChangeItsColor)
		{
			for (int i = 0; i < numberArray.Length; i++)
			{
				foreach (int index in indexOfNumberToChangeItsColor)
				{
					if (i == index)
					{
						Console.ForegroundColor = ConsoleColor.Red;
					}
				}
				Console.Write(" " + numberArray[i].ToString() + " ");
				Console.ResetColor();
			}
		}
		public static void DrawBarChart(int[] numberArray, ConsoleColor barColor)
		{
			for (int i = 0; i < numberArray.Length; i++)
			{
				Console.BackgroundColor = barColor;
				for (int j = 0; j < numberArray[i]; j++)
				{
					Console.Write(" ");
				}
				Console.BackgroundColor = ConsoleColor.Black;
				Console.Write(" " + numberArray[i].ToString());
				Console.WriteLine('\n');
				Console.BackgroundColor = barColor;
			}
			Console.BackgroundColor = ConsoleColor.Black;
		}
		public static void DrawBarChart(int[] numberArray, ConsoleColor normalBarColor, 
			List<int> indexOfNumberToChangeItsColor, ConsoleColor highlightColor)
		{
			for (int i = 0; i < numberArray.Length; i++)
			{
				Console.BackgroundColor = normalBarColor;
				for (int k = 0; k < indexOfNumberToChangeItsColor.Count; k++)
				{
					if (indexOfNumberToChangeItsColor[k] == i)
					{
						Console.BackgroundColor = highlightColor;
						break;
					}
				}

				/* REMOVE THIS COMMENT IF YOU WANT TO HEAR THE SOUND OF SORTING 
				
				Console.Beep(300 * numberArray[i], 100);

				*/ 
				for (int j = 0; j < numberArray[i]; j++)
				{
					Console.Write(" ");
				}
				Console.BackgroundColor = ConsoleColor.Black;
				Console.Write(" " + numberArray[i].ToString());
				Console.WriteLine('\n');
				
				Console.BackgroundColor = normalBarColor;
			}
			Console.BackgroundColor = ConsoleColor.Black;
		}
		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}
		public static void ClearConsoleScreen()
		{
			int currentLineCursor = Console.CursorTop;
			for (int i = 0; i < currentLineCursor; i++)
			{
				Console.SetCursorPosition(0, i);
				Console.Write(new string(' ', Console.WindowWidth));
			}
			Console.SetCursorPosition(0, 0);
		}
		//CheckIfArraySorted(numberArray, ConsoleColor.Green, ConsoleColor.Red);

		public static void CheckIfArraySorted(int[] numberArray)
		{
			indexOfNumberToChangeItsColor.Clear();
			for (int i = 0; i < numberArray.Length - 1; i++)
			{
				if (numberArray[i] > numberArray[i + 1])
				{
					indexOfNumberToChangeItsColor.Add(i);
					indexOfNumberToChangeItsColor.Add(i + 1);
				}
			}
			DrawBarChart(numberArray, ConsoleColor.Green, indexOfNumberToChangeItsColor, ConsoleColor.Red);
		}
		public static void CheckIfArraySorted(int[] numberArray, ConsoleColor normalBarColor, ConsoleColor wrongBarColor)
		{
			bool isArraySorted = true;
			for (int i = 1; i < numberArray.Length; i++)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				if (numberArray[i]<numberArray[i-1])
				{
					isArraySorted = false;
					Console.BackgroundColor = wrongBarColor;
					for (int j = 0; j < numberArray[i]; j++)
					{
						Console.Write(" ");
					}
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write(" " + numberArray[i].ToString());
					Console.WriteLine('\n');
				}
				else
				{
					Console.BackgroundColor = normalBarColor;
					for (int j = 0; j < numberArray[i]; j++)
					{
						Console.Write(" ");
					}
					Console.BackgroundColor = ConsoleColor.Black;
					Console.Write(" " + numberArray[i].ToString());
					Console.WriteLine('\n');
				}
				Thread.Sleep(100);
			}
			if (isArraySorted)
			{
				Console.WriteLine("\n\nArray Sorted.");
			}
			else
			{
				Console.WriteLine("\n\nArray NOT Sorted!");

			}
		}
		#region Bubble Sort
		private static void BubbleSort_Visualized(int[] numberArray)
		{
			bool isThereAnySwap = false;
			do
			{
				isThereAnySwap = false;
				for (int i = 0; i < numberArray.Length - 1; i++)

				{
					if (numberArray[i] > numberArray[i + 1])
					{
						Utility.SwapTwoNumbers(ref numberArray[i], ref numberArray[i + 1]);
						isThereAnySwap = true;

						/* VISUALIZED */
						indexOfNumberToChangeItsColor.Add(i);
						indexOfNumberToChangeItsColor.Add(i + 1);
						DrawBarChart(numberArray, ConsoleColor.Red, 
							indexOfNumberToChangeItsColor, ConsoleColor.Yellow);
						Thread.Sleep(500);
						indexOfNumberToChangeItsColor.Clear();
						ClearConsoleScreen();
						/* ********* */
					}
				}
			} while (isThereAnySwap);
			DrawBarChart(numberArray, ConsoleColor.Green);
			Console.WriteLine("\nSorted.");
		}
		#endregion
		#region Insertion Sort Visualized
		private static void InsertionSort_Visualized(int[] numberArray)
		{
			for (int i = 1; i < numberArray.Length; i++)
			{
				for (int j = i; j > 0; j--)
				{
					if (numberArray[j - 1] <= numberArray[j])
					{
						List<int> indexOfNumberToChangeItsColor = new List<int>(1) { j };
						DrawBarChart(numberArray, ConsoleColor.White, indexOfNumberToChangeItsColor, ConsoleColor.Green);
						Thread.Sleep(300);
						indexOfNumberToChangeItsColor.Clear();
						ClearConsoleScreen();
						break;
					}
					else
					{
						Utility.SwapTwoNumbers(ref numberArray[j - 1], ref numberArray[j]);
						List<int> indexOfNumberToChangeItsColor = new List<int>(1) { j - 1 };
						DrawBarChart(numberArray, ConsoleColor.White, indexOfNumberToChangeItsColor, ConsoleColor.Green);
						Thread.Sleep(300);
						indexOfNumberToChangeItsColor.Clear();
						ClearConsoleScreen();
					}
				}
			}
			CheckIfArraySorted(numberArray, ConsoleColor.Green, ConsoleColor.Red);
		}
		#endregion
	}
}
