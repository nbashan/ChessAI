using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    abstract public class Piece
    {
        #region attributes
        private bool white = false;
        #endregion

        #region ctor
        public Piece(bool white)
        {
            this.setWhite(white);
        }
        #endregion

        #region getters & setters
        public bool isWhite()
        {
            return this.white;
        }
        public void setWhite(bool white)
        {
            this.white = white;
        }
        #endregion

        #region functions
        public abstract bool canMove(Board board,
                                    Spot start, Spot end);
        public abstract int value();

        public abstract Uri getImage();

        public abstract double[,] getFactor();
        #endregion
    }
}
