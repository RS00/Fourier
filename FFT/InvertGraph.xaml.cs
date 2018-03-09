using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Fourier
{
    public partial class InvertGraph : Window
    {
        private ViewModels.InvertViewModel viewModel;
        private const int defaultVal = 8;
        public InvertGraph()
        {
            InitializeComponent();
            viewModel = new ViewModels.InvertViewModel();
            DataContext = viewModel;
            viewModel.UpdateDFT(defaultVal);
            viewModel.UpdateFFT(defaultVal);
            N1.Text = defaultVal.ToString();
            N2.Text = defaultVal.ToString();
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
            if ((sender as TextBox).Name == "N1")
            {
                viewModel.UpdateFFT(Int32.Parse(this.N1.Text.Length == 0 ? "1" : this.N1.Text));
            }
            else
            {
                viewModel.UpdateDFT(Int32.Parse(this.N2.Text.Length == 0 ? "1" : this.N2.Text));
            }
        }
    }
}
