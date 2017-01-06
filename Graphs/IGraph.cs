namespace Graphs
{
    public interface IGraph
    {
        void Show();

        /// <summary>
        /// Returns true if vertices i, j, k are neighbors such that
        /// they are aligned in the same direction
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="k"></param>
        /// <returns>True if vertices i, j, k are aligned neighbors</returns>
        bool AreAlignedNeighbors(int i, int j, int k);
    }
}
