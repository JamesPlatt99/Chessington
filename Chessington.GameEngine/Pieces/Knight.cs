using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            if (currentSquare.Row + 2 < Board.BoardSize && currentSquare.Col - 1 >= 0)
            {
                availableMoves.Add(new Square(currentSquare.Row + 2, currentSquare.Col - 1));
            }
            if (currentSquare.Row + 2 < Board.BoardSize && currentSquare.Col + 1 < Board.BoardSize)
            {
                availableMoves.Add(new Square(currentSquare.Row + 2, currentSquare.Col + 1));
            }
            if (currentSquare.Row - 2 >= 0 && currentSquare.Col - 1 >= 0)
            {
                availableMoves.Add(new Square(currentSquare.Row - 2, currentSquare.Col - 1));
            }
            if (currentSquare.Row - 2 >= 0 && currentSquare.Col + 1 < Board.BoardSize)
            {
                availableMoves.Add(new Square(currentSquare.Row - 2, currentSquare.Col + 1));
            }
            if (currentSquare.Row + 1 < Board.BoardSize && currentSquare.Col - 2 >= 0)
            {
                availableMoves.Add(new Square(currentSquare.Row + 1, currentSquare.Col - 2));
            }
            if (currentSquare.Row - 1 >= 0 && currentSquare.Col - 2 >= 0)
            {
                availableMoves.Add(new Square(currentSquare.Row - 1, currentSquare.Col - 2));
            }
            if (currentSquare.Row - 1 >= 0 && currentSquare.Col + 2 < Board.BoardSize)
            {
                availableMoves.Add(new Square(currentSquare.Row - 1, currentSquare.Col + 2));
            }
            if (currentSquare.Row + 1 < Board.BoardSize && currentSquare.Col + 2 < Board.BoardSize)
            {
                availableMoves.Add(new Square(currentSquare.Row + 1, currentSquare.Col + 2));
            }
            return availableMoves;

        }


    }
}