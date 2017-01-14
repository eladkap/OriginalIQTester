namespace Graphs
{
    public class Step
    {
        public Step(int phase, int from, int via, int to)
        {
            Phase = phase;
            From = from;
            Via = via;
            To = to;
        }

        public int Phase { get; set; }

        public int From { get; set; }

        public int Via { get; set; }

        public int To { get; set; }

        public override string ToString()
        {
            return $"#{Phase}: From {From} via {Via} to {To}";
        }
    }
}
