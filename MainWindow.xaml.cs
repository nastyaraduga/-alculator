using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

namespace Сalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() //Конструктор приложения
        {
            InitializeComponent();
            foreach (UIElement el in MainRoot.Children) /* Цикл для добавления обработчика событий 
             foreach - цикл,  UIElement - класс, element объект, Children - дочерни объекта MainRoot */
            { if (el is Button) // Условие. El - объект для класса Button
                {
                    ((Button)el).Click += Button_Click;  // Обработчик события для кнопок. 
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e) //Создание метода Button который обрабатывает нажатие на кнопку
        {
            string str = (string)((Button)e.OriginalSource).Content; //Переменная str обращается к нажатию объекта для получения данных
            if (str == "AC") //Если текст на кнопке = AC 
                textLabel.Text = ""; // то отображается пустая строка
            else if (str == "=") // если текст на кнопке  =
            {
                string value = new DataTable().Compute(textLabel.Text,null).ToString(); /* string = тип данных, переменная value. 
            Внутрь переменной создаем объект на основе класса DateTable.
            И обращаемся к методу Compute для высчитывания матиматического решения. */
                textLabel.Text = value;

            }
            else
             textLabel.Text += str; // Отображние вывода значений

        }
    }
}
