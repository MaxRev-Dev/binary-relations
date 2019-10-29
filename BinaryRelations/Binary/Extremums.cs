using System.Collections.Generic;
using System.Linq;

namespace MaxRev.Extensions.Binary
{
    public static partial class BinaryRelations
    {
        #region Extremums

        /// <summary>
        /// Returns true if matrix have any relational maximum
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMaximum(this bool[,] matrix1) => GetMaximums(matrix1).Any();

        /// <summary>
        /// Returns true if matrix have any relational minimum
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMinimum(this bool[,] matrix1) => GetMinimums(matrix1).Any();

        /// <summary>
        /// Returns true if matrix have any relational majorants
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMajorant(this bool[,] matrix1) => GetMajorants(matrix1).Any();

        /// <summary>
        /// Returns true if matrix have any relational minorants
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static bool HasMinorant(this bool[,] matrix1) => GetMinorants(matrix1).Any();

        /// <summary>
        /// Returns indexes of relations those are maximums
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMaximums(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var rulePassing = true;

                for (int j = 0; j < length; j++)
                {
                    if (matrix1[i, j]) 
                        continue;
                    rulePassing = false;
                    break;
                }

                if (rulePassing)
                    yield return i;
            }
        }

        /// <summary>
        /// Returns indexes of relations those are minimums
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMinimums(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var rulePassing = true;

                for (int j = 0; j < length; j++)
                {
                    if (matrix1[j, i])
                        continue;
                    rulePassing = false;
                    break;
                }

                if (rulePassing)
                    yield return i;
            }
        }

        /// <summary>
        /// Returns indexes of relations those are majorants
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMajorants(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var rulePassing = true;

                for (int j = 0; j < length; j++)
                {
                    if (!matrix1[j, i]) 
                        continue;
                    rulePassing = false;
                    break;
                }

                if (rulePassing)
                    yield return i;
            }
        }

        /// <summary>
        /// Returns indexes of relations those are minorants
        /// <see href="http://www.u.arizona.edu/~mwalker/econ519/Econ519LectureNotes/BinaryRelations.pdf"/>
        /// </summary>
        /// <param name="matrix1"></param>
        /// <returns></returns>
        public static IEnumerable<int> GetMinorants(this bool[,] matrix1)
        {
            ThrowIfNull_NotQuad(matrix1);

            var length = matrix1.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                var rulePassing = true;

                for (int j = 0; j < length; j++)
                {
                    if (!matrix1[i, j]) 
                        continue;
                    rulePassing = false;
                    break;
                }

                if (rulePassing)
                    yield return i;
            }
        }

        #endregion
    }
}