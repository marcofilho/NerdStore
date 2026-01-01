using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain
{
    public class Dimension
    {
        public decimal Height { get; private set; }
        public decimal Width { get; private set; }
        public decimal Depth { get; private set; }

        public Dimension(decimal height, decimal width, decimal depth)
        {
            Validation.ValidateIfLessThan(height, 1, "The field Height must be greater than zero.");
            Validation.ValidateIfLessThan(width, 1, "The field Width must be greater than zero.");
            Validation.ValidateIfLessThan(depth, 1, "The field Depth must be greater than zero.");

            Height = height;
            Width = width;
            Depth = depth;
        }

        public string GetFormattedDimension()
        {
            return $" HxWxD: {Height} x {Width} x {Depth}";
        }

        public override string ToString()
        {
            return GetFormattedDimension();
        }
    }
}
