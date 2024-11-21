namespace OnlineStore
{
    public struct Product
    {
        private readonly string _name;

        public Product(string name) =>
            _name = name ?? throw new System.ArgumentNullException(nameof(name));
    }
}
