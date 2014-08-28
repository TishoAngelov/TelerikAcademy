namespace MinesGame
{
    using System;

    public class Points
    {
        private string name;
        private int playerPoints;

        public Points()
        {
        }

        public Points(string name, int points)
        {
            this.Name = name;
            this.PlayerPoints = points;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int PlayerPoints
        {
            get { return this.playerPoints; }
            set { this.playerPoints = value; }
        }
    }
}
