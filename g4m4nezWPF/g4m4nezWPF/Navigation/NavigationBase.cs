﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace g4m4nez.GUI.WPF.Navigation
{
    public abstract class NavigationBase<TObject> : BindableBase where TObject : Enum
    {
        private readonly List<INavigatable<TObject>> _viewModels = new List<INavigatable<TObject>>();

        public INavigatable<TObject> CurrentViewModel
        {
            get;
            private set;
        }

        protected NavigationBase(){}

        public void Navigate(TObject type)
        {
            if (CurrentViewModel != null && CurrentViewModel.Type.Equals(type))
            {
                return;
            }

            INavigatable<TObject> viewModel = _viewModels.FirstOrDefault(navigatable => navigatable.Type.Equals(type));

            if (viewModel == null)
            {
                viewModel = CreateViewModel(type);
                _viewModels.Add(viewModel);
            }

            viewModel.ClearSensitiveData();
            CurrentViewModel = viewModel;
            RaisePropertyChanged(nameof(CurrentViewModel));
        }
        protected abstract INavigatable<TObject> CreateViewModel(TObject type);
    }
}
