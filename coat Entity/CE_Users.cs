namespace coat_Entity
{
    public class CE_Users
    {
        private int _IdUser;
        private string _Names;
        private string _Surnames;
        private int _DUI;
        private int _NIT;
        private string _Mail;
        private int _Phone;
        private DateTime _Birthday;
        private int _Privilege;
        private byte[] _img;
        private string _Userr;
        private string _Passwordd;
        private string _patron;

        public int IdUser { get => _IdUser; set => _IdUser = value; }
        public string Names { get => _Names; set => _Names = value; }
        public string Surnames { get => _Surnames; set => _Surnames = value; }
        public int DUI { get => _DUI; set => _DUI = value; }
        public int NIT { get => _NIT; set => _NIT = value; }
        public string Mail { get => _Mail; set => _Mail = value; }
        public int Phone { get => _Phone; set => _Phone = value; }
        public DateTime Birthday { get => _Birthday; set => _Birthday = value; }
        public int Privilege { get => _Privilege; set => _Privilege = value; }
        public byte[] Img { get => _img; set => _img = value; }
        public string Userr { get => _Userr; set => _Userr = value; }
        public string Passwordd { get => _Passwordd; set => _Passwordd = value; }
        public string Patron { get => _patron; set => _patron = value; }
    }
}
