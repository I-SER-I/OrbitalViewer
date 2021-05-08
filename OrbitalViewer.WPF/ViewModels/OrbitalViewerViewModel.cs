using System;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using OrbitalViewer.Core.Models.Functions;
using OrbitalViewer.WPF.Models;
using OxyPlot;
using OxyPlot.Axes;

namespace OrbitalViewer.WPF.ViewModels
{
    public class OrbitalViewerViewModel : BaseViewModel
    {
        private PlotModel _scatterModel;
        private readonly string[] _letters = {"s", "p", "d", "f", "g", "h", "i", "j", "k"};
        private int _principalQuantumNumber;
        private int _orbitalQuantumNumber;
        private int _magneticQuantumNumber;
        private string _orbitalsNumber;
        private string _orbitalName;
        private string _electronsNumber;

        private bool IsQuantumNumberCorrect() =>
            _principalQuantumNumber >= 1 && _orbitalQuantumNumber >= 0 &&
            _orbitalQuantumNumber <= _principalQuantumNumber - 1 &&
            Math.Abs(_magneticQuantumNumber) <= _orbitalQuantumNumber;

        public string PrincipalQuantumNumber
        {
            set
            {
                if (int.TryParse(value, out int quantumNumber) && _principalQuantumNumber != quantumNumber)
                {
                    _principalQuantumNumber = quantumNumber;
                    OnPropertyChanged();
                }
            }
        }

        public string OrbitalQuantumNumber
        {
            set
            {
                if (int.TryParse(value, out int quantumNumber) && _orbitalQuantumNumber != quantumNumber)
                {
                    _orbitalQuantumNumber = quantumNumber;
                    OnPropertyChanged();
                }
            }
        }

        public string MagneticQuantumNumber
        {
            set
            {
                if (int.TryParse(value, out int quantumNumber) && _magneticQuantumNumber != quantumNumber)
                {
                    _magneticQuantumNumber = quantumNumber;
                    OnPropertyChanged();
                }
            }
        }

        public string OrbitalsNumber
        {
            get => _orbitalsNumber;
            set
            {
                if (_orbitalsNumber != value)
                {
                    _orbitalsNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        public string OrbitalName
        {
            get => _orbitalName;
            set
            {
                if (_orbitalName != value)
                {
                    _orbitalName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ElectronsNumber
        {
            get => _electronsNumber;
            set
            {
                if (_electronsNumber != value)
                {
                    _electronsNumber = value;
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
                return new RelayCommand(() =>
                {
                    if (IsQuantumNumberCorrect())
                    {
                        PlotModel plotModel = new PlotModel
                        {
                            Title = "Electrons probability density",
                        };
                        plotModel.Axes.Add(new LinearColorAxis
                        {
                            Palette = OxyPalettes.Jet(1024),
                            Key = "Meter",
                        });
                        var waveFunction = new WaveFunction(_principalQuantumNumber, _orbitalQuantumNumber,
                            _magneticQuantumNumber);
                        var heatMapPlot = new OrbitalViewerPlotModel(waveFunction).GetHeatMapPlot(1000);
                        plotModel.Series.Add(heatMapPlot);
                        ScatterModel = plotModel;
                        OrbitalsNumber = $"{2 * _orbitalQuantumNumber + 1}";
                        OrbitalName = $"{_principalQuantumNumber}{_letters[_orbitalQuantumNumber]}";
                        ElectronsNumber = $"{(2 * _orbitalQuantumNumber + 1) * 2}";
                    }
                });
            }
        }
    }
}