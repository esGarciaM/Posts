using Data;
using Data.Interface;
using Entities;
using Entities._Entities;
using Entities._Interface;

namespace UnitTest
{
    [TestClass]
    public class CRUDTest
    {
        private IContext _context;
        private ICRUD<Prospecto> CProspecto;
        private ICRUD<Vacante> CVacante;
        private ICRUD<Entrevista> CEntrevista;

        Prospecto _prospecto;
        Entrevista _entrevista;
        Vacante _vacante;

        [TestInitialize]
        public void init() {
            _context = new Contest();
            Assert.IsNotNull(_context, "Error en inicializacion de contexto de prueba");
            CProspecto = new CRUD<Prospecto>(_context);
            CVacante = new CRUD<Vacante>(_context);
            CEntrevista = new CRUD<Entrevista>(_context);

            _prospecto = new Prospecto();
            _prospecto.id = new Random().Next();
            _prospecto.nombre = "testNombre";
            _prospecto.correo = "test@test.com";
            _prospecto.fecha_registro = DateTime.Now;
        }
        [TestMethod]
        public void test_delete() {
            CProspecto.Delete(1);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void Test_Add()
        {
            CProspecto.Add(_prospecto);
            
        }
        [TestMethod]
        public void Test_Get()
        {
        }

    }
}