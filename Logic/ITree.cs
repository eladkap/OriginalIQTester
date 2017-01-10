namespace Logic
{
    interface ITree<T>
    {
        /// <summary>
        /// Checks if tree is empty
        /// </summary>
        /// <returns>True if tree is empty and false otherwise</returns>
        bool IsEmpty();

        /// <summary>
        /// Displays nodes inorder
        /// </summary>
        void InorderDisplay();
    }
}
