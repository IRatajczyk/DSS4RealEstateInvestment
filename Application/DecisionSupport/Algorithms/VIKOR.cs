using DecisionSystemForRealEastateInvestment.Application.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace DecisionSystemForRealEastateInvestment.Application.DecisionSupport.Algorithms
{


    public class VIKOR: IAlgorithm
    {
        public PreferenceManager PreferenceManager
        {
            set
            {
                preferenceWeights = new double[4];
                preferenceWeights[0] = value.AreaWeight;
                preferenceWeights[1] = value.PriceWeight;
                preferenceWeights[2] = value.RoomsCountWeight;
                preferenceWeights[3] = value.BathroomsCountWeight;
            }
        }
        private double[] preferenceWeights;


        public VIKOR(PreferenceManager preferenceManager)
        {
            preferenceWeights = new double[4];
            preferenceWeights[0] = preferenceManager.AreaWeight;
            preferenceWeights[1] = preferenceManager.PriceWeight;
            preferenceWeights[2] = preferenceManager.RoomsCountWeight;
            preferenceWeights[3] = preferenceManager.BathroomsCountWeight;
        }

        public List<DataModel> GetBestOfferts(List<DataModel> dataModels)
        {
            double[,] data = new double[dataModels.Count, 4];
            for (int i = 0; i < dataModels.Count; i++)
            {
                double[] temp = dataModels[i].Serialized;
                data[i, 0] = temp[0];
                data[i, 1] = temp[1];
                data[i, 2] = temp[2];
                data[i, 3] = temp[3];
            }

            double[] minValues = GetMinValues(data);
            double[] maxValues = GetMaxValues(data);

            double[,] normData = NormalizeData(data, minValues, maxValues);

            double[,] weightedData = WeightData(normData);

            double[] S = Calculate(weightedData, minimum: true);
            double[] R = Calculate(weightedData, minimum: false);

            S = NormalizeVector(S);
            R = NormalizeVector(R);

            double v = 0.5;

            double[] Q = CalculateQValues(S, R, v);

            var sortedIndices = Q.Select((value, index) => new { Value = value, Index = index })
                                .OrderByDescending(item => item.Value)
                                .Select(item => item.Index)
                                .ToList();

            var sortedQValues = Q.OrderByDescending(x => x).ToList();

            return sortedIndices.Select(index => dataModels[index]).ToList();

        }

        double[] Calculate(double[,] vector, bool minimum = true)
        {
            double[] result = new double[vector.GetLength(0)];
            for (int i = 0; i < vector.GetLength(1); i++)
            {
                double extremum = minimum ? double.MaxValue : double.MinValue;
                for (int j = 0; j < vector.GetLength(1); j++)
                {
                    if (minimum ? vector[i,j] < extremum : vector[i, j] > extremum)
                    {
                        extremum = vector[i, j];
                    }
                }
                result[i] = extremum;
            }
            return result;
        }

        private double[] GetMinValues(double[,] matrix)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                             .Select(i => Enumerable.Range(0, matrix.GetLength(0))
                                                   .Select(j => matrix[j, i])
                                                   .Min())
                             .ToArray();
        }

        private double[] GetMaxValues(double[,] matrix)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                             .Select(i => Enumerable.Range(0, matrix.GetLength(0))
                                                   .Select(j => matrix[j, i])
                                                   .Max())
                             .ToArray();
        }

        private double[,] NormalizeData(double[,] matrix, double[] minValues, double[] maxValues)
        {
            double[,] normMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    normMatrix[i, j] = (matrix[i, j] - minValues[j]) / (maxValues[j] - minValues[j]);
                }
            }

            return normMatrix;
        }

        private double[,] WeightData(double[,] matrix)
        {
            double[,] resultMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    resultMatrix[i, j] = matrix[i, j] * preferenceWeights[j];
                }
            }

            return resultMatrix;
        }

        private double[] NormalizeVector(double[] vector)
        {
            double min = vector.Min();
            double max = vector.Max();
            return vector.Select(value => (value - min) / (max - min + 1e-6)).ToArray();
        }

        private double[] CalculateQValues(double[] S, double[] R, double v)
        {
            return Enumerable.Range(0, S.Length)
                             .Select(i => v * S[i] + (1 - v) * R[i])
                             .ToArray();
        }
    }

}
