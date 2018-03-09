using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Fourier
{
    public partial class Graph : Window
    {
        private ViewModels.GraphViewModel viewModel;
        private const int defaultVal = 8;

        public Graph()
        {
            InitializeComponent();
            viewModel = new ViewModels.GraphViewModel();
            DataContext = viewModel;
            viewModel.UpdateGraph(defaultVal);
            N.Text = defaultVal.ToString();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
            base.OnPreviewKeyDown(e);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewModel.UpdateGraph(Int32.Parse(this.N.Text.Length == 0 ? "0" : this.N.Text));
        }
    }
}
