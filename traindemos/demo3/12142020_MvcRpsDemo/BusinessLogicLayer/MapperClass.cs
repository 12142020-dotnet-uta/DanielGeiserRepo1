using Microsoft.AspNetCore.Http;
using ModelLayer;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MapperClass
    {
        public PlayerViewModel ConvertPlayerToPlayerViewModel(Player player)
        {
            PlayerViewModel playerViewModel = new PlayerViewModel()
            {
                PlayerId = player.PlayerId,
                Fname = player.Fname,
                Lname = player.Lname,
                numWins = player.numWins,
                numLosses = player.numLosses,
                JpgStringImage = ConvertByteArrayToJpgString(player.ByteArrayImage)
            };
            return playerViewModel;
        }

        private string ConvertByteArrayToJpgString(byte[] byteArray)
        {
            if (byteArray != null)
            {
                string imageBase64Data = Convert.ToBase64String(byteArray, 0, byteArray.Length);
                string imageDataURI = string.Format($"data:image/jpg;base64 {imageBase64Data}");
                return imageDataURI;
            }
            else return null;
        }

        public byte[] ConvertIformFileToByteArray(IFormFile iformFile)
        {
            using (var ms = new MemoryStream())
            {
                // convert the IFormFile into a byte[]
                iformFile.CopyTo(ms);

                if (ms.Length > 2097152)// if it's bigger that 2 MB
                {
                    return null;
                }
                else
                {
                    byte[] a = ms.ToArray(); // put the string into the Image property
                    return a;
                }
            }
        }
    }
}
