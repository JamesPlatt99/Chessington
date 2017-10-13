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
            
                AddMove(new Square(currentSquare.Row + 2, currentSquare.Col - 1),availableMoves);
                AddMove(new Square(currentSquare.Row + 2, currentSquare.Col + 1), availableMoves);
                AddMove(new Square(currentSquare.Row - 2, currentSquare.Col - 1), availableMoves);
                AddMove(new Square(currentSquare.Row - 2, currentSquare.Col + 1), availableMoves);
                AddMove(new Square(currentSquare.Row + 1, currentSquare.Col - 2), availableMoves);
                AddMove(new Square(currentSquare.Row - 1, currentSquare.Col - 2), availableMoves);
                AddMove(new Square(currentSquare.Row - 1, currentSquare.Col + 2), availableMoves);
                AddMove(new Square(currentSquare.Row + 1, currentSquare.Col + 2), availableMoves);
            return availableMoves;

        }


    }
}