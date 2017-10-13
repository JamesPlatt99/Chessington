using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public Square Position { get; set; }
        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            switch (Player)
            {
                case Player.Black:
                    availableMoves.Add(new Square(currentSquare.Row+1,currentSquare.Col));
                    break;
                case Player.White:
                    availableMoves.Add(new Square(currentSquare.Row-1,currentSquare.Col));
                    break;
            }

            return availableMoves;
        }
    }
}