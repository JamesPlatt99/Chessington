using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            Square newPosition = new Square(currentSquare.Row, currentSquare.Col);

            while (newPosition.Row < Board.BoardSize && newPosition.Col < Board.BoardSize)
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveRightForward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row < Board.BoardSize && newPosition.Col >= 0)
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveLeftForward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row >= 0 && newPosition.Col >= 0)
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveLeftBackward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row >= 0 && newPosition.Col < Board.BoardSize)
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveRightBackward(newPosition);

            }

            return availableMoves;
        }

        public Square MoveLeftForward(Square newPosition)
        {
            Square newestPosition = new Square(newPosition.Row + 1, newPosition.Col - 1);

            return newestPosition;
        }
        public Square MoveLeftBackward(Square newPosition)
        {
            Square newestPosition = new Square(newPosition.Row - 1, newPosition.Col - 1);

            return newestPosition;
        }
        public Square MoveRightForward(Square newPosition)
        {
            Square newestPosition = new Square(newPosition.Row + 1, newPosition.Col + 1);

            return newestPosition;
        }
        public Square MoveRightBackward(Square newPosition)
        {
            Square newestPosition = new Square(newPosition.Row - 1, newPosition.Col + 1);

            return newestPosition;
        }
    }
}