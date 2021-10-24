using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Pawn : Piece
    {
        #region ctor
        public Pawn(bool white) : base(white) { }
        #endregion

        #region factor
        public static double[,] factor = new double[,]
       {
            { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, 0.0 },
            { 5.0,  5.0,  5.0,  5.0,  5.0,  5.0,  5.0, 5.0 },
            { 1.0,  1.0,  1.0,  3.0,  3.0,  2.0,  1.0, 1.0 },
            { 0.5,  0.5,  0.5,  2.5,  2.5,  1.0,  0.5, 0.5 },
            { 0.0,  0.0,  0.0,  2.0,  2.0,  0.0,  0.0, 0.0 },
            { 0.5, -0.5, -0.5,  0.0,  0.0, -1.0, -5.0, 0.5 },
            { 0.5,  1.0,  1.0, -2.0, -2.0,  1.0,  1.0, 0.5 },
            { 0.0,  0.0,  0.0,  0.0,  0.0,  0.0,  0.0, 0.0 },
        };
        #endregion

        #region overrided functions
        public override bool canMove(Board board, Spot start,
                                           Spot end)
        {
            int distY = end.getY() - start.getY();
            int distX = end.getX() - start.getX();


            if (start.getPiece().isWhite())
            {
                if ((start.getY() == 6 && (distY == -1 || distY == -2)) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if ((start.getY() <= 6 && distY == -1) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if (distY == -1 && Math.Abs(distX) == 1 && end.getPiece() != null && end.getPiece().isWhite() != this.isWhite())
                {
                    return true;
                }

            }

            else
            {

                if ((start.getY() == 1 && (distY == 1 || distY == 2)) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if ((start.getY() >= 2 && distY == 1) && distX == 0 && end.getPiece() == null)
                {
                    return true;
                }
                else if (distY == 1 && Math.Abs(distX) == 1 && end.getPiece() != null && end.getPiece().isWhite() != this.isWhite())
                {
                    return true;
                }
            }
            return false;
        }


        public override int value()
        {
            return 10;
        }

        public override Uri getImage()
        {
            if (isWhite())
                return new Uri("images/white_pawn.png", UriKind.Relative);
            else
                return new Uri("images/black_pawn.png", UriKind.Relative);
        }

        public override double[,] getFactor()
        {
            return factor;
        }
        #endregion

    }
}
