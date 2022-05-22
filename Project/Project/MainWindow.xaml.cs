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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace Project {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        //Создим StackPanel для размещение дополнительных кнопок, и разместим его по левому краю.
        StackPanel stackPanelButtons = new StackPanel() {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Stretch,
            Orientation = Orientation.Horizontal,
            Margin = new Thickness(4, 0, 0, 0)
        };
        //Дополнительная кнопка.
        Button infoButton = new Button() {
            Width = 26,
            Height = 28,
            Content = "i",
            FontFamily = new FontFamily("Webdings")
        };

        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            infoButton.Click += InfoButton_Click; //Устанавливем событие Click
            infoButton.Style = Template.Resources["CaptionButton"] as System.Windows.Style; //Установливаем стиль CaptionButton
            stackPanelButtons.Children.Add(infoButton); //Добавляем кнопку в StackPanel


            Grid PART_Content = Template.FindName("PART_Content", this) as Grid; //Ищем элемент PART_Content в текущем стиле
            WindowChrome.SetIsHitTestVisibleInChrome(stackPanelButtons, true); //Не забываем про WindowChrome
            PART_Content.Children.Add(stackPanelButtons); // Добавляем StackPanel в PART_Content;

        }

        private void InfoButton_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("Эта кнопак была создана динамически и добавлена в шапку загаловка данного окна.");
        }
    }
}
