using App;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestProject1
{
    public class FakeWeightRepository : IDataRepository
    {
        IEnumerable<WeightCalculator> Weights;
        public FakeWeightRepository()
        {
            Weights = new List<WeightCalculator>()
            {
                new WeightCalculator(null,175,'w'),
                new WeightCalculator(null,167,'m'),
                new WeightCalculator(null,182,'m')
            };
        }
        public IEnumerable<WeightCalculator> GetWeights()
        {
            return this.Weights;
        }
    }
}
