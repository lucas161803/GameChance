using System.Collections.Generic;
using System.Linq;

namespace GameChanceTest
{
    public class RoomSelector
    {
        public string Query(List<string> roomIds)
        {
            if (roomIds.Any())
            {
                return "project2";
            }

            return "project1";
        }
    }
}