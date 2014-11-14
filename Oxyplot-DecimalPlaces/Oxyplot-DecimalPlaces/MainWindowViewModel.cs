using System;
using System.Collections.Generic;
using System.IO;
using OxyPlot;
using OxyPlot.Series;

namespace Oxyplot_DecimalPlaces
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Data = ReadData();

            var lineSeries = new LineSeries();
            Data.ForEach(data => lineSeries.Points.Add(new DataPoint(data.X, data.Y)));

            PlotModel = new PlotModel();
            PlotModel.Series.Add(lineSeries);
        }

        private List<Data> Data { get; set; }

        public PlotModel PlotModel { get; private set; }

        private List<Data> ReadData()
        {
            var data = new List<Data>();

            using (var streamReader = new StreamReader("VehicleSpeed-CumulativeDistributionFunction.csv"))
            {
                string recordLine;
                while (!string.IsNullOrEmpty(recordLine = streamReader.ReadLine()))
                {
                    string[] records = recordLine.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
                    double x = Convert.ToDouble(records[0]);
                    double y = Convert.ToDouble(records[1]);

                    data.Add(new Data(x, y));
                }
            }

            return data;
        }
    }

    public class Data
    {
        public Data(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}