using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevsterCv;
using DevsterCv.Models;
using DevsterCv.Service;
using DevsterCv.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace DevsterCv.Controllers
{
    public class EmployeeTradesController : Controller
    {
        public ActionResult Admin(int employeeid)
        {
            List<TradeViewModel> Tradeviewmodellist = new List<TradeViewModel>();
            List<Trade> employeetradelist = TradeService.GetByEmployee(employeeid);
            using var context = new SqlLiteContext();
            List<Trade> tradelist = context.Trades.ToList();

            foreach (Trade t in tradelist)
            {
                TradeViewModel tvm = new TradeViewModel();
                tvm.TradeId = t.TradeId;
                tvm.EmployeeId = employeeid;
                tvm.Name = t.Name;
                tvm.Connected = false;
                foreach (Trade te in employeetradelist)
                {
                    if (t.TradeId == te.TradeId)
                    {
                        tvm.Connected = true;
                    }
                }
                Tradeviewmodellist.Add(tvm);
            }
            var sortedlist = Tradeviewmodellist.OrderBy(foo => foo.Name).ToList();
            var model = new BindEmployeeTradeViewModel(sortedlist);
            return View(model);
        }


        public ActionResult Add(BindEmployeeTradeViewModel arv)
        {
            SqlLiteContext context = new SqlLiteContext();
            for (int i = 0; i < arv.Trades.Count(); i++)
            {
                var employeeTrade = context.EmployeeTrades.Where(a => a.EmployeeId == arv.Trades[i].EmployeeId && a.TradeId == arv.Trades[i].TradeId).FirstOrDefault();

                if (arv.Trades[i].Connected)
                {
                    if (employeeTrade == null)
                    {
                        var et = new EmployeeTrade();
                        et.EmployeeId = arv.Trades[i].EmployeeId;
                        et.TradeId = arv.Trades[i].TradeId;
                        var entity = context.EmployeeTrades.Add(et);
                        entity.State = EntityState.Added;
                    }
                }
                else
                {
                    if (employeeTrade != null)
                    {
                        var entity = context.EmployeeTrades.Remove(employeeTrade);
                        entity.State = EntityState.Deleted;
                    }
                }
            }

            context.SaveChanges();

            return RedirectToAction("Cv", "Home", new { id = arv.Trades[0].EmployeeId });
        }

    }
}
