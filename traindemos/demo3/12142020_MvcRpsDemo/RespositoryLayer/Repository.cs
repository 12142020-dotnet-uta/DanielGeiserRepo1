using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespositoryLayer
{
    public class Repository
    {
        private readonly ILogger<Repository> _logger;

        private readonly DbContextClass _dbContext;
        DbSet<Player> players;
        DbSet<Match> matches;
        DbSet<Round> rounds;

        public Repository(DbContextClass dbContextClass, ILogger<Repository> logger) 
        {
            _dbContext = dbContextClass;
            this.players = _dbContext.players;
            this.matches = _dbContext.matches;
            this.rounds = _dbContext.rounds;
			_logger = logger;
        }

		public Player LoginPlayer(Player player)
		{
			Player player1 = players.FirstOrDefault(x => x.Fname == player.Fname && x.Lname == player.Lname);// check if the player is in the Db

			if (player1 == null)// create new player if none exists
			{
				player1 = new Player()
				{
					Fname = player.Fname,
					Lname = player.Lname
				};
				players.Add(player1);// ass new player
				_dbContext.SaveChanges();// save new player to Db

				try
				{
					Player player2 = players.FirstOrDefault(x => x.PlayerId == player1.PlayerId);// check if the player is in the Db
					return player2;
				}
				catch (ArgumentNullException ex)
				{
					_logger.LogInformation($"Saving a player to the Db threw an error, {ex}");
				}
			}
			return player1;
		}

		public Player GetPlayerById(Guid id)
        {
            Player player1 = players.FirstOrDefault(x => x.PlayerId == id);

            return player1;

        }

		/// <summary>
		/// Takes a Player and returns the edited version of the Player after saving it to the Db.
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		public Player EditPlayer(Player player)
		{
			// search Db for the player
			Player player1 = GetPlayerById(player.PlayerId);

			// transfer over all the new values
			player1.Fname = player.Fname;
			player1.Lname = player.Lname;
			player1.numLosses = player.numLosses;
			player1.numWins = player.numWins;
			player1.ByteArrayImage = player.ByteArrayImage;
			_dbContext.SaveChanges();

			// search the player again to verify that the new player is in the Db
			Player player2 = GetPlayerById(player.PlayerId);
			// return the edited Player
			return player2;
		}
	}
}
