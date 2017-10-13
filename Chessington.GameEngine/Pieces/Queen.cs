using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var curSquare = board.FindPiece(this);
            IEnumerable<Square> availableMovesTmp = GetLateral(curSquare, board);
            availableMovesTmp = availableMovesTmp.Concat(GetDiagoanal(curSquare, board));
            List<Square> availableMoves = availableMovesTmp.ToList();
            availableMoves.Remove(curSquare);
            availableMoves.Remove(curSquare);

            return availableMoves;
        }
    }
}