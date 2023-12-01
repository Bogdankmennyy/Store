using coat_data_layer;
using coat_Entity;



namespace coat_Business
{
    public class CN_Users
    {
        private readonly CD_Users objData= new CD_Users();

        public CE_Users Consult(int IdUser)
        {
            return objData.Consult(IdUser);
        }


        public void Insertar(CE_Users Users)
        {
           objData.CD_Insentar(Users);
        }

        public void Remove(CE_Users Users)
        {
            objData.CD_Remove(Users);
        }

        public void UpdateData(CE_Users Users)
        {
            objData.CD_UpdateData(Users);
        }

        public void UpdatePass(CE_Users Users)
        {
            objData.CD_UpdatePass(Users);
        }

        public void UpdateIMG(CE_Users Users)
        {
            objData.CD_UpdateIMG(Users);
        }
    }
}
