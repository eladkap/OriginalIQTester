namespace Logic
{
    interface IExpressionTree
    {
        /// <summary>
        /// Creates expression tree according to the string nnfExp
        /// </summary>
        /// <param name="nnfExp">NNF expression</param>
        void CreateExpressionTree(string nnfExp);
    }
}
