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

            while (newPosition.Row < Board.Size && newPosition.Col < Board.Size)
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveRightForward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row < Board.Size && newPosition.Col >= 0)
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
            while (newPosition.Row >= 0 && newPosition.Col < Board.Size)
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
            for (int i = 0; i < Board.Size; i++)
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

        public List<Square> AddMove(Square move, List<Square> availableMoves)
        {
            if (ValidMove(move))
            {
                availableMoves.Add(move);
            }
            return availableMoves;
        }

        public Boolean ValidMove(Square move)
        {
            if (move.Row >= Board.Size | move.Row < 0 | move.Col >= Board.Size | move.Col < 0)
            {
                return false;
            }
            return true;
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