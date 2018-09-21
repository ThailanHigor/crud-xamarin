using crudXamarin.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace crudXamarin.Views
{
	public class PaginaExcluirEmpresa : ContentPage
	{

        private ListView _listView;
        private Button _botao;

        Empresa _empresa = new Empresa();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(
         System.Environment.SpecialFolder.Personal), "myDB.db3");

        public PaginaExcluirEmpresa ()
		{
            this.Title = "Excluir Empresa";

            var db = new SQLiteConnection(_dbPath);

            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Empresa>().OrderBy(x => x.Nome).ToList();
            _listView.ItemSelected += _listView_ItemSelected;
            stackLayout.Children.Add(_listView);


            _botao = new Button();
            _botao.Text = "Excluir";
            _botao.Clicked += _botao_Clicked;
            stackLayout.Children.Add(_botao);

        }

        private async void _botao_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.Table<Empresa>().Delete(x => x.Id == _empresa.Id);
            await Navigation.PopAsync();
        }

        private async void _listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            _empresa = (Empresa)e.SelectedItem;
        }
    }
}