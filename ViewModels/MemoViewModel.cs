using MyToDo.Common.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.ViewModels
{
    public class MemoViewModel:BindableBase
    {

        public MemoViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();
            CreateToDoList();
            AddCommand = new DelegateCommand(Add);
        }
        private bool isRigntDrawerOpen;

        /// <summary>
        /// 右侧窗口是否展开
        /// </summary>
        public bool IsRigntDrawerOpen
        {
            get { return isRigntDrawerOpen; }
            set { isRigntDrawerOpen = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加备忘录
        /// </summary>
        private void Add()
        {
            IsRigntDrawerOpen = true;
        }

        public DelegateCommand AddCommand { get; private set; }

        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; }
        }
        void CreateToDoList()
        {
            for (int i = 0; i < 20; i++)
            {
                MemoDtos.Add(new MemoDto()
                {
                    Title = "标题" + i,
                    Content = "测试数据..."

                });
            }
        }

    }
}
