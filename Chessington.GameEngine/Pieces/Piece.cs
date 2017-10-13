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

        protected Boolean GetNextPlayer(Square position,Board board)
        {
            Player otherPlayer = board.FindPosition(position.Row, position.Col).Player;
            if (this.Player != otherPlayer)
            {
                return true;
            }
            return false;
        }
        public List<Square> GetDiagoanal(Square curSquare, Board board)
        {
            List<Square> availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            Square newPosition = new Square(currentSquare.Row, currentSquare.Col);

            while (newPosition.Row < Board.Size && newPosition.Col < Board.Size && (board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare))
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveRightForward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row < Board.Size && newPosition.Col >= 0 && (board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare))
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveLeftForward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row >= 0 && newPosition.Col >= 0 && (board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare))
            {
                if (newPosition != currentSquare)
                {
                    availableMoves.Add(newPosition);

                }
                newPosition = MoveLeftBackward(newPosition);

            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row >= 0 && newPosition.Col < Board.Size && (board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare))
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
            Square newPosition = new Square(currentSquare.Row, currentSquare.Col);

            while (newPosition.Row < Board.Size -1 && (board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare)) 
            {
                newPosition = MoveForward(newPosition);
                if (newPosition != currentSquare)
                {
                    availableMoves = AddMove(newPosition, availableMoves, board);
                }
            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Row >0 && board.FindPosition(newPosition.Row,newPosition.Col) == null | newPosition == currentSquare)
            {
                newPosition = MoveBackward(newPosition); if (newPosition != currentSquare)
                {
                    availableMoves = AddMove(newPosition, availableMoves, board);
                }
            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Col < Board.Size -1 && board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare)
            {
                
                newPosition = MoveRight(newPosition);
                if (newPosition != currentSquare)
                {
                    availableMoves = AddMove(newPosition, availableMoves, board);
                }
            }
            newPosition = new Square(currentSquare.Row, currentSquare.Col);
            while (newPosition.Col >0 && board.FindPosition(newPosition.Row, newPosition.Col) == null | newPosition == currentSquare)
            {
                newPosition = MoveLeft(newPosition);
                if (newPosition != currentSquare)
                {
                    availableMoves = AddMove(newPosition, availableMoves, board);
                }
            }
            return availableMoves;
        }

        protected Square MoveForward(Square newPosition)
        {
            return new Square(newPosition.Row +1, newPosition.Col);
        }
        protected Square MoveBackward(Square newPosition)
        {
            return new Square(newPosition.Row - 1, newPosition.Col);
        }
        protected Square MoveLeft(Square newPosition)
        {
            return new Square(newPosition.Row, newPosition.Col-1);
        }
        protected Square MoveRight(Square newPosition)
        {
            return new Square(newPosition.Row, newPosition.Col+1);
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

        public List<Square> AddMove(Square move, List<Square> availableMoves,Board board)
        {
            if (ValidMove(move,board))
            {
                availableMoves.Add(move);
            }
            return availableMoves;
        }

        public Boolean ValidMove(Square move,Board board)
        {
            if (move.Row >= Board.Size | move.Row < 0 | move.Col >= Board.Size | move.Col < 0)
            {
                return false;
            }
            if (board.FindPosition(move.Row, move.Col) != null && board.FindPosition(move.Row, move.Col).Player == this.Player)
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