using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Bishop : Piece
    {
        #region ctor
        public Bishop(bool white) : base(white) { }
        #endregion

        #region factor
        public static double[,] factor = new double[,]
        {
            { -2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0 },
            { -1.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, -1.0 },
            { -1.0,  0.0,  0.5,  1.0,  1.0,  0.5,  0.0, -1.0 },
            { -1.0,  0.5,  0.5,  1.0,  1.0,  0.5,  0.5, -1.0 },
            { -1.0,  0.0,  1.0,  1.0,  1.0,  0.0,  0.0, -1.0 },
            { -1.0,  1.0,  1.0,  1.0,  1.0,  1.0,  1.0, -1.0 },
            { -1.0,  0.5,  0.0,  0.0,  0.0,  0.5,  0.5, -1.0 },
            { -2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0 },
         };
        #endregion

        #region overrided functions
        public override bool canMove(Board board, Spot start,
                                           Spot end)
        {
            // we can't move the piece to a spot that has
            // a piece of the same colour
            if (end.getPiece() != null && end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }
            return Math.Abs(end.getX() - start.getX()) == Math.Abs(end.getY() - start.getY()) && board.cleared(start.getX(), start.getY(), end.getX(), end.getY());
        }
        public override int value()
        {
            return 30;
        }

        public override Uri getImage()
        {
            if (isWhite())
                return new Uri("images/white_bishop.png", UriKind.Relative);
            else
                return new Uri("images/black_bishop.png", UriKind.Relative);
        }

        public override double[,] getFactor()
        {
            return factor;
        }


        #endregion
    }
}
