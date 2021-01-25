using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PizzaApp.Model;
using Xamarin.Forms;
  
namespace PizzaApp
{
     public partial class MainPage : ContentPage
    {

       


        public MainPage()
        {
            InitializeComponent();
             
         
            articlesListView.RefreshCommand = new Command((odj)=>
            {
 

                DowloadData((pizzas)  =>
                {
                    articlesListView.ItemsSource = pizzas;
                    articlesListView.IsVisible = true;  
                    articlesListView.IsRefreshing = false;

                }); 
           
            });
             
            articlesListView.IsVisible = false;
             waitingIndicator.IsVisible = true;


            DowloadData((pizzas) =>
            {
                articlesListView.ItemsSource = pizzas;
                articlesListView.IsVisible = true;
                waitingIndicator.IsVisible = false;
                 

            });




            articlesListView.ItemSelected += (sender, e) =>
            {

                if (articlesListView.SelectedItem != null)
                {
                    Pizza item = articlesListView.SelectedItem as Pizza;
                    DisplayAlert(item.Nom+" "+ item.PrixEuro, "" + item.IndregientsStr, "OK");

                    articlesListView.SelectedItem = null;
                }


            };
        }

        private void DowloadData(Action<List<Pizza>> action)
        {

            //url json from google drive
            String URL = "https://drive.google.com/uc?export=download&id=15kBwYKiSxpWAX2Ltcc0UtK0rLytz0rY7";


            using (var webClient = new WebClient())
            {


                webClient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                {
              try
                            {
                                string pizzaJson = e.Result;
                                List<Pizza>  pizzasJson = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);

                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    action.Invoke(pizzasJson);
                       
                                });
                 }
                            catch (Exception ex)
                            {
                                Device.BeginInvokeOnMainThread(() =>
                                {
                                    DisplayAlert("Erreur", ex.Message, "OK");
                                    return;
                                });

                }
                };


               

                    webClient.DownloadStringAsync(new Uri(URL));
           

            }
        }
    }
}
