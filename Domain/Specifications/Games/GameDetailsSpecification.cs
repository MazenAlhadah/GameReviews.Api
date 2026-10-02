using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.Games
{
    public class GameDetailsSpecification: BaseSpecification<Game>
    {
        public GameDetailsSpecification(int gameId):base (game => game.Id == gameId)
        {
            AddInclude(game=>game.Category);
            AddInclude(game => game.Reviews);
            AddIncludeString("Reviews.User");
        }
    }
}
