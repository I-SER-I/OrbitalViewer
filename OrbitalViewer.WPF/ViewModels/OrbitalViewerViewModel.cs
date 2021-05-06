using System;
using System.Windows;
using System.Windows.Input;
using OrbitalViewer.Core.Models.Functions;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Uno.UI.Common;

namespace OrbitalViewer.WPF.ViewModels
{
    public class OrbitalViewerViewModel : BaseViewModel
    {
        private PlotModel _scatterModel;

        private int _principalQuantumNumber;
        private int _azimuthalQuantumNumber;
        private int _magneticQuantumNumber;

        public string PrincipalQuantumNumber
        {
            set
            {
                int newValue = int.Parse(value);
                if (_principalQuantumNumber != newValue)
                {
                    _principalQuantumNumber = newValue;
                    OnPropertyChanged();
                }
            }
        }

        public string AzimuthalQuantumNumber
        {
            set
            {
                int newValue = int.Parse(value);
                if (_azimuthalQuantumNumber != newValue)
                {
                    _azimuthalQuantumNumber = newValue;
                    OnPropertyChanged();
                }
            }
        }

        public string MagneticQuantumNumber
        {
            set
            {
                int newValue = int.Parse(value);
                if (_magneticQuantumNumber != newValue)
                {
                    _magneticQuantumNumber = newValue;
                    OnPropertyChanged();
                }
            }
        }

        public PlotModel ScatterModel
        {
            get => _scatterModel;
            set
            {
                if (_scatterModel != value)
                {
                    _scatterModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GetPlot
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    int Size = 500;
                    PlotModel plot = new PlotModel
                    {
                        Title = "HeatMap",
                        Background = OxyColor.FromUInt32(4278192527)
                    };
                    plot.Axes.Add(new LinearColorAxis
                    {
                        Palette = OxyPalettes.Jet(1024)
                    });

                    var data = new double[Size * 2, Size * 2];
                    var waveFunction = new WaveFunction(_principalQuantumNumber, _azimuthalQuantumNumber, _magneticQuantumNumber);
                    for (int i = -Size; i < Size; i++)
                    {
                        for (int j = -Size; j < Size; j++)
                        {
                            var x = i * 0.1;
                            var y = j * 0.1;
                            var radius = Math.Sqrt(x * x + y * y);
                            var theta = Math.Atan2(radius, 0);
                            var phi = Math.Atan2(y, x);
                            data[i + Size, j + Size] = waveFunction.GetValue(radius, theta, phi);
                        }
                    }

                    var series = new HeatMapSeries()
                    {
                        X0 = -Size,
                        X1 = Size,
                        Y0 = -Size,
                        Y1 = Size,
                        Interpolate = true,
                        RenderMethod = HeatMapRenderMethod.Bitmap,
                        Data = data
                    };

                    plot.Series.Add(series);
                    ScatterModel = plot;
                });
            }
        }
    }
}