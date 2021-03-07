using System.Collections.Generic;
using System.Linq;

namespace GameChanceTest
{
    public class RoomSelector
    {
        public string Query(List<string> roomIds, Dictionary<string, List<RoomRow>> roomTable)
        {
            return roomTable[roomIds[0]][0].Sgame;
        }
    }
}