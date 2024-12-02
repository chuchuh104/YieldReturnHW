using System;
using System.Threading.Tasks;
using System.Windows;

namespace YieldDemo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(StartTextBox.Text, out int start) && int.TryParse(EndTextBox.Text, out int end))
            {
                var generator = new NumberGenerator();
                NumberListBox.Items.Clear();

                int totalNumbers = end - start + 1;
                ProgressIndicator.Maximum = totalNumbers;
                ProgressIndicator.Value = 0;

                foreach (var number in generator.GenerateNumbers(start, end))
                {
                    NumberListBox.Items.Add(number);
                    ProgressIndicator.Value++;

                    // Ждем для имитации асинхронного процесса
                    await Task.Delay(100);
                }

                MessageBox.Show("Генерация завершена!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите корректные числа.");
            }
        }
    }
}

