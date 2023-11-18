﻿using Autofac;
using GestionBanque.Models.DataService;
using GestionBanque.ViewModels;
using System.Windows;


namespace GestionBanque.Views
{
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = FournisseurDI.Container.Resolve<MainViewModel>();
        }
    }
}
