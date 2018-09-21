using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.IO;
using System.Text;

using Xamarin.Forms;
using crudXamarin.Models;

namespace crudXamarin.Views
{
	public class PaginaAdicionarEmpresa : ContentPage
    {

        private Entry _nomeEntrada;
        private Entry _enderecoEntrada;
        private Button _salvarBotao;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.Personal), "myDB.db3");

		public PaginaAdicionarEmpresa ()
		{
            this.Title = "Adicionar Empresa";

            StackLayout stackLayout = new StackLayout();

            _nomeEntrada = new Entry();
            _nomeEntrada.Keyboard = Keyboard.Text;
            _nomeEntrada.Placeholder = "Nome Empresa";
            stackLayout.Children.Add(_nomeEntrada);

            _enderecoEntrada = new Entry();
            _enderecoEntrada.Keyboard = Keyboard.Text;
            _enderecoEntrada.Placeholder = "Endereço";
            stackLayout.Children.Add(_enderecoEntrada);

            _salvarBotao = new Button();
            _salvarBotao.Text = "Adicionar";
            _salvarBotao.Clicked += _salvarBotao_Clicked;
            stackLayout.Children.Add(_salvarBotao);

            Content = stackLayout;

        }

        private async void _salvarBotao_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Empresa>();

            var maxPk = db.Table<Empresa>().OrderByDescending(c => c.Id).FirstOrDefault();

            Empresa empresa = new Empresa()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Nome = _nomeEntrada.Text,
                Endereco = _enderecoEntrada.Text
            };

            db.Insert(empresa);
            await DisplayAlert(null, empresa.Nome + "Salva", "Ok");
            await Navigation.PopAsync();
        }
    }
}