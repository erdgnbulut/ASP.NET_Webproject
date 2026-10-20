using efcoreApp.Data;
public class WishList
  {
    public List<WishListItem> Items {get; set;} = new List<WishListItem>();
    public virtual void Add(Game game,int quantity)
    {
        var item = Items.Where(i => i.Game.GameId == game.GameId).FirstOrDefault();
        if(item == null)
        {
            Items.Add(new WishListItem {Game = game, Quantity = 1,});
        }

    }
    public virtual void RemoveItem(Game game)
    {
        Items.RemoveAll(i =>i.Game.GameId ==game.GameId);

    }

    public float? Total()
    {
        return Items.Sum(i =>i.Game.GamePrice * i.Quantity);

    }
    public virtual void Clear()
    {
        Items.Clear();
    }
      
  }

public class WishListItem
{
    public int WishListItemID { get; set; }
    public Game Game { get; set; } = new();
    public int Quantity {get; set; }

}