namespace PlayingCardLibrary
{
    public class Pile
    {
        private Orientation faceUp;

        public Pile(Orientation faceUp)
        {
            this.faceUp = faceUp;
        }

        public bool Empty => true;
    }
}