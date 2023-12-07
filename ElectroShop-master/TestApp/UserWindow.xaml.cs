using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.ToList();
            if(DataTransfer.userID != 0)
            {
                userNameBox.Content = DataTransfer.Name + " " + DataTransfer.Surname + " " + DataTransfer.Patronic;
            }
            else
            {
                userNameBox.Content = "Неавторизованный пользователь";
            }

            var allTypes = Travel_HubEntities.GetContext().Вид_номера.ToList();
            allTypes.Insert(0, new Вид_номера
            {
                Название = "Все типы"
            });

            ComboElectronicType.ItemsSource = allTypes;

            ComboElectronicType.SelectedIndex = 0;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var current = (Номер)ProductsListView.SelectedItem;
            //MessageBox.Show($"{current.id} {current.name}");
            BasketClass.addProduct((int)current.ID);
            this.checkBasketCount();
        }

        private void checkBasketCount()
        {
            btnClearBasket.Visibility = Visibility.Hidden;
            btnEnterBasket.Visibility = Visibility.Hidden;
            if (BasketClass.getBasket().Count > 0)
            {
                btnClearBasket.Visibility = Visibility.Visible;
                btnEnterBasket.Visibility = Visibility.Visible;
            }

        }

        private void userNameBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(DataTransfer.userID != 0)
            {
                UserOrdersWindow userOrders = new UserOrdersWindow();
                userOrders.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Авторизуйтесь в приложении и забронируйте, чтобы увидеть список ваших бронирований");
                return;
            }
        }

        private void СlearBasketButtonClick(object sender, RoutedEventArgs e)
        {
            BasketClass.ClearBasket();
            this.checkBasketCount();
        }

        private void ToBasketClick(object sender, RoutedEventArgs e)
        {
                BasketView basketView = new BasketView();
                basketView.Show();
                this.Close();
        }

        private void ComboElectronicType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboElectronicType.SelectedIndex)
            {
                case 0:
                    ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.ToList();
                    break;

                case 1:
                    ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.Where(u => u.Вид_номера == 1).ToList();
                    break;
                case 2:
                    ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.Where(u => u.Вид_номера == 2).ToList();
                    break;
                case 3:
                    ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.Where(u => u.Вид_номера == 3).ToList();
                    break;
                case 4:
                    ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.Where(u => u.Вид_номера == 4).ToList();
                    break;
                case 5:
                    ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.Where(u => u.Вид_номера == 5).ToList();
                    break;
            }
        }

        private void ElectroSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ProductsListView.ItemsSource = Travel_HubEntities.GetContext().Номер.Where(u => u.Наименование.Contains(ElectroSearch.Text)).ToList();
        }
    }
}
