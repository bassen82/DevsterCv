using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevsterCv;
using DevsterCv.Models;

namespace DevsterCv.Controllers
{
    public class TradesController : Controller
    {

        // GET: Trades
        public async Task<IActionResult> Index()
        {
             var context = new SqlLiteContext();
                return View(await context.Trades.OrderBy(foo => foo.Name).ToListAsync());
        }

        // GET: Trades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var trade = await context.Trades
                .FirstOrDefaultAsync(m => m.TradeId == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // GET: Trades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TradeId,Name")] Trade trade)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = false;

                using var context = new SqlLiteContext();
                var trades = context.Trades.ToList();
                foreach (var entity in trades)
                {
                    if (trade.Name == entity.Name)
                    {
                        duplicate = true;
                    }
                }
                if (!duplicate)
                {
                    context.Add(trade);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("Duplicate", new { name = trade.Name });
        }

        // GET: Trades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var trade = await context.Trades.FindAsync(id);
            if (trade == null)
            {
                return NotFound();
            }
            return View(trade);
        }

        // POST: Trades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TradeId,Name")] Trade trade)
        {
            if (id != trade.TradeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var context = new SqlLiteContext();
                    context.Update(trade);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradeExists(trade.TradeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trade);
        }

        // GET: Trades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var trade = await context.Trades
                .FirstOrDefaultAsync(m => m.TradeId == id);
            if (trade == null)
            {
                return NotFound();
            }

            return View(trade);
        }

        // POST: Trades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var context = new SqlLiteContext();
            var trade = await context.Trades.FindAsync(id);
            context.Trades.Remove(trade);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradeExists(int id)
        {
            var context = new SqlLiteContext();
            return context.Trades.Any(e => e.TradeId == id);
        }

        public IActionResult Duplicate(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
