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
                    if (board.GetPosition(currentSquare.Row + 1, currentSquare.Col) == null)
                    {
                        AddMove(new Square(currentSquare.Row + 1, currentSquare.Col),availableMoves);
                    }

                   
                    if (FirstMove)
                    {
                        if (board.GetPosition(currentSquare.Row + 1, currentSquare.Col) == null && board.GetPosition(currentSquare.Row + 2, currentSquare.Col) == null)
                        {
                            AddMove(new Square(currentSquare.Row + 2, currentSquare.Col),availableMoves);
                        }
                    }
                    break;
                case Player.White:
                    if (board.GetPosition(currentSquare.Row -1, currentSquare.Col) == null)
                    {
                        AddMove(new Square(currentSquare.Row - 1, currentSquare.Col),availableMoves);
                    }
                   
                    if (FirstMove)
                    {
                        if (board.GetPosition(currentSquare.Row - 1, currentSquare.Col) == null && board.GetPosition(currentSquare.Row - 2, currentSquare.Col) == null)
                        {
                            AddMove(new Square(currentSquare.Row - 2, currentSquare.Col),availableMoves);
                        }
                    }
                    break;
            }

            return availableMoves;
        }
    }
}