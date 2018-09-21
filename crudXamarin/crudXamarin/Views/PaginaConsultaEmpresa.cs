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
	public class PaginaConsultaEmpresa : ContentPage
	{
        private ListView _listView;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(
          System.Environment.SpecialFolder.Personal), "myDB.db3");


        public PaginaConsultaEmpresa ()
		{
            this.Title = "Empresas";

            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();

            _listView = new ListView();
            _listView.ItemsSource = db.Table<Empresa>().OrderBy(x => x.Nome).ToList();
            stackLayout.Children.Add(_listView);

            Content = stackLayout;

		}
	}
}