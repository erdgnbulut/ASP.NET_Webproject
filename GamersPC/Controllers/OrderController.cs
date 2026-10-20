using efcoreApp.Data;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YourProject.Extensions;

namespace efcoreApp.Controllers
{
    public class OrderController: Controller
    {
        private PaymentList paymentlist;
        private IOrderRepository _orderRepository;
        public OrderController(PaymentList paymentlistService,IOrderRepository orderRepository)
        {
            paymentlist = paymentlistService;
            _orderRepository = orderRepository;
            

        }

        public IActionResult CheckOut(){
            return View(new OrderModel(){PaymentList = paymentlist});
        }
        [HttpPost]
        public IActionResult CheckOut(OrderModel model)
        {
            if(paymentlist.Items.Count==0)
            {
                ModelState.AddModelError("", "There is nothing here!");
            }
            if (ModelState.IsValid)
            {
                var order = new Order()
                {
                    Name=model.Name, 
                    Surname=model.Surname,
                    City=model.City,
                    Country=model.Country,
                    Address=model.Address,
                    PostCode=model.PostCode,
                    PhoneNo=model.PhoneNo,
                    OrderItems = paymentlist.Items.Select(i => new OrderItem{
                        GameId=i.Game.GameId,
                        Price =i.Game.GamePrice


                    }).ToList()
                    

                };
                model.PaymentList = paymentlist;
                _orderRepository.SaveOrder(order);
                paymentlist.Clear();
                return RedirectToAction("/PaymentFinalPage", new {OrderId = order.Id});

            }
            else
            {
                model.PaymentList = paymentlist;
                return View(model);
            }

        }

        public IActionResult PaymentFinalPage()
        {
            return View();
        }
 }

}