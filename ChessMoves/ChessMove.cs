using System;

namespace ChessMoves
{
	public class ChessMove
	{
		public enum ChessPieces
		{
			None,
			White_King, White_Queen, White_Bishop, White_Knight, White_Rook, White_Pawn,
			Black_King, Black_Queen, Black_Bishop, Black_Knight, Black_Rook, Black_Pawn
		}
		public static ChessPieces[,] InitialBoard = new ChessPieces[8, 8]
		{
			{ ChessPieces.White_Rook,  ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_Rook },
			{ ChessPieces.White_Knight, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_Knight },
			{ ChessPieces.White_Bishop, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_Bishop },
			{ ChessPieces.White_Queen, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn,  ChessPieces.Black_Queen },
			{ ChessPieces.White_King, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_King },
			{ ChessPieces.White_Bishop, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_Bishop },
			{ ChessPieces.White_Knight, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_Knight },
			{ ChessPieces.White_Rook, ChessPieces.White_Pawn, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.None, ChessPieces.Black_Pawn, ChessPieces.Black_Rook }
		};

		public static bool Try(string move, ref ChessMove result)
		{
			//Will need validation
			//var boardBefore = (ChessPieces[,])(result == null ? InitialBoard.Clone() : result.After.Clone());
			//var boardAfter = (ChessPieces[,])(result == null ? InitialBoard.Clone() : result.After.Clone());
			var beforeBoard = (ChessPieces[,])(result == null ? InitialBoard.Clone() : result.After.Clone());
			var afterBoard = (ChessPieces[,])(result == null ? InitialBoard.Clone() : result.After.Clone());
			var start = move.Substring(0, 2);
			var dest = move.Substring(2, 2);
			//Keep track of how the board looks before and after.
			afterBoard[dest[0] - 65, dest[1] - 49] = afterBoard[start[0] - 65, start[1] - 49];
			afterBoard[start[0] - 65, start[1] - 49] = ChessPieces.None;


			//result variable is ref
			var next = new ChessMove()
			{
				Move = move,
				MoveNumber = result?.MoveNumber + 1 ?? 1,
				Before = beforeBoard,
				After = afterBoard,
				CapturedPiece = beforeBoard[dest[0] - 65, dest[1] - 49]


			};
			result = next;
			return true;

		}//lets create properties for chess move type
		public string Move { get; set; }
		public string Origin { get => Move.Substring(0, 2); }
		public string Destination { get => Move.Substring(2, 2); }
		public uint MoveNumber { get; set; }
		public ChessPieces[,] Before { get; set; }
		public ChessPieces[,] After { get; set; }
		public bool Capture { get => CapturedPiece != ChessPieces.None; }
		public ChessPieces CapturedPiece { get; set; }



	}
}
