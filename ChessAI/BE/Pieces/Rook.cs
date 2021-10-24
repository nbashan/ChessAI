using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Rook : Piece
    {
        #region ctor
        public Rook(bool white) : base(white) { }
        #endregion

        #region factor
        public static double[,] factor = new double[,]
{
            {  0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,  0.0 },
            {  0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0,  0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            {  0.0, 0.0, 0.0, 0.5, 0.5, 0.0, 0.0,  0.0 },
 };
        #endregion

        #region overrided functions
        public override bool canMove(Board board, Spot start,
                                          Spot end)
        {
            if (end.getPiece() != null && end.getPiece().isWhite() == this.isWhite())
            {
                return false;
            }

            if (
                start.getX() == end.getX() && start.getY() != end.getY() && board.cleared(start.getX(), start.getY(), end.getX(), end.getY())
                ||
                start.getY() == end.getY() && start.getX() != end.getX() && board.cleared(start.getX(), start.getY(), end.getX(), end.getY()))
            {
                return true;
            }
            return false;
        }

        public override int value()
        {
            return 50;
        }

        public override Uri getImage()
        {
            if (isWhite())
                return new Uri("images/white_rook.png", UriKind.Relative);
            else
                return new Uri("images/black_rook.png", UriKind.Relative);
        }

        public override double[,] getFactor()
        {
            return factor;
        }
        #endregion
    }
}
