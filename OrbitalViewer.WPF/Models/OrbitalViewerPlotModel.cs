using System;
using OrbitalViewer.Core.Models.Functions;
using OxyPlot;
using OxyPlot.Series;

namespace OrbitalViewer.WPF.Models
{
    public class OrbitalViewerPlotModel
    {
        private readonly WaveFunction _waveFunction;

        public OrbitalViewerPlotModel(WaveFunction waveFunction)
        {
            _waveFunction = waveFunction;
        }

        public HeatMapSeries GetHeatMapPlot(int size)
        {
            var data = new double[size * 2, size * 2];
            for (int i = -size; i < size; i++)
            {
                for (int j = -size; j < size; j++)
                {
                    var x = i * 5e-12;
                    var y = j * 5e-12;
                    var radius = Math.Sqrt(x * x + y * y);
                    var theta = Math.Atan2(radius, 0);
                    var phi = Math.Atan2(y, x);
                    data[i + size, j + size] = _waveFunction.GetValue(radius, theta, phi);
                }
            }

            return new HeatMapSeries()
            {
                X0 = -size,
                X1 = size,
                Y0 = -size,
                Y1 = size,
                Interpolate = true,
                Background = OxyColor.FromUInt32(4278192527),
                RenderMethod = HeatMapRenderMethod.Bitmap,
                Data = data
            };
        }
    }
}