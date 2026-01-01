using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalog.Domain
{
    public class Product : Entity, IAggregateRoot
    {
        public Guid CategoryId { get; private set; }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Active { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string Image { get; private set; }
        public int StockAmount { get; private set; }
        public Category Category { get; private set; }
        public Dimension Dimension { get; private set; }

        public Product(string name, string description, bool active, decimal price, Guid categoryId, DateTime createdAt, string image, Dimension dimension)
        {
            CategoryId = categoryId;
            Name = name;
            Description = description;
            Active = active;
            Price = price;
            CreatedAt = createdAt;
            Image = image; 
            Dimension = dimension;

            Validate();
        }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

        public void ChangeCategory(Category category)
        {
            Category = category;
            CategoryId = Category.Id;
        }

        public void ChangeDescription(string description)
        {
            Validation.ValidateIfEmpty(Description, "The field Description can't be empty.");
            Description = description;
        }

        public void DecreaseStock(int amount)
        {
            if (amount < 0) amount *= -1;

            if (!StockAvailable(amount)) throw new DomainException("Unavailable Stock Amount.");

            StockAmount -= amount;
        }

        public void IncreaseStock(int amount)
        {
            if (amount < 0) amount *= -1;

            StockAmount += amount;
        }

        public bool StockAvailable(int amount)
        {
            return StockAmount >= amount;
        }

        public void Validate()
        {
            Validation.ValidateIfEmpty(Name, "The field Name can't be empty.");
            Validation.ValidateIfEmpty(Description, "The field Description can't be empty.");
            Validation.ValidateIfEquals(CategoryId, Guid.Empty, "The field Product Category can't be empty.");
            Validation.ValidateIfLessThanMinimum(Price, 0, "The field Price of the Product can't be less or equals 0.");
            Validation.ValidateIfEmpty(Image, "The field Image can't be empty.");
        }

    }
}
