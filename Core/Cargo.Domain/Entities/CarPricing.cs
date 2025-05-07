using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Domain.Entities
{
    public class CarPricing
    {
        public int CarPricingId { get; set; }

        public int CarId { get; set; }

        public Car Carr { get; set; }

        public int PricingId{ get; set; }

        public int Pricing { get; set; }

        public decimal Amount { get; set; }

    }
}
