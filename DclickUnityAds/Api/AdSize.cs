namespace DclickUnityAds.Api
{
    public class AdSize
    {
        private int width;
        private int height;
        public int Width
        {
            get
                {
                    return width;
                }
        }

        public int Height
        {
            get
                {
                    return height;
                }
        }
        public static readonly AdSize Banner = new AdSize(320, 50);

        public AdSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }
}
