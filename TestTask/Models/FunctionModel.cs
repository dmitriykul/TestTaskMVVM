using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using TestTask.ViewModels;

namespace TestTask.Models
{
    /// <summary>Используется для задания именованной функции от двух параметров.</summary>
    public class FunctionModel
    {
        /// <summary>Имя Функции.</summary>
        public string Name { get; }

        /// <summary>Делегат Функции.</summary>
        public Func<double, double, double> Function { get; }

        /// <summary>Коэффициент A.</summary>
        public double A { get; set; }

        /// <summary>Коэффициент B.</summary>
        public double B { get; set; }

        /// <summary>Коэффициент C.</summary>
        public double C { get; set; }

        public IReadOnlyList<double> Arguments { get; }

        /// <summary>Строки вычисленных значений.</summary>
        public ObservableCollection<FunctionRowTable> CalculatedFunctions { get; }
            = new ObservableCollection<FunctionRowTable>();

        private void OnRowsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Добавление выбранной Функции в новую строку.
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (FunctionRowTable row in e.NewItems)
                {
                    row.SetFunction(this);
                }
        }

        /// <summary>Создаёт экземпляр <see cref="FunctionModel"/>.</summary>
        /// <param name="name">Имя Функции.</param>
        /// <param name="function">Делегат Функции.</param>
        public FunctionModel(string name, IEnumerable<double> arguments, Func<double, double, double, double, double, double> function)
        {
            Name = name;
            Arguments = arguments.ToList().AsReadOnly();
            this.function = function ?? throw new ArgumentNullException(nameof(function));
            Function = Calculate;

            CalculatedFunctions.CollectionChanged += OnRowsChanged;
        }
        private readonly Func<double, double, double, double, double, double> function;
        private double Calculate(double x, double y)
            => function(A, B, C, x, y);
    }
}
