using System.Collections.Generic;
using System.Linq;

namespace ProductConfigurator.Domain
{
    public class ItemImages
    {
        private readonly InstrumentType type;
        private readonly string[] images;

        public bool HasMoreThanOneImage => images.Length > 1;
        public IEnumerable<int> ImageIndexCollection => Enumerable.Range(0, images.Length);

        public bool IsFirst() => currentImageIndex == 0;
        public void NextImage()
        {
            if (!IsLast())
            {
                currentImageIndex++;
            }
        }

        public bool IsLast() => currentImageIndex >= images.Count() - 1;
        public void PreviousImage()
        {
            if (!IsFirst())
            {
                currentImageIndex--;
            }
        }

        private int currentImageIndex;
        public bool IsIndex(int index) => currentImageIndex == index;

        public ItemImages(InstrumentType type, params string[] images)
        {
            this.type = type;
            this.images = images;
            currentImageIndex = 0;
        }

        public override string ToString()
        {
            if (!images.Any())
            {
                return Constants.DefaultImage;
            }
            return images.Select(x => $"img/{type.ToString().ToLower()}/{x}").ElementAt(currentImageIndex);
        }
    }
}
