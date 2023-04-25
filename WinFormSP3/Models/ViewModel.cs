using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace WinFormSP1.Models
{
    public partial class ViewModel
    {
        protected static readonly SKColor s_gray = new(195, 195, 195);
        protected static readonly SKColor s_black = new(0, 0, 0);

        public Axis[] xAxes { get; set; }
        public Axis[] yAxes { get; set; }

        private ObservableCollection<ObservablePoint> _observableValues;

        public ObservableCollection<ISeries> Series { get; set; }

        public ViewModel()
        {
            // Use ObservableCollections to let the chart listen for changes (or any INotifyCollectionChanged). 
            _observableValues = new ObservableCollection<ObservablePoint> { };

            Series = new ObservableCollection<ISeries>
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _observableValues,
                    Fill = null,
                    GeometrySize = 0,
                    LineSmoothness = 0
                }
            };
            xAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Replications",
                    NamePaint = new SolidColorPaint(s_gray),
                    SeparatorsPaint = new SolidColorPaint
                        {
                            Color = s_gray,
                            StrokeThickness = 1,
                        }
                }

            };
            yAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Y-Axis",
                    NamePaint = new SolidColorPaint(s_gray),
                    SeparatorsPaint = new SolidColorPaint
                        {
                            Color = s_gray,
                            StrokeThickness = 1,
                        }
                }
            };

        }

        public void AddPoint(ObservablePoint new_point)
        {
            _observableValues.Add(new_point);          
        }

        public void Reset()
        {
            _observableValues.Clear();
        }

        public void SetYAxisName(string yName)
        {
            yAxes[0].Name = yName;
        }

        public void SetXAxisName(string xName)
        {
            xAxes[0].Name = xName;
        }
    }
}
