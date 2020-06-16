﻿using Model.Director;
using Model.Doctor;
using Model.Dto;
using Model.PatientSecretary;
using Model.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HCIproject
{
    public partial class SideBar : Window, INotifyPropertyChanged
    {
        public Doctor user;
        public string Naslov { get; set; }
         public List<ExaminationDTO> upcomingExaminations { get; set; }
        public SideBar()
        {
            InitializeComponent();
            this.DataContext = this;
            setArticle();
            setDrug();
            setUpcomingExam();
        }
        public SideBar(Doctor _user)
        {
            InitializeComponent();
            this.DataContext = this;
            user = _user;
            setArticle();
            setDoctorsData();
            setDrug();
            upcomingExaminations = new List<ExaminationDTO>();


            setUpcomingExam();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        //pocetna stranica binduj imena


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            mainWin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {//otvara karton
            PatientFileWin fileWin = new PatientFileWin((Doctor)user);
            this.Visibility = Visibility.Hidden;
            fileWin.Show();
        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {//dodaj alternativni
            DrugAlternative drugAltWind = new DrugAlternative((Doctor)user);
          //  this.Visibility = Visibility.Hidden;
            drugAltWind.ShowDialog();
        }

        private void myGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //MyTabControl.Height = this.ActualHeight - 100;
            misljenje.Height = this.ActualHeight - 300;
            misljenje.Width = this.ActualHeight - 80;

            //utisakGrid.Height = this.ActualHeight - 40;
            //izmenaGrid.Height = this.ActualHeight - 40;
            //evidencijaGrid.Height = this.ActualHeight - 40;
            //kartoniGrid.Height = this.ActualHeight - 40;
            //pregledGrid.Height = this.ActualHeight - 40;
            //clanciGrid.Height = this.ActualHeight - 40;
            //pocetnaGrid.Height = this.ActualHeight - 40;
        }

        private string _testImePrz;
        private string _testSpec;
        private string _testEmail;
        private string _testPhoneNum;
        private string _testJMBG;
        public string TestImePrezime
        {
            get
            {
                return _testImePrz;
            }
            set
            {
                if (value != _testImePrz)
                {
                    _testImePrz = value;
                    OnPropertyChanged("TestImePrezime");
                }
            }
        }

        public string TestSpec
        {
            get
            {
                return _testSpec;
            }
            set
            {
                if (value != _testSpec)
                {
                    _testSpec = value;
                    OnPropertyChanged("TestSpec");
                }
            }
        }

        public string TestEmail
        {
            get
            {
                return _testEmail;
            }
            set
            {
                if (value != _testEmail)
                {
                    _testEmail = value;
                    OnPropertyChanged("TestEmail");
                }
            }
        }

        public string TestPhoneNumber
        {
            get
            {
                return _testPhoneNum;
            }
            set
            {
                if (value != _testPhoneNum)
                {
                    _testPhoneNum = value;
                    OnPropertyChanged("TestPhoneNumber");
                }
            }
        }

        public string TestJMBG
        {
            get
            {
                return _testJMBG;
            }
            set
            {
                if (value != _testJMBG)
                {
                    _testJMBG = value;
                    OnPropertyChanged("TestJMBG");
                }
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {//posalji izmene

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {//sacuvaj lozinku
         //TODO provera da li je dobra stara sifra
            if (NovaLozTxt.Password != PotvNovaLozTxt.Password)
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(199, 24, 24));
                obavesti.Text = "Unos se ne poklapa.Pokusajte ponovo.";
            }
            else
            {
                obavesti.Foreground = new SolidColorBrush(Color.FromRgb(64, 85, 81));

                obavesti.Text = "Uspešno ste promenili lozinku.";
                NovaLozTxt.Password = "";
                PotvNovaLozTxt.Password = "";
            }
        }


        private void Button_Click_7(object sender, RoutedEventArgs e)
        {//novi clanak
            CreateArticle creWin = new CreateArticle((Doctor)user);
         //   this.Visibility = Visibility.Hidden;
            creWin.ShowDialog();
        }

        private void setDoctorsData()
        {

            var app = Application.Current as App;

            ImePrzSet.Text = user.FirstName + " " + user.LastName;
            Speciality spec= app.SpecialityController.Get(user.Specialty.Id);
            SpecSet.Text = spec.Name;
            DatSet.Text = user.DateOfBirth.ToString();
            JmbgSet.Text = user.Jmbg.ToString();
            EmailSet.Text = user.Email;
            TelSet.Text = user.Phone;
            AdrSet.Text = user.Address.GetFullAddress();

        }

        //clanci
        private void setArticle()
        {
            var app = Application.Current as App;


            foreach (var article in app.ArticleController.GetAll())
            {

                Border b = new Border();
                b.BorderThickness = new Thickness(5);
                b.CornerRadius = new CornerRadius(5);
                b.BorderBrush = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                b.Margin = new Thickness(10, 10, 10, 10);

                StackPanel stackPanelArticle = new StackPanel();
                TextBlock newTopic = new TextBlock();
                TextBlock newText = new TextBlock();
                TextBlock writer = new TextBlock();

                newTopic.TextWrapping = TextWrapping.Wrap;
                newTopic.FontSize = 12;
                newTopic.FontWeight = FontWeights.Bold;
                newTopic.MaxWidth = 700;
                newTopic.HorizontalAlignment = HorizontalAlignment.Center;
                newText.TextWrapping = TextWrapping.Wrap;
                newText.FontSize = 10;
                newText.MaxWidth = 700;
                writer.FontSize = 8;
                writer.HorizontalAlignment = HorizontalAlignment.Right;


                newTopic.Text = article.Topic;
                
                writer.Text =user.FirstName + " " + user.LastName;
                newText.Text = article.Text;

                stackPanelArticle.Children.Add(newTopic);
                stackPanelArticle.Children.Add(writer);
                stackPanelArticle.Children.Add(newText);

                b.Child = stackPanelArticle;

                Articles.Children.Add(b);

            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {//posalji utisak
            misljenje.Text = "";
        }

        private void search_article_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_article.Text == "Unesite parametar pretrage")
            {
                search_article.Text = "";
            }

        }

        private void search_article_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_article.Text == "")
                {
                    return;
                }
                else
                {
                    List<Article> findArticles = searchMyArticles(search_article.Text);
                    var artWind = new ArticleWin(findArticles);
                    artWind.ShowDialog();
                }
            }
        }

        private List<Article> searchMyArticles(String input)
        {
            var app = Application.Current as App;
            List<Article> articles = new List<Article>();
            foreach (var article in app.ArticleController.GetAll())
            {
                if (article.Topic.Contains(input))
                {
                    articles.Add(article);
                }
            }
            return articles;
        }

        private void search_patient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (search_patient.Text == "")
                {
                    return;
                }
                else
                {
                    //TODO resiti pretragu kartona!!
                }
            }
        }

        private void search_patient_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (search_patient.Text == "Pretraga")
            {
                search_patient.Text = "";
            }

        }

        private void LozTxt_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            obavesti.Text = "";
        }



        private void setDrug()
        {
            var app = Application.Current as App;
            DrugValidationPanel.Children.Clear();
            if (app.DrugController.GetNotApprovedDrugs().Count == 0)
            {
                Grid myGrid = new Grid();
                myGrid.Width = 250;
                //myGrid.Height = 300;
                myGrid.HorizontalAlignment = HorizontalAlignment.Left;
                myGrid.VerticalAlignment = VerticalAlignment.Center;

                ColumnDefinition colDef1 = new ColumnDefinition();
                myGrid.ColumnDefinitions.Add(colDef1);

                RowDefinition rowDef1 = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef1);
                Label lab = new Label();
                lab.Content = "Trenutno ne postoje lekovi za validiranje!";
                lab.FontSize = 12;
                Grid.SetRow(lab, 0);
                Grid.SetColumn(lab, 0);

                myGrid.Children.Add(lab);
                DrugValidationPanel.Children.Add(myGrid);
            }
            else
            {
                foreach (var drug in app.DrugController.GetNotApprovedDrugs())
                {
                    Grid myGrid = new Grid();
                    myGrid.Width = 250;
                    //   myGrid.Height = 100;
                    myGrid.HorizontalAlignment = HorizontalAlignment.Center;
                    myGrid.VerticalAlignment = VerticalAlignment.Center;

                    ColumnDefinition colDef1 = new ColumnDefinition();
                    ColumnDefinition colDef2 = new ColumnDefinition();
                    myGrid.ColumnDefinitions.Add(colDef1);
                    myGrid.ColumnDefinitions.Add(colDef2);

                    RowDefinition rowDef1 = new RowDefinition();
                    myGrid.RowDefinitions.Add(rowDef1);

                    TextBlock newDrug = new TextBlock();
                    newDrug.TextWrapping = TextWrapping.Wrap;
                    newDrug.FontSize = 16;
                    newDrug.FontWeight = FontWeights.Bold;
                    newDrug.HorizontalAlignment = HorizontalAlignment.Left;
                    newDrug.VerticalAlignment = VerticalAlignment.Center;
                    newDrug.Margin = new Thickness(20, 10, 10, 10);
                    newDrug.Foreground = new SolidColorBrush(Color.FromRgb(84, 96, 89));
                    newDrug.Text = drug.Name;
                    Grid.SetRow(newDrug, 0);
                    Grid.SetColumn(newDrug, 0);

                    var myButton = new Button();
                    myButton.Content = "Validiraj";
                    myButton.Width = 100;
                    myButton.Height = 30;
                    myButton.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                    Grid.SetColumn(myButton, 1);
                    Grid.SetRow(myButton, 0);
                    myButton.Tag = drug.Id;
                    myButton.Click += new RoutedEventHandler(ClickValidation);

                    myGrid.Children.Add(myButton);
                    myGrid.Children.Add(newDrug);


                    DrugValidationPanel.Children.Add(myGrid);


                }
            }
        }
        private void ClickValidation(object sender, RoutedEventArgs e)
        {//posalji utisak
            var DrugId = ((Button)sender).Tag;
            DrugValidations drugValWind = new DrugValidations((Doctor)user, (long)DrugId);
            // this.Visibility = Visibility.Hidden;
            drugValWind.ShowDialog();
            setDrug();
        }

        private void setUpcomingExam()
        {
            upcomingExaminations.Clear();
            //long id,String name, String surname, String jmbg, String email, String phone, DateTime birth, Address address, String username, String password, Bitmap img)
            Patient p1 = new Patient(1, "Pera", "Perić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p2 = new Patient(2, "Jovan", "Jovanović", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p3 = new Patient(3, "Marko", "Zoric", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p4 = new Patient(4, "Zoran", "Jovov", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p5 = new Patient(5, "Mila", "Mijić", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p6 = new Patient(6, "Jovana", "Zivković", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p7 = new Patient(7, "Bojana", "Blejic", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);
            Patient p8 = new Patient(8, "Strahinja", "Markoović", "213123123123", "sadsds@sadsa.com", "2312312312", new DateTime(), null, "DDD", "ddd", null);

            Period period1 = new Period(new DateTime(2020, 6, 20, 9, 20, 0));
            Period period2 = new Period(new DateTime(2020, 6, 20, 9, 40, 0));
            Period period3 = new Period(new DateTime(2020, 6, 20, 10, 20, 0));
            Period period4 = new Period(new DateTime(2020, 6, 20, 10, 0, 0));
            Period period5 = new Period(new DateTime(2020, 6, 19, 14, 20, 0));
            Period period6 = new Period(new DateTime(2020, 7, 19, 15, 20, 0));
            Period period7 = new Period(new DateTime(2020, 7, 19, 16, 40, 0));
            Period period8 = new Period(new DateTime(2020, 7, 19, 17, 20, 0));
            Period period9 = new Period(new DateTime(2020, 7, 19, 18, 0, 0));
            ExaminationDTO exam1 = new ExaminationDTO(p1, period1);
            ExaminationDTO exam2 = new ExaminationDTO(p2, period2);
            ExaminationDTO exam3 = new ExaminationDTO(p3, period3);
            ExaminationDTO exam4 = new ExaminationDTO(p4, period4);
            ExaminationDTO exam5 = new ExaminationDTO(p5, period5);
            ExaminationDTO exam6 = new ExaminationDTO(p6, period6);
            ExaminationDTO exam7 = new ExaminationDTO(p7, period7);
            ExaminationDTO exam8 = new ExaminationDTO(p8, period8);

            upcomingExaminations.Add(exam1);
            upcomingExaminations.Add(exam2);
            upcomingExaminations.Add(exam3);
            upcomingExaminations.Add(exam4);
            upcomingExaminations.Add(exam5);
            upcomingExaminations.Add(exam6);
            upcomingExaminations.Add(exam7);
            upcomingExaminations.Add(exam8);
            setView();
        }

        public void setView() { 
            foreach (var exam in upcomingExaminations)
            {
                Grid myGrid = new Grid();
              //  myGrid.Width =500 ;
               // myGrid.Height = 100;
                myGrid.HorizontalAlignment = HorizontalAlignment.Left;
                myGrid.VerticalAlignment = VerticalAlignment.Center;

                ColumnDefinition colDef1 = new ColumnDefinition();
                ColumnDefinition colDef2 = new ColumnDefinition();
                ColumnDefinition colDef3 = new ColumnDefinition();
              //  ColumnDefinition colDef4 = new ColumnDefinition();
                colDef1.Width = new GridLength(20, GridUnitType.Star);
                colDef2.Width = new GridLength(20, GridUnitType.Star);
                colDef3.Width = new GridLength(20, GridUnitType.Star);
                myGrid.ColumnDefinitions.Add(colDef1);
                myGrid.ColumnDefinitions.Add(colDef2);
                myGrid.ColumnDefinitions.Add(colDef3);
             //   myGrid.ColumnDefinitions.Add(colDef4);

                RowDefinition rowDef1 = new RowDefinition();
                myGrid.RowDefinitions.Add(rowDef1);

                TextBlock newPatient = new TextBlock();
               // newPatient.TextWrapping = TextWrapping.Wrap;
                newPatient.FontSize = 15;
                newPatient.FontWeight = FontWeights.Bold;
                newPatient.HorizontalAlignment = HorizontalAlignment.Left;
                newPatient.VerticalAlignment = VerticalAlignment.Center;
                newPatient.Margin = new Thickness(10,10,10, 0); 
                newPatient.Foreground = new SolidColorBrush(Color.FromRgb(84, 96, 89));
                newPatient.Text = exam.Patient.FirstName+" "+exam.Patient.LastName;
                Grid.SetRow(newPatient, 0);
                Grid.SetColumn(newPatient, 0);

                var myButton = new Button();
                myButton.Content = "Zapocni";
                myButton.Width = 100;
                myButton.Height = 30;
                myButton.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                myButton.Margin = new Thickness(10, 10, 15, 0);
   

                Grid.SetColumn(myButton, 1);
                Grid.SetRow(myButton, 0);
                myButton.Tag = exam.Patient.Id;
                myButton.Click += new RoutedEventHandler(ClickStartExamination);

                var myButton1 = new Button();
                myButton1.Content = "Otkazi";
                myButton1.Width = 100;
                myButton1.Height = 30;
                myButton1.Background = new SolidColorBrush(Color.FromRgb(162, 217, 206));
                myButton1.Margin = new Thickness(10, 10, 15, 0);

                Grid.SetColumn(myButton1, 2);
                Grid.SetRow(myButton1, 0);
                //    myButton.Tag = exam.Id;

                myGrid.Children.Add(newPatient);
                myGrid.Children.Add(myButton);
                myGrid.Children.Add(myButton1);



                Examinations.Children.Add(myGrid);
            }

            }

        private void ClickStartExamination(object sender, RoutedEventArgs e)
        {//posalji utisak
            var PatientId = ((Button)sender).Tag;
            ExaminationWin examWinn = new ExaminationWin((Doctor)user, (long)PatientId);
             this.Visibility = Visibility.Hidden;
            examWinn.Show();
        }


    }
}