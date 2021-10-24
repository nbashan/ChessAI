using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Knight : Piece
    {
        #region ctor
        public Knight(bool white) : base(white) { }
        #endregion

        #region factor
        public static double[,] factor = new double[,]
       {
            { -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0 },
            { -4.0, -2.0,  0.0,  0.0,  0.0,  0.0, -2.0, -4.0 },
            { -3.0,  0.0,  1.0,  1.5,  1.5,  1.0,  0.0, -3.0 },
            { -3.0,  0.5,  1.5,  2.0,  2.0,  1.5,  0.5, -3.0 },
            { -3.0,  0.0,  1.5,  2.0,  2.0,  1.5,  0.0, -3.0 },
            { -3.0,  0.5,  1.0,  1.5,  1.5,  1.0,  0.5, -3.0 },
            { -4.0, -2.0,  0.0,  0.5,  0.5,  0.0, -2.0, -4.0 },
            { -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0 },
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

            int x = Math.Abs(start.getX() - end.getX());
            int y = Math.Abs(start.getY() - end.getY());
            return x * y == 2;
        }

        public override int value()
        {
            return 30;
        }

        public override Uri getImage()
        {
            if (isWhite())
                return new Uri("images/white_knight.png", UriKind.Relative);
            else
                return new Uri("images/black_knight.png", UriKind.Relative);
        }

        public override double[,] getFactor()
        {
            return factor;
        }
        #endregion
    }
}
