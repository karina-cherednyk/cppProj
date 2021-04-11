﻿using g4m4nez.GUI.WPF.Navigation;
using System;

namespace g4m4nez.GUI.WPF.Authentication
{

    public class AuthViewModel : NavigationBase<AuthNavigatableTypes>, INavigatable<MainNavigatableTypes>
    {
        private readonly Action _signInSuccess;

        public AuthViewModel(Action signInSuccess)
        {
            _signInSuccess = signInSuccess;
            Navigate(AuthNavigatableTypes.SignIn);
        }


        protected override INavigatable<AuthNavigatableTypes> CreateViewModel(AuthNavigatableTypes type)
        {
            if (type == AuthNavigatableTypes.SignIn)
            {
                return new SignInViewModel(() => Navigate(AuthNavigatableTypes.SignUp), _signInSuccess);
            }
            else
            {
                return new SignUpViewModel(() => Navigate(AuthNavigatableTypes.SignIn));
            }

        }


        public MainNavigatableTypes Type => MainNavigatableTypes.Auth;

        public void ClearSensitiveData()
        {
            CurrentViewModel.ClearSensitiveData();
        }
    }
}
