using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Queen : Piece
    {
        #region ctor
        public Queen(bool white) : base(white) { }
        #endregion

        #region factor
        public static double[,] factor = new double[,]
       {
            { -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0 },
            { -1.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -1.0 },
            { -1.0,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -1.0 },
            { -0.5,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -0.5 },
            {  0.0,  0.0,  0.5,  0.5,  0.5,  0.5,  0.0, -0.5 },
            { -1.0,  0.5,  0.5,  0.5,  0.5,  0.5,  0.0, -1.0 },
            { -1.0,  0.0,  0.5,  0.0,  0.0,  0.0,  0.0, -1.0 },
            { -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0 },
        };
        #endregion

        #region overrided functions
        public override bool canMove(Board board, Spot start,
                                           Spot end)
        {
            bool isWhite = start.getPiece().isWhite();
            Bishop bishop = new Bishop(isWhite);
            Rook rook = new Rook(isWhite);
            return bishop.canMove(board, start, end) || rook.canMove(board, start, end);
        }

        public override int value()
        {
            return 90;
        }

        public override Uri getImage()
        {
            if (isWhite())
                return new Uri("images/white_queen.png", UriKind.Relative);
            else
                return new Uri("images/black_queen.png", UriKind.Relative);
        }

        public override double[,] getFactor()
        {
            return factor;
        }
        #endregion
    }
}
