/* 
 * SortingAlgorithm_Visualized
 * 
 * Purpose: to visualize some common sorting algorithm using console screen
 * 
 * Author: Huy Pham
 * 
 * How to run this code: you can either run the executable (.exe) 
 *		or open with Visual Studio and run in debug mode
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
/* REMOVE AFTER FINISH */
using HPCSharpLibrary;
/* REMOVE AFTER FINISH */

namespace SortingAlgorithm_Visualized
{
	class Program
	{
		// store the list of index to change the bar colors at that index
		static List<int> indexOfNumberToChangeItsColor = new List<int>();
		static void Main(string[] args)
		{
			// make console in full screen
			Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
			PrintLogo();
			Thread.Sleep(5000);
			int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

			// shuffle the list
			Random rand = new Random();
			arr = arr.OrderBy(x => rand.Next()).ToArray();
			/*
			Console.WriteLine("\t--- BUBBLE SORT ---");
			Console.WriteLine("Swap two numbers if they are in wrong order. The greatest number tends to 'bubble' to the end");
			Thread.Sleep(5000);
			Console.Clear();
			BubbleSort_Visualized(arr);
			Thread.Sleep(3000);
			Console.Clear();
			// shuffle the list
			arr = arr.OrderBy(x => rand.Next()).ToArray();

			Console.WriteLine("\t--- SELECTION SORT ---");
			Console.WriteLine("Find the minimum value and put it at the beginning.");
			Thread.Sleep(5000);
			Console.Clear();
			SelectionSort_Visualized(arr);
			Thread.Sleep(3000);
			Console.Clear();
			// shuffle the list
			arr = arr.OrderBy(x => rand.Next()).ToArray();

			Console.WriteLine("\t--- INSERTION SORT ---");
			Console.WriteLine("Like sorting your cards. Pick a number and put it at the right place.");
			Thread.Sleep(5000);
			Console.Clear();
			InsertionSort_Visualized(arr);
			Thread.Sleep(3000);
			Console.Clear();
			// shuffle the list
			arr = arr.OrderBy(x => rand.Next()).ToArray();

			*/Console.WriteLine("\t--- COCKTAIL SHAKER SORT ---");
			Console.WriteLine("BUBBLE SORT IN TWO DIRECTIONS");
			Thread.Sleep(5000);
			Console.Clear();
			CocktailShakerSort_Visualized(arr);
			Thread.Sleep(3000);
			Console.Clear();
			// shuffle the list
			arr = arr.OrderBy(x => rand.Next()).ToArray();/*

			Console.WriteLine("\t--- QUICK SORT ---");
			Console.WriteLine("Pick a pivot, all the numbers greater than the pivot should be moved to the right hand side, " +
				"the numbers less than the pivot should be moved to the left. Repeat");
			Thread.Sleep(5000);
			Console.Clear();
			QuickSort_Visualized(arr);
			Thread.Sleep(3000);
			Console.Clear();
			// shuffle the list
			arr = arr.OrderBy(x => rand.Next()).ToArray();

			/* FORMAT - REMOVE WHEN FINISH 
			Console.WriteLine("\t--- ... SORT ---");
			Console.WriteLine("DESCRIPTION");
			Thread.Sleep(5000);
			Console.Clear();
			InsertionSort_Visualized(arr);
			Thread.Sleep(3000);
			Console.Clear();
			// shuffle the list
			arr = arr.OrderBy(x => rand.Next()).ToArray();
			 FORMAT - REMOVE WHEN FINISH */

		}
		#region Print Logo
		/// <summary>
		/// Print the logo: "Visualized Sorting Algorithm"
		/// </summary>
		private static void PrintLogo()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(@"__      ___                 _ _             _");
			Console.WriteLine(@"\ \    / (_)               | (_)           | |");
			Console.WriteLine(@" \ \  / / _ ___ _   _  __ _| |_ _______  __| |");
			Console.WriteLine(@"  \ \/ / | / __| | | |/ _` | | |_  / _ \/ _` |");
			Console.WriteLine(@"   \  /  | \__ \ |_| | (_| | | |/ /  __/ (_| |");
			Console.WriteLine(@"    \/   |_|___/\__,_|\__,_|_|_/___\___|\__,_|");
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(@"");
			Console.WriteLine(@"  _____            _   _                        _                  _ _   _");
			Console.WriteLine(@" / ____|          | | (_)                 /\   | |                (_) | | |");
			Console.WriteLine(@"| (___   ___  _ __| |_ _ _ __   __ _     /  \  | | __ _  ___  _ __ _| |_| |__  _ __ ___  ___");
			Console.WriteLine(@" \___ \ / _ \| '__| __| | '_ \ / _` |   / /\ \ | |/ _` |/ _ \| '__| | __| '_ \| '_ ` _ \/ __|");
			Console.WriteLine(@" ____) | (_) | |  | |_| | | | | (_| |  / ____ \| | (_| | (_) | |  | | |_| | | | | | | | \__ \");
			Console.WriteLine(@"|_____/ \___/|_|   \__|_|_| |_|\__, | /_/    \_\_|\__, |\___/|_|  |_|\__|_| |_|_| |_| |_|___/");
			Console.WriteLine(@"                                __/ |              __/ |");
			Console.WriteLine(@"			       |___/              |___/");
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("\n\n-by Huy Pham");
			Console.ResetColor();
		}
		#endregion
		#region Draw Bar Chart
		/// <summary>
		/// Draw a bar chart vertically, all bar in one specified color
		/// </summary>
		/// <param name="numberArray"></param>
		/// <param name="barColor">The color of all bars</param>
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
		/// <summary>
		/// Draw a bar chart vertically, specified bars in "highlight" color, other bars in normal color
		/// </summary>
		/// <param name="numberArray"></param>
		/// <param name="normalBarColor"></param>
		/// <param name="indexOfNumberToChangeItsColor">Index of numbers to be in highlight color</param>
		/// <param name="highlightColor"></param>
		public static void DrawBarChart(int[] numberArray, ConsoleColor normalBarColor,
			List<int> indexOfNumbersToChangeItsColor, ConsoleColor highlightColor)
		{
			for (int i = 0; i < numberArray.Length; i++)
			{
				Console.BackgroundColor = normalBarColor;
				for (int k = 0; k < indexOfNumbersToChangeItsColor.Count; k++)
				{
					if (indexOfNumbersToChangeItsColor[k] == i)
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
		/// <summary>
		/// Draw a bar chart vertically, ONLY ONE bar in "highlight" color, other bars in normal color
		/// </summary>
		/// <param name="numberArray"></param>
		/// <param name="normalBarColor"></param>
		/// <param name="indexOfNumberToChangeItsColor">The index of number to be in highlight color</param>
		/// <param name="highlightColor"></param>
		public static void DrawBarChart(int[] numberArray, ConsoleColor normalBarColor,
			int indexOfNumberToChangeItsColor, ConsoleColor highlightColor)
		{
			for (int i = 0; i < numberArray.Length; i++)
			{
				Console.BackgroundColor = normalBarColor;
				if (indexOfNumberToChangeItsColor == i)
				{
					Console.BackgroundColor = highlightColor;
				}
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
		#endregion
		/// <summary>
		/// Clear the console line where the cursor is on
		/// </summary>
		public static void ClearCurrentConsoleLine()
		{
			int currentLineCursor = Console.CursorTop;
			Console.SetCursorPosition(0, Console.CursorTop);
			Console.Write(new string(' ', Console.WindowWidth));
			Console.SetCursorPosition(0, currentLineCursor);
		}
		/// <summary>
		/// Clear the entire console screen, same as Console.Clear() but no lags occur
		/// </summary>
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

		/// <summary>
		/// Check whether the array is in ascending order
		/// </summary>
		/// <param name="numberArray"></param>
		public static void CheckIfArraySorted(int[] numberArray)
		{
			ClearConsoleScreen();
			bool isArraySorted = true;
			indexOfNumberToChangeItsColor.Clear();
			for (int i = 0; i < numberArray.Length - 1; i++)
			{
				if (numberArray[i] > numberArray[i + 1])
				{
					indexOfNumberToChangeItsColor.Add(i);
					indexOfNumberToChangeItsColor.Add(i + 1);
					isArraySorted = false;
				}
			}
			DrawBarChart(numberArray, ConsoleColor.Green, indexOfNumberToChangeItsColor, ConsoleColor.Red);
			if (isArraySorted)
			{ 
				Console.WriteLine("\nArray is sorted in ascending order."); 
			}
			else
			{
				Console.WriteLine("\nArray is NOT sorted!");
			}
		}
		/// <summary>
		/// Check whether the array is in ascending order, numbers in wrong order in "wrongBarColor" color
		/// </summary>
		/// <param name="numberArray"></param>
		/// <param name="normalBarColor"></param>
		/// <param name="wrongBarColor"></param>
		public static void CheckIfArraySorted(int[] numberArray, ConsoleColor normalBarColor, ConsoleColor wrongBarColor)
		{
			ClearConsoleScreen();
			bool isArraySorted = true;
			for (int i = 1; i < numberArray.Length; i++)
			{
				Console.BackgroundColor = ConsoleColor.Black;
				if (numberArray[i] < numberArray[i - 1])
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
						Thread.Sleep(400);
						indexOfNumberToChangeItsColor.Clear();
						ClearConsoleScreen();
						/* ********* */
					}
				}
			} while (isThereAnySwap);
			CheckIfArraySorted(numberArray);
		}
		#endregion
		#region Selection Sort
		public static void SelectionSort_Visualized(int[] numberArray)
		{
			int minValue;
			int minIndex = 0;
			for (int i = 0; i < numberArray.Length; i++)
			{
				minValue = numberArray[i];
				DrawBarChart(numberArray, ConsoleColor.White, i, ConsoleColor.Red);
				Thread.Sleep(200);
				ClearConsoleScreen();
				for (int j = i; j < numberArray.Length; j++)
				{
					if (numberArray[j] < minValue)
					{
						minValue = numberArray[j];
						minIndex = j;
						DrawBarChart(numberArray, ConsoleColor.White, minIndex, ConsoleColor.Red);
						Thread.Sleep(200);
						ClearConsoleScreen();
					}
				}
				if (minValue != numberArray[i])
				{
					Utility.SwapTwoNumbers(ref numberArray[i], ref numberArray[minIndex]);
				}
				DrawBarChart(numberArray, ConsoleColor.White, minIndex, ConsoleColor.Red);
				Thread.Sleep(200);
				ClearConsoleScreen();
			}
			CheckIfArraySorted(numberArray);
		}
		#endregion
		#region Insertion Sort
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
			CheckIfArraySorted(numberArray);
		}
		#endregion
		#region Cocktail Shaker Sort
		public static void CocktailShakerSort_Visualized(int[] numberArray)
		{
			bool isThereAnySwaps;
			int i;
			do
			{
				isThereAnySwaps = false;
				for (i = 0; i < numberArray.Length - 1; i++)
				{
					if (numberArray[i] > numberArray[i + 1])
					{
						Utility.SwapTwoNumbers(ref numberArray[i], ref numberArray[i + 1]);

						/* VISUALIZED */
						ClearConsoleScreen();
						DrawBarChart(numberArray, ConsoleColor.White, new List<int>() { i, i + 1 }, ConsoleColor.Green);
						Thread.Sleep(400);

						isThereAnySwaps = true;
					}
				}
				for (i = numberArray.Length - 1; i > 0; i--)
				{
					if (numberArray[i - 1] > numberArray[i])
					{
						Utility.SwapTwoNumbers(ref numberArray[i], ref numberArray[i - 1]);

						/* VISUALIZED */
						ClearConsoleScreen();
						DrawBarChart(numberArray, ConsoleColor.White, new List<int>() { i, i + 1 }, ConsoleColor.Red);
						Thread.Sleep(400);

						isThereAnySwaps = true;
					}
				}
			} while (isThereAnySwaps);
			CheckIfArraySorted(numberArray);
		}
		#endregion
		#region Quick Sort
		/// <summary>
		/// Sort the given number arry using Quick Sort algorithm
		/// </summary>
		/// <param name="numberArray"></param>
		/// <returns></returns>
		public static void QuickSort_Visualized(int[] numberArray)
		{
			QuickSort(numberArray, 0, numberArray.Length - 1);
			CheckIfArraySorted(numberArray);
		}
		/// <summary>
		/// This method is for the recursion of quick sort method
		/// </summary>
		/// <param name="numberArray"></param>
		/// <param name="low">Index of the first element of an array</param>
		/// <param name="high">Index of the last element of an array</param>
		public static void QuickSort(int[] numberArray, int low, int high)
		{
			if (low >= high)
			{
				return;
			}
			int pivot = numberArray[(low + high) / 2];
			int partitionIndex = Partition(numberArray, low, high, pivot);
			QuickSort(numberArray, low, partitionIndex - 1);
			QuickSort(numberArray, partitionIndex, high);
		}
		/// <summary>
		/// Find the partition index
		/// </summary>
		/// <param name="numberArray"></param>
		/// <param name="low">Index of the first element of an array</param>
		/// <param name="high">Index of the last element of an array</param>
		/// <param name="pivot">Value of chosen pivot</param>
		/// <returns></returns>
		public static int Partition(int[] numberArray, int low, int high, int pivot)
		{
			List<int> listOfIndexToChangeItsColor = new List<int>();
			for (int i = low; i < high; i++)
			{
				listOfIndexToChangeItsColor.Add(i);
			}

			while (low <= high)
			{
				while (numberArray[low] < pivot)
				{
					low++;
				}
				while (numberArray[high] > pivot)
				{
					high--;
				}
				if (low <= high)
				{
					Utility.SwapTwoNumbers(ref numberArray[low], ref numberArray[high]);
					low++;
					high--;
				}
			}
			ClearConsoleScreen();
			DrawBarChart(numberArray, ConsoleColor.White, listOfIndexToChangeItsColor, ConsoleColor.Red);
			Thread.Sleep(300);
			return low;
		}
		#endregion

	}
}
