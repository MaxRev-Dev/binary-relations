using System.Collections.Generic;
using System.Linq;

namespace MaxRev.Extensions.Matrix
{
    public static partial class MatrixExtensions
    {
        public static IEnumerable<IEnumerable<(int, int)>> RoomSearch(int[,] map, int roomId)
        {
            var maxX = map.GetLength(0);
            var maxY = map.GetLength(1);
            var rooms = new List<List<(int x, int y)>>();
            RoomCore(map, 0, 0, roomId, maxX, maxY, new bool[maxX, maxY], rooms, new List<(int x, int y)>());
            return rooms;
        }

        private static void RoomCore(int[,] map, int x, int y, int roomId, int maxX, int maxY, 
            bool[,] visited, ICollection<List<(int x, int y)>> rooms, List<(int x, int y)> current)
        {
            if (x < 0 || x >= maxX || y < 0 || y >= maxY || visited[x, y])
                return;

            var isRoom = map[x, y] == roomId;
            visited[x, y] = true;
            var room = isRoom ? current : new List<(int x, int y)>();

            if (isRoom)
            {
                var edge = (x, y);
                var exist = rooms.FirstOrDefault(h =>
                    h.Any(v => IsNeightbourStrictCross(v, edge)));
                if (exist != default)
                    exist.Add(edge);
                else
                    room.Add(edge);
            }
            if (room.Count > 0)
                rooms.Add(room);
            RoomCore(map, x, y - 1, roomId, maxX, maxY, visited, rooms, room);
            RoomCore(map, x - 1, y, roomId, maxX, maxY, visited, rooms, room);
            RoomCore(map, x + 1, y, roomId, maxX, maxY, visited, rooms, room);
            RoomCore(map, x, y + 1, roomId, maxX, maxY, visited, rooms, room);
        }

        private static bool IsNeightbourStrictCross((int x, int y) edge1, (int x, int y) edge2)
        {
            return (edge1.x + 1 == edge2.x && edge1.y + 1 != edge2.y // excluding diagonals
                    || edge1.x - 1 == edge2.x && edge1.y - 1 != edge2.y // excluding diagonals
                    || edge1.x == edge2.x) &&
                   (edge1.y + 1 == edge2.y && edge1.x + 1 != edge2.x // excluding diagonals
                    || edge1.y - 1 == edge2.y && edge1.x - 1 != edge2.x // excluding diagonals
                    || edge1.y == edge2.y);
        }
    }
}