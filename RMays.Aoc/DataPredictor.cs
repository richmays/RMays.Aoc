using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc
{
    public class DataPredictorResult
    {
        public bool HasPrediction { get; set; }
        public decimal Prediction { get; set; } = 0m;

        public DataPredictorResult() { }
    }

    public class DataPredictor
    {
        private SortedDictionary<long, decimal> Dict;
        private long FinalIndex;

        public DataPredictor(long finalIndex)
        {
            Dict = new SortedDictionary<long, decimal>();
            FinalIndex = finalIndex;
        }

        public void AddData(int index, decimal value)
        {
            if (Dict.ContainsKey(index))
            {
                Dict[index] = value;
            }
            else
            {
                Dict.Add(index, value);
            }
        }

        public DataPredictorResult Predict()
        {
            // 4 seems to be the magic number to get the fastest accurate results.  Depends on the data though.
            return Predict(4);
        }

        public DataPredictorResult Predict(int elementsToCheck)
        {
            var result = LinearPredict(elementsToCheck);
            if (result.HasPrediction)
            {
                return result;
            }

            return QuadraticPredict();
        }

        private DataPredictorResult LinearPredict(int elementsToCheck)
        {
            // Check the last X elements, then use that to predict what value is at 'FinalIndex'.
            // Then, check the last (X-1) elements; if we get a different value, don't return anything.
            // Continue until we check the last two elements.  If all predictions are the same, return the prediction.

            if (Dict.Count < elementsToCheck)
            {
                // Not enough elements in the dictionary to make a good prediction.
                return GetFailedPrediction();
            }

            // What can we assume?  Will all indexes in the dictionary be sequential?
            // Will there be any gaps?  I don't think we can assume anything about the indexes.  We might start at 0, or -100, or 90,000.
            // Get the latest index.
            var keys = Dict.Keys.ToList();

            long lastKey;
            decimal lastValue;
            lastKey = keys[keys.Count - 1];
            Dict.TryGetValue(lastKey, out lastValue);

            int prevKeyIndexDiff = elementsToCheck;
            decimal? bestPrediction = null;
            while (prevKeyIndexDiff > 1)
            {
                long prevKey;
                decimal prevValue;
                prevKey = keys[keys.Count - prevKeyIndexDiff];
                Dict.TryGetValue(prevKey, out prevValue);

                decimal currPrediction = GetSamplePrediction(prevKey, prevValue, lastKey, lastValue, FinalIndex);
                if (bestPrediction.HasValue && bestPrediction != currPrediction)
                {
                    // Jump out; they're different.
                    return GetFailedPrediction();
                }

                bestPrediction = currPrediction;
                prevKeyIndexDiff--;
            }

            return new DataPredictorResult { HasPrediction = true, Prediction = bestPrediction ?? 0m };
        }

        private DataPredictorResult QuadraticPredict()
        {
            // Check ALL combinations of the last 4 elements (4 combos total), then use that to predict what value is at 'FinalIndex'.
            // If all 4 combos give the same A, B, C values for y = Ax^2 + Bx + C ,
            //   then use A, B, and C to solve for Y where X is the 'FinalIndex'.

            if (Dict.Count < 4)
            {
                // Not enough elements in the dictionary to make a good prediction.
                return GetFailedPrediction();
            }

            var keys = Dict.Keys.ToList();

            var points = new List<Tuple<long, decimal>>();
            for (int i = 4; i >= 1; i--)
            {
                points.Add(new Tuple<long, decimal>(keys[keys.Count - i], Dict[keys[keys.Count - i]]));
            }

            // Given 3 points, what is A, B, and C for the quadratic equation that passes through those points?
            var result1 = GetQuadTermsFromPoints(points[0], points[1], points[2]);
            var result2 = GetQuadTermsFromPoints(points[0], points[1], points[3]);
            var result3 = GetQuadTermsFromPoints(points[0], points[2], points[3]);
            var result4 = GetQuadTermsFromPoints(points[1], points[2], points[3]);

            var finalResult1 = decimal.Round(result1.Item1 * (FinalIndex * FinalIndex) + result1.Item2 * FinalIndex + result1.Item3, 4);
            var finalResult2 = decimal.Round(result2.Item1 * (FinalIndex * FinalIndex) + result2.Item2 * FinalIndex + result2.Item3, 4);
            var finalResult3 = decimal.Round(result3.Item1 * (FinalIndex * FinalIndex) + result3.Item2 * FinalIndex + result3.Item3, 4);
            var finalResult4 = decimal.Round(result4.Item1 * (FinalIndex * FinalIndex) + result4.Item2 * FinalIndex + result4.Item3, 4);

            if (finalResult1 == finalResult2 && finalResult1 == finalResult3 && finalResult1 == finalResult4)
            {
                return new DataPredictorResult { HasPrediction = true, Prediction = finalResult1 };
            }

            return GetFailedPrediction();
        }

        private Tuple<decimal, decimal, decimal> GetQuadTermsFromPoints(Tuple<long, decimal> Point1, Tuple<long, decimal> Point2, Tuple<long, decimal> Point3)
        {
            long x1 = Point1.Item1;
            decimal y1 = Point1.Item2;
            long x2 = Point2.Item1;
            decimal y2 = Point2.Item2;
            long x3 = Point3.Item1;
            decimal y3 = Point3.Item2;

            // HOLY CRAP IT WORKS.  there's some rounding issues.  nothing we can't deal with.
            decimal F = 2 * x1 * x1 - (x2 * x2) - (x3 * x3);
            decimal E = (-2 * x1 + x2 + x3) / F;
            decimal D = (2 * y1 - y2 - y3) / F;
            decimal B = ((y3 - y1) - D * (x3 * x3 - x1 * x1)) / (E * (x3 * x3 - x1 * x1) + (x3 - x1));
            decimal A = D + E * B;
            decimal C = y1 - (A * x1 * x1 + B * x1);

            return new Tuple<decimal, decimal, decimal>(A, B, C);
        }

        private decimal GetSamplePrediction(long startX, decimal startY, long endX, decimal endY, long finalX)
        {
            decimal slope = (endY - startY) / (endX - startX);
            decimal yIntercept = startY - (startX * slope);

            return (FinalIndex * slope) + yIntercept;
        }

        private bool CloseEnough(decimal item1, decimal item2)
        {
            return Math.Abs(item1 - item2) < 0.000001m; // Might need to change this.
        }


        private DataPredictorResult GetFailedPrediction()
        {
            return new DataPredictorResult { HasPrediction = false };
        }
    }
}
