namespace LinqDemo;

public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
}


public class FullProduct {
	public string Name { get; set; }
	public double Price { get; set; }
	public string CategoryName { get; set; }
}
