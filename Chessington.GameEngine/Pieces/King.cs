using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            AddMove(MoveLeftBackward(currentSquare), availableMoves);
            AddMove(MoveLeftForward(currentSquare), availableMoves);
            AddMove(MoveRightBackward(currentSquare), availableMoves);
            AddMove(MoveRightForward(currentSquare), availableMoves);
            AddMove(new Square(currentSquare.Row + 1, currentSquare.Col), availableMoves);
            AddMove(new Square(currentSquare.Row - 1, currentSquare.Col), availableMoves);
            AddMove(new Square(currentSquare.Row, currentSquare.Col + 1), availableMoves);
            AddMove(new Square(currentSquare.Row, currentSquare.Col - 1), availableMoves);
            return availableMoves;
        }
    }
}