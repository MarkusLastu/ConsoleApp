using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using GrupparbeteVecka4.Commands;
using Microsoft.Maui.Controls;

namespace GrupparbeteVecka4.ViewModels;

public class MainPageViewModel
{
    public ICommand NavigateCommand { get; }

    public MainPageViewModel()
    {
        NavigateCommand = new Command<string>(async (pageName) =>
        {
            if (!string.IsNullOrWhiteSpace(pageName))
            {
                await Shell.Current.GoToAsync(pageName);
            }
        });
    }
}

