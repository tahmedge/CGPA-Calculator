using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace cgpa_calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinalResult : Page
    {
        EnterCgpa ob = new EnterCgpa();
        public static List<string> subjectandgrade = new List<string>();
        public FinalResult()
        {
            this.InitializeComponent();
          
          //  ListView1.Items.Clear();
            double sumgrades = 0.0;
            double sumcredits = 0;
            foreach(double i in EnterCgpa.gradecredit)
            {
                sumgrades += i;
            }
            foreach (double i in EnterCgpa.credits)
            {
                sumcredits += i;
            }
            double res = sumgrades/sumcredits;
          //  int tempres = 
            int tempres;
                tempres= Convert.ToInt32(res);
            res = Math.Round(res, 2);
            if (tempres == res)
                finalresulttext.Text = "Your GPA is " + res.ToString() + ".00";
            else
                finalresulttext.Text = "Your GPA is " + res.ToString(); 
           
            ListView1.FontSize = 600;
            int tempred  ;
            int f=0;
            foreach (string s in EnterCgpa.subjectnames)
            {
                tempres = Convert.ToInt32(EnterCgpa.grades.ElementAt(f));
                tempred = Convert.ToInt32(EnterCgpa.credits.ElementAt(f));
                string l;
                if (tempres == EnterCgpa.grades.ElementAt(f))
                {
                   // l = "Your  grade point  on  " + s + "  is     ->     " + EnterCgpa.grades.ElementAt(f).ToString() + ".00" + "\n" + "(" + "Credit " + EnterCgpa.credits.ElementAt(f).ToString()+")";
                    l = "Your  result  on  " + s + " :\nGrade Point  :  " + EnterCgpa.grades.ElementAt(f).ToString() + ".00" + "              " + " Credit  :  " + EnterCgpa.credits.ElementAt(f).ToString() + "";
                }
                else
                   // l = "Your  grade point  on  " + s + "  is     ->     " + EnterCgpa.grades.ElementAt(f).ToString() + "\n" + "(" + "Credit " + EnterCgpa.credits.ElementAt(f).ToString() + ")";
                    l = "Your  result  on  " + s + " :\nGrade Point  :  " + EnterCgpa.grades.ElementAt(f).ToString() + "              " + " Credit  :  " + EnterCgpa.credits.ElementAt(f).ToString() + "";
                if (tempred == EnterCgpa.credits.ElementAt(f))
                    l = l + ".00";
                l = l + "\n";
                subjectandgrade.Add(l);
                f++;
            }
            ListView1.ItemsSource = subjectandgrade;
           // ListView2.FontSize = 250;
           // ListView2.ItemsSource = EnterCgpa.grades;

        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
          EnterCgpa.  sumofgrade = 0.0;
          EnterCgpa.sumofcredits = 0.0;
          EnterCgpa.finalresult = 0.0;
          EnterCgpa.track = 1;
          EnterCgpa.maxtrack = 1;
          EnterCgpa.temptrack = 0;
            //   public static ArrayList a=new ArrayList();
          EnterCgpa.subjectnames.Clear();
          EnterCgpa.grades.Clear();
          EnterCgpa.credits.Clear();
          EnterCgpa.gradecredit.Clear();
          subjectandgrade.Clear();
          ListView1.ItemsSource = null;
          ListView1.Items.Clear();
      
    
        //  ListView1.Clear();
         // ListView1.DataSource = null; ListView1.DataBind();
            this.Frame.Navigate(typeof(Home));
        }
    }
}
