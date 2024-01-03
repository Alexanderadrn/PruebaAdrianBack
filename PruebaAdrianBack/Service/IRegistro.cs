using PruebaAdrianBack.ViewModels;

namespace PruebaAdrianBack.Service
{
    public interface IRegistro
    {
        public List<RegistroVM> ObtenerRegistro();
        public bool SetRegistro(SetRegistroVM setRegistro);
        public List<RegistroVM> ObtenerRegistroById(int id);
    }
}
