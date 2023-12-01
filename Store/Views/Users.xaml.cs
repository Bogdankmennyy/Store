using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;



namespace Store.Views
{
    /// <summary>
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            CargarDatos();
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        void CargarDatos()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select IdUser, Names, Surnames, Phone, Mail,NombrePrivilege from Users inner join privileges on Users.Privilege=Privileges.IdPrivilege order by IdUser ASC", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridData.ItemsSource = dt.DefaultView;
            con.Close();
        }


        private void Add(object sender, RoutedEventArgs e)
        {
            CRUDUsuarios ventana = new CRUDUsuarios();
            FrameUsers.Content = ventana;
            Content.Visibility = Visibility.Hidden;
            ventana.BtnCreate.Visibility = Visibility.Visible;
        }

        private void Consult(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUser = id;
            ventana.Consultar();
            FrameUsers.Content = ventana;
            Content.Visibility = Visibility.Hidden;
            ventana.Qualification.Text = "Запис користувача";
            ventana.tbNames.IsEnabled = false;
            ventana.tbSurnames.IsEnabled = false;
            ventana.tbDUI.IsEnabled = false;
            ventana.tbNIT.IsEnabled = false;
            ventana.tbBirthday.IsEnabled = false;
            ventana.tbPhone.IsEnabled = false;
            ventana.tbMail.IsEnabled = false;
            ventana.cbPrivilege.IsEnabled = false;
            ventana.tbUserr.IsEnabled = false;
            ventana.tbPasswordd.IsEnabled = false;
            ventana.BtnUpload.IsEnabled = false;
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUser = id;
            ventana.Consultar();
            FrameUsers.Content = ventana;
            Content.Visibility = Visibility.Hidden;
            ventana.Qualification.Text = "Оновити користувача";
            ventana.tbNames.IsEnabled = true;
            ventana.tbSurnames.IsEnabled = true;
            ventana.tbDUI.IsEnabled = true;
            ventana.tbNIT.IsEnabled = true;
            ventana.tbBirthday.IsEnabled = true;
            ventana.tbPhone.IsEnabled = true;
            ventana.tbMail.IsEnabled = true;
            ventana.cbPrivilege.IsEnabled = true;
            ventana.tbUserr.IsEnabled = true;
            ventana.tbPasswordd.IsEnabled = true;
            ventana.BtnUpload.IsEnabled = true;
            ventana.BtnUpdate.Visibility= Visibility.Visible;
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).CommandParameter;
            CRUDUsuarios ventana = new CRUDUsuarios();
            ventana.IdUser = id;
            ventana.Consultar();
            FrameUsers.Content = ventana;
            Content.Visibility = Visibility.Hidden;
            ventana.Qualification.Text = "Видалити користувача";
            ventana.tbNames.IsEnabled = false;
            ventana.tbSurnames.IsEnabled = false;
            ventana.tbDUI.IsEnabled = false;
            ventana.tbNIT.IsEnabled = false;
            ventana.tbBirthday.IsEnabled = false;
            ventana.tbPhone.IsEnabled = false;
            ventana.tbMail.IsEnabled = false;
            ventana.cbPrivilege.IsEnabled = false;
            ventana.tbUserr.IsEnabled = false;
            ventana.tbPasswordd.IsEnabled = false;
            ventana.BtnUpload.IsEnabled = false;
            ventana.BtnRemove.Visibility = Visibility.Visible;
        }
    }
}
