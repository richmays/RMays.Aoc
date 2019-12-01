using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.Aoc.Tests
{
    [TestFixture]
    public class DataPredictorTests
    {
        [Test]
        public void GoldenPath_Linear()
        {
            var myPredictor = new DataPredictor(10000000000);
            myPredictor.AddData(0, -1);
            myPredictor.AddData(1, 1);
            myPredictor.AddData(3, 5);
            myPredictor.AddData(4, 7);
            var result = myPredictor.Predict(4);
            Assert.IsTrue(result.HasPrediction);
            Assert.AreEqual(19999999999, result.Prediction);
        }

        [Test]
        public void GoldenPath_Quadratic()
        {
            var myPredictor = new DataPredictor(7);
            myPredictor.AddData(1, 1);
            myPredictor.AddData(2, 3);
            myPredictor.AddData(3, 6);
            myPredictor.AddData(4, 10);
            myPredictor.AddData(5, 15);
            myPredictor.AddData(6, 21);
            var result = myPredictor.Predict(4);
            Assert.IsTrue(result.HasPrediction);
            Assert.AreEqual(28, result.Prediction);
        }

        [Test]
        public void LotsOfPoints_Failure()
        {
            var myPredictor = new DataPredictor(100);
            myPredictor.AddData(1, -1);
            myPredictor.AddData(2, -2);
            myPredictor.AddData(3, -3);
            myPredictor.AddData(4, -4);
            myPredictor.AddData(5, 55); // Oops!  This data point means we can't find a good linear prediction.
            myPredictor.AddData(6, -6);
            var result = myPredictor.Predict(4);
            Assert.IsFalse(result.HasPrediction);
        }

        [Test]
        public void LotsOfPoints_Success()
        {
            var myPredictor = new DataPredictor(100);
            myPredictor.AddData(1, -1);
            myPredictor.AddData(2, -2);
            myPredictor.AddData(3, -3);
            myPredictor.AddData(4, -4);
            myPredictor.AddData(5, -5);
            myPredictor.AddData(6, -6);
            var result = myPredictor.Predict(5);
            Assert.IsTrue(result.HasPrediction);
            Assert.AreEqual(-100m, result.Prediction);
        }

    }
}
