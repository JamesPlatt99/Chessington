using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (int i = 0; i < Board.BoardSize; i++)
            {
                Square curMove = new Square(currentSquare.Row,i);
                availableMoves.Add(curMove);

                curMove = new Square(i,currentSquare.Col);
                availableMoves.Add(curMove);
            }
            return availableMoves;
        }
    }
}