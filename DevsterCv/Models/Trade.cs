using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Trade
    {
        [Key]
        [Display(Name = "Id")]
        public int TradeId { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }

        public virtual ICollection<EmployeeTrade> EmployeeTrades { get; set; }

        public List<TradeViewModel> GetTradeView(int employee)
        {
            List<TradeViewModel> TradeViewModels = new List<TradeViewModel>();
            List<Trade> targetData = TradeService.GetByEmployee(employee);

            if (targetData == null)
            {
                return TradeViewModels;
            }
            foreach (Trade target in targetData)
            {
                TradeViewModel evm = new TradeViewModel
                {
                    TradeId = target.TradeId,
                    Name = target.Name
                };

                TradeViewModels.Add(evm);
            }
            return TradeViewModels;
        }
    }
}
