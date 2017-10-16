using System;
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
                    if (board.FindPosition(currentSquare.Row + 1, currentSquare.Col) == null)
                    {
                        availableMoves = AddMove(new Square(currentSquare.Row + 1, currentSquare.Col), availableMoves, board);

                        if (FirstMove && board.FindPosition(currentSquare.Row + 2, currentSquare.Col) == null)
                        {
                            availableMoves = AddMove(new Square(currentSquare.Row + 2, currentSquare.Col), availableMoves, board);
                        }
                    }
                    break;
                case Player.White:
                    if (board.FindPosition(currentSquare.Row - 1, currentSquare.Col) == null)
                    {
                        availableMoves = AddMove(new Square(currentSquare.Row - 1, currentSquare.Col), availableMoves, board);
                        if (FirstMove && board.FindPosition(currentSquare.Row - 2, currentSquare.Col) == null)
                        {
                            availableMoves = AddMove(new Square(currentSquare.Row - 2, currentSquare.Col), availableMoves, board);
                        }
                    }

                    break;
            }

            return availableMoves;
        }
    }
}
