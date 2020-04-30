using ChessMoves;
using ChessMVC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Tests
{
	[TestClass]
	public class Tests_Chess
	{
		[TestMethod]
		public void Test_001()
		{
			//Model
			//View
			//Controller

			//var moves = new List<string>();

			//var game = new Chess();// another object
			
			//var board = new Board();
			//var printer = new BoardPrinter();

			//foreach (var move in moves)
			//{
			//	game.Apply(move, board);//representing the chess board; apply method to the board as a parameter; the method can be somewhere else.

			//	printer.Show(board);
			//}

		}
		[TestMethod]
		public void Test_002()
		{
			//Model
			//View
			//Controller

			var moves = new List<string>()
			{
				//white, Black - COLLECTION OF STRINGS TO REPRESENT MOVES
				"G1F3","G8F6",
				"C2C4","G7G6",
				"B1C3","F8G7",
				"D1D4","E8G8",//CASTLE
				"C1C4","D7D5",
				"D1B3","D5C4",//CAPTURE
				"B3C4",//CAPTURE

			};

			var game = new Chess();// refer to class library- view

			var board = new Board();// refer to class library -model
			var printer = new BoardPrinter();//printing to the console

			//board.Move += (moves) => Debug.WriteLine("");//we want an event and I have to declare that myself.
			
			//game.Result += (result) => Debug.WriteLine("");
			//game.Capture += (piece, position) => Debug.WriteLine("");

			foreach (var move in moves)
			{
				game.Apply(move, board);//representing the chess board; apply method to the board as a parameter; the method can be somewhere else.

				printer.Show(board);
			}

		}
		[TestMethod]
		public void Test_003()
		{
			var moves = new List<string>()
			{
				//white, Black - COLLECTION OF STRINGS TO REPRESENT MOVES
				"G1F3","G8F6",
				"C2C4","G7G6",
				"B1C3","F8G7",
				"D1D4","E8G8",//CASTLE
				"C1C4","D7D5",
				"D1B3","D5C4",//CAPTURE
				"B3C4",//CAPTURE
			};
			ChessMove result = null;

			//will keep track of the moves and progress of game and be move-centric
			var gameMoves = new List<ChessMove>();
			foreach(var move in moves)
			{
				if(ChessMove.Try(move, ref result))
				{
					gameMoves.Add(result);
				}
				else
				{
					break;
				}
			}
		}

		private class BoardPrinter
		{
			internal void Show(Board board)
			{
				for (int c=1; c <= 8; c++)
				{
					for(int r=1; r<=8; r++)
					{
						Debug.Write($"[{board[c, r]?.ToString() ?? " "}]"); 
					}
					Debug.WriteLine(string.Empty);
				}
				Debug.WriteLine(string.Empty.PadRight(8*3,'-')); 
			}
		}
	}
}
