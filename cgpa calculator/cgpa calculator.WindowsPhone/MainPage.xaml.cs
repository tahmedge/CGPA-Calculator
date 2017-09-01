using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace cgpa_calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
      
        public static int totaltheory = 0;
        public static int totallab = 0;
        public static int totaltheorylab = 0;
     
        public MainPage()
        {
            this.InitializeComponent();
           
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void errorsyntax()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("Only syntax from 0-9 are allowed");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }  
        private async void checknull()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("A field can not be empty");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }
        private async void shownull()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("No courses have been selected");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }  
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // String.IsNullOrEmpty(s)
            string s1 = theorytextbox.Text.ToString();
            string s2 = labtextbox.Text.ToString();
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
            {
                checknull();
            }
              
            else
            {
               string temp1=s1;
                string temp2 = s2;
                int l1 = temp1.Length;
                int l2 = temp2.Length;
                int flag1=0,flag2=0;
                for(int i=0;i<l1;i++)
                {
                    if(temp1[i]>'9'||temp1[i]<'0')
                    {
                        flag1=1;
                        break;
                    }
                }
                for(int i=0;i<l2;i++)
                {
                    if(temp2[i]>'9'||temp2[i]<'0')
                    {
                        flag2=1;
                        break;
                    }
                }
                if (flag1 != 1 && flag2 != 1)
                {
                    totaltheory = int.Parse(temp1);

                    totallab = int.Parse(temp2);
                    totaltheorylab = totaltheory + totallab;
                    if (totaltheorylab < 1)
                    {
                        shownull();
                    }
                    //  
                    else
                        this.Frame.Navigate(typeof(EnterCgpa));
                }
                else
                {
                    errorsyntax();
                }
               // this.Frame.Navigate(typeof(FinalResult));
            //    NavigationService.Navigate(new Uri("/entercgpa.xaml", UriKind.Relative));
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home));
        }
    }
}
