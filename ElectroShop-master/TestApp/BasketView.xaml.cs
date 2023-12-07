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

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для BasketView.xaml
    /// </summary>
    public partial class BasketView : Window
    {
        private List<Номер> basketItems = new List<Номер>();
        public BasketView()
        {
            InitializeComponent();
            DeliveryInput.ItemsSource = Travel_HubEntities.GetContext().Офис.ToList();
            basketItems = new List<Номер>();
            foreach (int id in BasketClass.getBasket())
            {
                basketItems.Add(Travel_HubEntities.GetContext().Номер.Find(id));
            }
            BasketListView.ItemsSource = basketItems;
            updateResultSum();
        }
        private void updateResultSum()
        {
            resultSum.Content = $"Итого:{basketItems.Sum(product => product.Цена)}";

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.ComponentModel.IEditableCollectionView items = BasketListView.Items; //Cast to interface

            Номер selectedItem = BasketListView.SelectedItems[0] as Номер; // cast item to product

            BasketClass.Delete((int)selectedItem.ID); // remove product from basket


            items.Remove(BasketListView.SelectedItem); // remove product from listView



            updateResultSum();
        }

        private void SnapBackButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow window = new UserWindow();
            window.Show();
            this.Close();
        }

        private void MakeOrderButton_Click(object sender, RoutedEventArgs e)
        {
            if(DataTransfer.userID != 0)
            {
                if (MessageBox.Show($"Вы точно хотите забронировать", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (DeliveryInput.Text != null)
                    {
                        Бронирование orderData = new Бронирование();

                        int deliveryID = int.Parse(DeliveryInput.SelectedValue.ToString());

                        orderData.ID_пользователя = DataTransfer.userID;

                        orderData.ID_офиса = deliveryID;

                        orderData.Статус_заказа = 2;

                        Travel_HubEntities.GetContext().Бронирование.Add(orderData);

                        foreach (int id in BasketClass.getBasket())
                        {
                            Бронирование_Номер orderGoodData = new Бронирование_Номер();

                            Номер productID = new Номер();

                            productID = Travel_HubEntities.GetContext().Номер.Where(u => u.ID == id).FirstOrDefault();

                            orderGoodData.ID_бронирования = orderData.ID;

                            orderGoodData.ID_бронирования = productID.ID;

                            Travel_HubEntities.GetContext().Бронирование_Номер.Add(orderGoodData);
                        }
                        try
                        {
                            Travel_HubEntities.GetContext().SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        MessageBox.Show("Бронирование оформлено!");
                    }
                    else
                    {
                        MessageBox.Show("Выберите офис!");
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, авторизуйтесь, чтобы забронировать!");
                return;
            }
        }

        private void DeliveryInput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
