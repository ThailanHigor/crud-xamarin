using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace crudXamarin.Views
{
	public class PaginaPrincipal : ContentPage
	{
		public PaginaPrincipal ()
		{

            this.Title = "Selecione a opção desejada";

            StackLayout stackLayout = new StackLayout();
            Button botao = new Button();
            botao.Text = "Adicionar Empresa";
            botao.Clicked += Botao_Clicked;
            stackLayout.Children.Add(botao);

            botao = new Button();
            botao.Text = "Consultar Empresas";
            botao.Clicked += Botao_Consultar_Clicked;
            stackLayout.Children.Add(botao);

            botao = new Button();
            botao.Text = "Alterar Empresa";
            botao.Clicked += Botao_Alterar_Clicked;
            stackLayout.Children.Add(botao);

            botao = new Button();
            botao.Text = "Excluir Empresa";
            botao.Clicked += Botao_Excluir_Clicked;
            stackLayout.Children.Add(botao);

            Content = stackLayout;

        }

        private async void Botao_Excluir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaExcluirEmpresa());
        }

        private async void Botao_Alterar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaAlterarEmpresa());
        }

        private async void Botao_Consultar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaConsultaEmpresa());
        }

        public async void Botao_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PaginaAdicionarEmpresa());
        }
	}
}