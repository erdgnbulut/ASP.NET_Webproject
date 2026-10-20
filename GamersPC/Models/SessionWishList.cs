using System.Text.Json.Serialization;
using efcoreApp.Data;
using YourProject.Extensions;

namespace GamersPC.Models;

public class SessionWishList : WishList
{
    public static WishList GetWishList(IServiceProvider services)
    {
         ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
         SessionWishList wishlist = session?.GetJson<SessionWishList>("WishList") ?? new SessionWishList();
         wishlist.Session = session;
         return wishlist;
    }
    [JsonIgnore]
    public ISession? Session { get; set; }
    public override void Add(Game game , int quantity)
    {
        base.Add(game , quantity);
        Session?.SetJson("WishList",this);
    }

    public override void RemoveItem(Game game)
    {
        base.RemoveItem(game);
        Session?.SetJson("WishList",this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("WishList");
    }

}