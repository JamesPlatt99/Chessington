using System;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public abstract class Piece
    {
        public Boolean FirstMove = true;
        protected Piece(Player player)
        {
            Player = player;
        }

        public List<Square> GetDiagoanal(Square curSquare, Board board)
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

        public List<Square> GetLateral(Square curSquare, Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            for (int i = 0; i < Board.BoardSize; i++)
            {
                Square curMove = new Square(currentSquare.Row, i);
                availableMoves.Add(curMove);

                curMove = new Square(i, currentSquare.Col);
                availableMoves.Add(curMove);
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


        public Player Player { get; private set; }

        public abstract IEnumerable<Square> GetAvailableMoves(Board board);

        public void MoveTo(Board board, Square newSquare)
        {
            var currentSquare = board.FindPiece(this);
            board.MovePiece(currentSquare, newSquare);
        }

    }
}