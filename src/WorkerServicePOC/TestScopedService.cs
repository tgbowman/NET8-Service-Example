using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServicePOC
{
    internal class TestScopedService
    {
        private readonly TestVisitPaymentService _visitPaymentService;

        public TestScopedService(TestVisitPaymentService visitPaymentService)
        {
            _visitPaymentService = visitPaymentService;
        }

        public async Task ProcessPayment(string message)
        {
            Console.WriteLine($"Processing payment for {message} from {this.GetHashCode()}");

            await Task.Delay(0);

            _visitPaymentService.PostPayment();

        }
    }
}
