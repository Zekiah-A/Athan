﻿using Athan.Avalonia.Contracts;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Athan.Avalonia.ViewModels;

internal sealed class YouSeemToBeOfflineViewModel : ObservableObject, INavigable
{
    public string Title => "You seem to be offline";
}