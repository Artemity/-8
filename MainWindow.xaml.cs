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

namespace практика_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FatherWorker _fatherWorker1; // Переменная для хранения первого работника-отца.
        FatherWorker _fatherWorker2; // Переменная для хранения второго работника-отца.
        Workman _workmanFirst; // Переменная для хранения первого работника.
        Workman _workmanSecond; // Переменная для хранения второго работника.
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Программу подготовил студент группы ИСП-31 Лотаков Артемий\nПрактическая 8 Вариант 13\nСоздать интерфейс - человек. Создать классы - работник и работник-отец семейства. Классы должны включать конструкторы, функцию для формирования строки информации о работнике. Сравнение производить по фамилии.","О программе");
        }

        private void btn_Reset(object sender, RoutedEventArgs e)
        {
            name.Clear();
            surname.Clear();
            position.Clear();
            amountChildren.Clear();
            firstWorker.Clear();
            secondWorker.Clear();
        }

        private void btn_AddInfo(object sender, RoutedEventArgs e)
        {
            // Проверяет, не являются ли текстовые поля пустыми.
            if (name.Text != string.Empty && surname.Text != string.Empty && position.Text != string.Empty)
            {
                // Если не отмечено, что у работника есть дети
                if (childrenSelected.IsChecked == false)
                {
                    // Проверяет, выбран ли первый работник
                    if (firstCheck.IsChecked == true)
                    {
                        // Создает нового работника и отображает информацию в текстовом поле.
                        _workmanFirst = new Workman(name.Text, surname.Text, position.Text);
                        firstWorker.Text = _workmanFirst.EmployeeInformation();
                        _fatherWorker1 = null; // Сбрасывает второго работника-отца.
                    }
                    // Проверяет, выбран ли второй работник
                    if (secondCheck.IsChecked == true)
                    {
                        // Создает нового работника и отображает информацию в текстовом поле.
                        _workmanSecond = new Workman(name.Text, surname.Text, position.Text);
                        secondWorker.Text = _workmanSecond.EmployeeInformation();
                        _fatherWorker2 = null; // Сбрасывает второго работника-отца.
                    }
                }
                // Если указано, что у работника есть дети
                else
                {
                    // Проверяет, введено ли количество детей и является ли оно положительным
                    if (childrenSelected.IsChecked == true && int.TryParse(amountChildren.Text, out int children) == true && children > 0)
                    {
                        // Проверяет, выбран ли первый работник
                        if (firstCheck.IsChecked == true)
                        {
                            // Создает нового работника-отца и отображает информацию в текстовом поле.
                            _fatherWorker1 = new FatherWorker(name.Text, surname.Text, children, position.Text);
                            firstWorker.Text = _fatherWorker1.EmployeeInformation();
                            _workmanFirst = null; // Сбрасывает первого работника.
                        }
                        // Проверяет, выбран ли второй работник
                        if (secondCheck.IsChecked == true)
                        {
                            // Создает нового работника-отца и отображает информацию в текстовом поле.
                            _fatherWorker2 = new FatherWorker(name.Text, surname.Text, children, position.Text);
                            secondWorker.Text = _fatherWorker2.EmployeeInformation();
                            _workmanSecond = null; // Сбрасывает второго работника.
                        }
                    }
                    else
                        MessageBox.Show("Введены неверные данные"); // Сообщает об ошибке, если введены неверные данные.
                }
            }
            else
                MessageBox.Show("Введены неверные данные"); // Сообщает об ошибке, если поля пустые.
        }

        private void btn_CompareWorker(object sender, RoutedEventArgs e)
        {
            if (_workmanFirst != null && _workmanSecond != null)
            {
                if (_workmanFirst.CompareTo(_workmanSecond) == -1) { MessageBox.Show("Фамилии не равны"); } // Если фамилии различаются, возвращает -1.  
                if (_workmanFirst.CompareTo(_workmanSecond) == 0) { MessageBox.Show("Фамилии равны"); } // Если фамилии одинаковы, возвращает 0.
            }
            if (_workmanFirst != null && _fatherWorker2 != null)
            {
                if (_workmanFirst.CompareTo(_fatherWorker2) == -1) { MessageBox.Show("Фамилии не равны"); }
                if (_workmanFirst.CompareTo(_fatherWorker2) == 0) { MessageBox.Show("Фамилии равны"); }
            }
            if (_fatherWorker1 != null && _fatherWorker2 != null)
            {
                if (_fatherWorker1.CompareTo(_fatherWorker2) == -1) { MessageBox.Show("Фамилии не равны"); }
                if (_fatherWorker1.CompareTo(_fatherWorker2) == 0) { MessageBox.Show("Фамилии равны"); }
            }
            if (_fatherWorker1 != null && _workmanSecond != null)
            {
                if (_fatherWorker1.CompareTo(_workmanSecond) == -1) { MessageBox.Show("Фамилии не равны"); }
                if (_fatherWorker1.CompareTo(_workmanSecond) == 0) { MessageBox.Show("Фамилии равны"); }
            }
        }

        private void ChildrenChecked(object sender, RoutedEventArgs e)
        {
            // Если выбран флажок "Имеются дети", разрешает редактирование поля для ввода количества детей.
            if (childrenSelected.IsChecked == true)
            {
                amountChildren.IsEnabled = true; // Активирует поле для ввода количества детей.
            }
            else
                amountChildren.IsEnabled = false; // Деактивирует поле, если флажок не установлен.
            amountChildren.Clear(); // Очищает поле для ввода количества детей.
        }

        private void btn_ClearLines(object sender, RoutedEventArgs e)
        {
            name.Clear();
            surname.Clear();
            position.Clear();
            amountChildren.Clear();
        }

        private void btn_CloneWorker(object sender, RoutedEventArgs e)
        {
            // Если имеется информация о первом работнике и выбран флажок для него
            if (_workmanFirst != null && firstCheck.IsChecked == true)
            {
                _workmanSecond = (Workman)_workmanFirst.Clone();// Клонирует объект первого работника во второго.
                secondWorker.Text = _workmanSecond.EmployeeInformation();// Отображает информацию о втором работнике.
                _fatherWorker2 = null;// Сбрасывает данные второго работника-отца.
            }
            if (_workmanSecond != null && secondCheck.IsChecked == true)
            {
                _workmanFirst = (Workman)_workmanSecond.Clone();
                firstWorker.Text = _workmanFirst.EmployeeInformation();
                _fatherWorker1 = null;
            }
            if (_fatherWorker1 != null && firstCheck.IsChecked == true)
            {
                _fatherWorker2 = (FatherWorker)_fatherWorker1.Clone();
                secondWorker.Text = _fatherWorker2.EmployeeInformation();
                _workmanSecond = null;
            }
            if (_fatherWorker2 != null && secondCheck.IsChecked == true)
            {
                _fatherWorker1 = (FatherWorker)_fatherWorker2.Clone();
                firstWorker.Text = _fatherWorker1.EmployeeInformation();
                _workmanFirst = null;
            }
            if (_workmanFirst == null && _workmanSecond == null && _fatherWorker1 == null && _fatherWorker2 == null)
            {
                MessageBox.Show("Информация ни об одном из работников не заполнена", "Ошибка");
            }
        }
    }
}