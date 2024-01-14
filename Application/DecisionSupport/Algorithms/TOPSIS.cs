using DecisionSystemForRealEastateInvestment.Application.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DecisionSupport.Algorithms
{
    public class TOPSIS: IAlgorithm
    {
        public PreferenceManager PreferenceManager { set {
                preferenceWeights = new double[4];
                preferenceWeights[0] = value.AreaWeight;
                preferenceWeights[1] = -value.PriceWeight;
                preferenceWeights[2] = value.RoomsCountWeight;
                preferenceWeights[3] = value.BathroomsCountWeight;
                normalizeVector();
            } }
        private double[] preferenceWeights;
        public TOPSIS(PreferenceManager preferenceManager)
        {
            preferenceWeights = new double[4];
            preferenceWeights[0] = preferenceManager.AreaWeight;
            preferenceWeights[1] = -preferenceManager.PriceWeight;
            preferenceWeights[2] = preferenceManager.RoomsCountWeight;
            preferenceWeights[3] = preferenceManager.BathroomsCountWeight;
            normalizeVector();

        }
        private void normalizeVector(double epsilon = 1e-2)
        {
            double sum = 0;
            for (int i = 0; i < preferenceWeights.Length; i++)
            {
                sum += preferenceWeights[i] + epsilon;
            }
            for (int i = 0; i < preferenceWeights.Length; i++)
            {
                preferenceWeights[i] += epsilon;
                preferenceWeights[i] /= sum;
            }
        }

        public List<DataModel> GetBestOfferts(List<DataModel> dataModels)
        {
            double[,] data = new double[dataModels.Count, 4];
            for (int i = 0; i < dataModels.Count; i++)
            {
                double[] temp = dataModels[i].Serialized;
                data[i,0] = temp[0];
                data[i,1] = temp[1];
                data[i,2] = temp[2];
                data[i,3] = temp[3];
            }
            double[,] normMatrix = NormalizeMatrix(data);

            double[,] weightedMatrix = ApplyWeights(normMatrix);

            double[] idealSolution = GetMaxValues(weightedMatrix);
            double[] negativeIdealSolution = GetMinValues(weightedMatrix);

            double[] separationFromIdeal = CalculateSeparationFromIdeal(weightedMatrix, idealSolution);
            double[] separationFromNegativeIdeal = CalculateSeparationFromIdeal(weightedMatrix, negativeIdealSolution);

            double[] relativeCloseness = CalculateRelativeCloseness(separationFromIdeal, separationFromNegativeIdeal);

            var sortedIndices = relativeCloseness.Select((value, index) => new { Value = value, Index = index })
                                                .OrderByDescending(item => item.Value)
                                                .Select(item => item.Index)
                                                .ToList();


            List<DataModel> sortedDataModels = new();
            for (int i = 0; i < sortedIndices.Count; i++)
            {
                sortedDataModels.Add(dataModels[sortedIndices[i]]);
            }


            return sortedDataModels;

        }


        private double[,] NormalizeMatrix(double[,] matrix)
        {
            double[,] normMatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                double columnSum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    columnSum += Math.Pow(matrix[j, i], 2);
                }

                double columnNorm = Math.Sqrt(columnSum);

                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    normMatrix[j, i] = matrix[j, i] / columnNorm;
                }
            }

            return normMatrix;
        }

        private double[,] ApplyWeights(double[,] matrix)
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

        private double[] GetMaxValues(double[,] matrix)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                             .Select(i => Enumerable.Range(0, matrix.GetLength(0))
                                                   .Select(j => matrix[j, i])
                                                   .Max())
                             .ToArray();
        }

        private double[] GetMinValues(double[,] matrix)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                             .Select(i => Enumerable.Range(0, matrix.GetLength(0))
                                                   .Select(j => matrix[j, i])
                                                   .Min())
                             .ToArray();
        }

        private double[] CalculateSeparationFromIdeal(double[,] matrix, double[] idealSolution)
        {
            return Enumerable.Range(0, matrix.GetLength(0))
                             .Select(i => Math.Sqrt(Enumerable.Range(0, matrix.GetLength(1))
                                                            .Select(j => Math.Pow(matrix[i, j] - idealSolution[j], 2))
                                                            .Sum()))
                             .ToArray();
        }

        private double[] CalculateRelativeCloseness(double[] separationFromIdeal, double[] separationFromNegativeIdeal)
        {
            return Enumerable.Range(0, separationFromIdeal.Length)
                             .Select(i => separationFromNegativeIdeal[i] / (separationFromIdeal[i] + separationFromNegativeIdeal[i]))
                             .ToArray();
        }
    }
    }

