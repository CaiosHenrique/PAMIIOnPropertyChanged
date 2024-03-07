﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppBindingCommands.ViewModel
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {

        public UsuarioViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
            CountCommand = new Command(async () => await CountCharacters());
            CleanCommand = new Command(async () => await CleanConfirmation());
            OptionCommand = new Command(async () => await ShowOptions());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string name = string.Empty;

        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));

            }
        }
        public string DisplayName => $"Nome digitado: {Name}";


        private string displayMessage = string.Empty;
        public string DisplayMessage
        {
            get => displayMessage; set
            {
                if (displayMessage == value)
                    return;
                displayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        public ICommand ShowMessageCommand { get; }

        public void ShowMessage()
        {
            DateTime data = Preferences.Get("dtAtual", DateTime.MinValue);
            DisplayMessage = $"Boa noite: {Name}, Hoje é {data} \n";
        }
        
        public async Task CountCharacters()
        {
            string nameLenght = string.Format("O nome {0} tem {1} caracteres", Name, Name.Length);
            await Application.Current.MainPage.DisplayAlert("Contagem de caracteres", nameLenght, "OK");
        }

        public ICommand CountCommand { get; }

        public async Task CleanConfirmation()
        {
            if (await Application.Current.MainPage.DisplayAlert("Confirmação", "Deseja limpar o campo?", "Sim", "Não"))
            {
                Name = string.Empty;
                DisplayMessage = string.Empty;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(DisplayName));

                await Application.Current.MainPage.DisplayAlert("Campo limpo", "Campo limpo com sucesso", "OK");
            }
        }

        public ICommand CleanCommand { get;}

        public async Task ShowOptions()
        {
            string result = await Application.Current.MainPage.DisplayActionSheet("Escolha uma opção", "Cancelar", "Limpar", "Contar Caracteres", "Exibir saudação");
        }

        public ICommand OptionCommand { get; }
    }

        
    }
