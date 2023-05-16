﻿using MyToDo.Common.Models;
using MyToDo.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MainViewModel:BindableBase
    {
        public MainViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();
            CreateMenuBar();
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            this.regionManager=regionManager;
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal!=null&&journal.CanGoBack)
                    journal.GoBack();
            });
            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null&&journal.CanGoForward)
                    journal.GoForward();
            });
        }

        private void Navigate(MenuBar obj)
        {
            if(obj==null||string.IsNullOrWhiteSpace(obj.NameSpace)) 
            {
                return;
            }
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal=back.Context.NavigationService.Journal;
            });

            
        }

        //用来做导航
        public DelegateCommand<MenuBar> NavigateCommand {  get; private set; }
        public DelegateCommand GoBackCommand {  get; private set; }
        public DelegateCommand GoForwardCommand {  get; private set; }

        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;
        private IRegionNavigationJournal journal;

        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }

        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon="Home", Title="首页", NameSpace="IndexView"});
            MenuBars.Add(new MenuBar() { Icon= "NotebookOutline", Title="待办事项", NameSpace="ToDoView"});
            MenuBars.Add(new MenuBar() { Icon= "NotebookPlus", Title="备忘录", NameSpace="MemoView"});
            MenuBars.Add(new MenuBar() { Icon= "Cog", Title="设置", NameSpace="SettingsView"});
        }

    }
}