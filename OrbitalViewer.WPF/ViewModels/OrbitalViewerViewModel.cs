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

        private int _principalQuantumNumber;
        private int _orbitalQuantumNumber;
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

        public string OrbitalQuantumNumber
        {
            set
            {
                int newValue = int.Parse(value);
                if (_orbitalQuantumNumber != newValue)
                {
                    _orbitalQuantumNumber = newValue;
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
                return new RelayCommand(() =>
                {
                    PlotModel plotModel = new PlotModel
                    {
                        Title = "Electrons probability density"
                    };
                    plotModel.Axes.Add(new LinearColorAxis
                    {
                        Palette = OxyPalettes.Jet(1024)
                    });
                    var waveFunction = new WaveFunction(_principalQuantumNumber, _orbitalQuantumNumber, _magneticQuantumNumber);
                    var heatMapPlot = new OrbitalViewerPlotModel(waveFunction).GetHeatMapPlot(1000);
                    plotModel.Series.Add(heatMapPlot);
                    ScatterModel = plotModel;
                });
            }
        }
    }
}