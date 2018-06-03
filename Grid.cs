namespace Grains
{
    public class Grid
    {
        public int width { get; set; }
        public int height { get; set; }

        public Grain[,] grid { get; set; }
        public Grain[,] tempGrid { get; set; }

        public int sum
        {
            get

            { return width * height; }
        }

        public Grid(int h, int w)
        {
            width = w;
            height = h;

            grid = new Grain[height, width];
            tempGrid = new Grain[height, width];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    grid[i, j] = new Grain(i, j);
                    tempGrid[i, j] = new Grain(i, j);
                }
            }
        }
    }
}