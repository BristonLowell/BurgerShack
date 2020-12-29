namespace BurgerShack.Models
{
  public class Listing
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public Profile Creator { get; set; }
    public string CreatorId { get; set; }
  }
}