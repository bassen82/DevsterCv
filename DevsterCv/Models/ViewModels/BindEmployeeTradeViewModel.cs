using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class BindEmployeeTradeViewModel
    {
        public List<TradeViewModel> Trades { get; set; }
        public BindEmployeeTradeViewModel(List<TradeViewModel> tradeviewmodel)
        {
            Trades = tradeviewmodel;
        }

        public BindEmployeeTradeViewModel()
        {
        }

    }
}
