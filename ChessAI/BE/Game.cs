using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum GameStatus
    {
        ACTIVE,
        BLACK_WIN,
        WHITE_WIN,
        FORFEIT,
        STALEMATE,
        RESIGNATION
    }
    public class Game
    {
        #region attributes
        private int VICTORY = 2147483647;
        private int LOSS = -2147483648;
        private GameStatus status;
        public List<Move> movesPlayed;
        public Board board;
        public Player[] players;
        public Player currentTurn;
        public List<Piece> whiteKilledPieces;
        public List<Piece> blackKilledPieces;
        #endregion

        public Game(Player p1, Player p2)
        {
            initialize(p1, p2);
        }

        public Game()
        {
        }

        #region getters & setters
        public GameStatus getStatus()
        {
            return status;
        }
        public void setStatus(GameStatus status)
        {
            this.status = status;
        }
        #endregion

        #region functions
        public void initialize(Player p1, Player p2)
        {

            whiteKilledPieces = new List<Piece>();
            blackKilledPieces = new List<Piece>();

            movesPlayed = new List<Move>();
            players = new Player[2];
            players[0] = p1;
            players[1] = p2;

            board = new Board();
            board.resetBoard();

            this.currentTurn = p1;
        }
        public bool isEnd()
        {
            return getStatus() != GameStatus.ACTIVE;
        }
        public bool playerMove(int startY,
                                    int startX, int endY, int endX)
        {
            Spot startBox = board.getBox(startY, startX);
            Spot endBox = board.getBox(endY, endX);
            Move move = new Move(startBox, endBox);
            return makeMove(move, currentTurn);
        }
        private bool makeMove(Move move, Player player)
        {
            Piece sourcePiece = move.getStart().getPiece(),
                  destPiece = move.getEnd().getPiece();

            if (sourcePiece == null)
            {
                return false;
            }

            // valid player
            if (player != currentTurn)
            {
                return false;
            }

            if (sourcePiece.isWhite() != player.isWhiteSide())
            {
                return false;
            }

            // valid move?
            if (!sourcePiece.canMove(board, move.getStart(),
                                                move.getEnd()))
            {
                return false;
            }

            if (destPiece != null)
            {
                Piece kPiece = move.getEnd().getPiece();
                if (move.getEnd().getPiece().isWhite())
                {
                    whiteKilledPieces.Add(kPiece);
                }
                else
                {
                    blackKilledPieces.Add(kPiece);
                }
            }
            movesPlayed.Add(new Move(new Spot(move.getStart().getY(), move.getStart().getX(), move.getStart().getPiece()), new Spot(move.getEnd().getY(), move.getEnd().getX(), move.getEnd().getPiece())));

            Spot rookmove;
            // castling
            if (sourcePiece != null && sourcePiece is King
            && !move.getCastlingMove())
            {
                move.setCastlingMove(true);
                if (move.getStart().getX() > move.getEnd().getX())
                {
                    rookmove = board.getBox(move.getStart().getY(), 0);
                    board.getBox(move.getStart().getY(), 3).setPiece(rookmove.getPiece());
                    rookmove.setPiece(null);
                }
                else
                {
                    rookmove = board.getBox(move.getStart().getY(), 7);
                    board.getBox(move.getStart().getY(), 5).setPiece(rookmove.getPiece());
                    rookmove.setPiece(null);
                }
            }
            // store the move
            //movesPlayed.Add(move);

            // move piece from the stat box to end box
            Spot start = board.getBox(move.getStart().getY(), move.getStart().getX());
            Spot end = board.getBox(move.getEnd().getY(), move.getEnd().getX());
            end.setPiece(start.getPiece());
            start.setPiece(null);

            if (destPiece != null && destPiece is King)
            {
                if (player.isWhiteSide())
                {
                    setStatus(GameStatus.WHITE_WIN);
                }
                else
                {
                    setStatus(GameStatus.BLACK_WIN);
                }
            }

            if (board.getKingSpot(!currentTurn.isWhiteSide()) != null && end.getPiece().canMove(board, end, board.getKingSpot(!currentTurn.isWhiteSide())))
            {
                board.setKingThreatned(true);
            }
            else
            {
                board.setKingThreatned(false);
            }


            // set the current turn to the other player
            switchTurn();
            return true;
        }
        public void switchTurn()
        {
            if (currentTurn == players[0])
            {
                currentTurn = players[1];
            }
            else
            {
                currentTurn = players[0];
            }
        }
        #endregion

        #region AI MIN MAX
        public void ai()
        {
            makeMove(abmax(new Board(board), 3, LOSS, VICTORY).board.getMove(), currentTurn);
        }
        private struct helper
        {
            public double value;
            public Board board;

            public helper(double value, Board board)
            {
                this.value = value;
                this.board = board;
            }
        }
        private helper abmax(Board board, int depth, int a, int b)
        {
            if (depth == 0 || board.getFinished())
                return new helper(board.value(currentTurn.isWhiteSide()), board);


            double v = int.MinValue;

            List<Board> ns = board.getNext(currentTurn.isWhiteSide());

            helper bestMove = new helper(0, null);
            foreach (var st in ns)
            {
                helper tmp = abmin(st, depth - 1, a, b);
                if (tmp.value > v)
                {
                    v = tmp.value;
                    bestMove = new helper(v, st);
                }
                if (v >= b)
                    return new helper(v, st);
            }
            return new helper(v, bestMove.board);
        }
        private helper abmin(Board board, int depth, int a, int b)
        {
            if (depth == 0 || board.getFinished())
                return new helper(board.value(currentTurn.isWhiteSide()), board);


            double v = int.MaxValue;

            List<Board> ns = board.getNext(!currentTurn.isWhiteSide());

            helper bestMove = new helper(0, null);
            foreach (var st in ns)
            {
                helper tmp = abmax(st, depth - 1, a, b);
                if (tmp.value < v)
                {
                    v = tmp.value;
                    bestMove = new helper(v, st);
                }
                if (v <= a)
                    return new helper(v, st);
            }
            return new helper(v, bestMove.board);
        }
        #endregion
    }
}
