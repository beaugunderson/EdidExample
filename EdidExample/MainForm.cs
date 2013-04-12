using System;
using System.Windows.Forms;

namespace EdidExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            var screenSize = EdidHelper.ScreenSize();
            var screenResolution = EdidHelper.ScreenResolution();

            double horizontalDpi = screenResolution.Item1 / (screenSize.Item1 / 25.4);
            double verticalDpi = screenResolution.Item2 / (screenSize.Item2 / 25.4);

            double chosenDpi = Math.Round((horizontalDpi + verticalDpi) / 2);

            dimensionsTextBox.Text = String.Format("{0}mm x {1}mm", screenSize.Item1, screenSize.Item2);
            resolutionTextBox.Text = String.Format("{0}px x {1}px", screenResolution.Item1, screenResolution.Item2);

            dpiTextBox.Text = chosenDpi.ToString();
        }
    }
}