using ModelLayer;
using ModelsLayer.ViewModels;
using RespositoryLayer;
using System;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        private readonly Repository _repository;
        private readonly MapperClass _mapperClass;

        public BusinessLogicClass(Repository repository, MapperClass mapperClass)
        {
            _repository = repository;
            _mapperClass = mapperClass;
        }
        /// <summary>
        /// Takes a LoginPlayerViewModel instance and return a PlayerViewModel instance
        /// </summary>
        /// <param name="loginPlayerViewModel"></param>
        /// <returns></returns>
        public PlayerViewModel LoginPlayer(LoginPlayerViewModel loginPlayerViewModel)
        {
            //have all login cinfines to this Business Layer
            Player player = new Player()
            {
                Fname = loginPlayerViewModel.Fname,
                Lname = loginPlayerViewModel.Lname
            };

            Player player1 = _repository.LoginPlayer(player);

            //convert the Player to a PlayerViewModel
            PlayerViewModel playerViewModel = _mapperClass.ConvertPlayerToPlayerViewModel(player1); //get access to the mapper class
            return playerViewModel;
        }

        public PlayerViewModel EditPlayer(Guid playerId)
        {
            //call a method in Repository that will return a player based on this ID
            Player player = _repository.GetPlayerById(playerId);

            //map the player to a playerViewmodel
            PlayerViewModel playerViewModel = _mapperClass.ConvertPlayerToPlayerViewModel(player);
            return playerViewModel;

        }

        public PlayerViewModel EditedPlayer(PlayerViewModel playerViewModel)
        {
            // get an instance of the player being edited.
            Player player = _repository.GetPlayerById(playerViewModel.PlayerId);

            player.Fname = playerViewModel.Fname;
            player.Lname = playerViewModel.Lname;
            player.numLosses = playerViewModel.numLosses;
            player.numWins = playerViewModel.numWins;
            player.ByteArrayImage = _mapperClass.ConvertIformFileToByteArray(playerViewModel.IformFileImage);  //call the mapper class method ot convert the iformfile to byte[]

            Player player1 = _repository.EditPlayer(player);
            PlayerViewModel playerViewModel1 = _mapperClass.ConvertPlayerToPlayerViewModel(player1);
            return playerViewModel1;
        }
    }
}
