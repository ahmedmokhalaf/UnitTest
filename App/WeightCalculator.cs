using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class WeightCalculator
    {
        private readonly IDataRepository repository;

        public double? Height { get;  set; }
        public char? Gander { get; set; }
        public WeightCalculator()
        {

        }
        public WeightCalculator(IDataRepository repository,  double? height, char? gander)
        {
            this.repository = repository;
            this.Height = height;
            this.Gander = gander;
        }


        public double GetIdealBodyWeight(char gander, double height)
        {
            switch (gander)
            {
                case 'm':
                    return (height - 100) - ((height - 150) / 4);
                case 'w':
                    return (height - 100) - ((height - 150) / 2);
                default:
                    throw new ArgumentException("The Gender Is Not Vaild");
            }
        }

        public List<double> GetIdealBodyWeightFromDataSource()
        {
            List<double> results = new List<double>();
            WeightRepository repo = new WeightRepository();
            IEnumerable<WeightCalculator> weights = repository.GetWeights();
            weights.ToList().ForEach(x => results.Add(x.GetIdealBodyWeight(x.Gander.Value,x.Height.Value)));
            return results;
        }

        public bool Validate()
        {
            return Gander == 'm' || Gander == 'w';
        }
    }
}
