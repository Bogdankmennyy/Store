using Microsoft.Win32;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using coat_Entity;
using coat_Business;

namespace Store.Views
{
    
    /// <summary>
    /// Логика взаимодействия для CRUDUsuarios.xaml
    /// </summary>
    public partial class CRUDUsuarios : Page
    {

        readonly CN_Users objeto_CN_Users=new CN_Users();
        readonly CE_Users objeto_CE_Users = new CE_Users();


        public CRUDUsuarios()
        {
            InitializeComponent();
            CargarCB();
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            Content = new Users();
        }


        //readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionDB"].ConnectionString);
        void CargarCB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select NombrePrivilege from Privileges", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cbPrivilege.Items.Add(dr["NombrePrivilege"].ToString());
            }
            con.Close(); 
        }

        #region CREATE


        private void Create(object sender, RoutedEventArgs e)
        {
            if (tbNames.Text == "" || tbSurnames.Text == "" || tbDUI.Text == "" || tbNIT.Text == "" || tbMail.Text == "" || tbPhone.Text == "" || tbBirthday.Text == "" || cbPrivilege.Text == "" || tbUserr.Text == "" || tbPasswordd.Text == "")
            {
                MessageBox.Show("Поле не можуть залишитись порожніми");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select IdPrivilege from privileges where NombrePrivilege = '"+cbPrivilege.Text+"'", con);
                object valor = cmd.ExecuteScalar();
                int privilege = (int)valor;
                string patron = "InfoTools";
                if(imagensubida == true)
                {
                    SqlCommand com = new SqlCommand("insert into users (names, Surnames, DUI, NIT,Birthday, Phone, Mail, Privilege, img, userr, passwordd) values(@Names, @Surnames, @DUI, @NIT, @Birthday, @Phone, @Mail, @Privilege, @img, @userr, (EncryptByPassPhrase('" + patron + "','" + tbPasswordd.Text + "')))", con);
                    com.Parameters.Add("@Names", SqlDbType.VarChar).Value = tbNames.Text;
                    com.Parameters.Add("@Surnames", SqlDbType.VarChar).Value = tbSurnames.Text;
                    com.Parameters.Add("@DUI", SqlDbType.Int).Value = int.Parse(tbDUI.Text);
                    com.Parameters.Add("@NIT", SqlDbType.Int).Value = int.Parse(tbNIT.Text);
                    com.Parameters.Add("@Birthday", SqlDbType.Date).Value = tbBirthday.Text;
                    com.Parameters.Add("@Phone", SqlDbType.Int).Value = int.Parse(tbPhone.Text);
                    com.Parameters.Add("@Mail", SqlDbType.VarChar).Value = tbMail.Text;
                    com.Parameters.Add("@Privilege", SqlDbType.Int).Value = privilege;
                    com.Parameters.Add("@userr", SqlDbType.VarChar).Value = tbUserr.Text;
                    com.Parameters.AddWithValue("@img", SqlDbType.VarChar).Value = data;
                    com.ExecuteNonQuery();
                    Content = new Users();
                }
                else
                {
                    MessageBox.Show("Необхідно додати фото профілю для користувача ");
                }
                con.Close();
               
            }
        }
        #endregion

        public int IdUser;


        public string Patron = "InfoTools";


        public void Consultar()
        {
            con.Open();
            SqlCommand com = new SqlCommand("select * from Users inner join Privileges on Users.Privilege=Privileges.IdPrivilege where IdUser=" + IdUser, con);
            SqlDataReader rdr = com.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            rdr.Read();
            this.tbNames.Text = rdr["Names"].ToString();
            this.tbSurnames.Text = rdr["Surnames"].ToString();
            this.tbDUI.Text = rdr["DUI"].ToString();
            this.tbNIT.Text = rdr["NIT"].ToString();
            this.tbBirthday.Text = rdr["Birthday"].ToString();
            this.tbPhone.Text = rdr["Phone"].ToString();
            this.tbMail.Text = rdr["Mail"].ToString();
            this.cbPrivilege.SelectedItem = rdr["NombrePrivilege"];
            this.tbUserr.Text = rdr["userr"].ToString();
            //this.tbPasswordd.Text = "Не може бути відображено";
            rdr.Close();

            //IMAGEN
            DataSet ds = new DataSet();
            SqlDataAdapter sqda = new SqlDataAdapter("select img from users where IdUser='"+IdUser+"'",con);
            sqda.Fill(ds);
            byte[] data = (byte[])ds.Tables[0].Rows[0][0];
            MemoryStream strm = new MemoryStream();
            strm.Write(data , 0, data.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            MemoryStream ms = new MemoryStream();
            img.Save(ms,System.Drawing.Imaging.ImageFormat.Bmp);
            ms.Seek(0, SeekOrigin.Begin);
            bi.StreamSource = ms;
            bi.EndInit();
            Imagen.Source = bi;
            //IMAGEN
            con.Close();

        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Users Where IdUser="+IdUser+"",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Content = new Users(); 
        }

        private void Update(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("Select IdPrivilege from Privileges where NombrePrivilege='"+cbPrivilege.Text+"'",con);
            object valor = com.ExecuteScalar();
            int privilege = (int)valor;
            string patron = "InfoTools";
            if (tbNames.Text == "" || tbSurnames.Text == "" || tbDUI.Text == "" || tbNIT.Text == "" || tbMail.Text == "" || tbPhone.Text == "" || tbBirthday.Text == "" || cbPrivilege.Text == "" || tbUserr.Text == "")
            {
                MessageBox.Show("Поле не можуть залишитись порожніми");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("update Users set Names='" + tbNames.Text + "',Surnames='" + tbSurnames.Text + "',DUI='" + tbDUI.Text + "',NIT='" + tbNIT.Text + "',Birthday='" + tbBirthday.Text + "',Phone='" + tbPhone.Text + "',Mail='" + tbMail.Text + "',Privilege='" + privilege + "',userr='" + tbUserr.Text + "'where IdUser="+IdUser, con);
                cmd.ExecuteNonQuery();
                if (imagensubida == true)
                {
                    SqlCommand img = new SqlCommand("Update Users set img=@img where IdUser='" + IdUser + "'", con);
                    img.Parameters.AddWithValue("@img", SqlDbType.VarBinary).Value = data;
                    img.ExecuteNonQuery();
                }
               

            }
            if(tbPasswordd.Text!="")
            {
                SqlCommand cmd = new SqlCommand("update Users set passwordd=(EncryptByPassPhrase('" + patron + "','" + tbPasswordd.Text + "')) where IdUser='"+IdUser+"'" , con);
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Content=new Users();
        }

        byte[] data;
        private bool imagensubida = false;
        private void Upload(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == true)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read );
                data = new byte[fs.Length];
                fs.Read(data,0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                ImageSourceConverter imgs = new ImageSourceConverter();
                Imagen.SetCurrentValue(Image.SourceProperty, imgs.ConvertFromString(ofd.FileName.ToString()));
            }
            imagensubida = true;
        }
    }
}
