using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using RpsGame_refactored_Db;

namespace RpsGamingMain.tests
{
    public class UnitTest1
    {
        [Fact]//the name of the function should tell the user what the function is doing
        public void FourPlusFiveEqualsNine()
        {
            // arrange
            // Creating the in-memory Db
            var options = new DbContextOptionsBuilder<RpsDbContext>()
                        .UseInMemoryDatabaseName(databaseName: "TestDb")
                        .options;
            // act
            // add to the In-memory Db
            using(var context = new RpsDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                RpsGameRepositoryLayer repo = new RpsGameRepositoryLayer(context);

                int x = 4;
                int y = 5;
                int z = x + y;

            }
          

            // assert
            // verify the results was as expected
            using(var context = new RpsDbContext(options))
            {
                Assert.Equal(9,z);
            }
        }


        [Theory]
        [InlineData(6,7)]
        [InlineData(5,8)]
        [InlineData(4,9)]
        public void VariousInputesEqualThirteen(int x, int y)
        {
            //act
            int z = x+y;

            //assert
            Assert.Equal(13,z);
        }

        [Theory]
        [InlineData(10,11)]
        [InlineData(5,9)]
        public void VariousInputesDoesNotEqualThirteen(int x, int y)
        {
            //act
            int z = x+y;

            //assert
            Assert.NotEqual(13,z);
        }

    }
}
