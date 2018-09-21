using crudXamarin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace crudXamarin.Views
{
	public class PaginaAlterarEmpresa : ContentPage
	{

        private ListView _listView;
        private Entry _idEntrada;
        private Entry _nomeEntrada;
        private Entry _enderecoEntrada;
        private Button _botao;

        Empresa _empresa = new Empresa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(
         System.Environment.SpecialFolder.Personal), "myDB.db3");

        public PaginaAlterarEmpresa ()
		{
            this.Title = "Alterar Empresa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Empresa>().OrderBy(x => x.Nome).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);

            _idEntrada = new Entry();
            _idEntrada.Placeholder = "ID";
            _idEntrada.IsVisible = false;
            stackLayout.Children.Add(_idEntrada);

            _nomeEntrada = new Entry();
            _nomeEntrada.Keyboard = Keyboard.Text;
            _nomeEntrada.Placeholder = "Nome Empresa";
            stackLayout.Children.Add(_nomeEntrada);

            _enderecoEntrada = new Entry();
            _enderecoEntrada.Keyboard = Keyboard.Text;
            _enderecoEntrada.Placeholder = "Endereço";
            stackLayout.Children.Add(_enderecoEntrada);

            _botao = new Button();
            _botao.Text = "Atualizar";
            _botao.Clicked += _botao_Clicked;
            stackLayout.Children.Add(_botao);

            Content = stackLayout;
        }

        private async void _botao_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);

            Empresa empresa = new Empresa()
            {
                Id = Convert.ToInt32(_idEntrada.Text),
                Nome = _nomeEntrada.Text,
                Endereco = _enderecoEntrada.Text
            };

            db.Update(empresa);
            await Navigation.PopAsync();
        }

        private void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _empresa = (Empresa)e.SelectedItem;
            _idEntrada.Text = _empresa.Id.ToString();
            _nomeEntrada.Text = _empresa.Nome;
            _enderecoEntrada.Text = _empresa.Endereco;

        }
    }
}