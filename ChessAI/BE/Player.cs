using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	abstract public class Player
	{
		#region attributes
		private bool whiteSide;
		private bool humanPlayer;
		#endregion

		#region getters & setters
		public bool isWhiteSide()
		{
			return this.whiteSide;
		}
		public bool isHumanPlayer()
		{
			return this.humanPlayer;
		}

		public void setWhiteSide(bool whiteSide)
		{
			this.whiteSide = whiteSide;
		}

		public void setHumanPlayer(bool humanPlayer)
		{
			this.humanPlayer = humanPlayer;
		}
		#endregion
	}
	class HumanPlayer : Player
	{
		#region ctor
		public HumanPlayer(bool whiteSide)
		{
			this.setWhiteSide(whiteSide);
			this.setHumanPlayer(true);
		}
		#endregion
	}
	class ComputerPlayer : Player
	{
		#region ctor
		public ComputerPlayer(bool whiteSide)
		{
			this.setWhiteSide(whiteSide);
			this.setHumanPlayer(false);
		}
		#endregion
	}
}
