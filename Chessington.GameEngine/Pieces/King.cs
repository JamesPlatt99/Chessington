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
            AddMove(MoveLeftBackward(currentSquare), availableMoves,board);
            AddMove(MoveLeftForward(currentSquare), availableMoves, board);
            AddMove(MoveRightBackward(currentSquare), availableMoves, board);
            AddMove(MoveRightForward(currentSquare), availableMoves, board);
            AddMove(new Square(currentSquare.Row + 1, currentSquare.Col), availableMoves, board);
            AddMove(new Square(currentSquare.Row - 1, currentSquare.Col), availableMoves, board);
            AddMove(new Square(currentSquare.Row, currentSquare.Col + 1), availableMoves, board);
            AddMove(new Square(currentSquare.Row, currentSquare.Col - 1), availableMoves, board);
            return availableMoves;
        }
    }
}