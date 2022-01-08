using GymModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProiectMango
{
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }

    public partial class MainWindow : Window
    {
        //using AutoLotModel;
        ActionState action = ActionState.Nothing;
        GymModel.Antrenori ctx = new GymModel.Antrenori();
        CollectionViewSource ClientiVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //using System.Data.Entity;
            ClientiVSource =
           ((System.Windows.Data.CollectionViewSource)(this.FindResource("customerViewSource")));
            ClientiVSource.Source = ctx.Clienti.Local;
            ctx.Clienti.Load();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }

        private void btnEditO_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }

        private void btnDeleteO_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ClientiVSource.View.MoveCurrentToNext();
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            ClientiVSource.View.MoveCurrentToPrevious();
        }
        private void SaveClienti()
        {
            Clienti clienti = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    clienti = new Clienti()
                    {
                        Nume = NumeTextBox.Text.Trim(),
                        TipAbonament = TipAbonamentTextBox.Text.Trim()
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Clienti.Add(clienti);
                    ClientiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    clienti = (Clienti)ClientiDataGrid.SelectedItem;
                    clienti.Nume = NumeTextBox.Text.Trim();
                    clienti.TipAbonament = TipAbonamentTextBox.Text.Trim();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    clienti = (Clienti)ClientiDataGrid.SelectedItem;
                    ctx.Clienti.Remove(clienti);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                ClientiVSource.View.Refresh();
            }

        }
        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }
        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel1_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlGYM.SelectedItem as TabItem;

            switch (ti.Header)
            {
                case "Antrenori":
                    SaveAntrenori();
                    break;
                case "Clienti":
                    SaveClienti();
                    break;
                case "Suplimente":
                    break;
            }
            ReInitialize();
        }
    }
}