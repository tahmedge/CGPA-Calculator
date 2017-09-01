using System;
using System.Collections;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
class CGPACAL
{
    public string Subject { get; set; }
    public int Grd { get; set; }
    public int Crd { get; set; }
}

namespace cgpa_calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EnterCgpa : Page
    {
        public static double sumofgrade = 0.0;
        public static double sumofcredits = 0.0;
        public static double finalresult = 0.0;
        public static int track = 1;
        public static int maxtrack = 1;
        public static int temptrack = 0;
     //   public static ArrayList a=new ArrayList();
        public static List<string> subjectnames = new List<string>();
        public static List<double> grades = new List<double>();
        public static List<double> credits = new List<double>();
        public static List<double> gradecredit = new List<double>();
      // string s=new string[100];
       //String s[]=new String[100];
        string[] s = new string[1000];
        public static int flag = 0;
        public EnterCgpa()
        {
            this.InitializeComponent();
            Backbtn.IsEnabled = false;
            if(track<=MainPage.totaltheory)
            {
                temptrack = track;
                gpatext.Text = "My grade point on Theory Course " + temptrack.ToString();
                credittext.Text = "Credit of Theory Course " + temptrack.ToString();
               subjectname.Text="Theory Course "+ temptrack.ToString();
            }
            else
            {
                temptrack = track-MainPage.totaltheory;
                gpatext.Text = "My grade point on Lab Course " + temptrack.ToString();
                credittext.Text = "Credit of Lab Course " + temptrack.ToString();
                subjectname.Text="Lab Course "+temptrack.ToString();
            }
           // trackbox.Text = track.ToString();
              
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          //  if(TextBox)
            if (track < maxtrack) flag = 1;
            else flag = 0;
            if (track > 1) Backbtn.IsEnabled = true;
         //   trackbox.Text = track.ToString();
            string s1, s2;
            
        //    else
            {
                s1 = grade.Text.ToString();
                s2 = credit.Text.ToString();
            }
            string temp1 = s1;
            string temp2 = s2;
            int l1 = temp1.Length;
            int l2 = temp2.Length;
            int flag1 = 0, flag2 = 0;
            int countdot1 = 0, countdot2 = 0;
            for (int i = 0; i < l1; i++)
            {
               
                    if (temp1[i] == '.')
                    {
                        countdot1++;
                        continue;
                    }
                 
            }
            for (int i = 0; i < l2; i++)
            {
                
                    if (temp2[i] == '.')
                    {
                        countdot2++;
                        continue;
                    }
                    
                
            }
            if (String.IsNullOrEmpty(s1) || String.IsNullOrEmpty(s2))
            {
                checknull();
            }
            else if(countdot1>1||countdot2>1)
            {
                doterror();
            }
            else
            {

                ++track;
                if (track == MainPage.totaltheorylab) Nextbtn.Content = "Confirm";
                else Nextbtn.Content = "Next";
                if (track > 1) Backbtn.IsEnabled = true;
              //  trackbox.Text = track.ToString();
                if (maxtrack < track) maxtrack++;
               temp1 = s1;
                double tempgrade = double.Parse(s1) * double.Parse(s2);
                
                sumofgrade = sumofgrade+tempgrade;
                 temp2 = s2;
                sumofcredits= sumofcredits+double.Parse(temp2);
               //  = totaltheory + totallab;
                //  
                if (flag == 0)
                {
                    subjectnames.Add(subjectname.Text.ToString());

                    grades.Add(double.Parse(grade.Text.ToString()));
                    credits.Add(double.Parse(credit.Text.ToString()));
                    double gc=double.Parse(grade.Text.ToString())*double.Parse(credit.Text.ToString());
                    gradecredit.Add(gc);
                }
                else
                {
                    subjectnames.RemoveAt(track-2);
                    subjectnames.Insert(track - 2, subjectname.Text.ToString());
                    grades.RemoveAt(track - 2);
                    grades.Insert(track - 2, double.Parse(grade.Text.ToString()));
                    credits.RemoveAt(track - 2);
                    credits.Insert(track - 2, double.Parse(credit.Text.ToString()));
                    double gc = double.Parse(grade.Text.ToString()) * double.Parse(credit.Text.ToString());
                    gradecredit.RemoveAt(track - 2);
                    gradecredit.Insert(track-2,gc);
                }
                // this.Frame.Navigate(typeof(FinalResult));
                //    NavigationService.Navigate(new Uri("/entercgpa.xaml", UriKind.Relative));
            }
            if (track >= maxtrack) flag = 0;
          
            if (track > MainPage.totaltheorylab)
            {
                finalresult=sumofgrade/sumofcredits;
               
                this.Frame.Navigate(typeof(FinalResult));
            }
            else if (track <= MainPage.totaltheory)
            {
                if (flag == 1)
                {
                    gpatext.Text = "My grade point on " + subjectnames.ElementAt(track - 1).ToString();
                    credittext.Text = "Credit of " + subjectnames.ElementAt(track - 1).ToString();
                    subjectname.Text = subjectnames.ElementAt(track - 1).ToString();
                    grade.Text=grades.ElementAt(track - 1).ToString();
                    credit.Text = credits.ElementAt(track - 1).ToString();

                }
                else
                {
                    temptrack = track;
                    gpatext.Text = "My grade point on " + subjectname.Text.ToString();
                    //"My GPA on Theory Course " + temptrack.ToString();
                    credittext.Text = "Credit of Theory Course " + temptrack.ToString();
                    subjectname.Text = "Theory Course " + temptrack.ToString();
                }
            }
            else
            {
                if (flag == 1)
                {
                    gpatext.Text = "My grade point on " + subjectnames.ElementAt(track - 1).ToString();
                    credittext.Text = "Credit of " + subjectnames.ElementAt(track - 1).ToString();
                    subjectname.Text = subjectnames.ElementAt(track - 1).ToString();
                    grade.Text = grades.ElementAt(track - 1).ToString();
                    credit.Text = credits.ElementAt(track - 1).ToString();

                }
                else
                {
                    temptrack = track - MainPage.totaltheory;
                    gpatext.Text = "My grade point on " + subjectname.Text.ToString();
                    //"My GPA on Lab Course " + temptrack.ToString();
                    credittext.Text = "Credit of Lab Course " + temptrack.ToString();
                    subjectname.Text = "Lab Course " + temptrack.ToString();
                }
                }
           // flag = 0;
           // this.InitializeComponent();
        }
        private async void doterror()
        {
            //Creating instance for the MessageDialog Class  
            //and passing the message in it's Constructor  
            MessageDialog msgbox = new MessageDialog("Syntax error");
            //Calling the Show method of MessageDialog class  
            //which will show the MessageBox  
            await msgbox.ShowAsync();
        }  
        private void subjectname_TextChanged(object sender, TextChangedEventArgs e)
        {
            gpatext.Text = "My grade point on " + subjectname.Text.ToString();
            credittext.Text = "Credit of " + subjectname.Text.ToString();

        }

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
           // if (flag == 0) maxtrack--;
            track--;
            Nextbtn.Content = "Next";
        //    trackbox.Text = track.ToString();
            if (track == 1) Backbtn.IsEnabled = false;
            flag = 1;
            subjectname.Text = subjectnames.ElementAt(track - 1);
            credit.Text = credits.ElementAt(track - 1).ToString();
            grade.Text = grades.ElementAt(track - 1).ToString() ;
            gpatext.Text = "My grade point on " + subjectname.Text.ToString();
            credittext.Text = "Credit of " + subjectname.Text.ToString();

            

        }

        private void Exit_Btn_Click(object sender, RoutedEventArgs e)
        {
                sumofgrade = 0.0;
                  sumofcredits = 0.0;
                finalresult = 0.0;
              track = 1;
            maxtrack = 1;
            temptrack = 0;
     //   public static ArrayList a=new ArrayList();
       subjectnames.Clear();
        grades.Clear();
     credits.Clear();
     gradecredit.Clear();
      // string s=new string[100];
       //String s[]=new String[100];
     
   flag = 0;
            this.Frame.Navigate(typeof(Home));
        }
    }
}
