using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class AmplitudeFrequencyGraph : Window
    {
        private ViewModels.AmplitudeFrequencyViewModel viewModel;
        private const int defaultVal = 8;

        public AmplitudeFrequencyGraph()
        {
            InitializeComponent();

            viewModel = new ViewModels.AmplitudeFrequencyViewModel();
            DataContext = viewModel;
            int c1 = viewModel.UpdateFFT(defaultVal);
            Count1.Text = c1.ToString();
            int c2 = viewModel.UpdateDFT(defaultVal);
            Count2.Text = c2.ToString();
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
                int c1 = viewModel.UpdateFFT(Int32.Parse(this.N1.Text.Length == 0 ? "1" : this.N1.Text));
                Count1.Text = c1.ToString();
            }
            else
            {
                int c2 = viewModel.UpdateDFT(Int32.Parse(this.N2.Text.Length == 0 ? "1" : this.N2.Text));
                Count2.Text = c2.ToString();
            }
        }
    }
}
