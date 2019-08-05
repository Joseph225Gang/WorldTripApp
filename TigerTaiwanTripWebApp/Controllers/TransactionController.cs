using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TigerTaiwanTripDomain;
using TigerTaiwanTripWebService;

namespace TigerTaiwanTripWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        WorldTripRepository worldTripRepository;

        public TransactionController(WorldTripRepository worldTripRepository)
        {
            this.worldTripRepository = worldTripRepository;
        }

        [HttpPost("[action]")]
        public void Add(dynamic transaction)
        {
            Transaction addTransaction = new Transaction();
            addTransaction.MemberName = transaction.transaction.transaction.memberName;
            addTransaction.TripName = transaction.transaction.transaction.tripName;
            addTransaction.PaymentMethod = transaction.transaction.transaction.paymentMethod;
            addTransaction.AdultTicket = transaction.transaction.transaction.adultTicket;
            addTransaction.ChildTicket = transaction.transaction.transaction.childTicket;
            addTransaction.TotalAmount = transaction.transaction.transaction.totalAmount;
            this.worldTripRepository.AddTransaction(addTransaction);
        }

        [HttpGet("[action]")]
        public IEnumerable<Transaction> ShowTransactionInformation(string userName)
        {
            return worldTripRepository.ShowTransactionInformation(userName);
        }
    }
}