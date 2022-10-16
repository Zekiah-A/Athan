﻿using System;
using System.Globalization;
using System.Threading.Tasks;
using Athan.Avalonia.Contracts;
using Athan.Avalonia.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Athan.Avalonia.ViewModels;

internal sealed partial class DashboardViewModel : ObservableObject, INavigable
{
    public string Title => DateTime.Now.DayOfWeek.ToString();

    [ObservableProperty]
    private string? location;

    [ObservableProperty]
    private string date;

    private readonly SettingsService settingsService;

    public DashboardViewModel(SettingsService settingsService)
    {
        this.settingsService = settingsService;

        var calendar = new HijriCalendar();

        var hijri =
            $"{calendar.GetYear(DateTime.Now)}/" +
            $"{calendar.GetMonth(DateTime.Now)}/" +
            $"{calendar.GetDayOfMonth(DateTime.Now)}";

        date = DateTime.Parse(hijri).ToShortDateString();
    }

    [RelayCommand]
    private async Task InitializedAsync()
    {
        var settings = await settingsService.ReadAsync();
        Location = $"{settings.Location?.City}, {settings.Location?.Country}";
    }
}