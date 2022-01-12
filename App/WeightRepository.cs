using System.Collections.Generic;

namespace App
{
    public class WeightRepository : IDataRepository
    {
        public IEnumerable<WeightCalculator> Weights { get; private set; }
        public WeightRepository()
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
