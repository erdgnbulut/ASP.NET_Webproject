using System.Text.Json.Serialization;
using efcoreApp.Data;
using YourProject.Extensions;

namespace GamersPC.Models;

public class SessionPaymentList : PaymentList
{
    public static PaymentList GetPaymentList(IServiceProvider services)
    {
         ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
         SessionPaymentList paymentlist = session?.GetJson<SessionPaymentList>("PaymentList") ?? new SessionPaymentList();
         paymentlist.Session = session;
         return paymentlist;
    }
    [JsonIgnore]
    public ISession? Session { get; set; }
    public override void Add(Game game , int quantity)
    {
        base.Add(game , quantity);
        Session?.SetJson("PaymentList",this);
    }

    public override void RemoveItem(Game game)
    {
        base.RemoveItem(game);
        Session?.SetJson("PaymentList",this);
    }

    public override void Clear()
    {
        base.Clear();
        Session?.Remove("PaymentList");
    }

}