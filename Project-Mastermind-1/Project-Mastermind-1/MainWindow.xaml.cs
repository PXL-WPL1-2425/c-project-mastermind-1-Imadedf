

using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection.Emit;


namespace project_MasterMind_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string[] colors = { "Red", "Yellow", "Orange", "White", "Green", "Blue" };
        private string[] generatedCode = new string[4];

        private void GenerateRandomCode()
        {
            Random random = new Random();
            for (int i = 0; i < generatedCode.Length; i++)
            {
                generatedCode[i] = colors[random.Next(colors.Length)];
            }
            // Toon de code in het titelvenster voor testdoeleinden
            this.Title = $"Mastermind - Geheime Code: {string.Join(", ", generatedCode)}";



        }
        public MainWindow()
        {
            InitializeComponent();
            InitializeComboBoxes();
            GenerateRandomCode();
        }
        private void InitializeComboBoxes()
        {
            foreach (var color in colors)
            {
                ComboBox1.Items.Add(color);
                ComboBox2.Items.Add(color);
                ComboBox3.Items.Add(color);
                ComboBox4.Items.Add(color);
            }
        }

        private void ValidateButton_Click(object sender, RoutedEventArgs e)
        {
            // Placeholder for validation logic
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not ComboBox comboBox)
                return;

            // Verkrijg de geselecteerde waarde als string
            string selectedColor = comboBox.SelectedItem as string;

            // Label opzoeken
            System.Windows.Controls.Label correspondingLabel = comboBox.Name switch
            {
                "ComboBox1" => Label1,
                "ComboBox2" => Label2,
                "ComboBox3" => Label3,
                "ComboBox4" => Label4,
                _ => null
            };

            if (correspondingLabel != null)
            {
                if (!string.IsNullOrEmpty(selectedColor))
                {
                    // Zet de achtergrondkleur van het Label
                    correspondingLabel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                    correspondingLabel.Content = ""; // Verwijder tekst
                }
                else
                {
                    // Reset naar standaard wanneer geen kleur is geselecteerd
                    correspondingLabel.Background = Brushes.Transparent;
                    correspondingLabel.Content = "Geen kleur gekozen";
                }





            }



        }
    }
}
